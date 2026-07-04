using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtFolio.VisualizzaContenutoMultimediale.Interface;


namespace ArtFolio.VisionaPagina.Interface;
public partial class PostBoundary : UserControl
{
	public PostBoundary()
	{
		InitializeComponent();
	}

	private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
	{

	}

	private int postID = -1;
	public void setPostId(int postID) { this.postID = postID; }
	public int getPostId() { return this.postID; }
	public void setDescrizione(string descrizione) { label1.Text = descrizione; }

	public void addMateriale(MiniaturaContenutoMultimedialeBoundary mcmb)
	{
		this.materialiPost.Controls.Add(mcmb);
	}

	private void label1_Click(object sender, EventArgs e)
	{

	}

	private void materialiPost_Paint(object sender, PaintEventArgs e)
	{

	}
}
