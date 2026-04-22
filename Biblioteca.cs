using biblioteca_tes2026.Models;

class Biblioteca
{
    public static void CadastrarUsuario(List<Usuario> usuarios)
    {
        Console.Write("Digite o nome do usuário: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a idade do usuário: ");
        int idade = int.Parse(Console.ReadLine());

        Console.Write("Digite o telefone do usuário: ");
        string telefone = Console.ReadLine();

        usuarios.Add(new Usuario(nome, idade, telefone));
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    public static void ListarUsuarios(List<Usuario> usuarios)
    {
        Console.WriteLine("\nLista de Usuários:");
        foreach (Usuario usuario in usuarios)
        {
            usuario.Exibir();
        }
    }

 public static void ListarLivros(List<Livro> livros)
    {
        Console.WriteLine("\nLista de Livros:");
        foreach (Livro livro in livros)
        {
            livro.Exibir();
        }
    }

    public static void BuscarLivro(List<Livro> livros)
{
    Console.WriteLine("Digite o título do livro que deseja buscar: ");
    string tituloBusca = Console.ReadLine();

    bool livroEncontrado = false;

    foreach (Livro li in livros)
    {
        if(li.Titulo.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
        {
            li.Exibir();
            livroEncontrado = true;
            break;
        }
    }

    if(livroEncontrado == false)
    {
        Console.WriteLine("Livro não encontrado.");
    }
}

    
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

    public static void ExcluirLivro(List<Livro> livros)
    {
        Console.WriteLine("Digite o título do livro que deseja excluir: ");
        string tituloBusca = Console.ReadLine();

        Livro livroEncontrado = null;

        foreach (Livro li in livros)
        {
            if (li.Titulo.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
            {
                livroEncontrado = li;
                break;
            }
        }

        if (livroEncontrado == null)
        {
            Console.WriteLine("Livro não encontrado na biblioteca.");
            return;
        }
        
        if (!livroEncontrado.Disponivel)
        {
            Console.WriteLine("O livro está emprestado e não pode ser excluído.");
            return;
        }

        livros.Remove(livroEncontrado);

        Console.WriteLine($"O livro '{livroEncontrado.Titulo}' foi excluído do sistema.");
    }

    public static void ListarLirvosDisponiveis(List<Livro> livros)
    {
        bool existeLivroDisponivel = false;

                foreach (Livro livro in livros){
                    if(livro.Disponivel){
                        livro.Exibir();
                        existeLivroDisponivel = true;
                    }
                }
                if(existeLivroDisponivel == false){
                    Console.WriteLine("Nenhum livro disponível no momento.");
                }
    }

    public static void ListarLirvosEmprestados(List<Livro> livros)
    {
        bool existeLivroEmprestado = false;

                foreach (Livro livro in livros){
                    if(!livro.Disponivel){
                        livro.Exibir();
                        existeLivroEmprestado = true;
                    }
                }
                if(existeLivroEmprestado == false){
                    Console.WriteLine("Nenhum livro emprestado no momento.");
                }
    }

    public static void RealizarEmprestimo(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos)
    {
      Console.WriteLine("Digite o nome do usuário que deseja realizar o empréstimo: ");
      string nomeUsuario = Console.ReadLine();
        Usuario usuarioEncontrado = null;
        foreach (Usuario usuario in usuarios)
        {
            if (usuario.Nome.Equals(nomeUsuario, StringComparison.OrdinalIgnoreCase))
            {
                usuarioEncontrado = usuario;
                break;
            }
        }
        if (usuarioEncontrado == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }

        Console.WriteLine("Digite o título do livro que deseja emprestar: ");
        string tituloLivro = Console.ReadLine();
        Livro livroEncontrado = null;
        foreach (Livro livro in livros)
        {
            if (livro.Titulo.Equals(tituloLivro, StringComparison.OrdinalIgnoreCase))
            {
                livroEncontrado = livro;
                break;
            
            }
        }
        if (livroEncontrado == null)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }
        if (!livroEncontrado.Disponivel)
        {
            Console.WriteLine("Livro indisponível para empréstimo.");
            return;
        }
        Console.WriteLine("Digite a quantidade de dias para o empréstimo: ");
        int quantidadeDias = int.Parse(Console.ReadLine());
        Emprestimo emprestimo = new Emprestimo(livroEncontrado, usuarioEncontrado, quantidadeDias);
        emprestimos.Add(emprestimo);
        livroEncontrado.Disponivel = false;
        Console.WriteLine("Empréstimo realizado com sucesso!");
        
    }
}
