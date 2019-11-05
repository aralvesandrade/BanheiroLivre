using System;
using System.Collections.Generic;
using System.Linq;

namespace banheiro_livre
{
    public class BanheiroService
    {
        private readonly Contexto _db;

        public BanheiroService(Contexto db)
        {
            _db = db;    
        }

        public IEnumerable<Banheiro> GetAll()
        {
            var banheiros = _db.Banheiros.ToList();

            if (!banheiros.Any())
            {
                var banheirosAux = new Banheiro[] {
                    new Banheiro { Descricao = "WC LABS MASCULINO", Ativo = true, Status = 0 },
                    new Banheiro { Descricao = "WC LABS FEMININO", Ativo = true, Status = 0 },
                    new Banheiro { Descricao = "WC RESOLVE MASCULINO", Ativo = true, Status = 0 },
                    new Banheiro { Descricao = "WC RESOLVE FEMININO", Ativo = true, Status = 0 },
                    new Banheiro { Descricao = "WC ANEXO TERREO", Ativo = true, Status = 0 },
                    new Banheiro { Descricao = "WC ANEXO INFERIOR (SUBSOLO)", Ativo = true, Status = 0 },
                    new Banheiro { Descricao = "WC ANEXO SUPERIOR", Ativo = true, Status = 0 }
                };

                try
                {
                    banheiros.AddRange(banheirosAux);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex; 
                }
            }

            var banheiroLimpezas = _db.LimpezaBanheiros.ToList();

            return banheiros;
        }
    }
}