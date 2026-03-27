

using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ModelsAPI;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext ctx;
    public ProdutoController(AppDbContext context){
        ctx = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync(){
        var produtos = ctx.Produtos.AsNoTracking().ToListAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "GetProdByID")]
    public async Task<ActionResult<Produto>> GetByIdAsync(int id)
    {
        var produto = await ctx.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> CreatAsync(Produto produto)
    {
        ctx.Produtos.Add(produto);
        await ctx.SaveChangesAsync();
        
        return CreatedAtRoute("GetProdByID", new {id = produto.Id}, produto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Produto Produto){
        if(id != Produto.Id) return BadRequest("Id do corpo diferente do parâmetro");

        var existe = await ctx.Produtos.FindAsync(id);
        if(existe is null) return NotFound();

        ctx.Entry(Produto).State = EntityState.Modified;

        await ctx.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id){
        var Produto = await ctx.Produtos.FindAsync(id);
        if(Produto is null) return NotFound();

        ctx.Produtos.Remove(Produto);
        await ctx.SaveChangesAsync();

        return NoContent();
    }
}