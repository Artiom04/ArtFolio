namespace ArtFolio.GestioneAccount.Interface
{
	partial class SchermataVerifica2FattoriBoundary
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
			textBox1 = new TextBox();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 12);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(331, 31);
			textBox1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(231, 49);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 1;
			button1.Text = "Verifica";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaVerifica;
			// 
			// button2
			// 
			button2.Location = new Point(12, 49);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 2;
			button2.Text = "Indietro";
			button2.UseVisualStyleBackColor = true;
			// 
			// SchermataVerifica2FattoriBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(355, 94);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SchermataVerifica2FattoriBoundary";
			Text = "Inserisci Codice";
			Load += SchermataVerifica2FattoriBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button button1;
		private Button button2;
	}
}