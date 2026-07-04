using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using ArtFolio.GestioneAccount.Entity;
using ArtFolio.CommonDBMS;
using ArtFolio.Utils;
using ArtFolio.VisionaPagina.Control;
using ArtFolio.GestioneMateriale.Interface;
using ArtFolio.VisionaPagina.Interface;
using ArtFolio.GestionePagina.Interface;

namespace ArtFolio.GestionePagina.Control;

internal class GestionePaginaControl
{

	public GestionePaginaControl()
	{
		instance = this;
        int studenteID = StudenteEntity.get().getID();
		var b = DBMSBoundary.get();

		var elencoPagine = b.getElencoPagine( studenteID );

		var c = new SchermataGestionePaginaBoundary();
		c.setElencoPagine(elencoPagine);
		c.mostra();

    }

	private static GestionePaginaControl? instance = null;

	public static GestionePaginaControl get()
	{
		return instance ?? new GestionePaginaControl();
		
	}

	public void cliccaRinomina()
	{
		var c = SchermataGestionePaginaBoundary.get();
		var paginaID = c.getPaginaSelezionataID();

		var nomePagina = c.getNomePaginaSelezionata();

		var dialog = new InputDialogBoundary();
		dialog.mostra("Inserisci nuovo nome per la pagina " + nomePagina);
		var nuovoNomePagina = dialog.getTesto();

		if (nuovoNomePagina == null)
		{
			return;
		}

		var verify = verificaCriteriFormattazione(nuovoNomePagina);
		var message = new MessageBoundary();
		if (verify)
		{
			var studenteID = StudenteEntity.get().getID();
            var b = DBMSBoundary.get();
            var esistePagina = b.esistePagina(nuovoNomePagina, studenteID);
			if (!esistePagina)
			{
				b.rinominaPagina(nomePagina, nuovoNomePagina, studenteID);
				message.mostra("Pagina rinominata correttamente");
				c.setNomePagina(nuovoNomePagina, nomePagina );
            }
			else
			{
				message.mostra("Esiste già una pagina con il nome inserito");
			}
		}
		else
		{
			message.mostra("Il nome inserito non rispetta i criteri di formattazione");
		}
		c.mostra();
    }

   public bool verificaCriteriFormattazione(string nuovoNomePagina)
	{
		if (nuovoNomePagina == "") return false;

		foreach(char c in " &%$#@^£*+?!()=^§[]{}:,;|")
			if (nuovoNomePagina.Contains(c)) return false;

		return true;
	}

	public void cliccaCreaPagina()
	{
		var c = SchermataGestionePaginaBoundary.get();
		var dialog = new InputDialogBoundary();
		dialog.mostra("Inserisci il nome della nuova pagina");
        var nomeNuovaPagina = dialog.getTesto();
        if (nomeNuovaPagina == null)
        {
            return;
        }
        var verify = verificaCriteriFormattazione(nomeNuovaPagina);
        var message = new MessageBoundary();
		if (verify)
		{
            var studenteID = StudenteEntity.get().getID();
            var b = DBMSBoundary.get();
            var esistePagina = b.esistePagina(nomeNuovaPagina, studenteID);
			if (!esistePagina)
			{
				var paginaID = b.creaPagina(nomeNuovaPagina, studenteID);
				message.mostra("Pagina creata correttamente");
				c.addPagina(nomeNuovaPagina, paginaID);
			}
			else
			{
				message.mostra("Esiste già una pagina con il nome inserito");

            }
        }
		else
		{
			message.mostra("Il nome inserito non rispetta i criteri di formattazione");
		}
		c.mostra();
    }

	public void cliccaElimina()
	{
        var c = SchermataGestionePaginaBoundary.get();
		var paginaID = c.getPaginaSelezionataID();
        var mesR = new MessageRequestBoundary();
		
		if (!mesR.mostra("Sei sicuro di voler eliminare la pagina? L'azione è irreversibile"))
		{
			return;
		}
        var b = DBMSBoundary.get();
        b.eliminaPagina(paginaID);
        var message = new MessageBoundary();
		message.mostra("Pagina eliminata con successo");
        c.rimuoviPaginaDaElenco(paginaID);
		c.mostra();
    }

