namespace ArtFolio
{
	partial class SchermataModificaBiografiaBoundary
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
			biografiaTextBox = new TextBox();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// biografiaTextBox
			// 
			biografiaTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			biografiaTextBox.Location = new Point(12, 12);
			biografiaTextBox.Multiline = true;
			biografiaTextBox.Name = "biografiaTextBox";
			biografiaTextBox.Size = new Size(570, 319);
			biografiaTextBox.TabIndex = 0;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button1.Location = new Point(12, 337);
			button1.Name = "button1";
			button1.Size = new Size(170, 67);
			button1.TabIndex = 1;
			button1.Text = "Annulla";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button2.Location = new Point(412, 337);
			button2.Name = "button2";
			button2.Size = new Size(170, 67);
			button2.TabIndex = 2;
			button2.Text = "Modifica";
			button2.UseVisualStyleBackColor = true;
			button2.Click += cliccaModifica;
			// 
			// SchermataModificaBiografiaBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(593, 418);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(biografiaTextBox);
			Name = "SchermataModificaBiografiaBoundary";
			Text = "Modifica Biografia";
			Load += SchermataModificaBiografiaBoundary_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox biografiaTextBox;
		private Button button1;
		private Button button2;
	}
}