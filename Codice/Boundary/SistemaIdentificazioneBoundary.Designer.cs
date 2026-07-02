namespace ArtFolio
{
	partial class SistemaIdentificazioneBoundary
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
			label1 = new Label();
			nomeTextBox = new TextBox();
			label2 = new Label();
			cognomeTextBox = new TextBox();
			label3 = new Label();
			codiceFiscaleTextBox = new TextBox();
			button1 = new Button();
			button2 = new Button();
			dateTimePicker1 = new DateTimePicker();
			label4 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(24, 15);
			label1.Name = "label1";
			label1.Size = new Size(58, 25);
			label1.TabIndex = 0;
			label1.Text = "nome";
			// 
			// nomeTextBox
			// 
			nomeTextBox.Location = new Point(120, 12);
			nomeTextBox.Name = "nomeTextBox";
			nomeTextBox.Size = new Size(343, 31);
			nomeTextBox.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(24, 58);
			label2.Name = "label2";
			label2.Size = new Size(88, 25);
			label2.TabIndex = 2;
			label2.Text = "cognome";
			// 
			// cognomeTextBox
			// 
			cognomeTextBox.Location = new Point(120, 55);
			cognomeTextBox.Name = "cognomeTextBox";
			cognomeTextBox.Size = new Size(343, 31);
			cognomeTextBox.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(32, 100);
			label3.Name = "label3";
			label3.Size = new Size(116, 25);
			label3.TabIndex = 4;
			label3.Text = "codice fiscale";
			// 
			// codiceFiscaleTextBox
			// 
			codiceFiscaleTextBox.Location = new Point(154, 97);
			codiceFiscaleTextBox.Name = "codiceFiscaleTextBox";
			codiceFiscaleTextBox.Size = new Size(309, 31);
			codiceFiscaleTextBox.TabIndex = 5;
			// 
			// button1
			// 
			button1.Location = new Point(351, 189);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 6;
			button1.Text = "Identifica";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaIdentifica;
			// 
			// button2
			// 
			button2.Location = new Point(22, 189);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 7;
			button2.Text = "Indietro";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(163, 141);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(300, 31);
			dateTimePicker1.TabIndex = 8;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(22, 146);
			label4.Name = "label4";
			label4.Size = new Size(126, 25);
			label4.TabIndex = 9;
			label4.Text = "data di nascita";
			// 
			// SistemaIdentificazioneBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(479, 241);
			Controls.Add(label4);
			Controls.Add(dateTimePicker1);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(codiceFiscaleTextBox);
			Controls.Add(label3);
			Controls.Add(cognomeTextBox);
			Controls.Add(label2);
			Controls.Add(nomeTextBox);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SistemaIdentificazioneBoundary";
			Text = "Inserisci i tuoi dati";
			Load += SistemaIdentificazioneBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox nomeTextBox;
		private Label label2;
		private TextBox cognomeTextBox;
		private Label label3;
		private TextBox codiceFiscaleTextBox;
		private Button button1;
		private Button button2;
		private DateTimePicker dateTimePicker1;
		private Label label4;
	}
}