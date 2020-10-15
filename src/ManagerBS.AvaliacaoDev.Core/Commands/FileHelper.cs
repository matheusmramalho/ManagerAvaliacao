using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManagerBS.AvaliacaoDev.Core.Commands
{
    /// <summary>
    /// Classe responsável por trabalhar com leitura e escrita de arquivos.
    /// </summary>
    public static class FileHelper
    {
        public static void SaveData(string input, string name )
        {
            TextWriter writer;
            var currentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists($"{currentPath}\\inputs")) Directory.CreateDirectory($"{currentPath}\\inputs");
            using (writer = new StreamWriter($"{currentPath}\\inputs\\{name}", append: false))
            {
                writer.WriteLine(input);
            }
        }

    }
}