namespace ArtFolio.GestioneMateriale.Interface
{
	partial class SchermataGestioneMaterialeBoundary
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
			filterLowerDate = new DateTimePicker();
			filterUpperDate = new DateTimePicker();
			filterType = new ComboBox();
			filterName = new TextBox();
			elencoMateriali = new DataGridView();
			ID = new DataGridViewTextBoxColumn();
			Nome = new DataGridViewTextBoxColumn();
			DataCaricamento = new DataGridViewTextBoxColumn();
			caricaMaterialeBtn = new Button();
			eliminaMaterialeBtn = new Button();
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			scaricaMaterialeBtn = new Button();
			selezionaMaterialeBtn = new Button();
			indietroBtn = new Button();
			((System.ComponentModel.ISupportInitialize)elencoMateriali).BeginInit();
			SuspendLayout();
			// 
			// filterLowerDate
			// 
			filterLowerDate.Location = new Point(12, 12);
			filterLowerDate.Name = "filterLowerDate";
			filterLowerDate.Size = new Size(300, 31);
			filterLowerDate.TabIndex = 0;
			filterLowerDate.DataContextChanged += filterLowerDate_DataContextChanged;
			// 
			// filterUpperDate
			// 
			filterUpperDate.Location = new Point(318, 12);
			filterUpperDate.Name = "filterUpperDate";
			filterUpperDate.Size = new Size(300, 31);
			filterUpperDate.TabIndex = 1;
			filterUpperDate.DataContextChanged += filterUpperDate_DataContextChanged;
			// 
			// filterType
			// 
			filterType.FormattingEnabled = true;
			filterType.Items.AddRange(new object[] { ".jpg", ".jpeg", ".svg", ".webp", ".mp4", ".avi", ".mp3", ".aac", ".wav", ".mid", ".pdf" });
			filterType.Location = new Point(745, 12);
			filterType.Name = "filterType";
			filterType.Size = new Size(190, 33);
			filterType.TabIndex = 2;
			// 
			// filterName
			// 
			filterName.Location = new Point(12, 49);
			filterName.Name = "filterName";
			filterName.Size = new Size(517, 31);
			filterName.TabIndex = 3;
			// 
			// elencoMateriali
			// 
			elencoMateriali.AllowUserToAddRows = false;
			elencoMateriali.AllowUserToDeleteRows = false;
			elencoMateriali.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			elencoMateriali.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			elencoMateriali.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, DataCaricamento });
			elencoMateriali.Location = new Point(12, 87);
			elencoMateriali.Name = "elencoMateriali";
			elencoMateriali.ReadOnly = true;
			elencoMateriali.RowHeadersWidth = 62;
			elencoMateriali.Size = new Size(1137, 434);
			elencoMateriali.TabIndex = 4;
			elencoMateriali.CellContentClick += elencoMateriali_CellContentClick;
			// 
			// ID
			// 
			ID.HeaderText = "ID";
			ID.MinimumWidth = 8;
			ID.Name = "ID";
			ID.ReadOnly = true;
			ID.Width = 150;
			// 
			// Nome
			// 
			Nome.HeaderText = "Nome";
			Nome.MinimumWidth = 8;
			Nome.Name = "Nome";
			Nome.ReadOnly = true;
			Nome.Width = 150;
			// 
			// DataCaricamento
			// 
			DataCaricamento.HeaderText = "DataCaricamento";
			DataCaricamento.MinimumWidth = 8;
			DataCaricamento.Name = "DataCaricamento";
			DataCaricamento.ReadOnly = true;
			DataCaricamento.Width = 150;
			// 
			// caricaMaterialeBtn
			// 
			caricaMaterialeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			caricaMaterialeBtn.Location = new Point(192, 524);
			caricaMaterialeBtn.Name = "caricaMaterialeBtn";
			caricaMaterialeBtn.Size = new Size(174, 55);
			caricaMaterialeBtn.TabIndex = 5;
			caricaMaterialeBtn.Text = "Carica Materiale";
			caricaMaterialeBtn.UseVisualStyleBackColor = true;
			caricaMaterialeBtn.Click += cliccaCarica;
			// 
			// eliminaMaterialeBtn
			// 
			eliminaMaterialeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			eliminaMaterialeBtn.Location = new Point(372, 524);
			eliminaMaterialeBtn.Name = "eliminaMaterialeBtn";
			eliminaMaterialeBtn.Size = new Size(162, 55);
			eliminaMaterialeBtn.TabIndex = 6;
			eliminaMaterialeBtn.Text = "Elimina Materiale";
			eliminaMaterialeBtn.UseVisualStyleBackColor = true;
			eliminaMaterialeBtn.Click += cliccaElimina;
			// 
			// button3
			// 
			button3.Location = new Point(627, 12);
			button3.Name = "button3";
			button3.Size = new Size(112, 34);
			button3.TabIndex = 7;
			button3.Text = "filtraData";
			button3.UseVisualStyleBackColor = true;
			button3.Click += cliccaFiltraDate;
			// 
			// button4
			// 
			button4.Location = new Point(941, 11);
			button4.Name = "button4";
			button4.Size = new Size(178, 34);
			button4.TabIndex = 8;
			button4.Text = "Filtra Tipologia";
			button4.UseVisualStyleBackColor = true;
			button4.Click += cliccaFitraTipologia;
			// 
			// button5
			// 
			button5.Location = new Point(535, 47);
			button5.Name = "button5";
			button5.Size = new Size(155, 34);
			button5.TabIndex = 9;
			button5.Text = "Filtra Nome";
			button5.UseVisualStyleBackColor = true;
			button5.Click += cliccaFitraNome;
			// 
			// scaricaMaterialeBtn
			// 
			scaricaMaterialeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			scaricaMaterialeBtn.Location = new Point(540, 524);
			scaricaMaterialeBtn.Name = "scaricaMaterialeBtn";
			scaricaMaterialeBtn.Size = new Size(166, 55);
			scaricaMaterialeBtn.TabIndex = 10;
			scaricaMaterialeBtn.Text = "Scarica materiale";
			scaricaMaterialeBtn.UseVisualStyleBackColor = true;
			scaricaMaterialeBtn.Click += cliccaScarica;
			// 
			// selezionaMaterialeBtn
			// 
			selezionaMaterialeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			selezionaMaterialeBtn.Location = new Point(971, 525);
			selezionaMaterialeBtn.Name = "selezionaMaterialeBtn";
			selezionaMaterialeBtn.Size = new Size(172, 54);
			selezionaMaterialeBtn.TabIndex = 11;
			selezionaMaterialeBtn.Text = "Fatto";
			selezionaMaterialeBtn.UseVisualStyleBackColor = true;
			selezionaMaterialeBtn.Visible = false;
			selezionaMaterialeBtn.Click += cliccaFatto;
			// 
			// indietroBtn
			// 
			indietroBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			indietroBtn.Location = new Point(12, 524);
			indietroBtn.Name = "indietroBtn";
			indietroBtn.Size = new Size(174, 55);
			indietroBtn.TabIndex = 12;
			indietroBtn.Text = "Indietro";
			indietroBtn.UseVisualStyleBackColor = true;
			indietroBtn.Click += button1_Click;
			// 
			// SchermataGestioneMaterialeBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1153, 593);
			Controls.Add(indietroBtn);
			Controls.Add(selezionaMaterialeBtn);
			Controls.Add(scaricaMaterialeBtn);
			Controls.Add(button5);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(eliminaMaterialeBtn);
			Controls.Add(caricaMaterialeBtn);
			Controls.Add(elencoMateriali);
			Controls.Add(filterName);
			Controls.Add(filterType);
			Controls.Add(filterUpperDate);
			Controls.Add(filterLowerDate);
			Name = "SchermataGestioneMaterialeBoundary";
			Text = "Gestione Materiale";
			Load += SchermataGestioneMaterialeBoundary_Load;
			((System.ComponentModel.ISupportInitialize)elencoMateriali).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DateTimePicker filterLowerDate;
		private DateTimePicker filterUpperDate;
		private ComboBox filterType;
		private TextBox filterName;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn Nome;
		private DataGridViewTextBoxColumn DataCaricamento;
		private Button button3;
		private Button button4;
		private Button button5;
		protected DataGridView elencoMateriali;
		protected Button caricaMaterialeBtn;
		protected Button eliminaMaterialeBtn;
		protected Button scaricaMaterialeBtn;
		protected Button selezionaMaterialeBtn;
		private Button indietroBtn;
	}
}