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
public partial class SchermataModificaBiografiaBoundary : Form
{
	string? biografia = null;
	public SchermataModificaBiografiaBoundary()
	{
		InitializeComponent();
	}

	private void cliccaModifica(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Close();
	}

	private void SchermataModificaBiografiaBoundary_Load(object sender, EventArgs e)
	{

	}

	public void setBiografia(string biografia)
	{
		biografiaTextBox.Text = biografia;
	}

	public string? getBiografia()
	{
		return biografia;
	}

	public void mostra() {
		if (Visible) return;
		biografia = ShowDialog() == DialogResult.OK ? biografiaTextBox.Text : null;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}
}
