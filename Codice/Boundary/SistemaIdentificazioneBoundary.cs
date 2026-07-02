using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtFolio
{
	public partial class SistemaIdentificazioneBoundary : Form
	{
		public SistemaIdentificazioneBoundary()
		{
			InitializeComponent();
		}

		private static SistemaIdentificazioneBoundary instance = new();

		public static SistemaIdentificazioneBoundary get()
		{
			return instance;
		}

		private void SistemaIdentificazioneBoundary_Load(object sender, EventArgs e)
		{

		}

		public bool identificaStudente(string tipologia)
		{
			return ShowDialog() == DialogResult.OK;
		}

		public Dictionary<string, object> getDatiIdentificazione()
		{
			Dictionary<string, object> result = new();

			result.Add("nome", nomeTextBox.Text);
			result.Add("cognome", cognomeTextBox.Text);
			result.Add("codice_fiscale", codiceFiscaleTextBox.Text);
			result.Add("data_di_nascita", dateTimePicker1.Value);

			return result;
		}

		//cliccaIdentifica
		private void cliccaIdentifica(object sender, EventArgs e)
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
}
