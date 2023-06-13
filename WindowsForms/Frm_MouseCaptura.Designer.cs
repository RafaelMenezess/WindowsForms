namespace WindowsForms
{
    partial class Frm_MouseCaptura
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
            this.Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn
            // 
            this.Btn.Location = new System.Drawing.Point(89, 64);
            this.Btn.Name = "Btn";
            this.Btn.Size = new System.Drawing.Size(202, 115);
            this.Btn.TabIndex = 0;
            this.Btn.Text = "Clique Aqui!";
            this.Btn.UseVisualStyleBackColor = true;
            this.Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            // 
            // Frm_MouseCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 259);
            this.Controls.Add(this.Btn);
            this.Name = "Frm_MouseCaptura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_MouseCaptura";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn;
    }
}