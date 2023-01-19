namespace ServidorDemoJogoCartas.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Simbolo { get; set; }
        public IList<Personagem> Personagens { get; set; }
    }
}
