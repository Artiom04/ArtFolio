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

public partial class SchermataElencoVisualizzazioneBoundary : Form
{
	public SchermataElencoVisualizzazioneBoundary()
	{
		InitializeComponent();
	}

	private void SchermataElencoVisualizzazioneBoundary_Load(object sender, EventArgs e)
	{

	}

	public void mostra() { ShowDialog(); }

	public void addItem(string link, string nickname, DateTime dataScadenza)
	{
		elencoVisualizzazione.Rows.Add(new object[] { link, nickname, dataScadenza });
	}

	private void cliccaFatto(object sender, EventArgs e)
	{
		this.Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		this.Close();
	}
}
