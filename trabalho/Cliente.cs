public class Cliente
{
    private string nome;
    public string Nome //Serve para controlar as mudanças que serão feita no valor de "nome"
    {
        get { return nome; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value)) //validação para verificar se o valor é nulo, vazio ou contém apenas espaços em branco
                Console.WriteLine("O nome não pode ser vazio.");
            nome = value;
        }
    }

    public string NumeroIdentificacao { get; set; }
    public string Endereco { get; set; }
    public string Contato { get; set; }

    public Cliente(string nome, string numeroIdentificacao, string endereco, string contato)
    {
        Nome = nome;
        NumeroIdentificacao = numeroIdentificacao;
        Endereco = endereco;
        Contato = contato;
    }

    public string ExibirInformacoes()
    {
        return $"Nome: {Nome}\n" +
               $"Identificação: {NumeroIdentificacao}\n" +
               $"Endereço: {Endereco}\n" +
               $"Contato: {Contato}";
    }
}

