using ArtFolio.GestioneAccount.Control;
using ArtFolio.AccessoPagina.Control;
namespace ArtFolio.GestioneAccount.Interface;

public partial class SchermataInizialeBoundary : Form
{
	public SchermataInizialeBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	private static SchermataInizialeBoundary? instance;
	public static SchermataInizialeBoundary get()
	{
		return instance ?? new SchermataInizialeBoundary();
	}

	private void cliccaRegistrazione(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaRegistrazione();
	}

	private void cliccaCercaStudenti(object sender, EventArgs e)
	{
		new AccessoPaginaControl();
	}

	private void SchermataHomeBoundary_Load(object sender, EventArgs e)
	{
			
	}

	private void cliccaLogin(object sender, EventArgs e)
	{
		GestioneAccountControl.get().cliccaLogin();
	}

	public string[] getCredenziali() { return new string[] { nicknameTextBox.Text, passwordTextBox.Text }; }
    public void mostra() {
		if (Visible) return;
		ShowDialog();
	}
}
