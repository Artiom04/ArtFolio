using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtFolio.VisualizzaContenutoMultimediale.Control;

namespace ArtFolio.VisualizzaContenutoMultimediale.Interface;
public partial class MiniaturaContenutoMultimedialeBoundary : UserControl
{
	public MiniaturaContenutoMultimedialeBoundary()
	{
		InitializeComponent();
	}

	private void cliccaMiniatura(object sender, EventArgs e)
	{
		new VisualizzaContenutoMultimedialeControl(this);
	}

	private int materialeID=-1;
	private string nomeMateriale = "";

	public string getNomeMateriale() { return nomeMateriale; }

	public void setNomeMateriale(string nomeMateriale)
	{
		this.nomeMateriale = nomeMateriale;
	}

	public int? getMaterialeID() {
		return materialeID > 0 ? materialeID: null ;
	}

	public void setMaterialeID(int materialeID)
	{
		this.materialeID = materialeID;
	}

	public void setImage(byte[] image) {
		if (image == null) return;
		pictureBox1.BackgroundImage = Image.FromStream(new MemoryStream(image));
	}

	public void setPdfImage() {
		pictureBox1.BackgroundImage = ArtFolio.Properties.Resources.Immagine1;
	}

	public void setDefaultProfileImage() {
		pictureBox1.BackgroundImage = ArtFolio.Properties.Resources.images;
	}

	public void setAudioImage() {
		pictureBox1.BackgroundImage = ArtFolio.Properties.Resources.Immagine2;
	}

	public void setVideoImage() {
		pictureBox1.BackgroundImage = ArtFolio.Properties.Resources.Immagine3;
	}
}
