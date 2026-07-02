using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFolio;

internal class GestioneAccountControl
{
	private static GestioneAccountControl? instance;

	public GestioneAccountControl()
	{
		instance = this;
	}

	public static GestioneAccountControl get()
	{
		return instance ?? new GestioneAccountControl();
	}

	public void cliccaModificaBiografia()
	{

		var a = SchermataHomeBoundary.get();
		var biografiaCorrente = a.getBiografia();
		
		var e = new SchermataModificaBiografiaBoundary();
		e.setBiografia(biografiaCorrente);
		e.mostra();
		
		var nuovaBiografia = e.getBiografia();
		var studenteID = StudenteEntity.get().getID();

		var b = DBMSBoundary.get();
		b.aggiornaBiografia(studenteID, nuovaBiografia);
		a.setBiografia(nuovaBiografia);
		a.mostra(); 


    }

	public void cliccaModificaPassword()
	{
		var a = new SchermataModificaPasswordBoundary();
		a.mostra();
		var b = a.getPasswords();
		if (b == null) { return; }
		var studenteID = StudenteEntity.get().getID(); ;
		bool esistePassword = DBMSBoundary.get().esistePasswordStudente( studenteID, b[0]);
		var verify = verificaPasswordSicura(b[1]);
		if((!esistePassword)  || (!verify))
		{
			var msg = new MessageBoundary();
			msg.mostra("Password non corretta o new password non sicura ");
		}
		else
		{
			DBMSBoundary.get().changePassword(studenteID, b[1]);
            var msg = new MessageBoundary();
			msg.mostra("Password modificata con successo");

        }
		SchermataHomeBoundary.get().mostra();
    }

    public bool verificaPasswordSicura(string secondaPassword)
    {
		bool contiene = false;
		foreach (char c in " &%$#@^£*+?!()=^§[]{}:,;")
			if (secondaPassword.Contains(c)) { contiene = true; break; }

		if (!contiene) return false;

		contiene = false;
        foreach (char c in " 123456789")
            if (secondaPassword.Contains(c)) { contiene = true; break; }

        if (!contiene) return false;

		contiene = false;
		foreach (char c in secondaPassword) {
			if('a' <= c && c <= 'z') { contiene = true; break; }
		}

		if (!contiene) return false;

		contiene = false;
		foreach (char c in secondaPassword)
		{
			if ('A' <= c && c <= 'Z') { contiene = true; break; }
		}

		if (!contiene) return false;

		return true;
    }

	public void cliccaModificaFotoProfilo()
	{
		var f = new SchermataModificaFotoProfiloBoundary();
		f.mostra();
	}


    public void cliccaCaricaFotoProfilo()
    {
		var fileSelect = new FileSelectionBoundary();

        fileSelect.mostra();

        string? foto = fileSelect.getFile();

        if (foto == null) return;

        if (!verificaFoto(foto)) 
        {
			var msg = new MessageBoundary();
			msg.mostra("File non valido");
        }
        else
        {
			var studenteID = StudenteEntity.get().getID();
			var b = DBMSBoundary.get();
			b.caricaFotoProfilo(studenteID, foto);
			var a = SchermataHomeBoundary.get();
			a.setFotoProfiloDaFile(foto);
        }

		SchermataHomeBoundary.get().mostra();
    }

    public void cliccaRimuoviFotoProfilo()
	{
		var msg = new MessageRequestBoundary();
		msg.mostra("Vuoi eliminare la foto attuale?");
		var studenteID = StudenteEntity.get().getID();
		var b = DBMSBoundary.get();
		b.impostaImmagineDefault(studenteID);
		var c = SchermataHomeBoundary.get();
		c.setFotoProfiloDefault();
		c.mostra();

	}

	public bool verificaFoto(string foto)
    {
		FileInfo fi = new(foto);

		if (fi.Length > 10 * 1024 * 1024) return false;

		return new string[] { ".png", ".jpg", ".jpeg" }.Contains(fi.Extension);
    }

	public void cliccaRegistrazione()
	{
		var sr = new SchermataRegistrazioneBoundary();
		sr.mostra();
	}


