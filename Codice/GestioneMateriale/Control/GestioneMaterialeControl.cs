using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ArtFolio.CommonDBMS;
using ArtFolio.GestioneAccount.Entity;
using ArtFolio.Utils;
using ArtFolio.GestioneMateriale.Interface;

namespace ArtFolio.GestioneMateriale.Control;

internal class GestioneMaterialeControl
{
	// filterParams
	private DateTime filterLowerDate = DateTime.MinValue; 
	private DateTime filterUpperDate = DateTime.MaxValue;
	private string filterType = "";
	private string filterName = "";

	public GestioneMaterialeControl() {
		instance = this;

		int studenteID = StudenteEntity.get().getID();

		var b = new SchermataGestioneMaterialeBoundary();

		b.setElencoMateriali(DBMSBoundary.get().getElencoMateriali(studenteID, filterLowerDate, filterUpperDate, filterType, filterName));
		b.setFilterParams(filterLowerDate, filterUpperDate, filterType, filterName);
		b.mostra();
	}

	private static GestioneMaterialeControl? instance = null;
	public static GestioneMaterialeControl get()
	{
		return instance ?? new GestioneMaterialeControl();
	}
	private static string[] allowedExtensions = {".jpg", ".jpeg", ".svg", ".webp", ".mp4", ".avi", ".mp3", ".aac", ".wav", ".mid", ".pdf" };

	public bool verificaFile(string file)
	{
		FileInfo info = new FileInfo(file);
		if(!info.Exists) return false;

		if (!allowedExtensions.Contains(info.Extension)) return false;

		return true;
	}

	public bool verificaConformitàFileParametriFiltraggio(string file)
	{
		FileInfo info = new FileInfo(file);

		if(filterName != null && filterName != "" && !info.Name.Contains(filterName)) return false;
		if(filterType != null && filterType != "" && info.Extension != "." + filterType) return false;

		if(!(filterLowerDate <= DateTime.Now && DateTime.Now <= filterUpperDate)) return false;
		return true;
	}

	public void cliccaCarica()
	{
		var fileSelect = new FileSelectionBoundary();

		fileSelect.mostra();

		string? file = fileSelect.getFile();

		if (file == null) return;

		if(verificaFile(file))
		{
			int studenteID = StudenteEntity.get().getID();

			int materialeID = DBMSBoundary.get().caricaFile(studenteID, file);

			if(verificaConformitàFileParametriFiltraggio(file))
			{
				SchermataGestioneMaterialeBoundary.get().aggiungiMateriale(materialeID, file);
			}
		} else {
			var m = new MessageBoundary();

			m.mostra("File non supportato");
		}
	}

	public void cliccaElimina()
	{
		var mrb = new MessageRequestBoundary();

		if (!mrb.mostra("Vuoi eliminare i materiali selezionati?")) return;

		var materialiID = SchermataGestioneMaterialeBoundary.get().getIDMaterialiSelezionati();

		int studenteID = StudenteEntity.get().getID();

		var postReferenziati = DBMSBoundary.get().verificaMaterialeReferenziatoDaPost(materialiID);

		if(postReferenziati.Count() == 0)
		{
			DBMSBoundary.get().eliminaMateriali(materialiID);
			new MessageBoundary().mostra("materiali eliminati");
			SchermataGestioneMaterialeBoundary.get().rimuoviMateriali(materialiID);
		} else
		{
			var msg = "I materiali che vuoi eliminare sono referenziati dai seguenti post:\n";
			foreach(var post in postReferenziati)
			{
				msg += post;
			}
			new MessageBoundary().mostra(msg);
		}

	}

    public void cliccaFitraDate()
	{
		var b = SchermataGestioneMaterialeBoundary.get();
        var studenteID = StudenteEntity.get().getID();
		DateTime[] date = b.getDateFiltro();
		setDate(date);
		var elencoMateriali = DBMSBoundary.get().getElencoMateriali(studenteID, filterLowerDate, filterUpperDate, filterType, filterName);
		b.setElencoMateriali(elencoMateriali);
    }

	public void setDate(DateTime[] date)
	{
        filterLowerDate = date[0]; 
        filterUpperDate = date[1];
    }

	public void cliccaFitraNome()
	{
        var b = SchermataGestioneMaterialeBoundary.get();
		var nome = b.getFiltroNome();
		setNome(nome);
        var studenteID = StudenteEntity.get().getID();
		var elencoMateriali = DBMSBoundary.get().getElencoMateriali(studenteID, filterLowerDate, filterUpperDate, filterType, filterName);
        b.setElencoMateriali(elencoMateriali);
    }

	public void setNome( string nome)
	{
		filterName = nome;

    }

	public void cliccaFitraTipologia()
	{
        var b = SchermataGestioneMaterialeBoundary.get();
		var tipologia = b.getTipologiaFile();
		setTipologiaFile(tipologia);
        var studenteID = StudenteEntity.get().getID();
        var elencoMateriali = DBMSBoundary.get().getElencoMateriali(studenteID, filterLowerDate, filterUpperDate, filterType, filterName);
        b.setElencoMateriali(elencoMateriali);
    }

    public void setTipologiaFile(string tipologia)
    {
        filterType = tipologia;

    }

	public void cliccaScarica()
	{
        var b = SchermataGestioneMaterialeBoundary.get();
        IEnumerable<int> materialiID = b.getIDMaterialiSelezionati();
        var studenteID = StudenteEntity.get().getID();
        IEnumerable<byte[]> materiali = DBMSBoundary.get().getMateriali(materialiID);
		caricaMaterialiSuDispositivoStudente(materiali);
		
    }


	private void caricaMaterialiSuDispositivoStudente(IEnumerable<byte[]> materiali)
	{
		var of = new SaveFileDialog();

		foreach(var materiale in materiali)
		{
			if(of.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(of.FileName, materiale);
			}
		}
	}

}

