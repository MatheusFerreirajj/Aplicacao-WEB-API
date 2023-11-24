namespace BrincandoDeAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; } 
    }
}
