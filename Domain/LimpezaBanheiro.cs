using System;

namespace banheiro_livre.Domain
{
    public class LimpezaBanheiro
    {
        public int Id { get; set; }
        public int BanheiroId { get; set; }
        public string Dia { get; set; }
        public int Servico { get; set; }
        public DateTime ManhaInicio { get; set; }
        public DateTime ManhaFinal { get; set; }
        public DateTime TardeInicio { get; set; }
        public DateTime TardeFinal { get; set; }

        public virtual Banheiro Banheiro { get; set; }
    }
}