namespace ArtFolio
{
	partial class SchermataGenerazioneLinkBoundary
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
			dateTimePicker1 = new DateTimePicker();
			label1 = new Label();
			label2 = new Label();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(116, 24);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(345, 31);
			textBox1.TabIndex = 0;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(161, 61);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(300, 31);
			dateTimePicker1.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(23, 24);
			label1.Name = "label1";
			label1.Size = new Size(87, 25);
			label1.TabIndex = 2;
			label1.Text = "nickname";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(31, 61);
			label2.Name = "label2";
			label2.Size = new Size(124, 25);
			label2.TabIndex = 3;
			label2.Text = "data scadenza";
			// 
			// button1
			// 
			button1.Location = new Point(349, 98);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 4;
			button1.Text = "Conferma";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaConferma;
			// 
			// button2
			// 
			button2.Location = new Point(23, 97);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 5;
			button2.Text = "Indietro";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// SchermataGenerazioneLinkBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(478, 143);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dateTimePicker1);
			Controls.Add(textBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SchermataGenerazioneLinkBoundary";
			Text = "Generazione Link";
			Load += SchermataGenerazioneLinkBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private DateTimePicker dateTimePicker1;
		private Label label1;
		private Label label2;
		private Button button1;
		private Button button2;
	}
}