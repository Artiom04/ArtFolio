using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFolio;

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
	//Form activeForm = Application.OpenForms
	//.Cast<Form>()
	//.LastOrDefault(f => f.Visible);

	public void richiesta(string link)
	{	//TODO guarda sequence
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
