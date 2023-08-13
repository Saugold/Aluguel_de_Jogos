using EmprestimoJogo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoJogo.Data
{
    public class ApplicationDbContext :DbContext //classe herda o DbContext para auxiliar no processo de conexão ao banco
    {
                                    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {                          //dbContextOptions recebe AplicationDbContext chamado options
                                   //dbContext é um tipo de dado
        }
        //criando uma prop do tipo DbSet com a estrutura montada na classe EmprestimosModel, dando o nome de Emprestimos
        public DbSet<EmprestimosModel> Emprestimos { get; set; }

    }
}
