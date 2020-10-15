using ManagerBS.AvaliacaoDev.Core.Commands;
using ManagerBS.AvaliacaoDev.Core.Models;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace ManagerBS.AvaliacaoDev.Tests
{
    /// <summary>
    /// Classe para teste do método CompareBytes
    /// </summary>
    public class CompararDoisDados
    {
        [Fact]
        public void RetornaReportDadosIguaisParaDadosIguais()
        {
            // Arranje
            var guid = Guid.NewGuid();
            var nameLeft = $"left-test-{guid}";
            var nameRight = $"right-test-{guid}";

            FileHelper.SaveData("dGlueQ==", nameLeft);
            FileHelper.SaveData("dGlueQ==", nameRight);
            var dc = new DataComparer();

            var leftData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameLeft}";
            var rightData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameRight}";

            // Act
            var result = dc.CompareBytes(leftData, rightData);

            // Assert
            Assert.True(result.Report == ReportEnum.DadosIguais);
        }

        [Fact]
        public void RetornaReportComOffsetsParaDadosDiferentesComMesmoTamanho()
        {
            // Arranje
            var guid = Guid.NewGuid();
            var nameLeft = $"left-test-{guid}";
            var nameRight = $"right-test-{guid}";

            FileHelper.SaveData("dGlueQ==", nameLeft);
            FileHelper.SaveData("dGlxeQ==", nameRight);
            var dc = new DataComparer();

            var leftData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameLeft}";
            var rightData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameRight}";

            // Act
            var result = dc.CompareBytes(leftData, rightData);

            // Assert
            Assert.True(result.OffsetDifferences.Any());
        }
    }
}
