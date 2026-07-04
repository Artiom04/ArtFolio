using ArtFolio.GestioneMateriale.Control;

namespace ArtFolio.GestioneMateriale.Interface;
public partial class SchermataGestioneMaterialeBoundary : Form
{
	private static SchermataGestioneMaterialeBoundary? instance;
	public SchermataGestioneMaterialeBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	public static SchermataGestioneMaterialeBoundary get()
	{
		return instance ?? new SchermataGestioneMaterialeBoundary();
	}

	private void SchermataGestioneMaterialeBoundary_Load(object sender, EventArgs e)
	{

	}

	public IEnumerable<int> getIDMaterialiSelezionati()
	{
		List<int> result = new();

		for (int i = 0; i < elencoMateriali.SelectedRows.Count; i++)
		{
			result.Add(Convert.ToInt32(elencoMateriali.SelectedRows[i].Cells[0].Value));
		}

		return result;
	}

	public void mostra() { ShowDialog(); }

	public void setFilterParams(DateTime filterLowerDate, DateTime filterUpperDate, string filterType, string filterName)
	{
		this.filterType.Text = filterType;
		if(filterLowerDate != DateTime.MinValue) this.filterLowerDate.Value = filterLowerDate;
		if (filterUpperDate != DateTime.MaxValue) this.filterUpperDate.Value = filterUpperDate;
		this.filterName.Text = filterName;
	}

	public void setElencoMateriali(IEnumerable<string> materiales)
	{
		elencoMateriali.Rows.Clear();
		foreach (var material in materiales)
		{
			elencoMateriali.Rows.Add(material.Split("|"));
		}
	}

	public void aggiungiMateriale(int materialeID, string file)
	{
		FileInfo info = new FileInfo(file);
		elencoMateriali.Rows.Add(new object[] { materialeID, info.Name, DateTime.Now });
	}

	public void rimuoviMateriali(IEnumerable<int> materialiID)
	{
		foreach (var id in materialiID)
		{
			for (int i = 0; i < elencoMateriali.Rows.Count; i++)
			{
				if (Convert.ToInt32(elencoMateriali.Rows[i].Cells[0].Value) == id)
				{
					elencoMateriali.Rows.RemoveAt(i);
					break;
				}
			}
		}
	}

	private void cliccaCarica(object sender, EventArgs e)
	{
		GestioneMaterialeControl.get().cliccaCarica();
	}

	private void cliccaElimina(object sender, EventArgs e)
	{
		GestioneMaterialeControl.get().cliccaElimina();
	}

	private void filterLowerDate_DataContextChanged(object sender, EventArgs e)
	{

	}

	private void filterUpperDate_DataContextChanged(object sender, EventArgs e)
	{

	}

	private void cliccaFiltraDate(object sender, EventArgs e)
	{
		GestioneMaterialeControl.get().cliccaFitraDate();
	}

	public DateTime[] getDateFiltro()
	{
		return new DateTime[] { filterLowerDate.Value, filterUpperDate.Value };
	}

	private void cliccaFitraTipologia(object sender, EventArgs e)
	{
		GestioneMaterialeControl.get().cliccaFitraTipologia();
	}

	private void cliccaFitraNome(object sender, EventArgs e)
	{
		GestioneMaterialeControl.get().cliccaFitraNome();
	}

	public string getFiltroNome()
	{
		return this.filterName.Text;
	}

	public string getTipologiaFile()
	{
		return this.filterType.Text;
	}

	private void elencoMateriali_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{

	}

	private void cliccaScarica(object sender, EventArgs e)
	{
		GestioneMaterialeControl.get().cliccaScarica();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		this.DialogResult = DialogResult.Cancel;
		this.Close();
	}

	private void cliccaFatto(object sender, EventArgs e)
	{
		this.DialogResult = DialogResult.OK;
		this.Close();
	}
}