	public void cliccaClona()
	{
        var c = SchermataGestionePaginaBoundary.get();
        var paginaID = c.getPaginaSelezionataID();
		var nomePaginadaClonare = c.getNomePaginaSelezionata();
		var nomiPagine = c.getElencoNomiPagine();
        var studenteID = StudenteEntity.get().getID();
		var generator = generaNomePagina(nomePaginadaClonare, nomiPagine);
        var b = DBMSBoundary.get();
        var newPageID =  b.creaPagina(generator, studenteID);
		b.copiaContenutiPagina(paginaID, newPageID);
        var message = new MessageBoundary();
		message.mostra("Pagina clonata con successo");
		c.addPagina(generator, newPageID);
		c.mostra();

    }

	public static string generaNomePagina(string nomePaginadaClonare, IEnumerable<string> nomiPagine)
	{
		for(int i = 0; ; ++i)
		{
			var nuovoNome = $"{nomePaginadaClonare}({i})";
			if (!nomiPagine.Contains(nuovoNome)) return nuovoNome;
		}
	}

	public static string generaLink(int paginaID, string nickname, DateTime dataScadenza, DateTime dataCorrente)
	{
		using Aes aes = Aes.Create();
		aes.Key = secret_key;
		aes.IV = new byte[16];

		using MemoryStream ms = new MemoryStream();
		using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
		using (StreamWriter sw = new StreamWriter(cs))
		{
			sw.WriteLine("paginaID"); sw.WriteLine(paginaID);
			sw.WriteLine("nickname"); sw.WriteLine(nickname);
			sw.WriteLine("data_scadenza"); sw.WriteLine(dataScadenza);
			sw.WriteLine("adesso"); sw.WriteLine(dataCorrente);
		}

		return "ids://sistema/" + Convert.ToBase64String(ms.ToArray());
	}

