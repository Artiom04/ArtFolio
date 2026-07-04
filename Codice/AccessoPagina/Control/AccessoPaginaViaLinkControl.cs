using ArtFolio.CommonDBMS;
using ArtFolio.GestionePagina.Control;
using ArtFolio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtFolio.VisionaPagina.Interface;
using ArtFolio.GestioneAccount.Interface;

namespace ArtFolio.AccessoPagina.Control;

internal class AccessoPaginaViaLinkControl
{
	public static bool verificaValiditaLink(string link)
	{
		return GestionePaginaControl.verificaLink(link);
	}

	public static int getPageIDFromLink(string link)
	{
		return (int)GestionePaginaControl.getLinkData(link)["paginaID"];
	}

	public AccessoPaginaViaLinkControl() { }

	public void richiesta(string link)
	{
		bool linkValido = verificaValiditaLink(link);
        var b = DBMSBoundary.get();

        if (linkValido) {

			int pageID = getPageIDFromLink(link);
			var esisteLink = b.esisteLinkElencoVisibilita(pageID, link);

			if (esisteLink) {
				b.aggiungiLinkAdElencoVisualizzazionePagina(pageID, link);
				var content = b.getPageContent(pageID);
				var pb = new PaginaBoundary();
				pb.setContent(content);
				pb.mostra();
			}
			else
			{
				var msg = new MessageBoundary();
				msg.mostra("Link non valido");
				SchermataInizialeBoundary.get().mostra();
			}
		} else
		{
			var msg = new MessageBoundary();
            msg.mostra("Link non valido");
            SchermataInizialeBoundary.get().mostra();
        }
	}


}
