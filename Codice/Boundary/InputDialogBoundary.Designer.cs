namespace ArtFolio
{
	partial class InputDialogBoundary
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
			button1 = new Button();
			button2 = new Button();
			label1 = new Label();
			textBox1 = new TextBox();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(525, 93);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 0;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaOK;
			// 
			// button2
			// 
			button2.Location = new Point(12, 93);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 1;
			button2.Text = "Cancel";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(30, 14);
			label1.Name = "label1";
			label1.Size = new Size(345, 25);
			label1.TabIndex = 2;
			label1.Text = "Questo testo varia a seconda del contesto";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 56);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(625, 31);
			textBox1.TabIndex = 3;
			// 
			// InputDialogBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(653, 139);
			Controls.Add(textBox1);
			Controls.Add(label1);
			Controls.Add(button2);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			Name = "InputDialogBoundary";
			Load += InputDialogBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Button button2;
		private Label label1;
		private TextBox textBox1;
	}
}