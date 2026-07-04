using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Security.Cryptography;
using System.Transactions;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;

// tabelle db
// studente: studente_id, email_studente, nickname_studente, biografia_studente, password_hash_studente, foto_profilo_id, nome_studente, cognome_studente, data_di_nascita_studente, codice_fiscale_studente
// materiale: materiale_id, studente_id, nome_materiale, data_caricamento_materiale
// contenuto_materiale: materiale_id, blob_materiale
// pagina: pagina_id, studente_id, nome_pagina, pagina_pubblica
// post: post_id, pagina_id, descrizione_post, posizione_post, data_caricamento_post
// contenuto_post: post_id, materiale_id
// elenco_visibilita: pagina_id, link
// elenco_visualizzazione: pagina_id, link

namespace ArtFolio.CommonDBMS;

internal class DBMSBoundary
{
	private SqlConnection connection;
	private DBMSBoundary()
	{
		if(!ping())
		{
			codaRieffetuaUltimaOperazione.Push(() => { });
			codaVerificaUltimaOperazione.Push(() => true);
			cadutaConnessione<object>();
		}
	}

	public bool ping() {
		try {
			connection = new("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0;Initial Catalog=ArtFolioDB");
			connection.Open();
			return true;
		}
		catch  {
			return false;
		}
	}

	private Stack<Action> codaRieffetuaUltimaOperazione = new();
	private Stack<Func<bool>> codaVerificaUltimaOperazione = new();

	public void rieffetuaUltimaOperazione()
	{
		codaRieffetuaUltimaOperazione.Peek()();
	}


	public bool verificaUltimaOperazione() {
		return codaVerificaUltimaOperazione.Peek()();
	}

	private object retryReturn=null;
	private DateTime momentoCadutaConnessione = DateTime.MinValue;

	private static DBMSBoundary instance = new DBMSBoundary();

	public static DBMSBoundary get() { return instance; }

	private T cadutaConnessione<T>()
	{
		var prev = momentoCadutaConnessione;
		momentoCadutaConnessione = DateTime.MinValue;

		var prev2 = retryReturn;
		retryReturn = null;

		new CadutaConnessioneControl();

		codaVerificaUltimaOperazione.Pop();
		codaRieffetuaUltimaOperazione.Pop();

		momentoCadutaConnessione = prev;

		var r = retryReturn;
		retryReturn = prev2;

		return (T)r;
	}

	public IEnumerable<string> getElencoMateriali(int studenteID, DateTime filterLowerDate, DateTime filterUpperDate, string filterType, string filterName)
	{
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getElencoMateriali(studenteID, filterLowerDate, filterUpperDate, filterType, filterName));
		codaVerificaUltimaOperazione.Push(() => false);

