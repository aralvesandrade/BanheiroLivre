using System.ComponentModel.DataAnnotations;

namespace banheiro_livre.ViewModel
{
    public class ViewModelBanheiro
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Ativo { get; set; }
    }
}