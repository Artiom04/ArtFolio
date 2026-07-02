using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFolio;
internal class CadutaConnessioneControl
{
	public CadutaConnessioneControl()
	{
		bool pong = false;

		for(int i = 0; i < 4 && !pong; ++i)
		{
			pong = DBMSBoundary.get().ping();
		}

		if (pong) {
			if(!DBMSBoundary.get().verificaUltimaOperazione())
			{
				DBMSBoundary.get().rieffetuaUltimaOperazione();
			}
		}
		else
		{
			new MessageBoundary().mostra("la conessione con il DBMS è caduta");

			Process.Start(Environment.ProcessPath!);//
			Environment.Exit(0);                   //per mostrare la schermata iniziale
		}
	}
}

