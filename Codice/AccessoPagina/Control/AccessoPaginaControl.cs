using ArtFolio.CommonDBMS;
using ArtFolio.VisionaPagina.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtFolio.VisionaPagina.Interface;
using ArtFolio.AccessoPagina.Interface;

namespace ArtFolio.AccessoPagina.Control;

internal class AccessoPaginaControl
{
	public AccessoPaginaControl()
	{
		instance = this;

        var b = DBMSBoundary.get();
        var elencoStudenti = b.getCampioneElencoStudenti();

        var c = new SchermataElencoStudentiBoundary();
		c.aggiornaElenco(elencoStudenti);
		c.mostra();
    }

	private static AccessoPaginaControl? instance = null;

	public static AccessoPaginaControl get()
	{
		return instance ?? new AccessoPaginaControl();
	}

	public void cliccaCerca()
	{
		var c = SchermataElencoStudentiBoundary.get();
		var testo = c.getTesto();
		var b = DBMSBoundary.get();
		var elenco = b.getElencoStudenti(testo);
		c.aggiornaElenco(elenco);
	}

	public void cliccaStudente()
	{
		var c = SchermataElencoStudentiBoundary.get();
		var studenteID = c.getStudenteSelezionatoID();
		var b = DBMSBoundary.get();
		var datiStudente = b.getDatiStudente(studenteID);
		var elencoPagine = b.getElencoPagine(studenteID);

		var d = new SchermataPubblicaStudenteBoundary();
		d.setDatiStudente(datiStudente);
		d.setElencoPagine(elencoPagine);
		d.mostra();



	}

	public void cliccaPaginaPubblica()
	{
		int paginaID = SchermataPubblicaStudenteBoundary.get().getPaginaID();

		var pageContent = DBMSBoundary.get().getPageContent(paginaID);

		new PaginaControl();

		var pb = new PaginaBoundary();

		pb.setContent(pageContent);
		
		pb.mostra();
	}



}
