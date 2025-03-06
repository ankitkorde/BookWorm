using BookWorm_Dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public interface IGenreService
    {
        Task<List<GenreMaster>> GetAllGenres();
        Task<GenreMaster> GetGenreById(int id);
        Task<GenreMaster> AddGenre(GenreMaster genre);
    }
}
