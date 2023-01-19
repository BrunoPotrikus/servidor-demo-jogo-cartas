namespace ServidorDemoJogoCartas.ValueObjects
{
    public class Nome
    {
        public Nome(string nome, string sobrenome, string apelido)
        {
            NomeUsuario = nome;
            Sobrenome = sobrenome;
            Apelido = apelido;
        }

        public string NomeUsuario { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
    }
}
