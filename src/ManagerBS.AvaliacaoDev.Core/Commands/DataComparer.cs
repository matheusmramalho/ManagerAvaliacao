using ManagerBS.AvaliacaoDev.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ManagerBS.AvaliacaoDev.Core.Commands
{
    /// <summary>
    /// Classe responsável para comparação de dados.
    /// </summary>
    public class DataComparer
    {
        /// <summary>
        /// Verifica se os dados de entrada tem o mesmo tamanho.
        /// </summary>
        /// <param name="left">Primeiro dado</param>
        /// <param name="right">Segundo dado</param>
        /// <returns>Retorna verdadeiro caso tenham o mesmo tamanho</returns>
        public bool CompareLenght(string left, string right)
        {
            var leftData = OpenFile(left);
            var rightData = OpenFile(right);

            // Comparação do tamanho dos arquivos.
            if (leftData.Length != rightData.Length)
                return false; // Arquivos diferentes.

            return true;
        }

        /// <summary>
        /// Compara dois arquivos de mesmo tamanho.
        /// </summary>
        /// <param name="left">Primeiro dado</param>
        /// <param name="right">Segundo dado</param>
        /// <returns>Relatório da diferença dos bytes com suas posições ou se são iguais</returns>
        public ResultReport CompareBytes(string left, string right)
        {
            var result = new ResultReport();
            var resultOffset = new List<ResultOffsetDifferences>();

            var leftData = OpenFile(left);
            var rightData = OpenFile(right);

            // Percorre os bytes para comparação dos dados.
            for (int i = 0; i < leftData.Length; i++)
            {
                // Atribui o byte do primeiro arquivo.
                var byte1 = leftData[i];

                // Atribui o byte do segundo arquivo.
                var byte2 = rightData[i];

                // Se achar um Byte diferente, adiciona ao resultado com a posição e os valores.
                if (byte1 != byte2)
                {
                    resultOffset.Add(new ResultOffsetDifferences(i, byte1, byte2));
                }
            }
            
            result.OffsetDifferences = resultOffset;
            result.FileSize = leftData.Length;

            // Caso não encontre offsets, os dados comparados são iguais.
            if (!result.OffsetDifferences.Any())
                result.Report = ReportEnum.DadosIguais;

            return result;
        }

        /// <summary>
        /// Método que prepara os arquivos para comparação.
        /// </summary>
        private byte[] OpenFile(string path)
        {
            string dataString;
            
            // Abre o arquivo.
            using (var sr = new StreamReader(path))
            {
                dataString = sr.ReadToEnd();
                sr.Close();
            }
            
            return Convert.FromBase64String(dataString);
        }
    }
}
