using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Infra.Db;
using WebApi.Model;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerfilController(DbCtx ctx) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostPerfil([FromBody] Perfil perfil)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await ctx.Perfis.AddAsync(perfil);
        await ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPerfis([FromQuery] int id)
    {
        var perfis = await ctx.Perfis.ToListAsync();
        return Ok(perfis);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPerfilById([FromRoute] int id)
    {
        var perfil = await ctx.Perfis.FirstOrDefaultAsync(p => p.Id == id);
        if (perfil is null)
        {
            return NotFound($"Não foi encontrado perfil com id {perfil!.Id}");
        }

        return Ok(perfil);
    }

    [HttpPatch]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdatePerfil(int id, Perfil perfil)
    {
        var perfilExistente = await ctx.Perfis.FirstOrDefaultAsync(p => p.Id == id);

        if (perfilExistente is null)
        {
            return NotFound("perfil para atualizar não existe");
        }

        perfilExistente.LoginUsuario = perfil.LoginUsuario;
        perfilExistente.Email = perfil.Email;
        perfilExistente.NomeUsuario = perfil.NomeUsuario;

        await ctx.SaveChangesAsync();
        return Ok(perfilExistente);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeletePerfil(int id)
    {
        var perfilDeletado = await ctx.Perfis.FirstOrDefaultAsync(p => p.Id == id);

        if (perfilDeletado is null)
        {
            return NotFound("não foi encontrado o perfil");
        }

        ctx.Perfis.Remove(perfilDeletado);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}