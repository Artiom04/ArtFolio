namespace ArtFolio.Utils;

internal class FileSelectionBoundary
{
	private OpenFileDialog op = new OpenFileDialog();
	private string? file="";

	public void mostra() {
		op.Multiselect = false;
		if (op.ShowDialog() == DialogResult.OK) {
			file = op.FileName;
		} else
		{
			file = null;
		}
	}

	public string? getFile() { return file; }


}

