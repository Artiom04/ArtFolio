namespace ArtFolio
{
	partial class SchermataModificaPasswordBoundary
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
			vecchiaPassword = new TextBox();
			nuovaPassword = new TextBox();
			modificaBtn = new Button();
			label1 = new Label();
			label2 = new Label();
			button1 = new Button();
			SuspendLayout();
			// 
			// vecchiaPassword
			// 
			vecchiaPassword.Location = new Point(174, 21);
			vecchiaPassword.Name = "vecchiaPassword";
			vecchiaPassword.Size = new Size(268, 31);
			vecchiaPassword.TabIndex = 0;
			// 
			// nuovaPassword
			// 
			nuovaPassword.Location = new Point(174, 55);
			nuovaPassword.Name = "nuovaPassword";
			nuovaPassword.Size = new Size(268, 31);
			nuovaPassword.TabIndex = 1;
			// 
			// modificaBtn
			// 
			modificaBtn.Location = new Point(330, 92);
			modificaBtn.Name = "modificaBtn";
			modificaBtn.Size = new Size(112, 34);
			modificaBtn.TabIndex = 2;
			modificaBtn.Text = "Modifica";
			modificaBtn.UseVisualStyleBackColor = true;
			modificaBtn.Click += cliccaModifica;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(18, 24);
			label1.Name = "label1";
			label1.Size = new Size(150, 25);
			label1.TabIndex = 3;
			label1.Text = "Vecchia Password";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(18, 58);
			label2.Name = "label2";
			label2.Size = new Size(144, 25);
			label2.TabIndex = 4;
			label2.Text = "Nuova Password";
			// 
			// button1
			// 
			button1.Location = new Point(18, 92);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 5;
			button1.Text = "Indietro";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// SchermataModificaPasswordBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(467, 142);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(modificaBtn);
			Controls.Add(nuovaPassword);
			Controls.Add(vecchiaPassword);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SchermataModificaPasswordBoundary";
			Text = "Modifica Password";
			Load += SchermataModificaPasswordBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox vecchiaPassword;
		private TextBox nuovaPassword;
		private Button modificaBtn;
		private Label label1;
		private Label label2;
		private Button button1;
	}
}