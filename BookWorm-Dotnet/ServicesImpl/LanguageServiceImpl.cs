using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class LanguageServiceImpl : ILanguageMasterService
    {
        private readonly BookWormDbContext _dbcontext;
        public LanguageServiceImpl(BookWormDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<LanguageMaster> AddLanguage(LanguageMaster language)
        {
            var lang = await _dbcontext.LanguageMasters.AddAsync(language);
            await _dbcontext.SaveChangesAsync();
            return language;
        }

        public async Task<List<LanguageMaster>> GetAllLanguages()
        {
            return await _dbcontext.LanguageMasters.ToListAsync();
        }

        public async Task<LanguageMaster> GetLanguageById(int id)
        {
            return await _dbcontext.LanguageMasters.FindAsync(id);
        }
    }
}
