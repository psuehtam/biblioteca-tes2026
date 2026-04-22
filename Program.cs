using biblioteca_tes2026.Models;

List<Livro> livros = new List<Livro>();
List<Usuario> usuarios = new List<Usuario>();
List<Emprestimo> emprestimos = new List<Emprestimo>();

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
    Console.WriteLine("7 - Consultar Disponibilidade");
    Console.WriteLine("8 - Consultar Indisponiveis");
    Console.WriteLine("9 - Realizar Empréstimo");
    Console.WriteLine("10 - Devolver Livro");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite sua escolha: ");
    escolha = int.Parse(Console.ReadLine());

    switch (escolha)
    {
        case 1: ;                              
        break;
        case 2: ;                              
        break;
        case 3: Biblioteca.CadastrarLivro(livros);                              
        break;
        
        default: Console.WriteLine("Opção inválida. Tente novamente.");             
        break;
    }

} while (escolha != 0);
