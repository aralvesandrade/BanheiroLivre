using System;

namespace banheiro_livre
{
    public class LimpezaBanheiro
    {
        public int Id { get; set; }
        public int BanheiroId { get; set; }
        public string Dia { get; set; }
        public int Serviço { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public string ResponsavelLimpeza { get; set; }

        public virtual Banheiro Banheiro { get; set; }
    }
}