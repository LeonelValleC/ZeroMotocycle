namespace Zero_SN
{
    partial class Scrap
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
            this.dg_Reprint = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbl_WO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Scrap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Reprint)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Reprint
            // 
            this.dg_Reprint.AllowUserToOrderColumns = true;
            this.dg_Reprint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Reprint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Reprint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Reprint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dg_Reprint.Location = new System.Drawing.Point(174, 148);
            this.dg_Reprint.Name = "dg_Reprint";
            this.dg_Reprint.Size = new System.Drawing.Size(534, 578);
            this.dg_Reprint.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Scrap";
            this.Column1.Name = "Column1";
            // 
            // lbl_WO
            // 
            this.lbl_WO.AutoSize = true;
            this.lbl_WO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WO.Location = new System.Drawing.Point(466, 15);
            this.lbl_WO.Name = "lbl_WO";
            this.lbl_WO.Size = new System.Drawing.Size(57, 20);
            this.lbl_WO.TabIndex = 12;
            this.lbl_WO.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Work Order:";
            // 
            // btn_Scrap
            // 
            this.btn_Scrap.Location = new System.Drawing.Point(400, 70);
            this.btn_Scrap.Name = "btn_Scrap";
            this.btn_Scrap.Size = new System.Drawing.Size(100, 42);
            this.btn_Scrap.TabIndex = 10;
            this.btn_Scrap.Text = "Scrap";
            this.btn_Scrap.UseVisualStyleBackColor = true;
            this.btn_Scrap.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // Scrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 738);
            this.Controls.Add(this.dg_Reprint);
            this.Controls.Add(this.lbl_WO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Scrap);
            this.Name = "Scrap";
            this.Text = "Scrap";
            this.Load += new System.EventHandler(this.Scrap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Reprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dg_Reprint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Label lbl_WO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Scrap;
    }
}