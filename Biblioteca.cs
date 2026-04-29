using biblioteca_tes2026.Models;

class Biblioteca
{
    private static void MostrarTitulo(string titulo)
    {
        Console.WriteLine($"\n========== {titulo.ToUpper()} ==========");
    }

    public static void CadastrarUsuario(List<Usuario> usuarios)
    {
        MostrarTitulo("Cadastrar Usuario");
        Console.Write("Digite o nome do usuário: ");
        string nome;
        do
        {
            nome = Console.ReadLine()?.Trim() ?? "";
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

        } while (string.IsNullOrWhiteSpace(telefone) || !telefone.All(char.IsDigit) || (telefone.Length < 10 || telefone.Length > 11));

        usuarios.Add(new Usuario(nome, idade, telefone));
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    public static void ListarUsuarios(List<Usuario> usuarios)
    {
        MostrarTitulo("Listar Usuarios");
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }

        foreach (Usuario usuario in usuarios)
        {
            usuario.Exibir();
        }
    }

    public static void ExcluirUsuario(List<Usuario> usuarios, List<Emprestimo> emprestimos)
    {
        MostrarTitulo("Excluir Usuario");
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado para excluir.");
            return;
        }

        Console.Write("Digite o nome do usuário que deseja excluir: ");
        string nome;
        do
        {
            nome = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(nome));

        Usuario? usuarioParaExcluir = null;
        Usuario? usuarioParaExcluir = null;
        foreach (Usuario usuario in usuarios)
        {
            if (usuario.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                usuarioParaExcluir = usuario;
                break;
            }
        }

        if (usuarioParaExcluir == null)
        {
            Console.WriteLine("Nenhum usuário encontrado com este nome.");
            return;
        }

