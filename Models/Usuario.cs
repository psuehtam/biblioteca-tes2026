namespace biblioteca_tes2026.Models
{
    class Usuario
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }

        public Usuario(string nome, int idade, string telefone)
        {
            Nome = nome;
            Idade = idade;
            Telefone = telefone;
        }

        public void Exibir()
        {
            Console.WriteLine(Nome + " - " + Idade + " anos - " + Telefone);
        }
    }
}
