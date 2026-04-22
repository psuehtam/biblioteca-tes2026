using biblioteca_tes2026.Models;

List<Livro> livros = new List<Livro>();
List<Usuario> usuarios = new List<Usuario>();
List<Emprestimo> emprestimos = new List<Emprestimo>();

usuarios.Add(new Usuario("João Silva", 28, "11999999999"));
usuarios.Add(new Usuario("Maria Santos", 35, "11988888888"));
usuarios.Add(new Usuario("Pedro Oliveira", 22, "11977777777"));

livros.Add(new Livro("Clean Code", "Robert Martin", 2008));
livros.Add(new Livro("Design Patterns", "Gang of Four", 1994));
livros.Add(new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954));
livros.Add(new Livro("1984", "George Orwell", 1949));

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
    escolha = int.Parse(Console.ReadLine());

    switch (escolha)
    {
        case 1: Biblioteca.CadastrarUsuario(usuarios);                              
        break;
        case 2: Biblioteca.ListarUsuarios(usuarios);                              
        break;
        case 3: Biblioteca.CadastrarLivro(livros);                              
        break;
        case 4: Biblioteca.ListarLivros(livros);                              
        break;
        case 5: Biblioteca.BuscarLivro(livros);                         
        break;
        case 6: Biblioteca.ExcluirLivro(livros);                              
        break;
        case 7: Biblioteca.ListarLirvosDisponiveis(livros);                             
        break;
        case 8: Biblioteca.ListarLirvosEmprestados(livros);                             
        break;
        case 9: Biblioteca.RealizarEmprestimo(livros, usuarios, emprestimos);                              
        break;
        case 10:                              
        break;
        case 0:                              
        break;
        
        default: Console.WriteLine("Opção inválida. Tente novamente.");             
        break;
    }

} while (escolha != 0);
