namespace chinamovementdb
{
    partial class FormVersion
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn32 = new System.Windows.Forms.Button();
            this.btn64 = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btn32
            // 
            this.btn32.Location = new System.Drawing.Point(26, 102);
            this.btn32.Name = "btn32";
            this.btn32.Size = new System.Drawing.Size(90, 36);
            this.btn32.TabIndex = 2;
            this.btn32.Text = "To 32 bit";
            this.btn32.UseVisualStyleBackColor = true;
            this.btn32.Click += new System.EventHandler(this.btn32_Click);
            // 
            // btn64
            // 
            this.btn64.Location = new System.Drawing.Point(239, 102);
            this.btn64.Name = "btn64";
            this.btn64.Size = new System.Drawing.Size(90, 36);
            this.btn64.TabIndex = 3;
            this.btn64.Text = "To 64 bit";
            this.btn64.UseVisualStyleBackColor = true;
            this.btn64.Click += new System.EventHandler(this.btn64_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(463, 102);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(90, 36);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // FormVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 150);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btn64);
            this.Controls.Add(this.btn32);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVersion";
            this.Text = "更换或恢复应用程序";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn32;
        private System.Windows.Forms.Button btn64;
        private System.Windows.Forms.Button btnRestore;
    }
}