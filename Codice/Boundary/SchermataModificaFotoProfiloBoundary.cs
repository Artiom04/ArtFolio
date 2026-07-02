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
public partial class SchermataModificaFotoProfiloBoundary : Form
{
	public SchermataModificaFotoProfiloBoundary()
	{
		InitializeComponent();
	}

	public void mostra() { Show(); }

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void cliccaCarica(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaCaricaFotoProfilo();
		Close();
	}

	private void cliccaRimuovi(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaRimuoviFotoProfilo();
		Close();
	}

	private void SchermataModificaFotoProfiloBoundary_Load(object sender, EventArgs e)
	{

	}
}
