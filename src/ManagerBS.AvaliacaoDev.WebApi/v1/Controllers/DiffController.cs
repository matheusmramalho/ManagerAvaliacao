using ManagerBS.AvaliacaoDev.Core.Commands;
using ManagerBS.AvaliacaoDev.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ManagerBS.AvaliacaoDev.WebApi.v1.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        [HttpPost("left")]
        public ActionResult<string> Left(DiffModel leftInput)
        {
            if (!ModelState.IsValid) return BadRequest("Formato inválido. Leia nosso arquivo Readme.");

            FileHelper.SaveData(leftInput.Data, "left");

            return Ok("Input \"left\" enviado com sucesso!");
        }

        [HttpPost("right")]
        public ActionResult<string> Right(DiffModel rightInput)
        {
            if (!ModelState.IsValid) return BadRequest("Formato inválido. Leia nosso arquivo Readme.");

            FileHelper.SaveData(rightInput.Data, "right");

            return Ok("Input \"right\" enviados com sucesso!");
        }

        [HttpGet]
        public ActionResult<ResultReport> Diff()
        {
            if (!ModelState.IsValid) return BadRequest();

            var response = new ResultReport();

            var leftFile = $"{Directory.GetCurrentDirectory()}\\inputs\\left";
            var rightFile = $"{Directory.GetCurrentDirectory()}\\inputs\\right";

            var fileComparer = new DataComparer();
            
            // Verifica se os dados são de diferente tamanho.
            if (!fileComparer.CompareLenght(leftFile, rightFile))
                response.Report = ReportEnum.DadosDiferentes;

            // Comparar cada byte, já que são do mesmo tamanho.
            response = fileComparer.CompareBytes(leftFile, rightFile);

            return Ok(response);
        }
    }
}