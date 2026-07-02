namespace ArtFolio
{
	partial class SchermataRegistrazioneBoundary
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
			textBox1 = new TextBox();
			label2 = new Label();
			textBox2 = new TextBox();
			label3 = new Label();
			button1 = new Button();
			maskedTextBox1 = new MaskedTextBox();
			button2 = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(17, 21);
			label1.Name = "label1";
			label1.Size = new Size(54, 25);
			label1.TabIndex = 0;
			label1.Text = "email";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(77, 18);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(268, 31);
			textBox1.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(19, 71);
			label2.Name = "label2";
			label2.Size = new Size(87, 25);
			label2.TabIndex = 2;
			label2.Text = "nickname";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(112, 68);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(233, 31);
			textBox2.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(19, 122);
			label3.Name = "label3";
			label3.Size = new Size(89, 25);
			label3.TabIndex = 4;
			label3.Text = "password";
			label3.Click += label3_Click;
			// 
			// button1
			// 
			button1.Location = new Point(241, 168);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 6;
			button1.Text = "Registrati";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaRegistrati;
			// 
			// maskedTextBox1
			// 
			maskedTextBox1.Location = new Point(122, 119);
			maskedTextBox1.Name = "maskedTextBox1";
			maskedTextBox1.Size = new Size(223, 31);
			maskedTextBox1.TabIndex = 7;
			// 
			// button2
			// 
			button2.Location = new Point(17, 168);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 8;
			button2.Text = "Indietro";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// SchermataRegistrazioneBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(379, 214);
			Controls.Add(button2);
			Controls.Add(maskedTextBox1);
			Controls.Add(button1);
			Controls.Add(label3);
			Controls.Add(textBox2);
			Controls.Add(label2);
			Controls.Add(textBox1);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SchermataRegistrazioneBoundary";
			Text = "Registrazione";
			Load += SchermataRegistrazioneBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBox1;
		private Label label2;
		private TextBox textBox2;
		private Label label3;
		private Button button1;
		private MaskedTextBox maskedTextBox1;
		private Button button2;
	}
}