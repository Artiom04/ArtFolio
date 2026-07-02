namespace ArtFolio;
internal class MessageRequestBoundary
{
	public bool mostra(string testo)
	{
		return MessageBox.Show(testo, "", MessageBoxButtons.OKCancel) == DialogResult.OK;
	}
}
