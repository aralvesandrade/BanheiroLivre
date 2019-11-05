using System.Linq;

namespace banheiro_livre
{
    public class BanheiroService
    {
        private readonly string[] Banheiros = new[]
        {
            "WC LABS MASCULINO", "WC LABS FEMININO", "WC RESOLVE MASCULINO", "WC RESOLVE FEMININO", "WC ANEXO TERREO", "WC ANEXO INFERIOR (SUBSOLO)", "WC ANEXO SUPERIOR"
        };

        private readonly Contexto _db;

        public BanheiroService(Contexto db)
        {
            _db = db;    
        }

        public string[] GetAll()
        {
            var _banheiros = _db.Banheiros.ToList();
            return Banheiros;
        }
    }
}