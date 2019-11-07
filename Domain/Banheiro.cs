using System.Collections.Generic;

namespace banheiro_livre.Domain
{
    public class Banheiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int Status { get; set; }

        public virtual ICollection<LimpezaBanheiro> LimpezaBanheiros { get; set; }
    }
}