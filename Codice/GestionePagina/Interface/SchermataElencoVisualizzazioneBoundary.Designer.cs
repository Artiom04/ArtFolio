namespace ArtFolio.GestionePagina.Interface
{
	partial class SchermataElencoVisualizzazioneBoundary
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
			elencoVisualizzazione = new DataGridView();
			link = new DataGridViewTextBoxColumn();
			Nickname = new DataGridViewTextBoxColumn();
			DataScadenza = new DataGridViewTextBoxColumn();
			button1 = new Button();
			button2 = new Button();
			((System.ComponentModel.ISupportInitialize)elencoVisualizzazione).BeginInit();
			SuspendLayout();
			// 
			// elencoVisualizzazione
			// 
			elencoVisualizzazione.AllowUserToAddRows = false;
			elencoVisualizzazione.AllowUserToDeleteRows = false;
			elencoVisualizzazione.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			elencoVisualizzazione.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			elencoVisualizzazione.Columns.AddRange(new DataGridViewColumn[] { link, Nickname, DataScadenza });
			elencoVisualizzazione.Location = new Point(12, 12);
			elencoVisualizzazione.Name = "elencoVisualizzazione";
			elencoVisualizzazione.ReadOnly = true;
			elencoVisualizzazione.RowHeadersWidth = 62;
			elencoVisualizzazione.Size = new Size(747, 403);
			elencoVisualizzazione.TabIndex = 0;
			// 
			// link
			// 
			link.HeaderText = "link";
			link.MinimumWidth = 8;
			link.Name = "link";
			link.ReadOnly = true;
			link.Width = 150;
			// 
			// Nickname
			// 
			Nickname.HeaderText = "Nickname";
			Nickname.MinimumWidth = 8;
			Nickname.Name = "Nickname";
			Nickname.ReadOnly = true;
			Nickname.Width = 150;
			// 
			// DataScadenza
			// 
			DataScadenza.HeaderText = "DataScadenza";
			DataScadenza.MinimumWidth = 8;
			DataScadenza.Name = "DataScadenza";
			DataScadenza.ReadOnly = true;
			DataScadenza.Width = 150;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button1.Location = new Point(12, 421);
			button1.Name = "button1";
			button1.Size = new Size(145, 50);
			button1.TabIndex = 1;
			button1.Text = "Indietro";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button2.Location = new Point(598, 421);
			button2.Name = "button2";
			button2.Size = new Size(161, 50);
			button2.TabIndex = 2;
			button2.Text = "Fatto";
			button2.UseVisualStyleBackColor = true;
			button2.Click += cliccaFatto;
			// 
			// SchermataElencoVisualizzazioneBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(777, 480);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(elencoVisualizzazione);
			Name = "SchermataElencoVisualizzazioneBoundary";
			Text = "Elenco Visualizzazione";
			Load += SchermataElencoVisualizzazioneBoundary_Load;
			((System.ComponentModel.ISupportInitialize)elencoVisualizzazione).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView elencoVisualizzazione;
		private Button button1;
		private DataGridViewTextBoxColumn link;
		private DataGridViewTextBoxColumn Nickname;
		private DataGridViewTextBoxColumn DataScadenza;
		private Button button2;
	}
}