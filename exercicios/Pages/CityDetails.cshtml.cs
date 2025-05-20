using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicios.Pages
{
    public class CityDetailsModel : PageModel
    {
        public string CityName { get; set; }

        public List<string> Cities { get; set; } = ["Rio", "São Paulo", "Brasília"];

        public void OnGet(string cityName)
        {
            CityName = cityName ?? "Nenhuma cidade selecionada";
        }
    }
}