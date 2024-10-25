namespace BankSystem.Views
{
    partial class TransactionDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)MainDataGrid).BeginInit();
            SuspendLayout();
            // 
            // MainDataGrid
            // 
            MainDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MainDataGrid.Dock = DockStyle.Fill;
            MainDataGrid.Location = new Point(0, 0);
            MainDataGrid.Name = "MainDataGrid";
            MainDataGrid.RowHeadersWidth = 82;
            MainDataGrid.Size = new Size(800, 450);
            MainDataGrid.TabIndex = 0;
            // 
            // TransactionDetailsForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainDataGrid);
            Name = "TransactionDetailsForm";
            Text = "资产详情";
            Load += TransactionDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)MainDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView MainDataGrid;
    }
}