using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFolio.GestioneMateriale.Interface;

internal class SchermataSelezioneMaterialeBoundary : SchermataGestioneMaterialeBoundary
{
	public SchermataSelezioneMaterialeBoundary()
	{
		eliminaMaterialeBtn.Hide();
		caricaMaterialeBtn.Hide();
		scaricaMaterialeBtn.Hide();
		Text = "Seleziona i materiali da inserire nel post";
		selezionaMaterialeBtn.Visible = true;
		selezionaMaterialeBtn.Click += SelezionaMaterialeBtn_Click;
	}

	private void SelezionaMaterialeBtn_Click(object? sender, EventArgs e)
	{
		Close();
	}

	

}
