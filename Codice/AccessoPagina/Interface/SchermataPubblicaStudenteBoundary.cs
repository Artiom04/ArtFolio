using ArtFolio.AccessoPagina.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtFolio.AccessoPagina.Interface;

public partial class SchermataPubblicaStudenteBoundary : Form
{
	public SchermataPubblicaStudenteBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	public void setDatiStudente(Dictionary<string, object> datiStudente)
	{
		this.nome.Text = (string)datiStudente["nome"];
		this.cognome.Text = (string)datiStudente["cognome"];
		this.nickname.Text = (string)datiStudente["nickname"];
		this.biografia.Text = (string)datiStudente["biografia"];
		byte[] img_bytes = (byte[])datiStudente["foto_profilo"];

		if(img_bytes != null)
		{
			miniaturaContenutoMultimedialeBoundary1.setImage(img_bytes);
		}
		else
		{
			miniaturaContenutoMultimedialeBoundary1.setDefaultProfileImage();
		}

			elencoPaginePubbliche.Rows.Clear();
		foreach (string s in (IEnumerable<string>)datiStudente["pagine_pubbliche"])
		{
			elencoPaginePubbliche.Rows.Add(s.Split('|'));
		}
	}

	public void setElencoPagine(IEnumerable<string> elencoPagine)
	{
		this.elencoPaginePubbliche.Rows.Clear();
		foreach (var pagina in elencoPagine)
		{
			var row = pagina.Split("|");

			if(bool.Parse(row[2])) this.elencoPaginePubbliche.Rows.Add(row);
		}
	}

	public int getPaginaID()
	{
		return Convert.ToInt32(this.elencoPaginePubbliche.SelectedRows[0].Cells[0].Value);
	}

	private static SchermataPubblicaStudenteBoundary instance;

	public static SchermataPubblicaStudenteBoundary get() { return instance ?? new(); }

	public void mostra() { ShowDialog(); }

	private void SchermataPubblicaStudenteBoundary_Load(object sender, EventArgs e)
	{

	}

	private void cliccaPagina(object sender, DataGridViewCellMouseEventArgs e)
	{
		AccessoPaginaControl.get().cliccaPaginaPubblica();
	}
}
