namespace ArtFolio
{
	partial class SchermataSceltaSistemaIdentificazioneBoundary
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
			listBox1 = new ListBox();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// listBox1
			// 
			listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			listBox1.FormattingEnabled = true;
			listBox1.Items.AddRange(new object[] { "Manuale" });
			listBox1.Location = new Point(12, 12);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(515, 254);
			listBox1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button1.Location = new Point(399, 277);
			button1.Name = "button1";
			button1.Size = new Size(128, 57);
			button1.TabIndex = 1;
			button1.Text = "Verifica";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaIdentifica;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button2.Location = new Point(12, 277);
			button2.Name = "button2";
			button2.Size = new Size(125, 57);
			button2.TabIndex = 2;
			button2.Text = "Indietro";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// SchermataSceltaSistemaIdentificazioneBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(539, 346);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(listBox1);
			Name = "SchermataSceltaSistemaIdentificazioneBoundary";
			Text = "Scegli il Sistema di Identificazione da usare";
			Load += SchermataSceltaSistemaIdentificazioneBoundary_Load;
			ResumeLayout(false);
		}

		#endregion

		private ListBox listBox1;
		private Button button1;
		private Button button2;
	}
}