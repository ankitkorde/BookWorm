using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface ILanguageMasterService
    {
        public Task<LanguageMaster> AddLanguage(LanguageMaster language);
        public Task<LanguageMaster> GetLanguageById(int id);
        public Task<List<LanguageMaster>> GetAllLanguages();
    }
}
