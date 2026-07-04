using ArtFolio.CommonDBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtFolio.VisualizzaContenutoMultimediale.Interface;

namespace ArtFolio.VisualizzaContenutoMultimediale.Control;

internal class VisualizzaContenutoMultimedialeControl
{
	public VisualizzaContenutoMultimedialeControl(MiniaturaContenutoMultimedialeBoundary cm) {
		int? materialeID = cm.getMaterialeID();
		string nomeMateriale = cm.getNomeMateriale();

		if(materialeID != null)
		{
			byte[] materiale = DBMSBoundary.get().getMateriale(materialeID.Value);

			var scmb = new SchermataContenutoMultimedialeBoundary();

			scmb.setContent(nomeMateriale, materiale);
			scmb.mostra();
			mostraSchermataPrecedente();
		}
	}

	private void mostraSchermataPrecedente()
	{

	}

}
