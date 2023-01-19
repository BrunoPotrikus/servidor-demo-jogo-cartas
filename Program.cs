using ServidorDemoJogoCartas.Data;
using ServidorDemoJogoCartas.Models;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new DataContext();

        context.Categorias.Add(new Categoria
        {
            Id = Guid.NewGuid(),
            Titulo = "Místico",
            Simbolo = "https://simbolo-mistico-nordico"
        });
        context.SaveChanges();

        var mistico = context.Categorias.Where(x => x.Titulo == "Místico").FirstOrDefault();

        context.Personagens.Add(new Personagem
        {
            Id = Guid.NewGuid(),
            Nome = "Anúbis",
            Imagem = "https://i.pinimg.com/474x/95/db/bf/95dbbfdd9369112bb8f5a2b201a002dd.jpg",
            Magia = 20,
            Forca = 3,
            Fogo = 22,
            Categoria = mistico,
            Descricao = "Deus egípcio dos mortos"
        });
        context.SaveChanges();
    }
}
