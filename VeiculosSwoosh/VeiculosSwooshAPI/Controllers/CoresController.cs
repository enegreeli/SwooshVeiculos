using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosSwooshAPI.Data;
using VeiculosSwooshAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace VeiculosSwooshAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoresController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db; // Injeção de dependência do contexto do banco de dados

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Cores.ToList()); // Retorna todos os registros da tabela Cores do banco de dados
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cor = _db.Cores.Find(id); // Busca um registro específico pelo ID
            if (cor == null)
                return NotFound(); // Retorna 404 se o registro não for encontrado
            return Ok(cor); // Retorna o registro encontrado
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cor cor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fora dos padrões do banco"); // Retorna 400 se o modelo não for válido
            _db.Cores.Add(cor); // Adiciona o novo registro ao contexto
            _db.SaveChanges(); // Salva as alterações no banco de dados
            return CreatedAtAction(nameof(Get), new { id = cor.Id }, cor); // Retorna 201 com o novo registro criado
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cor cor)
        {
            if (!ModelState.IsValid || id != cor.Id)
                return BadRequest("Fora dos padrões do banco"); // Retorna 400 se o modelo não for válido
            _db.Cores.Update(cor); // Atualiza o registro no contexto
            _db.SaveChanges(); // Salva as alterações no banco de dados
            return NoContent(); // Retorna 204 sem conteúdo
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cor = _db.Cores.Find(id); // Busca o registro pelo ID
            if (cor == null)
                return NotFound(); // Retorna 404 se o registro não for encontrado
            _db.Cores.Remove(cor); // Remove o registro do contexto
            _db.SaveChanges(); // Salva as alterações no banco de dados
            return NoContent(); // Retorna 204 sem conteúdo
        }

    }
}