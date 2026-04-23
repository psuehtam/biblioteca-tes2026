using biblioteca_tes2026.Models;

class Biblioteca
{
        // 1 - Cadastrar Usuário
    public static void CadastrarUsuario(List<Usuario> usuarios)
    {
        Console.WriteLine("\nCadastro de Usuário:\n");
        Console.Write("Digite o nome do usuário: ");
        string nome;
        do
        {
            nome = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido. Tente novamente: ");
            }
            else
            {
                bool nomeJaExiste = false;
                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                    {
                        nomeJaExiste = true;
                        break;
                    }
                }

                if (nomeJaExiste)
                {
                    Console.WriteLine("Este nome já está cadastrado. Tente novamente: ");
                    nome = "";
                }
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
            else if (telefone == usuarios.Select(u => u.Telefone).FirstOrDefault(t => t == telefone))
            {
                Console.WriteLine("Telefone já cadastrado para outro usuário. Tente novamente: ");
            }

        } while (string.IsNullOrWhiteSpace(telefone) || !telefone.All(char.IsDigit) || (telefone.Length < 10 || telefone.Length > 11) || telefone == usuarios.Select(u => u.Telefone).FirstOrDefault(t => t == telefone));

        usuarios.Add(new Usuario(nome, idade, telefone));
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    // 2 - Listar Usuários
    public static void ListarUsuarios(List<Usuario> usuarios)
    {
        Console.WriteLine("\nLista de Usuários:\n");
        foreach (Usuario usuario in usuarios)
        {
            usuario.Exibir();
        }
    }

     // 3 - Cadastrar Livro
    public static void CadastrarLivro(List<Livro> livros)
    {
        Console.WriteLine("\nCadastro de Livro:\n");
        Console.Write("Digite o título do livro: ");
        string titulo;
        do
        {
            titulo = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Título inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(titulo));


        Console.Write("Digite o nome do autor do livro: ");
        string autor;
        do
        {
            autor = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("Nome inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(autor));



        Console.Write("Digite o ano de publicação do livro: ");
        int AnoPublicacao;
        string inputAno;
        int anoAtual = DateTime.Now.Year;
        
        do
        {
            inputAno = Console.ReadLine() ?? "";
            if (!int.TryParse(inputAno, out AnoPublicacao))
            {
                Console.WriteLine("Ano inválido. Digite apenas números: ");
            }
            else if (AnoPublicacao < 0)
            {
                Console.WriteLine("Ano não pode ser negativo. Tente novamente: ");
            }
            else if (AnoPublicacao > anoAtual)
            {
                Console.WriteLine($"Ano não pode ser maior que o ano atual ({anoAtual}). Tente novamente: ");
            }
        } while (!int.TryParse(inputAno, out AnoPublicacao) || AnoPublicacao < 0 || AnoPublicacao > anoAtual);

        bool livroJaExiste = false;
        foreach (Livro livro in livros)
        {
            if (livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) &&
                livro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase) &&
                livro.AnoPublicacao == AnoPublicacao)
            {
                livroJaExiste = true;
                break;
            }
        }

        if (livroJaExiste)
        {
            Console.WriteLine("Este livro já está cadastrado na biblioteca!");
            return;
        }

        livros.Add(new Livro(titulo, autor, AnoPublicacao));
        Console.WriteLine("Livro cadastrado com sucesso!");
    }

    // 4 - Listar Todos os Livros
    public static void ListarLivros(List<Livro> livros, List<Emprestimo> emprestimos)
    {
        Console.WriteLine("\nLista de Livros:\n");
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

    // 5 - Buscar Livro
    public static void BuscarLivro(List<Livro> livros, List<Emprestimo> emprestimos)
    {
        Console.WriteLine("\nBusca de Livro:\n");
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

    // 6 - Excluir Livro
    public static void ExcluirLivro(List<Livro> livros)
    {
        Console.WriteLine("\nExclusão de Livro:\n");
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

    // 7 - Consultar Livros Disponíveis
    public static void ListarLivrosDisponiveis(List<Livro> livros)
    {
        Console.WriteLine("\nLista de Livros Disponíveis:\n");
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

    // 8 - Consultar Livros Emprestados
    public static void ListarLivrosEmprestados(List<Emprestimo> emprestimos)
    {
        Console.WriteLine("\nLista de Livros Emprestados:\n");
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

    // 9 - Realizar Empréstimo
    public static void RealizarEmprestimo(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos)
    {
        Console.WriteLine("\nRealização de Empréstimo:\n");
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

    // 10 - Devolver Livro
    public static void DevolverLivro(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos)
    {
        Console.WriteLine("\nDevolução de Livro:\n");
        Console.WriteLine("Digite o nome do usuário que deseja realizar a devolução: ");
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

        Console.WriteLine("Digite o título do livro que deseja devolver: ");
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

        Emprestimo emprestimoEncontrado = null;
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo.Usuario == usuarioEncontrado && emprestimo.Livro == livroEncontrado)
            {
                emprestimoEncontrado = emprestimo;
                break;
            }
        }
        if (emprestimoEncontrado == null)
        {
            Console.WriteLine("Empréstimo não encontrado para este usuário e livro.");
            return;
        }

        emprestimos.Remove(emprestimoEncontrado);
        livroEncontrado.Disponivel = true;
        Console.WriteLine("Devolução realizada com sucesso!");
    }
}