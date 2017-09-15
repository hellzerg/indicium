namespace Indicium
{
    partial class Messager
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
            this.msg = new System.Windows.Forms.Label();
            this.yesbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.msg.Location = new System.Drawing.Point(12, 9);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(540, 86);
            this.msg.TabIndex = 34;
            this.msg.Text = "Restart to apply changes?";
            // 
            // yesbtn
            // 
            this.yesbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.yesbtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.yesbtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesbtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.yesbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.yesbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.yesbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesbtn.ForeColor = System.Drawing.Color.White;
            this.yesbtn.Location = new System.Drawing.Point(432, 133);
            this.yesbtn.Name = "yesbtn";
            this.yesbtn.Size = new System.Drawing.Size(120, 39);
            this.yesbtn.TabIndex = 36;
            this.yesbtn.Tag = "themeable";
            this.yesbtn.Text = "OK";
            this.yesbtn.UseVisualStyleBackColor = false;
            this.yesbtn.Click += new System.EventHandler(this.yesbtn_Click);
            // 
            // Messager
            // 
            this.AcceptButton = this.yesbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CancelButton = this.yesbtn;
            this.ClientSize = new System.Drawing.Size(564, 184);
            this.Controls.Add(this.yesbtn);
            this.Controls.Add(this.msg);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Messager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Messager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Button yesbtn;
    }
}