using ArtFolio.CommonDBMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtFolio.Utils;
using ArtFolio.VisionaPagina.Interface;

namespace ArtFolio.VisionaPagina.Control;
internal class PaginaControl
{
	public PaginaControl() {
		instance = this;
	}

	private static PaginaControl instance;

	public static PaginaControl get() { return instance ?? new(); }

	public void cliccaElimina(int postID)
	{
		var msg = new MessageBoundary();
		msg.mostra("Sei sicuro di voler eliminare il post?");
		var b = DBMSBoundary.get();
		b.eliminaPost(postID);
		var p = PaginaBoundary.get();
		p.eliminaPostCorrente();
		p.mostra();
	}

	private int postDaSpostare;
	public void cliccaSposta(int postID)
	{
		postDaSpostare = postID;
		PaginaBoundary.get().abilitaRegioniIntraPost();
	}

	public void cliccaRegione(int newPosition)
	{
		var a = PaginaBoundary.get();
		PaginaBoundary.get().disabilitaRegioniIntraPost();
		DBMSBoundary.get().newPositionPost(postDaSpostare, newPosition);
		a.spostaPostCorrente(newPosition);
		
	}
}

