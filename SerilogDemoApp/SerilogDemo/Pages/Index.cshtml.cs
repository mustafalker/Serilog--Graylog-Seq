using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Bu index e istek gönderdiniz. ");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                    {
                        throw new Exception("Bu benim deneme exceptionumdur.");
                    }
                    else
                    {
                        _logger.LogInformation("Buradaki değer yani i is {LoopCountValue}", i);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bu indexe istek atarken bir hata ile karşılaşıldı.");
            }
        }
    }
}