namespace biblioteca_tes2026.Models
{
    class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public bool Disponivel { get; set; }

        public Livro(string titulo, string autor, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Disponivel = true;
        }

        public void Exibir()
        {
            Console.WriteLine(Titulo + " - " + Autor + " (" + AnoPublicacao + ") - " + (Disponivel ? "Disponível" : "Alugado"));
        }
    }
}
