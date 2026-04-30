using biblioteca_tes2026.Models;

class Program
{
    static void Main(string[] args)
    {
        List<Livro> livros = new List<Livro>();
        List<Usuario> usuarios = new List<Usuario>();
        List<Emprestimo> emprestimos = new List<Emprestimo>();


        usuarios.Add(new Usuario("Ana", 25, "4112345671"));
        usuarios.Add(new Usuario("Carlos", 30, "4112345672"));
        usuarios.Add(new Usuario("Beatriz", 20, "4112345673"));
        usuarios.Add(new Usuario("Daniel", 35, "4112345674"));

        livros.Add(new Livro("Harry Potter", "J.K. Rowling", 1997));
        livros.Add(new Livro("Dom Quixote", "Cervantes", 1605));
        livros.Add(new Livro("Biblia", "Varios", 0));
        livros.Add(new Livro("Crepusculo", "Stephenie Meyer", 2005));
        livros.Add(new Livro("Senhor dos Aneis", "Tolkien", 1954));

        int escolha = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("\n========= SISTEMA DE BIBLIOTECA =========");

            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Excluir Usuário");
            Console.WriteLine("4 - Cadastrar Livro");
            Console.WriteLine("5 - Listar Todos os Livros");
            Console.WriteLine("6 - Buscar Livro");
            Console.WriteLine("7 - Excluir Livro");
            Console.WriteLine("8 - Consultar Livros Disponíveis");
            Console.WriteLine("9 - Consultar Livros Emprestados");
            Console.WriteLine("10 - Realizar Empréstimo");
            Console.WriteLine("11 - Devolver Livro");
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
                    Biblioteca.ExcluirUsuario(usuarios, emprestimos);
                    break;
                case 4:
                    Biblioteca.CadastrarLivro(livros);
                    break;
                case 5:
                    Biblioteca.ListarLivros(livros, emprestimos);
                    break;
                case 6:
                    Biblioteca.BuscarLivro(livros, emprestimos);
                    break;
                case 7:
                    Biblioteca.ExcluirLivro(livros);
                    break;
                case 8:
                    Biblioteca.ListarLivrosDisponiveis(livros);
                    break;
                case 9:
                    Biblioteca.ListarLivrosEmprestados(emprestimos);
                    break;
                case 10:
                    Biblioteca.RealizarEmprestimo(livros, usuarios, emprestimos);
                    break;
                case 11:
                    Biblioteca.DevolverLivro(livros, usuarios, emprestimos);
                    break;
                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            
            if (escolha != 0)
            {
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
            
        } while (escolha != 0);
    }
}
