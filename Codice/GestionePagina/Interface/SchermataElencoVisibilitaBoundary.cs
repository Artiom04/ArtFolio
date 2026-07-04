using ArtFolio.GestionePagina.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtFolio.GestionePagina.Interface;
public partial class SchermataElencoVisibilitaBoundary : Form
{
	public SchermataElencoVisibilitaBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	public void mostra()
	{
		if (Visible) return;
		ShowDialog();
	}

	private static SchermataElencoVisibilitaBoundary instance;

	public static SchermataElencoVisibilitaBoundary get()
	{
		return instance ?? new();
	}

	private void cliccaGeneraLink(object sender, EventArgs e)
	{
		GestionePaginaControl.get().cliccaGeneraLink();
	}

	private void cliccaEliminaLink(object sender, EventArgs e)
	{
		GestionePaginaControl.get().cliccaEliminaLink();
	}

	private void SchermataElencoVisibilitaBoundary_Load(object sender, EventArgs e)
	{

	}

	public void addItem(string link, string nickname, DateTime dataScadenza)
	{
		elencoVisibilita.Rows.Add(new object[] { link, nickname, dataScadenza });
	}

	public string getLinkSelezionato()
	{
		return Convert.ToString(elencoVisibilita.SelectedRows[0].Cells[0].Value);
	}

	public void rimuoviLinkDaElenco(string link)
	{
		for (int i = 0; i < elencoVisibilita.Rows.Count; ++i)
		{
			if (Convert.ToString(elencoVisibilita.Rows[i].Cells[0].Value) == link)
			{
				elencoVisibilita.Rows.RemoveAt(i);
				return;
			}
		}
	}

	private int paginaID = -1;

	public void setPaginaID(int paginaID)
	{
		this.paginaID = paginaID;
	}

	public int getPaginaID()
	{
		return paginaID > 0 ? paginaID : SchermataGestionePaginaBoundary.get().getPaginaSelezionataID();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (elencoVisibilita.SelectedRows.Count != 1) return;

		Clipboard.SetText(getLinkSelezionato());
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}
}
