namespace Zero_SN
{
    partial class ValidateSN
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
            this.dg_Validate = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Validate = new System.Windows.Forms.TextBox();
            this.btn_Check = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Records = new System.Windows.Forms.Label();
            this.lbl_Validated = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Validate)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Validate
            // 
            this.dg_Validate.AllowUserToAddRows = false;
            this.dg_Validate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Validate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Validate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Validate.Location = new System.Drawing.Point(12, 194);
            this.dg_Validate.Name = "dg_Validate";
            this.dg_Validate.Size = new System.Drawing.Size(1088, 525);
            this.dg_Validate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Validate:";
            // 
            // txt_Validate
            // 
            this.txt_Validate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Validate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Validate.Location = new System.Drawing.Point(292, 81);
            this.txt_Validate.Name = "txt_Validate";
            this.txt_Validate.Size = new System.Drawing.Size(547, 22);
            this.txt_Validate.TabIndex = 2;
            this.txt_Validate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Validate_KeyDown);
            // 
            // btn_Check
            // 
            this.btn_Check.Location = new System.Drawing.Point(502, 120);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(88, 38);
            this.btn_Check.TabIndex = 3;
            this.btn_Check.Text = "Check";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Records:";
            // 
            // lbl_Records
            // 
            this.lbl_Records.AutoSize = true;
            this.lbl_Records.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Records.Location = new System.Drawing.Point(89, 175);
            this.lbl_Records.Name = "lbl_Records";
            this.lbl_Records.Size = new System.Drawing.Size(61, 16);
            this.lbl_Records.TabIndex = 5;
            this.lbl_Records.Text = "records";
            // 
            // lbl_Validated
            // 
            this.lbl_Validated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Validated.AutoSize = true;
            this.lbl_Validated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Validated.Location = new System.Drawing.Point(1027, 170);
            this.lbl_Validated.Name = "lbl_Validated";
            this.lbl_Validated.Size = new System.Drawing.Size(73, 16);
            this.lbl_Validated.TabIndex = 7;
            this.lbl_Validated.Text = "validated";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(942, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Validated:";
            // 
            // ValidateSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 731);
            this.Controls.Add(this.lbl_Validated);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Records);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.txt_Validate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Validate);
            this.Name = "ValidateSN";
            this.Text = "ValidateSN";
            this.Load += new System.EventHandler(this.ValidateSN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Validate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Validate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Validate;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Records;
        private System.Windows.Forms.Label lbl_Validated;
        private System.Windows.Forms.Label label4;
    }
}