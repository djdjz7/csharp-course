using Klotski.Controls;

namespace Klotski
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new PanelMatrixItem();
            PreviewPanel = new Panel();
            panel2 = new PanelMatrixItem();
            panel3 = new PanelMatrixItem();
            panel4 = new PanelMatrixItem();
            panel5 = new PanelMatrixItem();
            panel6 = new PanelMatrixItem();
            panel7 = new PanelMatrixItem();
            panel8 = new PanelMatrixItem();
            panel9 = new PanelMatrixItem();
            panel10 = new PanelMatrixItem();
            panel11 = new PanelMatrixItem();
            panel12 = new PanelMatrixItem();
            panel13 = new PanelMatrixItem();
            panel14 = new PanelMatrixItem();
            panel15 = new PanelMatrixItem();
            panel16 = new PanelMatrixItem();
            StartButton = new Button();
            TimerMode = new RadioButton();
            StepCountMode = new RadioButton();
            BestTimeLabel = new Label();
            LeastStepLabel = new Label();
            ModeSelectPanel = new Panel();
            statusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            ErrorLabel = new ToolStripStatusLabel();
            IngameButtons = new Panel();
            button1 = new Button();
            CancelButton = new Button();
            PicSelect = new ComboBox();
            EnableNumberCheckBox = new CheckBox();
            label1 = new Label();
            IngamePreviewPanel = new Panel();
            HelpHint = new Label();
            ModeSelectPanel.SuspendLayout();
            statusStrip1.SuspendLayout();
            IngameButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(43, 133);
            panel1.Name = "panel1";
            panel1.Position = new Point(0, 0);
            panel1.Size = new Size(64, 64);
            panel1.TabIndex = 0;
            // 
            // PreviewPanel
            // 
            PreviewPanel.Location = new Point(40, 133);
            PreviewPanel.Name = "PreviewPanel";
            PreviewPanel.Size = new Size(277, 274);
            PreviewPanel.TabIndex = 21;
            PreviewPanel.DragDrop += PreviewPanel_DragDrop;
            PreviewPanel.DragEnter += PreviewPanel_DragEnter;
            // 
            // panel2
            // 
            panel2.Location = new Point(113, 133);
            panel2.Name = "panel2";
            panel2.Position = new Point(1, 0);
            panel2.Size = new Size(64, 64);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(183, 133);
            panel3.Name = "panel3";
            panel3.Position = new Point(2, 0);
            panel3.Size = new Size(64, 64);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Location = new Point(253, 133);
            panel4.Name = "panel4";
            panel4.Position = new Point(3, 0);
            panel4.Size = new Size(64, 64);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Location = new Point(253, 203);
            panel5.Name = "panel5";
            panel5.Position = new Point(3, 1);
            panel5.Size = new Size(64, 64);
            panel5.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.Location = new Point(183, 203);
            panel6.Name = "panel6";
            panel6.Position = new Point(2, 1);
            panel6.Size = new Size(64, 64);
            panel6.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Location = new Point(113, 203);
            panel7.Name = "panel7";
            panel7.Position = new Point(1, 1);
            panel7.Size = new Size(64, 64);
            panel7.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Location = new Point(43, 273);
            panel8.Name = "panel8";
            panel8.Position = new Point(0, 2);
            panel8.Size = new Size(64, 64);
            panel8.TabIndex = 8;
            // 
            // panel9
            // 
            panel9.Location = new Point(183, 273);
            panel9.Name = "panel9";
            panel9.Position = new Point(2, 2);
            panel9.Size = new Size(64, 64);
            panel9.TabIndex = 10;
            // 
            // panel10
            // 
            panel10.Location = new Point(253, 273);
            panel10.Name = "panel10";
            panel10.Position = new Point(3, 2);
            panel10.Size = new Size(64, 64);
            panel10.TabIndex = 11;
            // 
            // panel11
            // 
            panel11.Location = new Point(183, 343);
            panel11.Name = "panel11";
            panel11.Position = new Point(2, 3);
            panel11.Size = new Size(64, 64);
            panel11.TabIndex = 14;
            // 
            // panel12
            // 
            panel12.Location = new Point(253, 343);
            panel12.Name = "panel12";
            panel12.Position = new Point(3, 3);
            panel12.Size = new Size(64, 64);
            panel12.TabIndex = 15;
            // 
            // panel13
            // 
            panel13.Location = new Point(113, 343);
            panel13.Name = "panel13";
            panel13.Position = new Point(1, 3);
            panel13.Size = new Size(64, 64);
            panel13.TabIndex = 13;
            // 
            // panel14
            // 
            panel14.Location = new Point(43, 343);
            panel14.Name = "panel14";
            panel14.Position = new Point(0, 3);
            panel14.Size = new Size(64, 64);
            panel14.TabIndex = 12;
            // 
            // panel15
            // 
            panel15.Location = new Point(113, 273);
            panel15.Name = "panel15";
            panel15.Position = new Point(1, 2);
            panel15.Size = new Size(64, 64);
            panel15.TabIndex = 9;
            // 
            // panel16
            // 
            panel16.Location = new Point(43, 203);
            panel16.Name = "panel16";
            panel16.Position = new Point(0, 1);
            panel16.Size = new Size(64, 64);
            panel16.TabIndex = 4;
            // 
            // StartButton
            // 
            StartButton.AutoSize = true;
            StartButton.FlatAppearance.BorderColor = Color.Yellow;
            StartButton.Font = new Font("Segoe MDL2 Assets", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.Location = new Point(342, 355);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(160, 53);
            StartButton.TabIndex = 16;
            StartButton.Text = "";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // TimerMode
            // 
            TimerMode.AutoSize = true;
            TimerMode.Location = new Point(0, 70);
            TimerMode.Name = "TimerMode";
            TimerMode.Size = new Size(121, 32);
            TimerMode.TabIndex = 17;
            TimerMode.Text = "计时模式";
            TimerMode.UseVisualStyleBackColor = true;
            // 
            // StepCountMode
            // 
            StepCountMode.AutoSize = true;
            StepCountMode.Checked = true;
            StepCountMode.Location = new Point(0, 0);
            StepCountMode.Name = "StepCountMode";
            StepCountMode.Size = new Size(121, 32);
            StepCountMode.TabIndex = 18;
            StepCountMode.TabStop = true;
            StepCountMode.Text = "步骤模式";
            StepCountMode.UseVisualStyleBackColor = true;
            // 
            // BestTimeLabel
            // 
            BestTimeLabel.AutoSize = true;
            BestTimeLabel.Location = new Point(25, 105);
            BestTimeLabel.Name = "BestTimeLabel";
            BestTimeLabel.Size = new Size(0, 28);
            BestTimeLabel.TabIndex = 22;
            // 
            // LeastStepLabel
            // 
            LeastStepLabel.AutoSize = true;
            LeastStepLabel.Location = new Point(25, 35);
            LeastStepLabel.Name = "LeastStepLabel";
            LeastStepLabel.Size = new Size(0, 28);
            LeastStepLabel.TabIndex = 23;
            // 
            // ModeSelectPanel
            // 
            ModeSelectPanel.AutoSize = true;
            ModeSelectPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ModeSelectPanel.Controls.Add(StepCountMode);
            ModeSelectPanel.Controls.Add(LeastStepLabel);
            ModeSelectPanel.Controls.Add(TimerMode);
            ModeSelectPanel.Controls.Add(BestTimeLabel);
            ModeSelectPanel.Location = new Point(343, 134);
            ModeSelectPanel.Name = "ModeSelectPanel";
            ModeSelectPanel.Size = new Size(124, 133);
            ModeSelectPanel.TabIndex = 24;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel, ErrorLabel });
            statusStrip1.Location = new Point(0, 430);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(750, 37);
            statusStrip1.TabIndex = 25;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(18, 28);
            StatusLabel.Text = " ";
            // 
            // ErrorLabel
            // 
            ErrorLabel.ForeColor = Color.Crimson;
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(0, 28);
            // 
            // IngameButtons
            // 
            IngameButtons.Controls.Add(button1);
            IngameButtons.Controls.Add(CancelButton);
            IngameButtons.Location = new Point(343, 355);
            IngameButtons.Name = "IngameButtons";
            IngameButtons.Size = new Size(159, 53);
            IngameButtons.TabIndex = 26;
            IngameButtons.Visible = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe MDL2 Assets", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(-1, 0);
            button1.Name = "button1";
            button1.Size = new Size(77, 53);
            button1.TabIndex = 0;
            button1.Text = "";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe MDL2 Assets", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(82, 0);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(77, 53);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // PicSelect
            // 
            PicSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            PicSelect.FormattingEnabled = true;
            PicSelect.Items.AddRange(new object[] { "经典", "小屋", "鲜花", "自定义..." });
            PicSelect.Location = new Point(40, 80);
            PicSelect.Name = "PicSelect";
            PicSelect.Size = new Size(277, 36);
            PicSelect.TabIndex = 27;
            PicSelect.SelectedIndexChanged += PicSelect_SelectedIndexChanged;
            // 
            // EnableNumberCheckBox
            // 
            EnableNumberCheckBox.AutoSize = true;
            EnableNumberCheckBox.Location = new Point(343, 305);
            EnableNumberCheckBox.Name = "EnableNumberCheckBox";
            EnableNumberCheckBox.Size = new Size(122, 32);
            EnableNumberCheckBox.TabIndex = 28;
            EnableNumberCheckBox.Text = "显示序号";
            EnableNumberCheckBox.UseVisualStyleBackColor = true;
            EnableNumberCheckBox.CheckedChanged += EnableNumberCheckBox_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15.000001F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(452, 47);
            label1.TabIndex = 29;
            label1.Text = "（也许能算是）数字华容道";
            // 
            // IngamePreviewPanel
            // 
            IngamePreviewPanel.Location = new Point(342, 137);
            IngamePreviewPanel.Name = "IngamePreviewPanel";
            IngamePreviewPanel.Size = new Size(160, 160);
            IngamePreviewPanel.TabIndex = 30;
            IngamePreviewPanel.Visible = false;
            // 
            // HelpHint
            // 
            HelpHint.AutoSize = true;
            HelpHint.Font = new Font("Segoe Script", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HelpHint.Location = new Point(519, 15);
            HelpHint.Name = "HelpHint";
            HelpHint.Size = new Size(204, 66);
            HelpHint.TabIndex = 31;
            HelpHint.Text = "             ↑\r\nsee this? click it!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(750, 467);
            Controls.Add(HelpHint);
            Controls.Add(IngamePreviewPanel);
            Controls.Add(label1);
            Controls.Add(EnableNumberCheckBox);
            Controls.Add(PicSelect);
            Controls.Add(IngameButtons);
            Controls.Add(statusStrip1);
            Controls.Add(ModeSelectPanel);
            Controls.Add(PreviewPanel);
            Controls.Add(StartButton);
            Controls.Add(panel12);
            Controls.Add(panel13);
            Controls.Add(panel14);
            Controls.Add(panel15);
            Controls.Add(panel9);
            Controls.Add(panel10);
            Controls.Add(panel11);
            Controls.Add(panel6);
            Controls.Add(panel7);
            Controls.Add(panel8);
            Controls.Add(panel16);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Klotski";
            HelpButtonClicked += Form1_HelpButtonClicked;
            Shown += Form1_Shown;
            ModeSelectPanel.ResumeLayout(false);
            ModeSelectPanel.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            IngameButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelMatrixItem panel1;
        private PanelMatrixItem panel2;
        private PanelMatrixItem panel3;
        private PanelMatrixItem panel4;
        private PanelMatrixItem panel5;
        private PanelMatrixItem panel6;
        private PanelMatrixItem panel7;
        private PanelMatrixItem panel8;
        private PanelMatrixItem panel9;
        private PanelMatrixItem panel10;
        private PanelMatrixItem panel11;
        private PanelMatrixItem panel12;
        private PanelMatrixItem panel13;
        private PanelMatrixItem panel14;
        private PanelMatrixItem panel15;
        private PanelMatrixItem panel16;
        private Button StartButton;
        private RadioButton TimerMode;
        private RadioButton StepCountMode;
        private Panel PreviewPanel;
        private Label BestTimeLabel;
        private Label LeastStepLabel;
        private Panel ModeSelectPanel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel;
        private ToolStripStatusLabel ErrorLabel;
        private Panel IngameButtons;
        private Button button1;
        private Button CancelButton;
        private ComboBox PicSelect;
        private CheckBox EnableNumberCheckBox;
        private Label label1;
        private Panel IngamePreviewPanel;
        private Label HelpHint;
    }
}
