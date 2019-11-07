using System;
using System.Collections.Generic;
using System.Linq;
using banheiro_livre.Domain;
using banheiro_livre.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace banheiro_livre
{
    public class BanheiroService
    {
        private readonly ILogger<BanheiroService> _logger;
        private readonly Contexto _db;

        public BanheiroService(ILogger<BanheiroService> logger, Contexto db)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<Banheiro> ListarTodos()
        {
            var banheiros = _db.Banheiros.ToList();
            return banheiros;
        }

        public (bool, string, Banheiro) ListarPorId(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id));

            Banheiro banheiro = null;

            try
            {
                banheiro = _db.Banheiros.Include(x => x.LimpezaBanheiros).FirstOrDefault(x => x.Id == id);    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro na tentativa de obter Banheiro [{id}], exception: {0}", ex.Message);
                throw new Exception($"Erro na tentativa de obter Banheiro [{id}], objeto nulo.");
            }

            if (banheiro == null)
            {
                _logger.LogDebug($"Erro na tentativa de obter Banheiro [{id}], objeto nulo");
                return (false, $"Erro na tentativa de obter Banheiro [{id}].", null);
            }

            return (true, "", banheiro);
        }

        public Banheiro Adicionar(Banheiro banheiro)
        {
            try
            {
                banheiro.Ativo = true;
                banheiro.Status = (int)Status.Livre;

                _db.Set<Banheiro>().Add(banheiro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro na tentativa de adicionar um novo Banheiro, exception: {0}", ex.Message);
                throw new Exception("Erro na tentativa de adicionar um novo Banheiro.");
            }
            
            return banheiro;
        }

        public (bool, Banheiro) Atualizar(int id, Banheiro banheiro)
        {
            var _banheiro = _db.Banheiros.FirstOrDefault(x => x.Id == id);

            if (_banheiro != null)
            {
                _banheiro.Descricao = banheiro.Descricao;
                _banheiro.Ativo = banheiro.Ativo;

                _db.Set<Banheiro>().Update(_banheiro);
                _db.SaveChanges();
            }

            return (true, _banheiro);
        }

        public (bool, Banheiro) AtualizarStatus(int id, int status)
        {
            var _banheiro = _db.Banheiros.FirstOrDefault(x => x.Id == id);

            if (_banheiro != null)
            {
                _banheiro.Status = status;

                _db.Set<Banheiro>().Update(_banheiro);
                _db.SaveChanges();
            }

            return (true, _banheiro);
        }

        public bool Excluir(int id)
        {
            var _banheiro = _db.Banheiros.FirstOrDefault(x => x.Id == id);

            if (_banheiro != null)
            {
                _db.Set<Banheiro>().Remove(_banheiro);
                _db.SaveChanges();
            }

            return true;
        }
    }
}