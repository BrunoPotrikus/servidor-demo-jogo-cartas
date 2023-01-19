using ServidorDemoJogoCartas.ValueObjects;

namespace ServidorDemoJogoCartas.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public IList<Personagem> Personagens { get; set; }
    }
}
