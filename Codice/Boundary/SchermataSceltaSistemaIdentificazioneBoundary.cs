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
public partial class SchermataSceltaSistemaIdentificazioneBoundary : Form
{
	string? tipoSistemaIdentificazione = null;

	public SchermataSceltaSistemaIdentificazioneBoundary()
	{
		InitializeComponent();
		listBox1.SetSelected(0, true);
	}

	private void cliccaIdentifica(object sender, EventArgs e)
	{
		tipoSistemaIdentificazione = listBox1.GetItemText(listBox1.SelectedItem);
		Close();
	}

	public string? getTipoSistemaIdentificazione()
	{
		return tipoSistemaIdentificazione;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	public void mostra() { ShowDialog(); }

	private void SchermataSceltaSistemaIdentificazioneBoundary_Load(object sender, EventArgs e)
	{

	}
}
