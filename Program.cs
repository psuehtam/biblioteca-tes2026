using biblioteca_tes2026.Models;

List<Livro> livros = new List<Livro>();
List<Usuario> usuarios = new List<Usuario>();
List<Emprestimo> emprestimos = new List<Emprestimo>();


usuarios.Add(new Usuario("Ana", 25, "4112345678"));
usuarios.Add(new Usuario("Carlos", 30, "4112345678"));
usuarios.Add(new Usuario("Beatriz", 20, "4112345678"));
usuarios.Add(new Usuario("Daniel", 35, "4112345678"));

livros.Add(new Livro("Harry Potter", "J.K. Rowling", 1997));
livros.Add(new Livro("Dom Quixote", "Cervantes", 1605));
livros.Add(new Livro("Biblia", "Varios", 0));
livros.Add(new Livro("Crepusculo", "Stephenie Meyer", 2005));
livros.Add(new Livro("Senhor dos Aneis", "Tolkien", 1954));

int escolha = 0;

do
{
    Console.WriteLine("\n========= SISTEMA DE BIBLIOTECA =========");

    Console.WriteLine("1 - Cadastrar Usuário");
    Console.WriteLine("2 - Listar Usuários");
    Console.WriteLine("3 - Cadastrar Livro");
    Console.WriteLine("4 - Listar Todos os Livros");
    Console.WriteLine("5 - Buscar Livro");
    Console.WriteLine("6 - Excluir Livro");
    Console.WriteLine("7 - Consultar Livros Disponíveis");
    Console.WriteLine("8 - Consultar Livros Emprestados");
    Console.WriteLine("9 - Realizar Empréstimo");
    Console.WriteLine("10 - Devolver Livro");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite sua escolha: ");
    string? input;
    do
    {
        input = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out escolha));

    switch (escolha)
    {
        case 1:
            Biblioteca.CadastrarUsuario(usuarios);
            break;
        case 2:
            Biblioteca.ListarUsuarios(usuarios);
            break;
        case 3:
            Biblioteca.CadastrarLivro(livros);
            break;
        case 4:
            Biblioteca.ListarLivros(livros, emprestimos);
            break;
        case 5:
            Biblioteca.BuscarLivro(livros, emprestimos);
            break;
        case 6:
            Biblioteca.ExcluirLivro(livros);
            break;
        case 7:
            Biblioteca.ListarLirvosDisponiveis(livros);
            break;
        case 8:
            Biblioteca.ListarLirvosEmprestados(emprestimos);
            break;
        case 9:
            Biblioteca.RealizarEmprestimo(livros, usuarios, emprestimos);
            break;
        case 10:
            break;
        case 0:
            Console.WriteLine("Saindo do sistema...");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

} while (escolha != 0);
