# Sistema de Gestão de Biblioteca

## Descrição do Projeto
Este projeto consiste em um sistema de gerenciamento de biblioteca desenvolvido em console utilizando a linguagem C#. O software foi criado como parte da avaliação A2-1 da disciplina de Tópicos Especiais de Sistemas, com foco na aplicação de Programação Orientada a Objetos e lógica de negócio real.

## Integrantes da Equipe
* **Matheus Pupia**
* **Gabriel Henrique Alves Raatz**

## Funcionalidades
O sistema permite realizar as seguintes operações:
- Cadastrar usuários com validações obrigatórias:
  - Nome não pode ser nulo, vazio ou apenas espaços.
  - Nome deve ser único no sistema (não aceita duplicado, ignorando maiúsculas/minúsculas).
  - Idade deve ser numérica e estar entre 0 e 120 anos.
  - Telefone deve conter apenas números e ter entre 10 e 11 dígitos.
- Listar usuários cadastrados com saída padronizada.
- Excluir usuários com regras de segurança:
  - Solicita confirmação (`S/N`) antes de excluir.
  - Bloqueia exclusão de usuário com empréstimos ativos.
- Cadastrar livros com validações de dados:
  - Título e autor não podem ser nulos, vazios ou apenas espaços.
  - Ano deve ser numérico e estar entre 0 e o ano atual.
  - Permite mesmo título e autor quando o ano é diferente.
  - Bloqueia duplicidade exata (mesmo título, autor e ano).
- Listar todos os livros com status (`Disponível` ou `Emprestado`) e usuário responsável quando aplicável.
- Buscar livros por título (ignorando maiúsculas/minúsculas), com retorno de múltiplos resultados quando houver.
- Excluir livros com confirmação (`S/N`) e bloqueio para livros emprestados.
- Listar apenas livros disponíveis.
- Listar apenas livros emprestados.
- Realizar empréstimo com validações:
  - Usuário e livro informados são obrigatórios e devem existir.
  - Para títulos repetidos, permite selecionar qual exemplar será emprestado.
  - Só permite empréstimo de livro disponível.
  - Quantidade de dias deve ser numérica e maior ou igual a 1 e menor ou igual a 30.
- Devolver livro com validações:
  - Usuário informado deve existir.
  - Usuário precisa ter empréstimos ativos.
  - Permite selecionar qual livro será devolvido quando houver mais de um.

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Ferramentas**: .NET SDK, Git e GitHub.

## Instruções de Execução
Para executar o sistema em sua máquina local:
1. Clone este repositório para o seu computador.
2. Abra o terminal na pasta raiz do projeto.
3. Certifique-se de que o SDK do .NET está instalado.
4. Execute o comando:
   ```bash
   dotnet run
   ```
Siga as opções exibidas no menu interativo do console.