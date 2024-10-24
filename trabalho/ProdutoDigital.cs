public class ProdutoDigital : Produto
{
    private double tamanhoArquivo;
    public double TamanhoArquivo  //Serve para controlar as mudanças que serão feita no valor de "tamanhoArquivo"
    {
        get { return tamanhoArquivo; }
        set 
        {
            if (value > 0)
                tamanhoArquivo = value; //É válido caso o valor for maior que 0
            else
                Console.WriteLine("O tamanho do arquivo deve ser positivo.");
        }
    }
      public ProdutoDigital(string nome, string codigo, decimal preco)
        : base(nome, codigo, preco)
        {
           
        }


    public string Formato { get; set; }

    public override decimal CalcularPrecoFinal()
    {
        decimal TaxaDeDesconto = 0.10m;
        decimal Desconto = Preco * TaxaDeDesconto;

        decimal precoFinal = Preco - Desconto;

        return precoFinal;
    }
}