        bool temEmprestimo = false;
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo.Usuario == usuarioParaExcluir)
            {
                temEmprestimo = true;
                break;
            }
        }

        if (temEmprestimo)
        {
            Console.WriteLine("Este usuário possui empréstimos ativos e não pode ser excluído.");
            return;
        }

        Console.Write($"\nTem certeza que deseja excluir o usuário '{usuarioParaExcluir.Nome}'? (S/N): ");
        string confirmacao;
        do
        {
            confirmacao = Console.ReadLine()?.ToUpper() ?? "";
            if (confirmacao != "S" && confirmacao != "N")
            {
                Console.WriteLine("Responda com 'S' para sim ou 'N' para não: ");
            }
        } while (confirmacao != "S" && confirmacao != "N");

        if (confirmacao == "N")
        {
            Console.WriteLine("Exclusão cancelada.");
            return;
        }

        usuarios.Remove(usuarioParaExcluir);
        Console.WriteLine($"Usuário '{usuarioParaExcluir.Nome}' foi excluído com sucesso!");
    }

    public static void ListarLivros(List<Livro> livros, List<Emprestimo> emprestimos)
    {
        MostrarTitulo("Listar Livros");
        if (livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
            return;
        }

        foreach (Livro livro in livros)
        {
            livro.Exibir();
            if (!livro.Disponivel)
            {
                Emprestimo? emprestimo = emprestimos.Find(e => e.Livro == livro);
                Emprestimo? emprestimo = emprestimos.Find(e => e.Livro == livro);
                if (emprestimo != null)
                {
                    Console.WriteLine("Emprestado por: " + emprestimo.Usuario.Nome);
                }
            }
        }
    }

    public static void BuscarLivro(List<Livro> livros, List<Emprestimo> emprestimos)
    {
        MostrarTitulo("Buscar Livro");
        if (livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado para buscar.");
            return;
        }

        Console.WriteLine("Digite o título do livro que deseja buscar: ");
        string tituloBusca;
        do
        {
            tituloBusca = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(tituloBusca))
            {
                Console.WriteLine("Título inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(tituloBusca));

        List<Livro> livrosEncontrados = new List<Livro>();

        foreach (Livro li in livros)
        {
            if (li.Titulo.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
            {
                livrosEncontrados.Add(li);
            }
        }

        if (livrosEncontrados.Count == 0)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }

        Console.WriteLine($"\nEncontrado(s) {livrosEncontrados.Count} livro(s) com esse título:\n");
        foreach (Livro li in livrosEncontrados)
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
        }
    }


    public static void CadastrarLivro(List<Livro> livros)
    {
        MostrarTitulo("Cadastrar Livro");
        Console.Write("Digite o título do livro: ");
        string titulo;
        do
        {
            titulo = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Título inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(titulo));

        Console.Write("Digite o autor do livro: ");
        string autor;
        do
        {
            autor = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("Autor inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(autor));

        Console.Write("Digite o ano de publicação do livro: ");
        int ano;
        string inputAno;
        do
        {
            inputAno = Console.ReadLine() ?? "";
            if (!int.TryParse(inputAno, out ano))
            {
                Console.WriteLine("Ano inválido. Digite um número: ");
            }
            else if (ano < 0 || ano > DateTime.Now.Year)
            {
                Console.WriteLine($"Ano deve ser entre 0 e {DateTime.Now.Year}. Tente novamente: ");
            }
        } while (!int.TryParse(inputAno, out ano) || ano < 0 || ano > DateTime.Now.Year);

        bool livroDuplicado = false;
        foreach (Livro livro in livros)
        {
            if (livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) &&
                livro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase) &&
                livro.AnoPublicacao == ano)
            {
                livroDuplicado = true;
                break;
            }
        }

        if (livroDuplicado)
        {
            Console.WriteLine("Já existe um livro com o mesmo título, autor e ano.");
            return;
        }

        livros.Add(new Livro(titulo, autor, ano));
        Console.WriteLine("Livro cadastrado com sucesso!");
    }

    public static void ExcluirLivro(List<Livro> livros)
    {
        MostrarTitulo("Excluir Livro");
        if (livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado para excluir.");
            return;
        }

        Console.Write("Digite o título do livro que deseja excluir: ");
        string tituloBusca;
        do
        {
            tituloBusca = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(tituloBusca))
            {
                Console.WriteLine("Título inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(tituloBusca));

        List<Livro> livrosEncontrados = new List<Livro>();
        foreach (Livro li in livros)
        {
            if (li.Titulo.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
            {
                livrosEncontrados.Add(li);
            }
        }

        if (livrosEncontrados.Count == 0)
        {
            Console.WriteLine("Livro não encontrado na biblioteca.");
            return;
        }

        Livro? livroParaExcluir = null;
        Livro? livroParaExcluir = null;

        if (livrosEncontrados.Count > 1)
        {
            Console.WriteLine("\nMúltiplos livros encontrados com este título:\n");
            for (int i = 0; i < livrosEncontrados.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Título: {livrosEncontrados[i].Titulo} | Autor: {livrosEncontrados[i].Autor} | Ano: {livrosEncontrados[i].AnoPublicacao}");
            }

            Console.Write("\nDigite o número do livro que deseja excluir: ");
            int escolha;
            string inputEscolha;
            do
            {
                inputEscolha = Console.ReadLine() ?? "";
                if (!int.TryParse(inputEscolha, out escolha))
                {
                    Console.WriteLine("Número inválido. Tente novamente: ");
                }
                else if (escolha < 1 || escolha > livrosEncontrados.Count)
                {
                    Console.WriteLine($"Digite um número entre 1 e {livrosEncontrados.Count}: ");
                }
            } while (!int.TryParse(inputEscolha, out escolha) || escolha < 1 || escolha > livrosEncontrados.Count);

            livroParaExcluir = livrosEncontrados[escolha - 1];
        }
        else
        {
            livroParaExcluir = livrosEncontrados[0];
        }

        if (!livroParaExcluir.Disponivel)
        {
            Console.WriteLine("O livro está emprestado e não pode ser excluído.");
            return;
        }

        Console.Write($"\nTem certeza que deseja excluir '{livroParaExcluir.Titulo}' ({livroParaExcluir.Autor}, {livroParaExcluir.AnoPublicacao})? (S/N): ");
        string confirmacao;
        do
        {
            confirmacao = Console.ReadLine()?.ToUpper() ?? "";
            if (confirmacao != "S" && confirmacao != "N")
            {
                Console.WriteLine("Responda com 'S' para sim ou 'N' para não: ");
            }
        } while (confirmacao != "S" && confirmacao != "N");

        if (confirmacao == "N")
        {
            Console.WriteLine("Exclusão cancelada.");
            return;
        }

        livros.Remove(livroParaExcluir);
        Console.WriteLine($"O livro '{livroParaExcluir.Titulo}' foi excluído do sistema.");
    }

    public static void ListarLivrosDisponiveis(List<Livro> livros)
    {
        MostrarTitulo("Livros Disponiveis");
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

    public static void ListarLivrosEmprestados(List<Emprestimo> emprestimos)
    {
        MostrarTitulo("Livros Emprestados");
        if (emprestimos.Count == 0)
        {
            Console.WriteLine("Nenhum livro emprestado no momento.");
            return;
        }

        foreach (Emprestimo emprestimo in emprestimos)
        {
            emprestimo.Exibir();
        }
    }

    public static void RealizarEmprestimo(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos)
    {
        MostrarTitulo("Realizar Emprestimo");
        if (usuarios.Count == 0 || livros.Count == 0)
        {
            Console.WriteLine("Você precisa de pelo menos um usuário e um livro cadastrado para fazer um empréstimo.");
            return;
        }

        Console.Write("Digite o nome do usuário que deseja realizar o empréstimo: ");
        string nomeUsuario;
        do
        {
            nomeUsuario = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(nomeUsuario))
            {
                Console.WriteLine("Nome inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(nomeUsuario));
        Usuario? usuarioEncontrado = null;
        Usuario? usuarioEncontrado = null;
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

        Console.Write("Digite o título do livro que deseja emprestar: ");
        string tituloLivro;
        do
        {
            tituloLivro = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(tituloLivro))
            {
                Console.WriteLine("Título inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(tituloLivro));

        List<Livro> livrosEncontrados = new List<Livro>();
        foreach (Livro livro in livros)
        {
            if (livro.Titulo.Equals(tituloLivro, StringComparison.OrdinalIgnoreCase))
            {
                livrosEncontrados.Add(livro);
            }
        }

        if (livrosEncontrados.Count == 0)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }

        Livro? livroEncontrado = null;
        Livro? livroEncontrado = null;

        if (livrosEncontrados.Count > 1)
        {
            Console.WriteLine("\nMúltiplos livros encontrados com este título:\n");
            for (int i = 0; i < livrosEncontrados.Count; i++)
            {
                string statusDisp = livrosEncontrados[i].Disponivel ? "Disponível" : "Indisponível";
                Console.WriteLine($"{i + 1} - Título: {livrosEncontrados[i].Titulo} | Autor: {livrosEncontrados[i].Autor} | Ano: {livrosEncontrados[i].AnoPublicacao} | Status: {statusDisp}");
            }

            Console.Write("\nDigite o número do livro que deseja emprestar: ");
            int escolha;
            string inputEscolha;
            do
            {
                inputEscolha = Console.ReadLine() ?? "";
                if (!int.TryParse(inputEscolha, out escolha))
                {
                    Console.WriteLine("Número inválido. Tente novamente: ");
                }
                else if (escolha < 1 || escolha > livrosEncontrados.Count)
                {
                    Console.WriteLine($"Digite um número entre 1 e {livrosEncontrados.Count}: ");
                }
            } while (!int.TryParse(inputEscolha, out escolha) || escolha < 1 || escolha > livrosEncontrados.Count);

            livroEncontrado = livrosEncontrados[escolha - 1];
        }
        else
        {
            livroEncontrado = livrosEncontrados[0];
        }

        if (!livroEncontrado.Disponivel)
        {
            Console.WriteLine("Livro indisponível para empréstimo.");
            return;
        }

        Console.Write("Digite a quantidade de dias para o empréstimo: ");
        int quantidadeDias;
        string inputDias;
        do
        {
            inputDias = Console.ReadLine() ?? "";
            if (!int.TryParse(inputDias, out quantidadeDias))
            {
                Console.WriteLine("Quantidade inválida. Digite um número: ");
            }
            else if (quantidadeDias <= 0)
            {
                Console.WriteLine("Quantidade de dias deve ser maior que zero. Tente novamente: ");
            } else if (quantidadeDias > 30)
            {
                Console.WriteLine("Quantidade de dias deve ser menor ou igual a 30. Tente novamente: ");
            }

        } while (!int.TryParse(inputDias, out quantidadeDias) || quantidadeDias <= 0 || quantidadeDias > 30);
        Emprestimo emprestimo = new Emprestimo(livroEncontrado, usuarioEncontrado, quantidadeDias);
        emprestimos.Add(emprestimo);
        livroEncontrado.Disponivel = false;
        Console.WriteLine("Empréstimo realizado com sucesso!");
    }
    public static void DevolverLivro(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos)
    {
        MostrarTitulo("Devolver Livro");
        if (usuarios.Count == 0 || emprestimos.Count == 0)
        {
            Console.WriteLine("Não há empréstimos para devolver.");
            return;
        }

        Console.Write("Digite o nome do usuário que deseja realizar a devolução: ");
        string nomeUsuario;
        do
        {
            nomeUsuario = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(nomeUsuario))
            {
                Console.WriteLine("Nome inválido. Tente novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(nomeUsuario));
        Usuario? usuarioEncontrado = null;
        Usuario? usuarioEncontrado = null;
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

        List<Emprestimo> emprestimosDusuario = new List<Emprestimo>();
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo.Usuario == usuarioEncontrado)
            {
                emprestimosDusuario.Add(emprestimo);
            }
        }

        if (emprestimosDusuario.Count == 0)
        {
            Console.WriteLine("Este usuário não possui livros emprestados.");
            return;
        }

        Console.WriteLine("\nLivros emprestados por " + usuarioEncontrado.Nome + ":");
        for (int i = 0; i < emprestimosDusuario.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1} - Título: {emprestimosDusuario[i].Livro.Titulo} | Devolução prevista: {emprestimosDusuario[i].DataDevolucaoPrevista:dd/MM/yyyy}"
            );
        }

        Console.Write("\nEscolha o número do livro que deseja devolver: ");
        int escolha;
        string input;
        do
        {
            input = Console.ReadLine() ?? "";
            if (!int.TryParse(input, out escolha) || escolha < 1 || escolha > emprestimosDusuario.Count)
            {
                Console.WriteLine("Opção inválida. Escolha um número entre 1 e " + emprestimosDusuario.Count + ": ");
            }
            else
            {
                break;
            }
        } while (true);

        Emprestimo emprestimoParaDevolver = emprestimosDusuario[escolha - 1];
        emprestimos.Remove(emprestimoParaDevolver);
        emprestimoParaDevolver.Livro.Disponivel = true;
        Console.WriteLine("Devolução do livro '" + emprestimoParaDevolver.Livro.Titulo + "' realizada com sucesso!");
    }
}
