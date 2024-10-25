using System.Text.Json;
using Klotski.Controls;

namespace Klotski;

public partial class Form1 : Form
{
    private PanelMatrixItem[,] _panelMatrixItems = new PanelMatrixItem[4, 4];

    private Bitmap _currentBitmap = null!;

    private Record record;

    public Bitmap CurrentBitmap
    {
        get => _currentBitmap;
        set
        {
            if (_currentBitmap is not null)
            {
                try
                {
                    _currentBitmap.Dispose();
                }
                catch { }
            }
            var perX = value.Width / 4;
            var perY = value.Height / 4;
            for (int x = perX * 3; x < value.Width; x++)
            {
                for (int y = perY * 3; y < value.Height; y++)
                {
                    var px = value.GetPixel(x, y);
                    var v = px.GetBrightness();
                    v *= 0.5f;

                    var h = px.GetHue();
                    var s = px.GetSaturation();

                    var (r, g, b) = Utils.HsvToRgb(h, s, v);

                    value.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }
            _currentBitmap = value;
        }
    }

    private int[,] _board =
    {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 9, 10, 11, 12 },
        { 13, 14, 16, 15 }
    };

    private readonly int shuffleTime = 10000;

    private int? _bitmapPerX
    {
        get { return CurrentBitmap?.Width / 4; }
    }
    private int? _bitmapPerY
    {
        get { return CurrentBitmap?.Height / 4; }
    }

    private int _stepCount = 0;
    private DateTime _startTime;
    private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

    private readonly Graphics previewGraphics;
    private readonly Graphics ingamePreviewGraphics;

    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public Form1()
    {
        InitializeComponent();
        try
        {
            var content = File.ReadAllText("record.json");
            record = JsonSerializer.Deserialize<Record>(content) ?? new Record();
        }
        catch
        {
            record = new Record();
        }

        if (record.BestSteps is not null)
            LeastStepLabel.Text = $"��¼��{record.BestSteps} ��";
        if (record.BestTime is not null)
            BestTimeLabel.Text = $"��¼��{record.BestTime:hh\\:mm\\:ss\\.fff}";

        PicSelect.SelectedIndex = 0;

        foreach (var control in this.Controls)
        {
            var panel = control as PanelMatrixItem;
            if (panel is not null)
            {
                panel.Click += PanelClicked;
                _panelMatrixItems[panel.Position.X, panel.Position.Y] = panel;
            }
        }

        previewGraphics = PreviewPanel.CreateGraphics();
        ingamePreviewGraphics = IngamePreviewPanel.CreateGraphics();

        var woodBg = Resources.WoodBgWithNum;
        using var stream = new MemoryStream(woodBg);

        CurrentBitmap = new Bitmap(stream);

        var res = IsBoardValid();
    }

    private void PanelClicked(object? sender, EventArgs e)
    {
        var item = sender as PanelMatrixItem ?? throw new Exception("Unexpected sender type.");
        var x = item.Position.X;
        var y = item.Position.Y;
        var num = _board[x, y];
        var moveDirection = GetMoveDirection(x, y);

        ErrorLabel.Text = "";

        switch (moveDirection)
        {
            case MoveDirection.Left:
                _board[x - 1, y] = num;
                _board[x, y] = 16;
                RefreshItem(item, EnableNumberCheckBox.Checked);
                RefreshItem(_panelMatrixItems[x - 1, y], EnableNumberCheckBox.Checked);
                break;
            case MoveDirection.Right:
                _board[x + 1, y] = num;
                _board[x, y] = 16;
                RefreshItem(item, EnableNumberCheckBox.Checked);
                RefreshItem(_panelMatrixItems[x + 1, y], EnableNumberCheckBox.Checked);
                break;
            case MoveDirection.Up:
                _board[x, y - 1] = num;
                _board[x, y] = 16;
                RefreshItem(item, EnableNumberCheckBox.Checked);
                RefreshItem(_panelMatrixItems[x, y - 1], EnableNumberCheckBox.Checked);
                break;
            case MoveDirection.Down:
                _board[x, y + 1] = num;
                _board[x, y] = 16;
                RefreshItem(item, EnableNumberCheckBox.Checked);
                RefreshItem(_panelMatrixItems[x, y + 1], EnableNumberCheckBox.Checked);
                break;
            case MoveDirection.None:
                ErrorLabel.Text = "�޷��ƶ�Ŀ���ľ��";
                return;
        }

        if (StepCountMode.Checked)
        {
            _stepCount++;
            StatusLabel.Text = $"��ǰ {_stepCount} ����";
        }

        if (JudgeBoard())
        {
            if (StepCountMode.Checked)
            {
                if (record.BestSteps is null || _stepCount < record.BestSteps)
                {
                    StatusLabel.Text = $"{_stepCount} ����ɡ��¼�¼��";
                    LeastStepLabel.Text = $"��¼��{_stepCount} ��";
                    record.BestSteps = _stepCount;
                    FlushRecordToDisk();
                }
                else
                {
                    StatusLabel.Text = $"{_stepCount} ����ɡ�δ�ܴ��Ƽ�¼���ٽ�������";
                }
            }
            else
            {
                _timer.Dispose();
                _timer = new System.Windows.Forms.Timer();

                var elapsed = DateTime.Now - _startTime;
                if (record.BestTime is null || elapsed < record.BestTime)
                {
                    StatusLabel.Text = $"��ʱ��{elapsed:hh\\:mm\\:ss\\.fff}���¼�¼��";
                    BestTimeLabel.Text = $"��¼��{elapsed:hh\\:mm\\:ss\\.fff}";
                    record.BestTime = elapsed;
                    FlushRecordToDisk();
                }
                else
                {
                    StatusLabel.Text = $"��ʱ��{elapsed:hh\\:mm\\:ss\\.fff}��δ�ܴ��Ƽ�¼���ٽ�������";
                }
            }
            BoardCleanUp();
        }
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
        Shuffle();

        if (CurrentBitmap is null)
            throw new Exception("No bitmap loaded");

        PreviewPanel.Visible = false;

        RefreshAllItems(EnableNumberCheckBox.Checked);

        StartButton.Text = "\ue777";
        ModeSelectPanel.Visible = false;
        PicSelect.Visible = false;
        StartButton.Visible = false;
        IngameButtons.Visible = true;

        StatusLabel.Text = "�ѿ�ʼ��Ϸ��";

        IngamePreviewPanel.Visible = true;
        ingamePreviewGraphics.DrawImage(
            CurrentBitmap,
            0,
            0,
            IngamePreviewPanel.Width,
            IngamePreviewPanel.Height
        );

        _stepCount = 0;
        _startTime = DateTime.Now;

        if (TimerMode.Checked)
        {
            _timer.Interval = 10;
            _timer.Tick += UpdateTime;
            _timer.Start();
        }
    }

