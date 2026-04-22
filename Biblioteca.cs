using biblioteca_tes2026.Models;

class Biblioteca
{

     public static void CadastrarLivro(List<Livro> livros)
    {
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine();

        Console.Write("Digite o ano de publicação do livro: ");
        int ano = int.Parse(Console.ReadLine());

        livros.Add(new Livro(titulo, autor, ano));
        Console.WriteLine("Livro cadastrado com sucesso!");
    }
}