    public void cliccaLogin() 
	{
		var a = SchermataInizialeBoundary.get();
		var credenziali = a.getCredenziali();
		var msg = new MessageBoundary();
		var verify = verificaFormatoCredenziali(credenziali);
		if (!verify)
		{
			msg.mostra("Formato credenziali errato");
			a.mostra();
        }
		else
		{
			var accountID = DBMSBoundary.get().esisteAccount(credenziali[0], credenziali[1]);
			if (accountID > 0)
			{
				var codice = generaCodiceRandom();
				var email = DBMSBoundary.get().getEmail(accountID);
				mandaEmailCodice(email, codice);
				var f = new SchermataVerifica2FattoriBoundary();
				f.mostra();
				var codiceInserito = f.getCodice();
				if (true || codice == codiceInserito) //TODO
				{
					var e = new StudenteEntity();
					e.setID(accountID);

                    object[] datiProfilo = DBMSBoundary.get().getBioEFotoProfilo(accountID);
                    string biografia = (string)datiProfilo[0];
                    byte[] fotoProfilo = (byte[])datiProfilo[1];

					var shb = new SchermataHomeBoundary();
					shb.setBiografia(biografia);
					shb.setFotoProfilo(fotoProfilo);
					shb.mostra();

                  

                }
				else
				{
					msg.mostra("Codice di verifica errato");
					a.mostra();
				}
            }
			else
			{
                msg.mostra("Nickname o password non validi");
				a.mostra();
            }
        }

    }

	public bool verificaFormatoCredenziali(string[] credenziali)
	{
        if (credenziali[0] == "") return false;

        foreach (char c in " &%$#@^£*+?!()=^§[]{}:,;")
            if (credenziali[0].Contains(c)) return false;

		if ('0' <= credenziali[0][0] && credenziali[0][0] <= '9') return false;

		return verificaPasswordSicura(credenziali[1]);

	}

	public void cliccaEliminaAccount()
	{
		var dialog = new InputDialogBoundary();
		dialog.mostra("Inserisci la password del tuo account");
		var studenteID = StudenteEntity.get().getID();
		var passwordStudente = dialog.getTesto();
		var b = DBMSBoundary.get();
		var esistePassword = b.esistePasswordStudente(studenteID, passwordStudente);

		if (esistePassword == false) {
			var msg = new MessageBoundary();
			msg.mostra("Password non valida");
			SchermataHomeBoundary.get().mostra(); 
		} else {
			b.eliminaAccount(studenteID);
			var msg = new MessageBoundary();
			msg.mostra("Account Eliminato");

			var c = new SchermataInizialeBoundary();
			c.mostra(); 
		}
	}


	public string generaCodiceRandom()
	{
		return Random.Shared.Next(1000000).ToString();
	}

	public void mandaEmailCodice(string email, string codice)
	{
		//TODO per claudio
	}

	public void cliccaRegistrati()
	{
		var credenziali = SchermataRegistrazioneBoundary.get().getCredenziali();
		var credenzialiVerificate = this.verificaFormatoCredenziali(new string[] { credenziali["nickname"], credenziali["password"] });
		var msg = new MessageBoundary(); 
		if (credenzialiVerificate)
		{
			var esisteAccount = DBMSBoundary.get().esisteAccount(credenziali["nickname"]);

			if (esisteAccount == false)
			{
				var identif = new SchermataSceltaSistemaIdentificazioneBoundary();
				identif.mostra();
				var tipoSistemaIdentificazione = identif.getTipoSistemaIdentificazione();
				if (tipoSistemaIdentificazione == null) { return; }
				var successoIdentificazione = SistemaIdentificazioneBoundary.get().identificaStudente(tipoSistemaIdentificazione);

				if (successoIdentificazione)
				{
					var datiIdentificazione = SistemaIdentificazioneBoundary.get().getDatiIdentificazione();
					var studenteID = DBMSBoundary.get().creaAccount(credenziali, datiIdentificazione);
					var studEnt = new StudenteEntity();
					studEnt.setID(studenteID);
					var b = new SchermataHomeBoundary();
					b.mostra();
                } else
				{
					msg.mostra("Identificazione fallita");
					SchermataRegistrazioneBoundary.get().mostra();
				}

			} else
			{
				msg.mostra("Nickname già in uso");
				SchermataRegistrazioneBoundary.get().mostra();
			}
		} else
		{
			msg.mostra("Formato credenziali errato");
			SchermataRegistrazioneBoundary.get().mostra();
		}

	}

	public void cliccaLogout()
	{
		// TODO
        SchermataRegistrazioneBoundary.get().Close();

    }
}
