using System.Diagnostics;
using ArtFolio.AccessoPagina.Control;
using ArtFolio.GestioneAccount.Interface;

namespace ArtFolio;
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        if(Environment.GetCommandLineArgs().Length > 1)
        {
			var current = Process.GetCurrentProcess();

			foreach (var p in Process.GetProcessesByName(current.ProcessName))
			{
				if (p.Id != current.Id)
				{
					p.Kill();
				}
			}

			new AccessoPaginaViaLinkControl().richiesta(Environment.GetCommandLineArgs()[1]);
        }
        else
        {
			Application.Run(new SchermataInizialeBoundary());
		}
            
    }
}