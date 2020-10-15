using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerBS.AvaliacaoDev.Core.Models
{
    /// <summary>
    /// Relatório com o resultado da comparação de dois arquivos.
    /// </summary>
    public class ResultReport
    {
        /// <summary>
        /// Lista da posição e valor da diferença nos arquivos binário.
        /// </summary>
        public IEnumerable<ResultOffsetDifferences> OffsetDifferences { get; set; }
        
        /// <summary>
        /// Tamanho dos arquivo.
        /// </summary>
        public long? FileSize { get; set; }
        /// <summary>
        /// Relatório com o resultado da comparação.
        /// </summary>
        public string Report { get; set; }
    }

    public static class ReportEnum
    {
        public static String DadosIguais { get { return "Os arquivos são identicos."; } }
        public static String DadosDiferentes { get { return "Arquivos são diferentes, há diferença nos tamanhos."; } }
    }
}