    private void UpdateTime(object? sender, EventArgs e)
    {
        var elapsed = DateTime.Now - _startTime;
        StatusLabel.Text = $"����ʱ�䣺{elapsed:hh\\:mm\\:ss\\.fff}";
    }

    private void Shuffle()
    {
        var random = Random.Shared;
        for (int i = 0; i < shuffleTime; i++)
        {
            var x1 = random.Next(4);
            var y1 = random.Next(4);
            var x2 = random.Next(4);
            var y2 = random.Next(4);
            (_board[x2, y2], _board[x1, y1]) = (_board[x1, y1], _board[x2, y2]);
        }

        if (IsBoardValid())
            return;

        // If the board is not valid, swap once to make it valid.

        if (_board[0, 0] == 16)
        {
            (_board[2, 0], _board[1, 0]) = (_board[1, 0], _board[2, 0]);
            return;
        }
        if (_board[1, 0] == 16)
        {
            (_board[2, 0], _board[0, 0]) = (_board[0, 0], _board[2, 0]);
            return;
        }
        {
            (_board[1, 0], _board[0, 0]) = (_board[0, 0], _board[1, 0]);
        }
    }

    private bool IsBoardValid()
    {
        var flattened = new int[16];
        var rowOfEmpty = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                flattened[i * 4 + j] = _board[i, j];
                if (_board[i, j] == 16)
                {
                    rowOfEmpty = i + 1;
                }
            }
        }

        var inversions = 0;
        for (int i = 0; i < 15; i++)
        {
            if (flattened[i] == 16)
                continue;
            for (int j = i + 1; j < 16; j++)
            {
                if (flattened[j] == 16)
                    continue;
                if (flattened[i] > flattened[j])
                {
                    inversions++;
                }
            }
        }

        return (inversions + rowOfEmpty) % 2 == 0;
    }

    private void RefreshItem(PanelMatrixItem item, bool enableNumber)
    {
        if (CurrentBitmap is null)
            throw new Exception("No bitmap loaded");
        var panelX = item.Position.X;
        var panelY = item.Position.Y;
        var num = _board[panelX, panelY];
        var numX = (num - 1) % 4;
        var numY = (num - 1) / 4;
        var perX = _bitmapPerX!;
        var perY = _bitmapPerY!;
        var destRect = new Rectangle(0, 0, item.Width, item.Height);
        var srcRect = new Rectangle(numX * perX.Value, numY * perY.Value, perX.Value, perY.Value);
        using var graphics = item.CreateGraphics();

        // graphics.Clear(Color.White);

        graphics.DrawImage(CurrentBitmap, destRect, srcRect, GraphicsUnit.Pixel);

        if (enableNumber)
        {
            if (_board[panelX, panelY] != 16)
                graphics.DrawString(
                    _board[panelX, panelY].ToString(),
                    new Font("Arial", 20),
                    Brushes.Black,
                    new PointF(0, 0)
                );
        }
    }

    private MoveDirection GetMoveDirection(int x, int y)
    {
        if (x != 0 && _board[x - 1, y] == 16)
            return MoveDirection.Left;
        if (x != 3 && _board[x + 1, y] == 16)
            return MoveDirection.Right;
        if (y != 0 && _board[x, y - 1] == 16)
            return MoveDirection.Up;
        if (y != 3 && _board[x, y + 1] == 16)
            return MoveDirection.Down;
        return MoveDirection.None;
    }

    private bool JudgeBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (_board[j, i] != i * 4 + j + 1)
                    return false;
            }
        }

        return true;
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        Show();
        RefreshPreviewPanel();
    }

    private void BoardCleanUp()
    {
        PreviewPanel.Visible = true;
        ModeSelectPanel.Visible = true;
        StartButton.Text = "\ue768";
        IngameButtons.Visible = false;
        StartButton.Visible = true;
        PicSelect.Visible = true;
        IngamePreviewPanel.Visible = false;

        RefreshPreviewPanel();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        BoardCleanUp();
        _timer.Dispose();
        _timer = new System.Windows.Forms.Timer();
        StatusLabel.Text = "��ȡ����Ϸ��";
    }

    private void RefreshAllItems(bool enbaleNumber)
    {
        foreach (var item in _panelMatrixItems)
        {
            RefreshItem(item, enbaleNumber);
        }
    }

    private void EnableNumberCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        RefreshAllItems(EnableNumberCheckBox.Checked);
    }

    private void PicSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        var data = PicSelect.SelectedIndex switch
        {
            0 => Resources.WoodBgWithNum,
            1 => Resources.HouseBg,
            2 => Resources.FlowerBg,
            3 => Resources.CustomBg,
            _ => throw new Exception("Unexpected index.")
        };

        using var stream = new MemoryStream(data);
        if (PicSelect.SelectedIndex == 3)
        {
            _currentBitmap = new Bitmap(stream);
            PreviewPanel.AllowDrop = true;
            StartButton.Enabled = false;
        }
        else
        {
            CurrentBitmap = new Bitmap(stream);
            PreviewPanel.AllowDrop = false;
            StartButton.Enabled = true;
        }

        RefreshPreviewPanel();
    }

    private void PreviewPanel_DragDrop(object sender, DragEventArgs e)
    {
        var data = e.Data?.GetData(DataFormats.FileDrop) as string[];
        if (data is null || data.Length < 1)
            return;
        var file = data[0];
        try
        {
            var bitmap = new Bitmap(file);
            CurrentBitmap = bitmap;
            RefreshPreviewPanel();
            StartButton.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"δ�ܳɹ�����ͼƬ������������ͼƬ�𻵻���ͼƬ���Ͳ�֧��\n{ex.Message}",
                "δ�ܳɹ�����ͼƬ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void PreviewPanel_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            e.Effect = DragDropEffects.Link;
    }

    private void RefreshPreviewPanel()
    {
        previewGraphics?.DrawImage(CurrentBitmap, 0, 0, PreviewPanel.Width, PreviewPanel.Height);
    }

    private void FlushRecordToDisk()
    {
        try
        {
            File.WriteAllText("record.json", JsonSerializer.Serialize(record));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"δ�ܳɹ������¼��\n{ex.Message}",
                "δ�ܳɹ������¼",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;

        HelpHint.Visible = false;
        MessageBox.Show(
            "1. ���ֻ��ݵ����ϻ���\n"
                + "2. �������ֵĻ��ݵ�\n"
                + "3. �Զ���ͼƬ�Ĳ������ֵĻ��ݵ�\n"
                + "4. ��ʱ���߼Ʋ��������ܹ���¼��Ѽ�¼\n"
                + "5. ��Ѽ�¼�������浽���أ��´δ�ʱ���Զ�����",
            "�����������ʲô��",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );

        MessageBox.Show(
            "1. ͼƬһ���Լ��أ�ÿ����ľ��Ӧ��ͼƬ�Ǽ�����Ƶģ���������ǰ�зֵ� 16 ��ͼƬ��\n"
                + "2. ���½ǵİ����Ǽ���ͼƬʱ��ͼƬ��Ӧ��������õģ�ÿ�������� * 0.5f ��ת��Ϊ RGB ֵ����Ȼ HSV ת RGB ������㷨������д�ġ�\n"
                + "3. ����ģʽͼƬ�������ֳɵ�ͼƬ���Զ���ģʽռλ��ͼƬ�����ֻ棬��������ͼƬ���� AI �����ġ�\n" +
                "4. \n\n" +
                "Ϊʲôû����ͣ����\n" +
                "˼����ʱ��ҲӦ�ñ������ʱ�䣡��֮ͣ��˼����ʲô��������ʵ�ǱȽ��鷳��",
            "����ϸ��",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }
}
