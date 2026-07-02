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
	public partial class SchermataCreazionePostBoundary : Form
	{
		public SchermataCreazionePostBoundary()
		{
			instance = this;
			InitializeComponent();
		}

		private static SchermataCreazionePostBoundary instance;

		public static SchermataCreazionePostBoundary get()
		{
			return instance ?? new();
		}

		public void mostra() { ShowDialog(); }

		public string getDescrizione() { return textBox1.Text; }

		private void SchermataCreazionePostBoundary_Load(object sender, EventArgs e)
		{

		}

		private void cliccaCaricaMateriale(object sender, EventArgs e)
		{
			GestionePaginaControl.get().cliccaCaricaMaterialePost();
		}

		private void cliccaPubblica(object sender, EventArgs e)
		{
			GestionePaginaControl.get().cliccaPubblica();
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
