using System.ComponentModel.DataAnnotations;

namespace EmprestimoJogo.Models
{
    public class EmprestimosModel //Criando uma classe para os emprestimos
                                  //obs sempre colocar Model apos o nome de uma model
    {
        //as propriedades da classe referência uma coluna no banco de dados
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Recebedor")]
        public string Recebedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do Fornecedor")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do Jogo emprestado")]
        public string JogoEmprestado { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now; //DateTime pega a data atual do sistema
    }
}
