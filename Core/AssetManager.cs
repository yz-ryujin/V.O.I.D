using System;
using System.IO;
using Spectre.Console;

namespace Void.Core // Use o mesmo namespace do seu projeto
{
    public static class AssetManager
    {
        public static string[] Load(string fileName)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Assets", fileName);

            // --- LINHA DE DEPURAÇÃO ADICIONADA ---
            // Esta linha vai nos dizer o caminho exato que o programa está usando.
            AnsiConsole.MarkupLine($"[yellow]Tentando carregar asset do caminho:[/] [grey]{path}[/]");

            if (!File.Exists(path))
            {
                AnsiConsole.MarkupLine($"[bold red]Erro Fatal: O arquivo de asset '{fileName}' não foi encontrado.[/]");
                AnsiConsole.MarkupLine("[bold red]Verifique se o arquivo existe e se a propriedade 'Copiar para Diretório de Saída' está como 'Copiar se for mais novo'.[/]");
                Environment.Exit(1); 
                return null;
            }
            
            return File.ReadAllLines(path);
        }
    }
}