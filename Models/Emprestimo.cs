namespace biblioteca_tes2026.Models
{
    class Emprestimo
    {
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }

        public Emprestimo(Livro livro, Usuario usuario, int quantidadeDias)
        {
            Livro = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
            DataDevolucaoPrevista = DateTime.Now.AddDays(quantidadeDias);
        }

        public void Exibir()
        {
            Console.WriteLine(
                Livro.Titulo + " → " + Usuario.Nome +
                " | Devolução prevista: " + DataDevolucaoPrevista.ToString("dd/MM/yyyy")
            );
        }
    }
}
