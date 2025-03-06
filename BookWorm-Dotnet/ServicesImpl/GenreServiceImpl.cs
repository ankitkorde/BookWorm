using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class GenreServiceImpl : IGenreService
    {
        private readonly BookWormDbContext _dbContext;

        public GenreServiceImpl(BookWormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GenreMaster>> GetAllGenres()
        {
            return await _dbContext.GenreMasters.ToListAsync();
        }

        public async Task<GenreMaster> GetGenreById(int id)
        {
            return await _dbContext.GenreMasters.FindAsync(id);
        }

        public async Task<GenreMaster> AddGenre(GenreMaster genre)
        {
            var addedGenre = await _dbContext.GenreMasters.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
            return addedGenre.Entity;
        }
    }
}
