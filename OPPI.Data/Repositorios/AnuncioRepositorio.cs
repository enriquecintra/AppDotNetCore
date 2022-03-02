using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios
{
    public class AnuncioRepositorio : Repositorio<Anuncio>, IAnuncioRepositorio
    {
        public AnuncioRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public new async Task<Anuncio> ObterCompleto(object id)
        {
            return await _dbContext.Anuncio
                    .AsNoTracking()
                    .Include(i => i.AnuncioFotos).ThenInclude(i => i.Foto)
                    .FirstOrDefaultAsync(u => u.Id == Convert.ToInt32(id));
        }

        public new async Task<IEnumerable<Anuncio>> ListarCompleto()
        {
            return await _dbContext.Anuncio
                    .AsNoTracking()
                    .Include(i => i.AnuncioFotos).ThenInclude(i => i.Foto)
                    .ToListAsync();
        }
    }
}
