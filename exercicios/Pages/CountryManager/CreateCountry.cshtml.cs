using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ex1.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string Texto { get; set; }
        [BindProperty]
        public List<InputModel> Paises { get; set; } = new List<InputModel>();
        public List<InputModel> PaisesEnviados { get; set; } = new List<InputModel>();

        public void OnGet()
        {
            for (int i = 0; i < 5; i++)
            {
                Paises.Add(new InputModel());
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                PaisesEnviados = Paises;
            }
        }
    }
    public class InputModel
    {
        [Required(ErrorMessage = "Campo não pode estar vazio")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Campo não pode estar vazio")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Digite apenas duas letras")]
        public string CountryCode { get; set; }
    }
}
