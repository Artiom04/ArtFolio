namespace ArtFolio
{
	partial class SchermataPubblicaStudenteBoundary
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
			nome = new Label();
			cognome = new Label();
			nickname = new Label();
			elencoPaginePubbliche = new DataGridView();
			ID = new DataGridViewTextBoxColumn();
			NomePagina = new DataGridViewTextBoxColumn();
			miniaturaContenutoMultimedialeBoundary1 = new MiniaturaContenutoMultimedialeBoundary();
			biografia = new Label();
			((System.ComponentModel.ISupportInitialize)elencoPaginePubbliche).BeginInit();
			SuspendLayout();
			// 
			// nome
			// 
			nome.AutoSize = true;
			nome.Location = new Point(78, 105);
			nome.Name = "nome";
			nome.Size = new Size(58, 25);
			nome.TabIndex = 1;
			nome.Text = "nome";
			// 
			// cognome
			// 
			cognome.AutoSize = true;
			cognome.Location = new Point(202, 105);
			cognome.Name = "cognome";
			cognome.Size = new Size(88, 25);
			cognome.TabIndex = 2;
			cognome.Text = "cognome";
			// 
			// nickname
			// 
			nickname.AutoSize = true;
			nickname.Location = new Point(340, 105);
			nickname.Name = "nickname";
			nickname.Size = new Size(87, 25);
			nickname.TabIndex = 3;
			nickname.Text = "nickname";
			// 
			// elencoPaginePubbliche
			// 
			elencoPaginePubbliche.AllowUserToAddRows = false;
			elencoPaginePubbliche.AllowUserToDeleteRows = false;
			elencoPaginePubbliche.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			elencoPaginePubbliche.Columns.AddRange(new DataGridViewColumn[] { ID, NomePagina });
			elencoPaginePubbliche.Location = new Point(12, 225);
			elencoPaginePubbliche.Name = "elencoPaginePubbliche";
			elencoPaginePubbliche.ReadOnly = true;
			elencoPaginePubbliche.RowHeadersWidth = 62;
			elencoPaginePubbliche.Size = new Size(481, 329);
			elencoPaginePubbliche.TabIndex = 4;
			elencoPaginePubbliche.RowHeaderMouseClick += cliccaPagina;
			// 
			// ID
			// 
			ID.HeaderText = "ID";
			ID.MinimumWidth = 8;
			ID.Name = "ID";
			ID.ReadOnly = true;
			ID.Width = 150;
			// 
			// NomePagina
			// 
			NomePagina.HeaderText = "NomePagina";
			NomePagina.MinimumWidth = 8;
			NomePagina.Name = "NomePagina";
			NomePagina.ReadOnly = true;
			NomePagina.Width = 150;
			// 
			// miniaturaContenutoMultimedialeBoundary1
			// 
			miniaturaContenutoMultimedialeBoundary1.Location = new Point(175, 12);
			miniaturaContenutoMultimedialeBoundary1.Name = "miniaturaContenutoMultimedialeBoundary1";
			miniaturaContenutoMultimedialeBoundary1.Size = new Size(159, 90);
			miniaturaContenutoMultimedialeBoundary1.TabIndex = 5;
			// 
			// biografia
			// 
			biografia.AutoSize = true;
			biografia.Location = new Point(208, 168);
			biografia.Name = "biografia";
			biografia.Size = new Size(82, 25);
			biografia.TabIndex = 11;
			biografia.Text = "Biografia";
			// 
			// SchermataPubblicaStudenteBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(508, 566);
			Controls.Add(biografia);
			Controls.Add(miniaturaContenutoMultimedialeBoundary1);
			Controls.Add(elencoPaginePubbliche);
			Controls.Add(nickname);
			Controls.Add(cognome);
			Controls.Add(nome);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "SchermataPubblicaStudenteBoundary";
			Text = "Schermata Pubblica Studente";
			Load += SchermataPubblicaStudenteBoundary_Load;
			((System.ComponentModel.ISupportInitialize)elencoPaginePubbliche).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label nome;
		private Label cognome;
		private Label nickname;
		private DataGridView elencoPaginePubbliche;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn NomePagina;
		private MiniaturaContenutoMultimedialeBoundary miniaturaContenutoMultimedialeBoundary1;
		private Label biografia;
	}
}