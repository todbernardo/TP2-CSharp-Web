using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicios.Pages
{
    public class SaveNoteModel : PageModel
    {
        public class InputModel
        {
            [Required]
            public string Content { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string Caminho { get; set; }
        public List<string>
    Arquivos
        { get; set; } = new();
        public string ConteudoVisualizado { get; set; }
        public string NomeSelecionado { get; set; }

        public void OnGet(string file = null)
        {
            string pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            Arquivos = Directory.GetFiles(pasta, "*.txt")
            .Select(Path.GetFileName)
            .ToList();

            if (!string.IsNullOrEmpty(file))
            {
                string caminhoArquivo = Path.Combine(pasta, file);

                if (System.IO.File.Exists(caminhoArquivo))
                {
                    NomeSelecionado = file;
                    ConteudoVisualizado = System.IO.File.ReadAllText(caminhoArquivo);
                }
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string nomeArquivo = $"note_{timestamp}.txt";

                string pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }
                string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (StreamWriter writer = new(caminhoCompleto))
                {
                    writer.WriteLine(Input.Content);
                }
                Caminho = $"/files/{nomeArquivo}";

                Arquivos = Directory.GetFiles(pasta, "*.txt")
                .Select(Path.GetFileName)
                .ToList();
            }
        }
    }
}