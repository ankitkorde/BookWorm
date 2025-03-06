using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageMasterController : ControllerBase
    {
        private readonly ILanguageMasterService _languageService;

        public LanguageMasterController(ILanguageMasterService languageService)
        {
            _languageService = languageService;
        }

        // GET: api/LanguageMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageMaster>>> GetAllLanguages()
        {
            var languages = await _languageService.GetAllLanguages();
            return Ok(languages);
        }

        // GET: api/LanguageMaster/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageMaster>> GetLanguageById(int id)
        {
            var language = await _languageService.GetLanguageById(id);
            if (language == null)
            {
                return NotFound(new { message = "Language not found" });
            }
            return Ok(language);
        }

        // POST: api/LanguageMaster
        [HttpPost]
        public async Task<ActionResult<LanguageMaster>> AddLanguage(LanguageMaster language)
        {
            if (language == null)
            {
                return BadRequest(new { message = "Invalid language data" });
            }

            var newLanguage = await _languageService.AddLanguage(language);
            return CreatedAtAction(nameof(GetLanguageById), new { id = newLanguage.LanguageId }, newLanguage);
        }
    }
}
