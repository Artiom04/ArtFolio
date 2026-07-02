namespace ArtFolio;
public partial class SchermataGestionePaginaBoundary : Form
{
	private static SchermataGestionePaginaBoundary? instance;
	public SchermataGestionePaginaBoundary()
	{
		instance = this;
		InitializeComponent();

	}

	public static SchermataGestionePaginaBoundary get()
	{
		return instance ?? new SchermataGestionePaginaBoundary();

	}

	public void setElencoPagine(IEnumerable<string> elencoPagine)
	{
		this.elencoPagine.Rows.Clear();
		foreach (var pagina in elencoPagine)
		{
			this.elencoPagine.Rows.Add(pagina.Split("|"));
		}
	}

	public void mostra()
	{
		if (Visible) return;
		ShowDialog();
	}


	private void cliccaCreaPagina(object sender, EventArgs e)
	{
		GestionePaginaControl.get().cliccaCreaPagina();
	}

	private void cliccaRinomina(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaRinomina();
	}

	public int getPaginaSelezionataID()
	{
		return Convert.ToInt32(elencoPagine.SelectedRows[0].Cells[0].Value);
	}

	public string getNomePaginaSelezionata()
	{
		return Convert.ToString(elencoPagine.SelectedRows[0].Cells[1].Value);
	}

	private void cliccaElimina(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaElimina();
	}

	public void setNomePagina(string nuovoNomePagina, string nomePagina)
	{
		for (int i = 0; i < elencoPagine.Rows.Count; i++)
		{
			if (elencoPagine.Rows[i].Cells[1].Value.ToString() == nomePagina)
			{
				elencoPagine.Rows[i].Cells[1].Value = nuovoNomePagina;
				break;
			}
		}
	}

	public void addPagina(string nomeNuovaPagina, int paginaID)
	{
		elencoPagine.Rows.Add(new object[] { paginaID, nomeNuovaPagina, false });
	}

	private void SchermataGestionePaginaBoundary_Load(object sender, EventArgs e)
	{

	}

	public void rendiPaginaPrivata(int paginaID)
	{
		for (int i = 0; i < elencoPagine.Rows.Count; i++)
		{
			if (Convert.ToInt32(elencoPagine.Rows[i].Cells[0].Value) == paginaID)
			{
				elencoPagine.Rows[i].Cells[2].Value = false;
				break;
			}
		}
	}

	public void rendiPaginaPubblica(int paginaID)
	{
		for (int i = 0; i < elencoPagine.Rows.Count; i++)
		{
			if (Convert.ToInt32(elencoPagine.Rows[i].Cells[0].Value) == paginaID)
			{
				elencoPagine.Rows[i].Cells[2].Value = true;
				break;
			}
		}
	}

	public void rimuoviPaginaDaElenco(int paginaID)
	{
		for (int i = 0; i < elencoPagine.Rows.Count; i++)
		{
			if (Convert.ToInt32(elencoPagine.Rows[i].Cells[0].Value) == paginaID)
			{
				elencoPagine.Rows.RemoveAt(i);
				break;
			}
		}
	}

	private void cliccaClona(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaClona();
	}

	public IEnumerable<string> getElencoNomiPagine()
	{
		List<string> result = new();
		for (int i = 0; i < elencoPagine.Rows.Count; i++)
		{
			result.Add((string)elencoPagine.Rows[i].Cells[1].Value);
		}
		return result;
	}

	private void cliccaMostraVisualizzatori(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaMostraVisualizzatori();
	}

	private void cliccaElencoVisibilità(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaElencoVisibilità();
	}

	private void cliccaRendiPubblica(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaRendiPubblica();
	}

	private void cliccaRendiPrivata(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaRendiPrivata();
	}

	private void cliccacreaPost(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaCreaPost();
	}

	private void cliccaVisita(object sender, EventArgs e)
	{
		if (elencoPagine.SelectedRows.Count != 1) return;
		GestionePaginaControl.get().cliccaVisitaPagina();
	}
}
