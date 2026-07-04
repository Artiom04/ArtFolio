using ArtFolio.VisualizzaContenutoMultimediale.Interface;
namespace ArtFolio.GestioneAccount.Interface
{
	partial class SchermataHomeBoundary
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
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			button6 = new Button();
			biografiaLabel = new Label();
			button7 = new Button();
			miniaturaContenutoMultimedialeBoundary1 = new MiniaturaContenutoMultimedialeBoundary();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(0, 316);
			button1.Name = "button1";
			button1.Size = new Size(198, 76);
			button1.TabIndex = 0;
			button1.Text = "Gestione Materiale";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaGestioneMateriale;
			// 
			// button2
			// 
			button2.Location = new Point(637, 398);
			button2.Name = "button2";
			button2.Size = new Size(198, 76);
			button2.TabIndex = 1;
			button2.Text = "Gestione Pagine";
			button2.UseVisualStyleBackColor = true;
			button2.Click += cliccaGestionePagine;
			// 
			// button3
			// 
			button3.Location = new Point(117, 480);
			button3.Name = "button3";
			button3.Size = new Size(198, 76);
			button3.TabIndex = 2;
			button3.Text = "Cambia Password";
			button3.UseVisualStyleBackColor = true;
			button3.Click += cliccaModificaPassword;
			// 
			// button4
			// 
			button4.Location = new Point(0, 398);
			button4.Name = "button4";
			button4.Size = new Size(198, 76);
			button4.TabIndex = 3;
			button4.Text = "Modifica Biografia";
			button4.UseVisualStyleBackColor = true;
			button4.Click += cliccaModificaBiografia;
			// 
			// button5
			// 
			button5.Location = new Point(321, 480);
			button5.Name = "button5";
			button5.Size = new Size(198, 76);
			button5.TabIndex = 4;
			button5.Text = "Modifica Foto Profilo";
			button5.UseVisualStyleBackColor = true;
			button5.Click += cliccaModificaFotoProfilo;
			// 
			// button6
			// 
			button6.Location = new Point(637, 316);
			button6.Name = "button6";
			button6.Size = new Size(198, 76);
			button6.TabIndex = 5;
			button6.Text = "Logout";
			button6.UseVisualStyleBackColor = true;
			button6.Click += cliccaLogout;
			// 
			// biografiaLabel
			// 
			biografiaLabel.Location = new Point(204, 316);
			biografiaLabel.Name = "biografiaLabel";
			biografiaLabel.Size = new Size(427, 158);
			biografiaLabel.TabIndex = 6;
			biografiaLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// button7
			// 
			button7.Location = new Point(525, 480);
			button7.Name = "button7";
			button7.Size = new Size(198, 76);
			button7.TabIndex = 7;
			button7.Text = "Elimina Account";
			button7.UseVisualStyleBackColor = true;
			button7.Click += cliccaEliminaAccount;
			// 
			// miniaturaContenutoMultimedialeBoundary1
			// 
			miniaturaContenutoMultimedialeBoundary1.Location = new Point(248, 12);
			miniaturaContenutoMultimedialeBoundary1.Name = "miniaturaContenutoMultimedialeBoundary1";
			miniaturaContenutoMultimedialeBoundary1.Size = new Size(352, 301);
			miniaturaContenutoMultimedialeBoundary1.TabIndex = 8;
			miniaturaContenutoMultimedialeBoundary1.Load += miniaturaContenutoMultimedialeBoundary1_Load;
			// 
			// SchermataHomeBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(861, 566);
			Controls.Add(miniaturaContenutoMultimedialeBoundary1);
			Controls.Add(button7);
			Controls.Add(biografiaLabel);
			Controls.Add(button6);
			Controls.Add(button5);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SchermataHomeBoundary";
			Text = "Home";
			Load += SchermataHomeBoundary_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button button6;
		private Label biografiaLabel;
		private Button button7;
		private MiniaturaContenutoMultimedialeBoundary miniaturaContenutoMultimedialeBoundary1;
	}
}