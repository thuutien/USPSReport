namespace USPS_Invidual_Report
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_directory = new System.Windows.Forms.TextBox();
            this.btn_generate = new System.Windows.Forms.Button();
            this.btn_openFolder = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Directory to USPS Report Files (.PSE)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_directory
            // 
            this.txt_directory.Location = new System.Drawing.Point(27, 76);
            this.txt_directory.Name = "txt_directory";
            this.txt_directory.Size = new System.Drawing.Size(606, 22);
            this.txt_directory.TabIndex = 2;
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(27, 115);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(141, 36);
            this.btn_generate.TabIndex = 3;
            this.btn_generate.Text = "Generate Report";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_openFolder
            // 
            this.btn_openFolder.Location = new System.Drawing.Point(27, 166);
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.Size = new System.Drawing.Size(141, 36);
            this.btn_openFolder.TabIndex = 4;
            this.btn_openFolder.Text = "Open Report";
            this.btn_openFolder.UseVisualStyleBackColor = true;
            this.btn_openFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(575, 341);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(58, 16);
            this.lbl_version.TabIndex = 5;
            this.lbl_version.Text = "Ver 0.0.1";
            this.lbl_version.Click += new System.EventHandler(this.lbl_version_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 366);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btn_openFolder);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.txt_directory);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "USPS Reports Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_directory;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Button btn_openFolder;
        private System.Windows.Forms.Label lbl_version;
    }
}