		try
		{

			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT materiale_id, nome_materiale, data_caricamento_materiale FROM materiale WHERE studente_id = @studente_id";
			cmd.Parameters.AddWithValue("@studente_id", studenteID);

			if (filterName != null && filterName != "")
			{
				cmd.CommandText += " AND nome_materiale like '%' + @nome_materiale + '%'";
				cmd.Parameters.AddWithValue("@nome_materiale", filterName);
			}

			if (filterType != null && filterType != "")
			{
				cmd.CommandText += " AND nome_materiale like '%' + @tipo_materiale";
				cmd.Parameters.AddWithValue("@tipo_materiale", filterType);
			}

			if (filterLowerDate != null && filterLowerDate != DateTime.MinValue)
			{
				cmd.CommandText += " AND @lowerDate <= data_caricamento_materiale";
				cmd.Parameters.AddWithValue("@lowerDate", filterLowerDate);
			}

			if (filterUpperDate != null && filterUpperDate != DateTime.MaxValue)
			{
				cmd.CommandText += " AND data_caricamento_materiale <= @upperDate";
				cmd.Parameters.AddWithValue("@upperDate", filterUpperDate);
			}
			using var reader = cmd.ExecuteReader();

			List<string> result = new();

			while (reader.Read())
			{
				string s = $"{reader.GetInt32(0)}|{reader.GetString(1)}|{reader.GetDateTime(2)}";
				result.Add(s);
			}

			codaRieffetuaUltimaOperazione.Pop();
			codaVerificaUltimaOperazione.Pop();

			return result;
		} catch (SqlException ex)
		{
			return cadutaConnessione< IEnumerable<string>>();
		}
	}

	private bool verificaCaricaFile(int studenteID, string file)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = verificaCaricaFile(studenteID, file));

		try
		{
			using SqlCommand cmd = new SqlCommand("SELECT MAX(data_caricamento_materiale) FROM materiale WHERE studente_id = @studente_id AND nome_materiale = @nome_materiale", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.Parameters.AddWithValue("@nome_materiale", new FileInfo(file).Name);
			var dt = (DateTime)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
			return (momentoCadutaConnessione - dt).Duration() < TimeSpan.FromSeconds(1);
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
	}

	public int caricaFile(int studenteID, string file)
	{
		codaVerificaUltimaOperazione.Push(() => verificaCaricaFile(studenteID, file));
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = caricaFile(studenteID, file));

		try
		{
			FileInfo info = new FileInfo(file);
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = @"
				DECLARE @materiale_id TABLE (id INT);

				INSERT INTO materiale (studente_id, nome_materiale)
				OUTPUT INSERTED.materiale_id INTO @materiale_id
				VALUES (@studente_id, @nome_materiale);

				INSERT INTO contenuto_materiale (materiale_id, blob_materiale)
				SELECT id, @blob_materiale
				FROM @materiale_id;

				SELECT id
				FROM @materiale_id;";
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.Parameters.AddWithValue("@nome_materiale", info.Name);
			cmd.Parameters.AddWithValue("@blob_materiale", File.ReadAllBytes(file));

			int r = Convert.ToInt32(cmd.ExecuteScalar());
			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
			return r;
		}
		catch (SqlException e)
		{
			return cadutaConnessione<int>();
		}
	}

	public IEnumerable<string> verificaMaterialeReferenziatoDaPost(IEnumerable<int> materialiID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = verificaMaterialeReferenziatoDaPost(materialiID));

		try
		{
			List<string> result = new();

			foreach (int materialeID in materialiID)
			{
				using SqlCommand cmd = new(
					"SELECT pagina.pagina_id, pagina.nome_pagina, post.post_id, post.descrizione_post FROM contenuto_post, post, pagina WHERE materiale_id = @materiale_id AND contenuto_post.post_id = post.post_id AND pagina.pagina_id = post.pagina_id",
					connection);

				cmd.Parameters.AddWithValue("@materiale_id", materialeID);

				using var reader1 = cmd.ExecuteReader();

				while (reader1.Read())
				{
					result.Add($"{reader1.GetInt32(0)}:{reader1.GetString(1)}:{reader1.GetInt32(2)}:{reader1.GetString(3)}");
				}

			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
			return result;

		}
		catch (SqlException e) {
			return cadutaConnessione<IEnumerable<string>>();
		}
	}

	public void eliminaMateriali(IEnumerable<int> materialiID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => eliminaMateriali(materialiID));

		try
		{
			foreach (int materialeID in materialiID)
			{
				using SqlCommand cmd = new("DELETE FROM materiale WHERE materiale_id = @materiale_id; DELETE FROM contenuto_materiale WHERE materiale_id = @materiale_id", connection);
				cmd.Parameters.AddWithValue("materiale_id", materialeID);
				cmd.ExecuteNonQuery();
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException e) {
			cadutaConnessione<object>();
		}
	}

	public IEnumerable<string> getElencoPagine(int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getElencoPagine(studenteID));
		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT pagina_id, nome_pagina, pagina_pubblica FROM pagina WHERE studente_id = @studente_id ";
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			using var reader = cmd.ExecuteReader();

			List<string> result = new();

			while (reader.Read())
			{
				string s = $"{reader.GetInt32(0)}|{reader.GetString(1)}|{reader.GetBoolean(2)}";
				result.Add(s);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;
		}
		catch (SqlException e) {
			return cadutaConnessione<IEnumerable<string>>();
		}
    }

	public bool esistePagina(string nuovoNomePagina, int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = esistePagina(nuovoNomePagina, studenteID));

		try
		{
			using SqlCommand cmd = new("SELECT count(*) FROM pagina WHERE studente_id = @studente_id AND nome_pagina = @nome_pagina", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.Parameters.AddWithValue("@nome_pagina", nuovoNomePagina);

			bool r = (int)cmd.ExecuteScalar() > 0;

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;

		}
		catch (SqlException e) {
			return cadutaConnessione<bool>();
		}
	}

	public void rinominaPagina(string nomePagina, string nuovoNomePagina, int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => rinominaPagina(nomePagina, nuovoNomePagina, studenteID));

		try
		{
			using SqlCommand cmd = new("UPDATE pagina SET nome_pagina = @nuovo_nome_pagina WHERE studente_id = @studente_id AND nome_pagina = @nome_pagina", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.Parameters.AddWithValue("@nuovo_nome_pagina", nuovoNomePagina);
			cmd.Parameters.AddWithValue("@nome_pagina", nomePagina);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException e) {
			cadutaConnessione<object>();
		}
	}

	public int creaPagina(string nomeNuovaPagina, int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = creaPagina(nomeNuovaPagina, studenteID));

		try
		{
			using SqlCommand cmd = new("INSERT INTO pagina( studente_id, nome_pagina) OUTPUT INSERTED.pagina_id VALUES (@studente_id, @nome_nuova_pagina)", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.Parameters.AddWithValue("@nome_nuova_pagina", nomeNuovaPagina);

			var r = (int)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;
		}
		catch (SqlException e) {
			return cadutaConnessione<int>();
		}
    }

	public void eliminaPagina(int paginaID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => eliminaPagina(paginaID));

		try
		{
			using SqlCommand cmd = new("DELETE FROM pagina WHERE pagina_id = @pagina_id", connection);
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException e) {
			cadutaConnessione<object>();
		}
	}

	public IEnumerable<string> getCampioneElencoStudenti()
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getCampioneElencoStudenti());
		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT TOP 20 studente_id, nickname_studente, nome_studente, cognome_studente FROM studente ORDER BY studente_id DESC";

			using var reader = cmd.ExecuteReader();
			List<string> result = new();

			while (reader.Read())
			{
				string s = $"{reader.GetInt32(0)}|{reader.GetString(1)}|{reader.GetString(2)}|{reader.GetString(3)}";
				result.Add(s);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;
		}
		catch (SqlException e) {
			return cadutaConnessione<IEnumerable<string>>();
		}

    }

    public void copiaContenutiPagina(int paginaID, int nuovaPaginaID)
    {
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => copiaContenutiPagina(paginaID, nuovaPaginaID));

		try
		{
			var content = getPageContent(paginaID);

			using SqlCommand cmd = new("SELECT COUNT(*) FROM post WHERE pagina_id = @pagina_id", connection);
			cmd.Parameters.AddWithValue("@pagina_id", nuovaPaginaID);

			int post_gia_clonati = (int)cmd.ExecuteScalar();

			while (content.Count > 0 && content.First() != null)
			{
				content.RemoveAt(0); // schippa post_id
				var descrizione = (string)content.First(); content.RemoveAt(0);
				List<int> materiali = new();

				while (content.First() != null)
				{
					materiali.Add((int)content.First()); content.RemoveAt(0); // prendi id materiale
					content.RemoveAt(0); //skippa nome
					content.RemoveAt(0); //skippa dati
				}

				content.RemoveAt(0); //togli il tappo dei materiali

				if (--post_gia_clonati < 0) inserimentoDatiPost(nuovaPaginaID, descrizione, materiali);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (Exception ex) {
			cadutaConnessione<object>();
		}
		
	}

    public IEnumerable<string> getElencoStudenti(string testo)
    {
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getElencoStudenti(testo));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;

			cmd.CommandText = @"
				SELECT studente_id, nickname_studente, nome_studente, cognome_studente 
				FROM studente 
				WHERE nome_studente LIKE @testo 
				OR cognome_studente LIKE @testo 
				OR nickname_studente LIKE @testo
				ORDER BY cognome_studente, nome_studente";
			cmd.Parameters.AddWithValue("@testo", "%" + testo + "%");

			using var reader = cmd.ExecuteReader();
			List<string> result = new();

			while (reader.Read())
			{
				string s = $"{reader.GetInt32(0)}|{reader.GetString(1)}|{reader.GetString(2)}|{reader.GetString(3)}";
				result.Add(s);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;
		}
		catch (SqlException ex) {
			return cadutaConnessione<IEnumerable<string>>();
		}
    }

	public IEnumerable<string> getLinkVisualizzazione( int paginaID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getLinkVisualizzazione(paginaID));

		try
		{

			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT link FROM elenco_visualizzazione WHERE pagina_id = @pagina_id ";
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);

			using var reader = cmd.ExecuteReader();
			List<string> result = new();
			while (reader.Read())
			{
				string s = reader.GetString(0);
				result.Add(s);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;

		}
		catch (SqlException ex) {
			return cadutaConnessione<IEnumerable<string>>();
		}

    }

	public Dictionary<string, object> getDatiStudente(int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getDatiStudente(studenteID));

		try
		{
			Dictionary<string, object> result = new();

			SqlCommand cmd = new();
			cmd.Connection = connection;

			cmd.CommandText = @"
				SELECT nickname_studente, nome_studente, cognome_studente, foto_profilo_id, biografia_studente
				FROM studente 
				WHERE studente_id = @studente_id";

			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			int? fotoProfiloID;
			using (var reader = cmd.ExecuteReader())
			{
				reader.Read();
				result.Add("nickname", reader.GetString(0));
				result.Add("nome", reader.GetString(1));
				result.Add("cognome", reader.GetString(2));
				result.Add("biografia", reader.GetString(4));
				fotoProfiloID = reader.IsDBNull(3) ? null : reader.GetInt32(3);
			}

			if (fotoProfiloID != null)
			{
				cmd = new SqlCommand("SELECT blob_materiale FROM contenuto_materiale WHERE materiale_id = @materiale_id", connection);
				cmd.Parameters.AddWithValue("@materiale_id", fotoProfiloID.Value);
				result.Add("foto_profilo", cmd.ExecuteScalar());
				cmd.Dispose();
			}
			else
			{
				result.Add("foto_profilo", null);
			}

			List<string> elencoPaginePubbliche = new();

			cmd.CommandText = @"
				SELECT pagina_id, nome_pagina
				FROM pagina
				WHERE studente_id = @studente_id";

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@studente_id", studenteID);

			using (var reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					string s = $"{reader.GetInt32(0)}|{reader.GetString(1)}";
					elencoPaginePubbliche.Add(s);
				}

				result.Add("pagine_pubbliche", elencoPaginePubbliche);

			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;

		}
		catch (SqlException ex) {
			return cadutaConnessione<Dictionary<string, object>>();
		}
        
	}

	public void eliminaLink(string link)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => eliminaLink(link));

		try
		{
			using SqlCommand cmd = new("DELETE FROM elenco_visibilita WHERE link = @link; DELETE FROM elenco_visualizzazione WHERE link = @link", connection);
			cmd.Parameters.AddWithValue("@link", link);
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}

	}

	public IEnumerable<string> getLinkVisibilita(int paginaID) 
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getLinkVisibilita(paginaID));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT link FROM elenco_visibilita WHERE pagina_id = @pagina_id ";
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);

			using var reader = cmd.ExecuteReader();
			List<string> result = new();
			while (reader.Read())
			{
				string s = reader.GetString(0);
				result.Add(s);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;
		}
		catch (SqlException ex) {
			return cadutaConnessione<IEnumerable<string>>();
		}
	}

	public List<byte[]> getMateriali(IEnumerable<int> materialiID)
	{
		List<byte[]> result = new();
		foreach(int materialeID in materialiID)
		{
			result.Add(getMateriale(materialeID));
		}

		return result;
        
    }

	public byte[] getMateriale(int? materialeID)
	{
		if (materialeID == null) return null;

		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getMateriale(materialeID));

		try
		{

			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT blob_materiale FROM contenuto_materiale WHERE materiale_id = @materiale_id ";
			cmd.Parameters.AddWithValue("@materiale_id", materialeID);

			var r = (byte[])cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;
		}
		catch (SqlException ex) {
			return cadutaConnessione<byte[]>();
		}
	}

	public string getNomeMateriale(int materialeID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getNomeMateriale(materialeID));

		try
		{
			using SqlCommand cmd = new("SELECT nome_materiale FROM materiale WHERE materiale_id = @materiale_id", connection);
			cmd.Parameters.AddWithValue("@materiale_id", materialeID);
			var r = (string)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
			return r;
		}
		catch (SqlException ex) {
			return cadutaConnessione<string>();
		}
	}

	public bool isPaginaPrivata(int paginaID)
	{
        return !isPaginaPubblica(paginaID);
    } 

    public bool isPaginaPubblica(int paginaID)
    {
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = isPaginaPubblica(paginaID));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT pagina_pubblica FROM pagina WHERE pagina_id = @pagina_id";
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);
			var r = (bool)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
    }

	public void rendiPaginaPrivata(int paginaID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => rendiPaginaPrivata(paginaID));

		try
		{
			using SqlCommand cmd = new("UPDATE pagina SET pagina_pubblica = 0 WHERE pagina_id = @pagina_id", connection);
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
    }


    public void rendiPaginaPubblica(int paginaID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => rendiPaginaPubblica(paginaID));

		try
		{
			using SqlCommand cmd = new("UPDATE pagina set pagina_pubblica = 1 WHERE pagina_id = @pagina_id", connection);
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	public void aggiornaBiografia(int studenteID, string nuovaBiografia)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => aggiornaBiografia(studenteID, nuovaBiografia));

		try
		{

			using SqlCommand cmd = new();
			cmd.Connection = connection;

			cmd.CommandText = @"
				UPDATE studente 
				SET biografia_studente = @nuova_biografia
				WHERE studente_id = @studente_id";

			cmd.Parameters.AddWithValue("@nuova_biografia", nuovaBiografia);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	public void caricaFotoProfilo(int studenteID, string foto)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => caricaFotoProfilo(studenteID, foto));

		try
		{
			FileInfo info = new FileInfo(foto);
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = @"
				DECLARE @materiale_id TABLE (id INT);

				INSERT INTO materiale (studente_id, nome_materiale)
				OUTPUT INSERTED.materiale_id INTO @materiale_id
				VALUES (@studente_id, @nome_materiale);

				INSERT INTO contenuto_materiale (materiale_id, blob_materiale)
				SELECT id, @blob_materiale
				FROM @materiale_id;

				UPDATE studente 
				SET foto_profilo_id = (SELECT TOP 1 id FROM @materiale_id)
				WHERE studente_id = @studente_id;";

			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.Parameters.AddWithValue("@nome_materiale", info.Name);
			cmd.Parameters.AddWithValue("@blob_materiale", File.ReadAllBytes(foto));
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
    }

    public bool esistePasswordStudente(int studenteID, string passwordAttuale)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = esistePasswordStudente(studenteID, passwordAttuale));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT password_hash_studente FROM studente WHERE studente_id = @studente_id";
			cmd.Parameters.AddWithValue("@studente_id", studenteID);

			string password_hash = (string)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return cmpPassword(password_hash, passwordAttuale);
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
	}


    //NON includere nel diagramma delle classi
    public bool cmpPassword(string password_hash, string password) {
		if (password == null || password == "") return false;
		return password_hash == hashPassword(password);
	}

	public string hashPassword(string password) {
		byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
		return Convert.ToBase64String(hash);
	}


	public void changePassword(int studenteID, string secondaPassword)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => changePassword(studenteID, secondaPassword));

		try
		{
			using SqlCommand cmd = new("UPDATE studente SET password_hash_studente = @password_hash_studente WHERE studente_id = @studente_id", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			string pasw_hash = hashPassword(secondaPassword);
			cmd.Parameters.AddWithValue("@password_hash_studente", pasw_hash);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	private bool verificaInserimentoDatiPost(int paginaID, string descrizione, IEnumerable<int> materialiID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = verificaInserimentoDatiPost(paginaID, descrizione, materialiID));

		string inClause = string.Join(",", materialiID);

		string sql = $@"
			SELECT TOP (1)
				p.data_caricamento_post
			FROM post p
			INNER JOIN contenuto_post cp
				ON p.post_id = cp.post_id
			WHERE p.pagina_id = @pagina_id
			  {(materialiID.Count() > 0 ? $"AND cp.MaterialeId IN ({inClause})" : "")}
			  AND p.descrizione_post = @descrizione_post
			ORDER BY p.data_caricamento_post DESC;";

		try
		{
			using SqlCommand cmd = new SqlCommand(sql, connection);

			cmd.Parameters.Add("@pagina_id", SqlDbType.Int).Value = paginaID;
			cmd.Parameters.AddWithValue("@descrizione_post", descrizione);

			object result = cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			if (result == null || result == DBNull.Value) return false;

			return ((DateTime)result - momentoCadutaConnessione).Duration() > TimeSpan.FromSeconds(1);
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
	}
	public int inserimentoDatiPost(int paginaID, string descrizione, IEnumerable<int> materialiID)
	{
		codaVerificaUltimaOperazione.Push(() => verificaInserimentoDatiPost(paginaID, descrizione, materialiID));
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = inserimentoDatiPost(paginaID, descrizione, materialiID));

		try
		{
			var t = connection.BeginTransaction();
			using SqlCommand cmd1 = new("INSERT INTO post (pagina_id, descrizione_post, posizione_post) OUTPUT INSERTED.post_id VALUES(@pagina_id, @descrizione_post, ISNULL((SELECT MAX(posizione_post) FROM post WHERE pagina_id = @pagina_id), -1) + 1)", connection);
			cmd1.Transaction = t;
			cmd1.Parameters.AddWithValue("@pagina_id", paginaID);
			cmd1.Parameters.AddWithValue("descrizione_post", descrizione);
			int postID = (int)cmd1.ExecuteScalar();

			if (materialiID != null)
				foreach (int materialeID in materialiID)
				{
					using SqlCommand cmd2 = new("INSERT INTO contenuto_post (post_id, materiale_id) VALUES (@post_id, @materiale_id)", connection);
					cmd2.Transaction = t;
					cmd2.Parameters.AddWithValue("@post_id", postID);
					cmd2.Parameters.AddWithValue("@materiale_id", materialeID);
					cmd2.ExecuteNonQuery();
				}

			t.Commit();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return postID;
		}
		catch (SqlException ex) {
			return cadutaConnessione<int>();
		}
	}

	public void eliminaAccount(int studenteID) {
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => eliminaAccount(studenteID));

		try
		{
			using SqlCommand cmd = new("DELETE FROM studente WHERE studente_id = @studente_id", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	public int esisteAccount(string nickname, string password)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = esisteAccount(nickname, password));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT studente_id FROM studente WHERE nickname_studente = @nickname_studente AND  password_hash_studente = @password_hash_studente";
			cmd.Parameters.AddWithValue("@nickname_studente", nickname);
			string pasw_hash = hashPassword(password);
			cmd.Parameters.AddWithValue("@password_hash_studente", pasw_hash);
			var o = cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return o != null ? Convert.ToInt32(o) : 0;
		}
		catch (SqlException ex) {
			return cadutaConnessione <int>();
		}
    }

	public bool esisteAccount(string nickname)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = esisteAccount(nickname));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT COUNT(*) FROM studente WHERE nickname_studente = @nickname_studente";
			cmd.Parameters.AddWithValue("@nickname_studente", nickname);
			var r = (int)cmd.ExecuteScalar() > 0;

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
	}

	public void impostaImmagineDefault(int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => impostaImmagineDefault(studenteID));

		try
		{
			using SqlCommand cmd = new("UPDATE studente SET foto_profilo_id = NULL WHERE studente_id = @studente_id", connection);
			cmd.Parameters.AddWithValue("@studente_id", studenteID);

			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	public string getEmail(int studenteID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getEmail(studenteID));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT email_studente FROM studente WHERE studente_id = @studente_id";
			cmd.Parameters.AddWithValue("@studente_id", studenteID);
			var r = (string)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;
		}
		catch (SqlException ex) {
			return cadutaConnessione<string>();
		}
    }

	private bool verificaCreaAccount(string nickname)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = verificaCreaAccount(nickname));

		try
		{
			using SqlCommand cmd = new("SELECT COUNT(*) FROM studente WHERE nickname = @nickname", connection);
			cmd.Parameters.AddWithValue("@nickname", nickname);

			var r = (int)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r > 0;
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
	}

	public int creaAccount(Dictionary<string, string> credenziali, Dictionary<string, object> datiIdentificazione)
	{
		codaVerificaUltimaOperazione.Push(() => verificaCreaAccount(credenziali["nickname"]));
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = creaAccount(credenziali, datiIdentificazione));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;

			cmd.CommandText = @"
				INSERT INTO studente (
					email_studente, 
					nickname_studente, 
					password_hash_studente, 
					nome_studente, 
					cognome_studente, 
					data_di_nascita_studente, 
					codice_fiscale_studente
				) 
				OUTPUT INSERTED.studente_id 
				VALUES (
					@email_studente, 
					@nickname_studente, 
					@password_hash_studente, 
					@nome_studente, 
					@cognome_studente, 
					@data_di_nascita_studente, 
					@codice_fiscale_studente
				)";

			cmd.Parameters.AddWithValue("@email_studente", credenziali["email"]);
			cmd.Parameters.AddWithValue("@nickname_studente", credenziali["nickname"]);
			cmd.Parameters.AddWithValue("@password_hash_studente", hashPassword(credenziali["password"]));
			cmd.Parameters.AddWithValue("@nome_studente", datiIdentificazione["nome"]);
			cmd.Parameters.AddWithValue("@cognome_studente", datiIdentificazione["cognome"]);
			cmd.Parameters.AddWithValue("@data_di_nascita_studente", datiIdentificazione["data_di_nascita"]);
			cmd.Parameters.AddWithValue("@codice_fiscale_studente", datiIdentificazione["codice_fiscale"]);

			int nuovoStudenteID = (int)cmd.ExecuteScalar();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return nuovoStudenteID;
		}
		catch (SqlException ex) {
			return cadutaConnessione<int>();
		}
    }

	public List<object> getPageContent(int paginaID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getPageContent(paginaID));

		try
		{
			List<object> result = new();

			using SqlCommand cmd = new("SELECT post_id, descrizione_post FROM post WHERE pagina_id = @pagina_id ORDER BY posizione_post", connection);
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);

			List<object> postList = new();

			using (var postReader = cmd.ExecuteReader())
			{
				while (postReader.Read())
				{
					int postID = postReader.GetInt32(0);
					postList.Add(postID);
					postList.Add(postReader.GetString(1));
				}
			}

			while (postList.Count > 0)
			{
				int postID = (int)postList.First(); postList.RemoveAt(0);
				result.Add(postID);
				result.Add(postList.First()); postList.RemoveAt(0);

				using SqlCommand cmd2 = new("SELECT materiale.materiale_id, materiale.nome_materiale FROM contenuto_post, materiale WHERE materiale.materiale_id = contenuto_post.materiale_id AND post_id = @post_id", connection);
				cmd2.Parameters.AddWithValue("@post_id", postID);

				List<object> materialiList = new();

				using (var materialeReader = cmd2.ExecuteReader())
				{
					while (materialeReader.Read())
					{
						materialiList.Add(materialeReader.GetInt32(0));
						materialiList.Add(materialeReader.GetString(1));
					}
				}

				while (materialiList.Count > 0)
				{
					int materialeID = (int)materialiList.First(); materialiList.RemoveAt(0);
					string nomeMateriale = (string)materialiList.First(); materialiList.RemoveAt(0);

					result.Add(materialeID);
					result.Add(nomeMateriale);

					if (nomeMateriale.EndsWith(".svg") || nomeMateriale.EndsWith(".jpg") || nomeMateriale.EndsWith(".jpeg"))
					{
						result.Add(getMateriale(materialeID));
					}
					else
					{
						result.Add(null);
					}
				}

				result.Add(null);
			}

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return result;
		}
		catch (SqlException ex) {
			return cadutaConnessione<List<object>>();
		}
	}

	public bool esisteLinkElencoVisibilita(int pageID, string link)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = esisteLinkElencoVisibilita(pageID, link));

		try
		{

			using SqlCommand cmd = new("SELECT COUNT(*) FROM elenco_visibilita WHERE pagina_id = @pagina_id AND link = @link", connection);
			cmd.Parameters.AddWithValue("@pagina_id", pageID);
			cmd.Parameters.AddWithValue("@link", link);

			var r = (int)cmd.ExecuteScalar() > 0;

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return r;
		}
		catch (SqlException ex) {
			return cadutaConnessione<bool>();
		}
	}

	public void aggiungiLinkAdElencoVisualizzazionePagina(int pageID, string link)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => aggiungiLinkAdElencoVisualizzazionePagina(pageID, link));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = @"
			IF NOT EXISTS ( SELECT 1 FROM elenco_visualizzazione WHERE pagina_id = @pagina_id AND link = @link )
			BEGIN
				INSERT INTO elenco_visualizzazione(pagina_id, link) VALUES (@pagina_id, @link)
			END
		";
			cmd.Parameters.AddWithValue("@pagina_id", pageID);
			cmd.Parameters.AddWithValue("@link", link);
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	public void eliminaPost(int postID)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => eliminaPost(postID));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = @"
			IF EXISTS ( SELECT 1 FROM post WHERE post_id = @post_id )
			BEGIN
				DECLARE @pagina_id INT;
				DECLARE @posizione_post INT;
				SELECT @pagina_id = pagina_id, @posizione_post = posizione_post FROM post WHERE post_id = @post_id;
				DELETE FROM post WHERE post_id = @post_id;
				UPDATE post SET posizione_post = posizione_post - 1 WHERE pagina_id = @pagina_id AND posizione_post > @posizione_post;
			END
		";
			cmd.Parameters.AddWithValue("@post_id", postID);
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

	public void newPositionPost(int postID, int newPosition)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => newPositionPost(postID, newPosition));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;
			cmd.CommandText = @"
				DECLARE @old_pos INT;
				DECLARE @post_id_2 INT;
				DECLARE @pagina_id INT;
				SELECT @old_pos = posizione_post, @pagina_id = pagina_id FROM post WHERE post_id = @post_id;
				SELECT @post_id_2 = post_id FROM post WHERE pagina_id = @pagina_id AND posizione_post = @new_pos;

				UPDATE post SET posizione_post = @old_pos WHERE post_id = @post_id_2;
				UPDATE post SET posizione_post = @new_pos WHERE post_id = @post_id;
			";
			cmd.Parameters.AddWithValue("@post_id", postID);
			cmd.Parameters.AddWithValue("@new_pos", newPosition);
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione <object>();
		}
	}

	public object[] getBioEFotoProfilo(int studenteID)
	{
        string biografia = "";
        int? fotoProfiloID = null;

		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => retryReturn = getBioEFotoProfilo(studenteID));

		try
		{
			using SqlCommand cmd = new();
			cmd.Connection = connection;

			cmd.CommandText = @"
				SELECT biografia_studente, foto_profilo_id 
				FROM studente 
				WHERE studente_id = @studente_id";

			cmd.Parameters.AddWithValue("@studente_id", studenteID);

			using (var reader = cmd.ExecuteReader())
			{
				if (reader.Read())
				{
					biografia = reader.IsDBNull(0) ? "" : reader.GetString(0);

					if (!reader.IsDBNull(1))
					{
						fotoProfiloID = reader.GetInt32(1);
					}
				}
			}

			byte[] foto = getMateriale(fotoProfiloID);

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();

			return new object[] { biografia, foto };
		}
		catch (SqlException ex) {
			return cadutaConnessione<object[]>();
		}
    }

	public void salvaLinkENickname(int paginaID, string link)
	{
		codaVerificaUltimaOperazione.Push(() => false);
		codaRieffetuaUltimaOperazione.Push(() => salvaLinkENickname(paginaID, link));

		try
		{
			using SqlCommand cmd = new("INSERT INTO elenco_visibilita(pagina_id, link) VALUES (@pagina_id, @link)", connection);
			cmd.Parameters.AddWithValue("@pagina_id", paginaID);
			cmd.Parameters.AddWithValue("@link", link);
			cmd.ExecuteNonQuery();

			codaVerificaUltimaOperazione.Pop();
			codaRieffetuaUltimaOperazione.Pop();
		}
		catch (SqlException ex) {
			cadutaConnessione<object>();
		}
	}

}
