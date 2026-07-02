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
 
public partial class SchermataRegistrazioneBoundary : Form
{
	public SchermataRegistrazioneBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	private static SchermataRegistrazioneBoundary? instance;

	public static SchermataRegistrazioneBoundary get()
	{
		return instance ?? new();
	}

	private void label3_Click(object sender, EventArgs e)
	{

	}

	private void cliccaRegistrati(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaRegistrati();
	}

	public Dictionary<string, string> getCredenziali()
	{
		Dictionary<string, string> credenziali = new();
		credenziali.Add("email", textBox1.Text);
		credenziali.Add("nickname", textBox2.Text);
		credenziali.Add("password", maskedTextBox1.Text);
		return credenziali;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void SchermataRegistrazioneBoundary_Load(object sender, EventArgs e)
	{

	}

	public void mostra() { Show(); }
}