	public static Dictionary<string, object> getLinkData(string link)
	{

		link = link.Remove(0, "ids://sistema/".Length);

		using Aes aes = Aes.Create();
		aes.Key = secret_key;
		aes.IV = new byte[16];

		using MemoryStream ms = new MemoryStream(Convert.FromBase64String(link));

		try
		{
			using CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);

			using StreamReader sr = new StreamReader(cs);

			var lines = sr.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
			Dictionary<string, object> result = new();

			for (int i = 0; i < lines.Length ; i += 2)
			{
				string key = lines[i];
				string value = lines[i + 1];

				if(DateTime.TryParse(value, out DateTime valD))
				{
					result[key] = valD;
				}
				else if (int.TryParse(value, out int valI))
				{
					result[key] = valI;
				}
				else
				{
					result[key] = value;
				}
			}

			return result;
		}
		catch (Exception ex) {
			return null;
		}
		
	}

	public void cliccaMostraVisualizzatori()
	{
        var c = SchermataGestionePaginaBoundary.get();
        var paginaID = c.getPaginaSelezionataID();
		var d = new SchermataElencoVisualizzazioneBoundary();
        var link = DBMSBoundary.get().getLinkVisualizzazione(paginaID);

		foreach (var l in link) 
		{
			var a = verificaLink(l);
			if (a)
			{
				var data = getLinkData(l);
				d.addItem(l, (string)data["nickname"], (DateTime)data["data_scadenza"]);
            }
			else
			{
				var b = DBMSBoundary.get();
				b.eliminaLink(l);
            }

			DBMSBoundary.get().getLinkVisualizzazione(paginaID);
        }

		d.mostra();
		c.mostra();
    }

	private static byte[] secret_key = Encoding.UTF8.GetBytes("chiave_complicata_blaaaaaahuabduqwavbdcuaWVDUIEAVB")[..32];

	public static bool verificaLink(string link)
	{
		var ld = getLinkData(link);

		if (ld == null) return false;

		return (DateTime)ld["data_scadenza"] > DateTime.Now;
	}

    public void cliccaElencoVisibilità()
	{
        var c = SchermataGestionePaginaBoundary.get();
        var paginaID = c.getPaginaSelezionataID();
        var d = new SchermataElencoVisibilitaBoundary();
		var link = DBMSBoundary.get().getLinkVisibilita(paginaID);

		foreach (var l in link)
		{
            var a = verificaLink(l);
			if (a)
			{
				var data = getLinkData(l);
				d.addItem(l, (string)data["nickname"], (DateTime)data["data_scadenza"]);

            }
			else
			{
				var b = DBMSBoundary.get();
                b.eliminaLink(l);
            }

            DBMSBoundary.get().getLinkVisibilita(paginaID);
        }
		d.mostra();

    }

	public void cliccaRendiPubblica()
	{
        var c = SchermataGestionePaginaBoundary.get();
        var paginaID = c.getPaginaSelezionataID();
        var privata = DBMSBoundary.get().isPaginaPrivata(paginaID);
		if(privata)
		{
            DBMSBoundary.get().rendiPaginaPubblica(paginaID);
            c.rendiPaginaPubblica(paginaID);
            var msg = new MessageBoundary(); 
            msg.mostra("La pagina è stata resa pubblica");
			c.mostra();
        }
    }
	
	public void cliccaRendiPrivata()
	{
        var c = SchermataGestionePaginaBoundary.get();
        var paginaID = c.getPaginaSelezionataID();
		var pubblica = DBMSBoundary.get().isPaginaPubblica(paginaID);
		if (pubblica)
		{
            DBMSBoundary.get().rendiPaginaPrivata(paginaID);
			c.rendiPaginaPrivata(paginaID);
			var msg = new MessageBoundary();
			msg.mostra("La pagina è stata resa privata");
			c.mostra();

        }
    }

	public void cliccaEliminaLink()
	{
		var c = SchermataElencoVisibilitaBoundary.get();
		var link = c.getLinkSelezionato();
		var msg = new MessageRequestBoundary();
		if(!msg.mostra("Confermi l'eliminazione del link?")) return;
		DBMSBoundary.get().eliminaLink(link);
		var msg2 = new MessageBoundary();
		msg2.mostra("Link eliminato con successo");
		c.rimuoviLinkDaElenco(link);
		c.mostra();
    }

	public void cliccaVisitaPagina()
	{
		int paginaID = SchermataGestionePaginaBoundary.get().getPaginaSelezionataID();

		var pageContent = DBMSBoundary.get().getPageContent(paginaID);

		new PaginaControl();

		var pb = new PaginaBoundary();
		pb.abilitaModifica();
		pb.setContent(pageContent);
		pb.mostra();
	}

	public void cliccaCreaPost()
	{
		var p = new SchermataCreazionePostBoundary();
		p.mostra();
    }

	private IEnumerable<int> materialiCreazionePost;
	public void cliccaCaricaMaterialePost() 
	{
        var m = new SchermataSelezioneMaterialeBoundary();
        var studenteID = StudenteEntity.get().getID();
        var elencoMateriali = DBMSBoundary.get().getElencoMateriali(studenteID, DateTime.MinValue, DateTime.MaxValue, "%", "%");
        m.setElencoMateriali(elencoMateriali);
		m.mostra();
        var materialiID = m.getIDMaterialiSelezionati();
		materialiCreazionePost = materialiID;
    }

	public void cliccaPubblica()
	{
        var paginaID = SchermataGestionePaginaBoundary.get().getPaginaSelezionataID();
        var descrizione = SchermataCreazionePostBoundary.get().getDescrizione();
        var postID = DBMSBoundary.get().inserimentoDatiPost(paginaID, descrizione, materialiCreazionePost);
        var msg = new MessageBoundary();
        msg.mostra("Post creato con successo");
        SchermataGestionePaginaBoundary.get().mostra();
    }

    public void cliccaGeneraLink()
	{
		var b = SchermataElencoVisibilitaBoundary.get();
        var a = new SchermataGenerazioneLinkBoundary();
		a.mostra();
		var nickname = a.getNickname();
		var dataScadenza = a.getDataScadenza();

		if (nickname == null && dataScadenza == null) return;

		if(dataScadenza < DateTime.Now)
		{
			var msg = new MessageBoundary();
			msg.mostra("Data di scadenza errata");

        }
		else
		{
			var paginaID = b.getPaginaID();
			var dataCorrente = getDataCorrente();
			var link = generaLink(paginaID, nickname, dataScadenza.Value, dataCorrente);
			DBMSBoundary.get().salvaLinkENickname(paginaID, link);
			b.addItem(link, nickname, dataScadenza.Value);
        }

		b.mostra();
    }

	public DateTime getDataCorrente()
	{
		return DateTime.Now;
	}
}