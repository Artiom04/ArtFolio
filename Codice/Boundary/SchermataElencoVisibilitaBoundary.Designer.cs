namespace ArtFolio
{
	partial class SchermataElencoVisibilitaBoundary
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
			elencoVisibilita = new DataGridView();
			link = new DataGridViewTextBoxColumn();
			Nickname = new DataGridViewTextBoxColumn();
			DataScadenza = new DataGridViewTextBoxColumn();
			button3 = new Button();
			button4 = new Button();
			((System.ComponentModel.ISupportInitialize)elencoVisibilita).BeginInit();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button1.Location = new Point(12, 563);
			button1.Name = "button1";
			button1.Size = new Size(183, 58);
			button1.TabIndex = 0;
			button1.Text = "Genera Link";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaGeneraLink;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button2.Location = new Point(201, 563);
			button2.Name = "button2";
			button2.Size = new Size(181, 58);
			button2.TabIndex = 1;
			button2.Text = "Elimina Link";
			button2.UseVisualStyleBackColor = true;
			button2.Click += cliccaEliminaLink;
			// 
			// elencoVisibilita
			// 
			elencoVisibilita.AllowUserToAddRows = false;
			elencoVisibilita.AllowUserToDeleteRows = false;
			elencoVisibilita.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			elencoVisibilita.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			elencoVisibilita.Columns.AddRange(new DataGridViewColumn[] { link, Nickname, DataScadenza });
			elencoVisibilita.Location = new Point(12, 12);
			elencoVisibilita.Name = "elencoVisibilita";
			elencoVisibilita.ReadOnly = true;
			elencoVisibilita.RowHeadersWidth = 62;
			elencoVisibilita.Size = new Size(781, 545);
			elencoVisibilita.TabIndex = 2;
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
			// button3
			// 
			button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button3.Location = new Point(388, 563);
			button3.Name = "button3";
			button3.Size = new Size(181, 58);
			button3.TabIndex = 3;
			button3.Text = "Copia Link";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button4
			// 
			button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button4.Location = new Point(575, 563);
			button4.Name = "button4";
			button4.Size = new Size(181, 58);
			button4.TabIndex = 4;
			button4.Text = "Indietro";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// SchermataElencoVisibilitaBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(809, 627);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(elencoVisibilita);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "SchermataElencoVisibilitaBoundary";
			Text = "Elenco Visibilità";
			Load += SchermataElencoVisibilitaBoundary_Load;
			((System.ComponentModel.ISupportInitialize)elencoVisibilita).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private Button button2;
		private DataGridView elencoVisibilita;
		private DataGridViewTextBoxColumn link;
		private DataGridViewTextBoxColumn Nickname;
		private DataGridViewTextBoxColumn DataScadenza;
		private Button button3;
		private Button button4;
	}
}