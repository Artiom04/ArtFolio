namespace ArtFolio.GestionePagina.Interface;

partial class SchermataCreazionePostBoundary
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
		label1 = new Label();
		button1 = new Button();
		button2 = new Button();
		button3 = new Button();
		SuspendLayout();
		// 
		// textBox1
		// 
		textBox1.Location = new Point(12, 37);
		textBox1.Multiline = true;
		textBox1.Name = "textBox1";
		textBox1.Size = new Size(776, 258);
		textBox1.TabIndex = 0;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(12, 9);
		label1.Name = "label1";
		label1.Size = new Size(167, 25);
		label1.TabIndex = 1;
		label1.Text = "Inserisci descrizione";
		// 
		// button1
		// 
		button1.Location = new Point(617, 301);
		button1.Name = "button1";
		button1.Size = new Size(171, 65);
		button1.TabIndex = 2;
		button1.Text = "Pubblica";
		button1.UseVisualStyleBackColor = true;
		button1.Click += cliccaPubblica;
		// 
		// button2
		// 
		button2.Location = new Point(12, 301);
		button2.Name = "button2";
		button2.Size = new Size(171, 65);
		button2.TabIndex = 3;
		button2.Text = "Indietro";
		button2.UseVisualStyleBackColor = true;
		button2.Click += button2_Click_1;
		// 
		// button3
		// 
		button3.Location = new Point(440, 301);
		button3.Name = "button3";
		button3.Size = new Size(171, 65);
		button3.TabIndex = 4;
		button3.Text = "Carica Materiale";
		button3.UseVisualStyleBackColor = true;
		button3.Click += cliccaCaricaMateriale;
		// 
		// SchermataCreazionePostBoundary
		// 
		AutoScaleDimensions = new SizeF(10F, 25F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 378);
		Controls.Add(button3);
		Controls.Add(button2);
		Controls.Add(button1);
		Controls.Add(label1);
		Controls.Add(textBox1);
		Name = "SchermataCreazionePostBoundary";
		Text = "Crea Post";
		Load += SchermataCreazionePostBoundary_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private TextBox textBox1;
	private Label label1;
	private Button button1;
	private Button button2;
	private Button button3;
}