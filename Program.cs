using Microsoft.EntityFrameworkCore;
using ServidorDemoJogoCartas.Data;
using ServidorDemoJogoCartas.Models;
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new DataContext();

        //context.Categorias.Add(new Categoria
        //{
        //    Id = Guid.NewGuid(),
        //    Titulo = "Místico",
        //    Simbolo = "https://simbolo-mistico-nordico"
        //});
        //context.SaveChanges();

        //var mistico = context.Categorias.Where(x => x.Titulo == "Místico").FirstOrDefault();

        //context.Personagens.Add(new Personagem
        //{
        //    Id = Guid.NewGuid(),
        //    Nome = "Anúbis",
        //    Imagem = "https://i.pinimg.com/474x/95/db/bf/95dbbfdd9369112bb8f5a2b201a002dd.jpg",
        //    Magia = 20,
        //    Forca = 3,
        //    Fogo = 22,
        //    Categoria = mistico,
        //    Descricao = "Deus egípcio dos mortos"
        //});
        //context.SaveChanges();

        //var usuario = new Usuario
        //{
        //    Id = Guid.NewGuid(),
        //    Nome = "José",
        //    Sobrenome = "Santos",
        //    Apelido = "JoseSantos",
        //    Email = "jose@email.com",
        //    Senha = "senha456"
        //};

        //await context.Usuarios.AddAsync(usuario);
        //context.SaveChanges();

        // Eager Loading
        //var usuarios = context.Usuarios.Include(x => x.Personagens);

        //foreach(var usuario in usuarios)
        //{
        //    if(usuario.Personagens.Count != 0)
        //    {
        //        foreach (var personagem in usuario.Personagens)
        //        {
        //            Console.WriteLine(personagem.Nome);
        //        }               
        //    }
        //    else
        //    {
        //        Console.WriteLine($"O usuário {usuario.Apelido} não possui personagens");
        //    }
        //}

        var usuarios = ListaUsuarios(context, 0, 25);
    }

    public static List<Usuario> ListaUsuarios(DataContext context, int skip = 0, int take = 25)
    {
        var usuarios = context
            .Usuarios
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToList();
        return usuarios;
    }
}
