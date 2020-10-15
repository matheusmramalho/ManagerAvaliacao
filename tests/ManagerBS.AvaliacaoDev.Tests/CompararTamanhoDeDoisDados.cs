using ManagerBS.AvaliacaoDev.Core.Commands;
using System;
using System.IO;
using Xunit;

namespace ManagerBS.AvaliacaoDev.Tests
{
    /// <summary>
    /// Classe para teste do método CompareLenght
    /// </summary>
    public class CompararTamanhoDeDoisDados
    {
        [Fact]
        public void RetornarTrueParaArquivosComMesmoTamanho()
        {
            // Arranje
            var guid = Guid.NewGuid(); var nameLeft = $"left-test-{guid}";
            var nameRight = $"right-test-{guid}";

            FileHelper.SaveData("dGlueQ==", nameLeft);
            FileHelper.SaveData("dGlueQ==", nameRight);
            var dc = new DataComparer();
            
            var leftData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameLeft}";
            var rightData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameRight}";

            // Act
            var result = dc.CompareLenght(leftData, rightData);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RetornaFalseParaArquivosComTamanhoDiferente()
        {
            // Arranje
            var guid = Guid.NewGuid();
            var nameLeft = $"left-test-{guid}";
            var nameRight = $"right-test-{guid}";
            
            FileHelper.SaveData("dGlueQ==", nameLeft );
            FileHelper.SaveData("ZmlsZXR3bw==", nameRight);
            var dc = new DataComparer();

            var leftData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameLeft}";
            var rightData = $"{Directory.GetCurrentDirectory()}\\inputs\\{nameRight}";

            // Act
            var result = dc.CompareLenght(leftData, rightData);

            // Assert
            Assert.False(result);
        }
    }
}
