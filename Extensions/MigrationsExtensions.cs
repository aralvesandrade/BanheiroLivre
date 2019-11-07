using System;
using System.Linq;
using banheiro_livre.Domain;
using banheiro_livre.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace banheiro_livre.Extensions
{
    public static class DbExtensions
    {
        public static void DbInitializer(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var db = serviceScope.ServiceProvider.GetService<Contexto>())
                {
                    if (!db.Banheiros.Any())
                    {
                        var banheiros = new Banheiro[]
                        {
                            new Banheiro { Descricao = "WC LABS MASCULINO", Ativo = true, Status = 0 },
                            new Banheiro { Descricao = "WC LABS FEMININO", Ativo = true, Status = 0 },
                            new Banheiro { Descricao = "WC RESOLVE MASCULINO", Ativo = true, Status = 0 },
                            new Banheiro { Descricao = "WC RESOLVE FEMININO", Ativo = true, Status = 0 },
                            new Banheiro { Descricao = "WC ANEXO TERREO", Ativo = true, Status = 0 },
                            new Banheiro { Descricao = "WC ANEXO INFERIOR (SUBSOLO)", Ativo = true, Status = 0 },
                            new Banheiro { Descricao = "WC ANEXO SUPERIOR", Ativo = true, Status = 0 }
                        };

                        db.AddRange(banheiros);
                        db.SaveChanges();
                    }

                    if (!db.LimpezaBanheiros.Any())
                    {
                        var banheiros = db.Banheiros.ToList();

                        var limpezaBanheiros = new LimpezaBanheiro[]
                        {
                            new LimpezaBanheiro {
                                BanheiroId = banheiros.Single(x => x.Descricao == "WC LABS MASCULINO").Id,
                                Dia = Dia.Segunda,
                                Servico = (int)Servico.LimpezaCompleta,
                                ManhaInicio = Convert.ToDateTime("01/01/1900 06:30:00"),
                                ManhaFinal = Convert.ToDateTime("01/01/1900 07:30:00"),
                                TardeInicio = Convert.ToDateTime("01/01/1900 14:30:00"),
                                TardeFinal = Convert.ToDateTime("01/01/1900 15:30:00")
                            },
                            new LimpezaBanheiro {
                                BanheiroId = banheiros.Single(x => x.Descricao == "WC LABS MASCULINO").Id,
                                Dia = Dia.Segunda,
                                Servico = (int)Servico.Revisao,
                                ManhaInicio = Convert.ToDateTime("01/01/1900 09:30:00"),
                                ManhaFinal = Convert.ToDateTime("01/01/1900 09:45:00"),
                                TardeInicio = Convert.ToDateTime("01/01/1900 17:30:00"),
                                TardeFinal = Convert.ToDateTime("01/01/1900 17:45:00")
                            }
                        };

                        db.AddRange(limpezaBanheiros);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}