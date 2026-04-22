using biblioteca_tes2026.Models;

class Biblioteca
{
    public static void CadastrarUsuario(List<Usuario> usuarios)
    {
        Console.Write("Digite o nome do usuário: ");
        string nome;
        do
        {
            nome = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(nome));

        Console.Write("Digite a idade do usuário: ");
        int idade;
        string inputIdade;
        do
        {
            inputIdade = Console.ReadLine() ?? "";
            if (!int.TryParse(inputIdade, out idade))
            {
                Console.WriteLine("Idade inválida. Digite um número: ");
            }
            else if (idade < 0 || idade > 120)
            {
                Console.WriteLine("Idade deve ser entre 0 e 120 anos. Tente novamente: ");
            }
        } while (!int.TryParse(inputIdade, out idade) || idade < 0 || idade > 120);

        Console.Write("Digite o telefone do usuário: ");
        string telefone;
        do
        {
            telefone = Console.ReadLine() ?? "";
            telefone = telefone.Trim();
            if (string.IsNullOrWhiteSpace(telefone))
            {
                Console.WriteLine("Telefone inválido. Tente novamente: ");
            }
            else if (!telefone.All(char.IsDigit))
            {
                Console.WriteLine("O telefone deve conter apenas números. Tente novamente: ");
            }
            else if (telefone.Length < 10 || telefone.Length > 11)
            {
                Console.WriteLine("Telefone deve conter no mínimo 10 dígitos e maximo de 11 digitos. Tente novamente: ");
            }

        } while (string.IsNullOrWhiteSpace(telefone) || !telefone.All(char.IsDigit) || (telefone.Length < 10 || telefone.Length > 11));

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

    public static void ListarLivros(List<Livro> livros, List<Emprestimo> emprestimos)
    {
        Console.WriteLine("\nLista de Livros:");
        foreach (Livro livro in livros)
        {
            livro.Exibir();
            if (!livro.Disponivel)
            {
                Emprestimo emprestimo = emprestimos.Find(e => e.Livro == livro);
                if (emprestimo != null)
                {
                    Console.WriteLine("Emprestado por: " + emprestimo.Usuario.Nome);
                }
            }
            Console.WriteLine();
        }
    }

    public static void BuscarLivro(List<Livro> livros, List<Emprestimo> emprestimos)
    {
        Console.WriteLine("Digite o título do livro que deseja buscar: ");
        string tituloBusca;
        do
        {
            tituloBusca = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(tituloBusca))
            {
                Console.WriteLine("Título inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(tituloBusca));

        bool livroEncontrado = false;

        foreach (Livro li in livros)
        {
            if (li.Titulo.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
            {
                li.Exibir();
                if (!li.Disponivel)
                {
                    Emprestimo? emprestimo = emprestimos.Find(e => e.Livro == li);
                    if (emprestimo != null)
                    {
                        Console.WriteLine("Emprestado por: " + emprestimo.Usuario.Nome);
                    }
                }
                livroEncontrado = true;
                break;
            }
        }

        if (livroEncontrado == false)
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

        foreach (Livro livro in livros)
        {
            if (livro.Disponivel)
            {
                livro.Exibir();
                existeLivroDisponivel = true;
            }
        }
        if (existeLivroDisponivel == false)
        {
            Console.WriteLine("Nenhum livro disponível no momento.");
        }
    }

    public static void ListarLirvosEmprestados(List<Emprestimo> emprestimos)
    {
        if (emprestimos.Count == 0)
        {
            Console.WriteLine("Nenhum livro emprestado no momento.");
            return;
        }

        Console.WriteLine("\nLista de Livros Emprestados:");
        foreach (Emprestimo emprestimo in emprestimos)
        {
            emprestimo.Exibir();
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
