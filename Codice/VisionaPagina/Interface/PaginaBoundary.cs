using ArtFolio.VisualizzaContenutoMultimediale.Interface;
using ArtFolio.VisionaPagina.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtFolio.VisionaPagina.Interface;
public partial class PaginaBoundary : Form
{
	public PaginaBoundary()
	{
		instance = this;
		InitializeComponent();
	}

	private static PaginaBoundary instance;

	public static PaginaBoundary get() { return instance ?? new(); }

	private void PaginaBoundary_Load(object sender, EventArgs e)
	{

	}

	private bool modifica = false;

	public void abilitaModifica() { modifica = true; }

	public void mostra()
	{
		if (Visible) return;
		ShowDialog();
	}

	private void cliccaElimina(int postID)
	{
		ArtFolio.VisionaPagina.Control.PaginaControl.get().cliccaElimina(postID);
	}

	private void cliccaSposta(int postID)
	{
		ArtFolio.VisionaPagina.Control.PaginaControl.get().cliccaSposta(postID);
	}

	private event EventHandler _abilitaRegioneIntraPost;
	private event EventHandler _disabilitaRegioneIntraPost;

	public void abilitaRegioniIntraPost()
	{
		_abilitaRegioneIntraPost.Invoke(this, EventArgs.Empty);
	}

	public void disabilitaRegioniIntraPost()
	{
		_disabilitaRegioneIntraPost?.Invoke(this, EventArgs.Empty);
	}

	private void cliccaRegione(int p)
	{
		ArtFolio.VisionaPagina.Control.PaginaControl.get().cliccaRegione(p);
	}

	public void spostaPostCorrente(int newPosition)
	{
		int curr_pos = flowLayoutPanel1.Controls.IndexOf(postCorrente) / 2;

		flowLayoutPanel1.SuspendLayout();

		List<System.Windows.Forms.Control> list = new();

		for (int i = 1; i < flowLayoutPanel1.Controls.Count; i += 2)
		{
			list.Add(flowLayoutPanel1.Controls[i]);
		}

		flowLayoutPanel1.Controls.Clear();

		(list[curr_pos], list[newPosition]) = (list[newPosition], list[curr_pos]);

		foreach (var control in list)
		{
			flowLayoutPanel1.Controls.Add(createIntraRegion());
			flowLayoutPanel1.Controls.Add(control);
		}

		flowLayoutPanel1.ResumeLayout();


	}

	private PostBoundary? postCorrente = null;

	public void eliminaPostCorrente()
	{
		if (postCorrente == null) return;

		flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.IndexOf(postCorrente) - 1); // rimuove la post_region
		flowLayoutPanel1.Controls.Remove(postCorrente);
		postCorrente = null;
	}

	private System.Windows.Forms.Control createIntraRegion()
	{
		System.Windows.Forms.Control result = new();
		result.BackColor = Color.Empty;
		//result.Width = 10;
		result.Height = 10;
		result.Anchor = AnchorStyles.Left | AnchorStyles.Right;

		result.Click += (s, e) =>
		{
			if (result.BackColor != Color.Empty)
			{
				cliccaRegione(flowLayoutPanel1.Controls.IndexOf(result) / 2);
			}
		};

		_abilitaRegioneIntraPost += (s, e) =>
		{
			result.BackColor = Color.Blue;
		};

		_disabilitaRegioneIntraPost += (s, e) =>
		{
			result.BackColor = Color.Empty;
		};

		return result;
	}

	public void setContent(List<object> content)
	{
		while (content.Count() > 0)
		{
			int postID = (int)content.First(); content.RemoveAt(0);
			string descrizione = (string)content.First(); content.RemoveAt(0);

			PostBoundary pb = new();
			pb.setPostId(postID);
			pb.setDescrizione(descrizione);
			pb.eliminaBtn.Click += (s, e) =>
			{
				postCorrente = pb;
				cliccaElimina(postID);
			};
			pb.riordinaBtn.Click += (s, e) =>
			{
				postCorrente = pb;
				cliccaSposta(postID);
			};

			if (!modifica)
			{
				pb.eliminaBtn.Hide();
				pb.riordinaBtn.Hide();
			}

			while (content.Count > 0 && content.First() != null)
			{
				int materialeID = (int)content.First(); content.RemoveAt(0);
				string nomeMateriale = (string)content.First(); content.RemoveAt(0);
				byte[] data = (byte[])content.First(); content.RemoveAt(0);

				MiniaturaContenutoMultimedialeBoundary mcmb = new();
				mcmb.setMaterialeID(materialeID);
				mcmb.setNomeMateriale(nomeMateriale);

				if (nomeMateriale.EndsWith(".pdf"))
				{
					mcmb.setPdfImage();
				}
				else if (nomeMateriale.EndsWith(".mp3"))
				{
					mcmb.setAudioImage();
				}
				else if (data != null)
				{
					mcmb.setImage(data);
				}
				else
				{
					mcmb.setVideoImage();
				}

				pb.addMateriale(mcmb);
			}

			content.RemoveAt(0);
			pb.Width = flowLayoutPanel1.Width;
			this.Load += (s, e) =>
			{
				pb.Width = flowLayoutPanel1.Width;
				//pb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			};
			flowLayoutPanel1.SizeChanged += (s, e) => { pb.Width = flowLayoutPanel1.Width; };
			flowLayoutPanel1.Controls.Add(createIntraRegion());
			flowLayoutPanel1.Controls.Add(pb);
		}

	}

	private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
	{

	}
}
