using System.ComponentModel;

namespace BrincandoDeAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get;set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }

    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
