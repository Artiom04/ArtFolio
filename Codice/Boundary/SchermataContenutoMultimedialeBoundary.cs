using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtFolio;

public partial class SchermataContenutoMultimedialeBoundary : Form
{
	public SchermataContenutoMultimedialeBoundary()
	{
		InitializeComponent();
	}

	private void SchermataContenutoMultimedialeBoundary_Load(object sender, EventArgs e)
	{
		webView21.EnsureCoreWebView2Async();
	}

	private string path = "";

	public void setContent(string nome, byte[] data)
	{
		path = Path.GetTempPath() + Path.GetRandomFileName() + nome;
		File.WriteAllBytes(path, data);
	}

	public void mostra() { Show(); }

	private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
	{
		webView21.CoreWebView2.Navigate($"file://{path}");
	}
}
