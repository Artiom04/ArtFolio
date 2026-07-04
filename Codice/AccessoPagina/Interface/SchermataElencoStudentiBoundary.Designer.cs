namespace ArtFolio.AccessoPagina.Interface
{
	partial class SchermataElencoStudentiBoundary
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
			elencoStudenti = new DataGridView();
			ID = new DataGridViewTextBoxColumn();
			Nickname = new DataGridViewTextBoxColumn();
			Nome = new DataGridViewTextBoxColumn();
			Cognome = new DataGridViewTextBoxColumn();
			button1 = new Button();
			barraRicerca = new TextBox();
			((System.ComponentModel.ISupportInitialize)elencoStudenti).BeginInit();
			SuspendLayout();
			// 
			// elencoStudenti
			// 
			elencoStudenti.AllowUserToAddRows = false;
			elencoStudenti.AllowUserToDeleteRows = false;
			elencoStudenti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			elencoStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			elencoStudenti.Columns.AddRange(new DataGridViewColumn[] { ID, Nickname, Nome, Cognome });
			elencoStudenti.Location = new Point(12, 49);
			elencoStudenti.MultiSelect = false;
			elencoStudenti.Name = "elencoStudenti";
			elencoStudenti.ReadOnly = true;
			elencoStudenti.RowHeadersWidth = 62;
			elencoStudenti.Size = new Size(830, 299);
			elencoStudenti.TabIndex = 0;
			elencoStudenti.RowHeaderMouseClick += elencoStudenti_RowHeaderMouseClick;
			// 
			// ID
			// 
			ID.HeaderText = "ID";
			ID.MinimumWidth = 8;
			ID.Name = "ID";
			ID.ReadOnly = true;
			ID.Width = 150;
			// 
			// Nickname
			// 
			Nickname.HeaderText = "Nickname";
			Nickname.MinimumWidth = 8;
			Nickname.Name = "Nickname";
			Nickname.ReadOnly = true;
			Nickname.Width = 150;
			// 
			// Nome
			// 
			Nome.HeaderText = "Nome";
			Nome.MinimumWidth = 8;
			Nome.Name = "Nome";
			Nome.ReadOnly = true;
			Nome.Width = 150;
			// 
			// Cognome
			// 
			Cognome.HeaderText = "Cognome";
			Cognome.MinimumWidth = 8;
			Cognome.Name = "Cognome";
			Cognome.ReadOnly = true;
			Cognome.Width = 150;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button1.Location = new Point(730, 9);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 1;
			button1.Text = "Cerca";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaCerca;
			// 
			// barraRicerca
			// 
			barraRicerca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			barraRicerca.Location = new Point(12, 12);
			barraRicerca.Name = "barraRicerca";
			barraRicerca.Size = new Size(712, 31);
			barraRicerca.TabIndex = 2;
			// 
			// SchermataElencoStudentiBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(858, 359);
			Controls.Add(barraRicerca);
			Controls.Add(button1);
			Controls.Add(elencoStudenti);
			Name = "SchermataElencoStudentiBoundary";
			Text = "Elenco Studenti";
			Load += SchermataElencoStudentiBoundary_Load;
			((System.ComponentModel.ISupportInitialize)elencoStudenti).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView elencoStudenti;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn Nickname;
		private DataGridViewTextBoxColumn Nome;
		private DataGridViewTextBoxColumn Cognome;
		private Button button1;
		private TextBox barraRicerca;
	}
}