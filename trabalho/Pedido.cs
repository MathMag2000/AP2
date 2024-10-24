public enum Status
{
    EmProcessamento,
    Concluido,
    Cancelado
}

public class Pedido : ICarriavel
{
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; private set; }
    public Status Status { get; private set; }
    private List<Produto> produtos;

    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
        DataPedido = DateTime.Now;
        Status = Status.EmProcessamento;
        produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        if (produto != null)
        {
            produtos.Add(produto);
        }
    }

    public void RemoverProduto(Produto produto)
    {
        if (produtos.Contains(produto))
        {
            produtos.Remove(produto);
        }
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var produto in produtos)
        {
            total += produto.CalcularPrecoFinal();
        }
        return total;
    }

    public void FinalizarPedido()
    {
        // Atualizar o estoque de produtos físicos
        foreach (var produto in produtos)
        {
            if (produto is ProdutoFisico produtoFisico)
            {
                produtoFisico.ReduzirEstoque(); // Método que diminui a quantidade no estoque
            }
        }

        // Atualiza o status do pedido para "Concluído"
        Status = Status.Concluido;
    }
}
