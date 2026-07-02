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

public partial class SchermataModificaPasswordBoundary : Form
{
	public SchermataModificaPasswordBoundary()
	{
		InitializeComponent();
	}

	private void SchermataModificaPasswordBoundary_Load(object sender, EventArgs e)
	{

	}

	private string[]? passwords; //TODO

	public void mostra()
	{
		if (Visible) return;

		passwords = ShowDialog() == DialogResult.OK ? new string[] { vecchiaPassword.Text, nuovaPassword.Text } : null;
	}

	public string[]? getPasswords() { return passwords; }

	private void cliccaModifica(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}
}
