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
public partial class SchermataGenerazioneLinkBoundary : Form
{
	private bool indietro = false;
	public SchermataGenerazioneLinkBoundary()
	{
		InitializeComponent();
	}

	public void mostra() { ShowDialog(); }

	private void cliccaConferma(object sender, EventArgs e)
	{
		indietro = false;
		Close();
	}

	public string? getNickname()
	{
		return !indietro ? textBox1.Text : null;
	}

	public DateTime? getDataScadenza()
	{
		return !indietro ? dateTimePicker1.Value : null;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		indietro = true;
		Close();
	}

	private void SchermataGenerazioneLinkBoundary_Load(object sender, EventArgs e)
	{

	}
}
