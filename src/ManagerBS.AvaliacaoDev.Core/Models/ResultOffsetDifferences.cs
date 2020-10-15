using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerBS.AvaliacaoDev.Core.Models
{
    /// <summary>
    /// Model para identificar a posição e diferença binária de um arquivo para o outro.
    /// </summary>
    public class ResultOffsetDifferences
    {
        public ResultOffsetDifferences(int position, byte byteLeftValue, byte byteRightValue)
        {
            this.position = position;
            this.byteLeftValue = byteLeftValue;
            this.byteRightValue = byteRightValue;
        }

        /// <summary>
        /// Posição do array de byte.
        /// </summary>
        public int position { get; set; }

        /// <summary>
        /// Valor do primeiro arquivo, ou arquivo left.
        /// </summary>
        public byte byteLeftValue { get; set; }

        /// <summary>
        /// Valor do segundo arquivo, ou arquivo right.
        /// </summary>
        public byte byteRightValue { get; set; }
    }
}
