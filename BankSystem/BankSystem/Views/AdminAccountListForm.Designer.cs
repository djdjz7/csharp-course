namespace BankSystem.Views
{
    partial class AdminAccountListForm
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
            components = new System.ComponentModel.Container();
            MainDataGrid = new DataGridView();
            accountBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)MainDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountBindingSource).BeginInit();
            SuspendLayout();
            // 
            // MainDataGrid
            // 
            MainDataGrid.AllowUserToAddRows = false;
            MainDataGrid.AllowUserToDeleteRows = false;
            MainDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MainDataGrid.Dock = DockStyle.Fill;
            MainDataGrid.Location = new Point(0, 0);
            MainDataGrid.Name = "MainDataGrid";
            MainDataGrid.ReadOnly = true;
            MainDataGrid.RowHeadersWidth = 82;
            MainDataGrid.Size = new Size(1488, 822);
            MainDataGrid.TabIndex = 0;
            // 
            // accountBindingSource
            // 
            accountBindingSource.DataSource = typeof(Models.Account);
            // 
            // AdminAccountListForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1488, 822);
            Controls.Add(MainDataGrid);
            Name = "AdminAccountListForm";
            Text = "AdminUserListForm";
            Load += AdminUserListForm_Load;
            ((System.ComponentModel.ISupportInitialize)MainDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView MainDataGrid;
        private BindingSource accountBindingSource;
    }
}