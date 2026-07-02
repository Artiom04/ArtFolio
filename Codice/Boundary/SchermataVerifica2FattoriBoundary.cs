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
public partial class SchermataVerifica2FattoriBoundary : Form
{
	public SchermataVerifica2FattoriBoundary()
	{
		InitializeComponent();
	}

	private void cliccaVerifica(object sender, EventArgs e)
	{
		Close();
	}

	public void mostra() { ShowDialog(); }

	public string getCodice() { return textBox1.Text; }

	private void SchermataVerifica2FattoriBoundary_Load(object sender, EventArgs e)
	{

	}
}
