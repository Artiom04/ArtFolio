namespace ArtFolio.GestionePagina.Interface
{
	partial class SchermataGestionePaginaBoundary
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
			elencoPagine = new DataGridView();
			ID = new DataGridViewTextBoxColumn();
			nome = new DataGridViewTextBoxColumn();
			pubblica = new DataGridViewTextBoxColumn();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			button6 = new Button();
			button7 = new Button();
			button8 = new Button();
			button9 = new Button();
			button10 = new Button();
			((System.ComponentModel.ISupportInitialize)elencoPagine).BeginInit();
			SuspendLayout();
			// 
			// elencoPagine
			// 
			elencoPagine.AllowUserToAddRows = false;
			elencoPagine.AllowUserToDeleteRows = false;
			elencoPagine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			elencoPagine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			elencoPagine.Columns.AddRange(new DataGridViewColumn[] { ID, nome, pubblica });
			elencoPagine.Location = new Point(12, 12);
			elencoPagine.MultiSelect = false;
			elencoPagine.Name = "elencoPagine";
			elencoPagine.ReadOnly = true;
			elencoPagine.RowHeadersWidth = 62;
			elencoPagine.Size = new Size(1631, 445);
			elencoPagine.TabIndex = 0;
			// 
			// ID
			// 
			ID.HeaderText = "ID";
			ID.MinimumWidth = 8;
			ID.Name = "ID";
			ID.ReadOnly = true;
			ID.Width = 150;
			// 
			// nome
			// 
			nome.HeaderText = "nome";
			nome.MinimumWidth = 8;
			nome.Name = "nome";
			nome.ReadOnly = true;
			nome.Width = 150;
			// 
			// pubblica
			// 
			pubblica.HeaderText = "pubblica";
			pubblica.MinimumWidth = 8;
			pubblica.Name = "pubblica";
			pubblica.ReadOnly = true;
			pubblica.Width = 150;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button1.Location = new Point(12, 463);
			button1.Name = "button1";
			button1.Size = new Size(151, 79);
			button1.TabIndex = 1;
			button1.Text = "Crea Pagina";
			button1.UseVisualStyleBackColor = true;
			button1.Click += cliccaCreaPagina;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button2.Location = new Point(169, 463);
			button2.Name = "button2";
			button2.Size = new Size(188, 79);
			button2.TabIndex = 2;
			button2.Text = "Rinomina Pagina";
			button2.UseVisualStyleBackColor = true;
			button2.Click += cliccaRinomina;
			// 
			// button3
			// 
			button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button3.Location = new Point(363, 463);
			button3.Name = "button3";
			button3.Size = new Size(112, 79);
			button3.TabIndex = 3;
			button3.Text = "Elimina";
			button3.UseVisualStyleBackColor = true;
			button3.Click += cliccaElimina;
			// 
			// button4
			// 
			button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button4.Location = new Point(481, 463);
			button4.Name = "button4";
			button4.Size = new Size(147, 79);
			button4.TabIndex = 4;
			button4.Text = "Clona Pagina";
			button4.UseVisualStyleBackColor = true;
			button4.Click += cliccaClona;
			// 
			// button5
			// 
			button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button5.Location = new Point(1435, 463);
			button5.Name = "button5";
			button5.Size = new Size(208, 78);
			button5.TabIndex = 5;
			button5.Text = "Mostra Visualizzatori";
			button5.UseVisualStyleBackColor = true;
			button5.Click += cliccaMostraVisualizzatori;
			// 
			// button6
			// 
			button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button6.Location = new Point(1243, 463);
			button6.Name = "button6";
			button6.Size = new Size(186, 78);
			button6.TabIndex = 6;
			button6.Text = "Mostra Visibilita";
			button6.UseVisualStyleBackColor = true;
			button6.Click += cliccaElencoVisibilità;
			// 
			// button7
			// 
			button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button7.Location = new Point(1058, 463);
			button7.Name = "button7";
			button7.Size = new Size(179, 79);
			button7.TabIndex = 7;
			button7.Text = "Rendi Pubblica";
			button7.UseVisualStyleBackColor = true;
			button7.Click += cliccaRendiPubblica;
			// 
			// button8
			// 
			button8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button8.Location = new Point(882, 463);
			button8.Name = "button8";
			button8.Size = new Size(170, 79);
			button8.TabIndex = 8;
			button8.Text = "Rendi Privata";
			button8.UseVisualStyleBackColor = true;
			button8.Click += cliccaRendiPrivata;
			// 
			// button9
			// 
			button9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button9.Location = new Point(744, 463);
			button9.Name = "button9";
			button9.Size = new Size(132, 79);
			button9.TabIndex = 9;
			button9.Text = "Crea Post";
			button9.UseVisualStyleBackColor = true;
			button9.Click += cliccacreaPost;
			// 
			// button10
			// 
			button10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button10.Location = new Point(634, 463);
			button10.Name = "button10";
			button10.Size = new Size(104, 79);
			button10.TabIndex = 10;
			button10.Text = "Visita";
			button10.UseVisualStyleBackColor = true;
			button10.Click += cliccaVisita;
			// 
			// SchermataGestionePaginaBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1659, 549);
			Controls.Add(button10);
			Controls.Add(button9);
			Controls.Add(button8);
			Controls.Add(button7);
			Controls.Add(button6);
			Controls.Add(button5);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(elencoPagine);
			Name = "SchermataGestionePaginaBoundary";
			Text = "Gestione Pagine";
			Load += SchermataGestionePaginaBoundary_Load;
			((System.ComponentModel.ISupportInitialize)elencoPagine).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView elencoPagine;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn nome;
		private DataGridViewTextBoxColumn pubblica;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button button6;
		private Button button7;
		private Button button8;
		private Button button9;
		private Button button10;
	}
}