public class Dimensoes
{
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Profundidade { get; set; }
    

}

public class ProdutoFisico : Produto
{
    public double Peso { get; set; }
    public Dimensoes Dimensao { get; set; }
    public string Categoria { get; set; }
    public int QuantidadeEstoque { get; private set; }

    public ProdutoFisico(Dimensoes dimensao, string nome, string codigo, decimal preco, int quantidadeEstoque)
        : base(nome, codigo, preco)
    {
        QuantidadeEstoque = quantidadeEstoque;
        Dimensao = dimensao;
    }
    public override decimal CalcularPrecoFinal()
    {
        decimal TaxaDeImposto = 0.10m;
        int ValorPorKg = 5;
        decimal ValorImposto = Preco * TaxaDeImposto;
        decimal CustoEnvio = (decimal)Peso * ValorPorKg;
        decimal Desconto = 0; 
        decimal precoFinal = (Preco + ValorImposto + CustoEnvio) - Desconto;

        return precoFinal;
    }
    public void ReduzirEstoque()
    {
        if (QuantidadeEstoque > 0)
        {
            QuantidadeEstoque--;
        }
        else
        {
            throw new InvalidOperationException("Estoque insuficiente.");
        }
    }
}
