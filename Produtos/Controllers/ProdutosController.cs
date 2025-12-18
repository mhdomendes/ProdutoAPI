using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.DTOs;
using ProdutoAPI.Services;

namespace ProdutoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CreateProdutoDto dto)
        {
            var produto = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);
        }
        
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _service.ListarAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await _service.ObterPorIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, UpdateProdutoDto dto)
        {
            await _service.AtualizarAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _service.ExcluirAsync(id);
            return NoContent();
        }

    }
}
