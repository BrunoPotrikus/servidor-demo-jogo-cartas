using ServidorDemoJogoCartas.ValueObjects;

namespace ServidorDemoJogoCartas.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IList<Personagem>? Personagens { get; set; }
    }
}
