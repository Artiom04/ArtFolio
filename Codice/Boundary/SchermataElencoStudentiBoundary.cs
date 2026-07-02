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

public partial class SchermataElencoStudentiBoundary : Form
{
	public static SchermataElencoStudentiBoundary? instance;

	public SchermataElencoStudentiBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	public static SchermataElencoStudentiBoundary get()
	{
		return instance ?? new SchermataElencoStudentiBoundary();
	}

	private void cliccaCerca(object sender, EventArgs e)
	{
		AccessoPaginaControl.get().cliccaCerca();
	}

	private void SchermataElencoStudentiBoundary_Load(object sender, EventArgs e)
	{

	}

	public void aggiornaElenco(IEnumerable<string> elencoStudenti)
	{
		this.elencoStudenti.Rows.Clear();

		foreach (string s in elencoStudenti)
		{
			this.elencoStudenti.Rows.Add(s.Split('|'));
		}
	}

	public void mostra() { Show(); }

	public string getTesto()
	{
		return barraRicerca.Text;
	}

	public int getStudenteSelezionatoID()
	{
		return Convert.ToInt32(elencoStudenti.SelectedRows[0].Cells[0].Value);
	}

	private void elencoStudenti_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		AccessoPaginaControl.get().cliccaStudente();
	}
}

