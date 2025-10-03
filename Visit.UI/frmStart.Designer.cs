namespace Visit.UI
{
    partial class frmStart
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
            this.btnDoctor = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnBimar = new Guna.UI2.WinForms.Guna2CircleButton();
            this.SuspendLayout();
            // 
            // btnDoctor
            // 
            this.btnDoctor.Animated = true;
            this.btnDoctor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDoctor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDoctor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDoctor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDoctor.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.btnDoctor.ForeColor = System.Drawing.Color.White;
            this.btnDoctor.Location = new System.Drawing.Point(113, 87);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDoctor.Size = new System.Drawing.Size(92, 88);
            this.btnDoctor.TabIndex = 0;
            this.btnDoctor.Text = "ورود دکتر";
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnBimar
            // 
            this.btnBimar.Animated = true;
            this.btnBimar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBimar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBimar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBimar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBimar.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.btnBimar.ForeColor = System.Drawing.Color.White;
            this.btnBimar.Location = new System.Drawing.Point(211, 87);
            this.btnBimar.Name = "btnBimar";
            this.btnBimar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBimar.Size = new System.Drawing.Size(92, 88);
            this.btnBimar.TabIndex = 1;
            this.btnBimar.Text = "ورود بیمار";
            this.btnBimar.Click += new System.EventHandler(this.btnBimar_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 283);
            this.Controls.Add(this.btnBimar);
            this.Controls.Add(this.btnDoctor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStart";
            this.Text = "ویزیت 24";
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton btnDoctor;
        private Guna.UI2.WinForms.Guna2CircleButton btnBimar;
    }
}