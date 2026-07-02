namespace ArtFolio
{
    partial class SchermataInizialeBoundary
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
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			nicknameTextBox = new TextBox();
			label1 = new Label();
			label2 = new Label();
			passwordTextBox = new MaskedTextBox();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(133, 95);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 0;
			button1.Text = "Registrati";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaRegistrazione;
			// 
			// button2
			// 
			button2.Location = new Point(15, 95);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 1;
			button2.Text = "Login";
			button2.UseVisualStyleBackColor = true;
			button2.Click += cliccaLogin;
			// 
			// button3
			// 
			button3.Location = new Point(15, 135);
			button3.Name = "button3";
			button3.Size = new Size(267, 34);
			button3.TabIndex = 2;
			button3.Text = "Visualizza Elenco Studenti";
			button3.UseVisualStyleBackColor = true;
			button3.Click += cliccaCercaStudenti;
			// 
			// nicknameTextBox
			// 
			nicknameTextBox.Location = new Point(108, 12);
			nicknameTextBox.Name = "nicknameTextBox";
			nicknameTextBox.Size = new Size(224, 31);
			nicknameTextBox.TabIndex = 3;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(15, 15);
			label1.Name = "label1";
			label1.Size = new Size(87, 25);
			label1.TabIndex = 5;
			label1.Text = "nickname";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(15, 61);
			label2.Name = "label2";
			label2.Size = new Size(93, 25);
			label2.TabIndex = 6;
			label2.Text = "password:";
			// 
			// passwordTextBox
			// 
			passwordTextBox.Location = new Point(114, 58);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(218, 31);
			passwordTextBox.TabIndex = 7;
			// 
			// SchermataInizialeBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(344, 185);
			Controls.Add(passwordTextBox);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(nicknameTextBox);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SchermataInizialeBoundary";
			Text = "Schermata iniziale";
			Load += SchermataHomeBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Button button2;
		private Button button3;
		private TextBox nicknameTextBox;
		private Label label1;
		private Label label2;
		private MaskedTextBox passwordTextBox;
	}
}
