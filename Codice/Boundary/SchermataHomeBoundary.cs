using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtFolio;
public partial class SchermataHomeBoundary : Form
{
	public SchermataHomeBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	private static SchermataHomeBoundary instance;

	public static SchermataHomeBoundary get() { return instance ?? new(); }

	private void SchermataHomeBoundary_Load(object sender, EventArgs e)
	{

	}

	public string getBiografia() { return biografiaLabel.Text; }

	public void setBiografia(string biografia)
	{
		biografiaLabel.Text = biografia;
	}

	private void cliccaGestioneMateriale(object sender, EventArgs e)
	{
		new GestioneMaterialeControl();
	}

	private void cliccaGestionePagine(object sender, EventArgs e)
	{
		new GestionePaginaControl();
	}

	public void mostra() {
		if (Visible) return;

		ShowDialog();
	}


	private void cliccaModificaBiografia(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaModificaBiografia();
	}

	private void cliccaLogout(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaLogout();
		Close();
	}

	private void cliccaModificaPassword(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaModificaPassword();
	}

	private void cliccaModificaFotoProfilo(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaModificaFotoProfilo();
	}

	public void setFotoProfiloDaFile(string foto)
	{
		setFotoProfilo(File.ReadAllBytes(foto));
	}

	public void setFotoProfilo(byte[]? foto)
	{
		if (foto == null)
			setFotoProfiloDefault();
		else
			miniaturaContenutoMultimedialeBoundary1.setImage(foto);
	}

	public void setFotoProfiloDefault()
	{
		miniaturaContenutoMultimedialeBoundary1.setDefaultProfileImage();
	}

	private void cliccaEliminaAccount(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaEliminaAccount();
	}

	private void miniaturaContenutoMultimedialeBoundary1_Load(object sender, EventArgs e)
	{

	}
}
