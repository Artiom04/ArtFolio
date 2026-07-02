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
public partial class InputDialogBoundary : Form
{
	public InputDialogBoundary()
	{
		InitializeComponent();
	}

	private void InputDialogBoundary_Load(object sender, EventArgs e)
	{

	}

	private string testo = null;

	public void mostra(string text)
	{
		if (Visible) return;
		this.label1.Text = text;
		testo = ShowDialog() == DialogResult.OK ? textBox1.Text : null;
	}

	public string? getTesto() { return testo; }

	private void cliccaOK(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}
}
