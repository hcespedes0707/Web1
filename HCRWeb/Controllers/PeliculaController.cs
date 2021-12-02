using HCRWeb.Data;
using HCRWeb.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HCRWeb.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PeliculaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // /api/pelicula/usuario/3

        [HttpGet]
        [Route("usuario/{userId}")]
        public async Task<IActionResult> GetPeliculasUsuario([FromRoute] int userId)
        {
            List<Pelicula> peliculas =await _dbContext.Pelicula.Where(x => x.UsuarioId == userId).ToListAsync();

            return Ok(peliculas);





        }

        // /api/contacto/2
        [HttpGet]
        [Route("{peliculaId}")]
        public async Task<IActionResult> GetPeliculaById([FromRoute] int peliculaId)
        {
            var pelicula =
                await GetPeliculaByIdFromDb(peliculaId);
            if (pelicula != null)
            {
                return Ok(pelicula);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> InsertContacto([FromBody] Pelicula pelicula)
        {
            var usuario = await _dbContext.Usuario
                .Where(x => x.UsuarioId == pelicula.UsuarioId)
                .FirstOrDefaultAsync();

            if (usuario != null)
            {
                if (pelicula.ImagenId > 0)
                {
                    var img = await _dbContext.Imagen
                        .Where(x => x.ImagenId == pelicula.ImagenId)
                        .FirstOrDefaultAsync();
                   // img.Temporal = false;

                    pelicula.Imagen = img;
                    pelicula.ImagenId = img.ImagenId;

                    _dbContext.Imagen.Update(img);
                }


                pelicula.Usuario = usuario;
                await _dbContext.Pelicula.AddAsync(pelicula);
                await _dbContext.SaveChangesAsync();
                return Ok(pelicula);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContacto([FromBody] Pelicula pelicula)
        {
            var obj =
                await GetPeliculaByIdFromDb(pelicula.PeliculaId);

            Imagen oldImage = null;
            if (obj.ImagenId > 0)
            {
                oldImage = await _dbContext.Imagen
                    .Where(x => x.ImagenId == obj.ImagenId)
                    .FirstOrDefaultAsync();
            }
            Imagen newImage = null;
            if (pelicula.ImagenId > 0)
            {
                newImage = await _dbContext.Imagen
                    .Where(x => x.ImagenId == pelicula.ImagenId)
                    .FirstOrDefaultAsync();
            }

            if (oldImage != null && oldImage.ImagenId != pelicula.ImagenId)
            {
               // oldImage.Temporal = true;
                _dbContext.Imagen.Update(oldImage);
            }

            if (newImage != null)
            {
                //newImage.Temporal = false;
                _dbContext.Imagen.Update(newImage);
                obj.Imagen = newImage;
                obj.ImagenId = newImage.ImagenId;
            }
            else
            {
                obj.Imagen = null;
                obj.ImagenId = 0;
            }

            obj.NombrePelicula = pelicula.NombrePelicula;
            obj.Temporada = pelicula.Temporada;
            obj.Capitulo = pelicula.Capitulo;

            _dbContext.Pelicula.Update(obj);
            await _dbContext.SaveChangesAsync();
            return Ok(pelicula);
        }

        // api/contacto/2

        [HttpDelete]
        [Route("{peliculaId}")]
        public async Task<IActionResult> DeletePelicula([FromRoute] int peliculaId)
        {
            var pelicula = await GetPeliculaByIdFromDb(peliculaId);
            if (pelicula != null)
            {
                if (pelicula.ImagenId > 0)
                {
                    var img = await _dbContext.Imagen
                        .Where(x => x.ImagenId == pelicula.ImagenId)
                        .FirstOrDefaultAsync();
                   // img.Temporal = true;

                    _dbContext.Imagen.Update(img);
                }

                _dbContext.Pelicula.Remove(pelicula);
                await _dbContext.SaveChangesAsync();
                return Ok(true);
            }

            return BadRequest();
        }

        private async Task<Pelicula> GetPeliculaByIdFromDb(int peliculaId)
        {
            return await _dbContext.Pelicula
                .Where(x => x.PeliculaId == peliculaId)
                .FirstOrDefaultAsync();
        }

    }

}
