namespace ArtFolio.VisionaPagina.Interface
{
	partial class PostBoundary
	{
		/// <summary> 
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Pulire le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione componenti

		/// <summary> 
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			tableLayoutPanel1 = new TableLayoutPanel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			eliminaBtn = new Button();
			riordinaBtn = new Button();
			label1 = new Label();
			materialiPost = new FlowLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.BackColor = Color.White;
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
			tableLayoutPanel1.Controls.Add(label1, 0, 1);
			tableLayoutPanel1.Controls.Add(materialiPost, 0, 2);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(445, 448);
			tableLayoutPanel1.TabIndex = 0;
			tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel1.Controls.Add(eliminaBtn);
			flowLayoutPanel1.Controls.Add(riordinaBtn);
			flowLayoutPanel1.Dock = DockStyle.Fill;
			flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
			flowLayoutPanel1.Location = new Point(3, 3);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(439, 40);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// eliminaBtn
			// 
			eliminaBtn.Location = new Point(324, 3);
			eliminaBtn.Name = "eliminaBtn";
			eliminaBtn.Size = new Size(112, 34);
			eliminaBtn.TabIndex = 0;
			eliminaBtn.Text = "Elimina";
			eliminaBtn.UseVisualStyleBackColor = true;
			// 
			// riordinaBtn
			// 
			riordinaBtn.Location = new Point(206, 3);
			riordinaBtn.Name = "riordinaBtn";
			riordinaBtn.Size = new Size(112, 34);
			riordinaBtn.TabIndex = 1;
			riordinaBtn.Text = "Riordina";
			riordinaBtn.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = DockStyle.Fill;
			label1.Location = new Point(3, 46);
			label1.Name = "label1";
			label1.Size = new Size(439, 25);
			label1.TabIndex = 1;
			label1.Text = "label1";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Click += label1_Click;
			// 
			// materialiPost
			// 
			materialiPost.AutoScroll = true;
			materialiPost.AutoSize = true;
			materialiPost.Dock = DockStyle.Fill;
			materialiPost.Location = new Point(3, 74);
			materialiPost.Name = "materialiPost";
			materialiPost.Size = new Size(439, 371);
			materialiPost.TabIndex = 2;
			materialiPost.WrapContents = false;
			materialiPost.Paint += materialiPost_Paint;
			// 
			// PostBoundary
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "PostBoundary";
			Size = new Size(445, 448);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel1;
		private Button button2;
		private Label label1;
		private FlowLayoutPanel materialiPost;
		public Button eliminaBtn;
		public Button riordinaBtn;
	}
}
