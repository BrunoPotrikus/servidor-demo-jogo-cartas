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

        //var usuarios = ListaUsuarios(context, 0, 25);

        var usuario = context.Usuarios.FirstOrDefault(x => x.Apelido == "BrunoPotrikus");
        var personagem = context.Personagens
                                .AsNoTracking()
                                //.Where(x => x.Nome == "Anúbis")
                                .FirstOrDefault(x => x.Id == Guid.Parse("c9268ce7-7b96-41e8-afc7-b6ab1014ba7d"));
        var categoria = context.Categorias.FirstOrDefault(x => x.Id == personagem.CategoriaId);

        Console.WriteLine($"Nome: {personagem?.Nome} \n" +
                          $"Categoria: {categoria.Titulo} \n" +
                          $"Descrição: {personagem?.Descricao} \n" +
                          $"Magia: {personagem?.Magia} \n" +
                          $"Força: {personagem?.Forca} \n" +
                          $"Fogo: {personagem?.Fogo}");

        usuario.Personagens.Add(personagem);
        context.Usuarios.Update(usuario);
        context.SaveChanges();
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
