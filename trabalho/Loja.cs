public class Loja
{
    private  List<Produto> produtos;
    private  List<Cliente> clientes;
    private  List<Pedido> pedidos;

    public Loja()
    {
        produtos = new List<Produto>();
        clientes = new List<Cliente>();
        pedidos = new List<Pedido>();
    }

    
    public void CadastrarProduto(Produto produto)
    {
        if (produto != null && !produtos.Any(p => p.Codigo == produto.Codigo)) //garante que o produto não seja nulo e que não exista na lista
        {
            produtos.Add(produto);
            
        }
    }

    public Produto ConsultarProdutoPorCodigo(string codigo)
    {
        return produtos.FirstOrDefault(p => p.Codigo == codigo); 
    }

    public void ListarProdutos()
    {
        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Nome} - {produto.Codigo} - Preço: {produto.Preco:C}");
        }
    }

    
    public void CadastrarCliente(Cliente cliente)
    {
        if (cliente != null && !clientes.Any(c => c.NumeroIdentificacao == cliente.NumeroIdentificacao))
        {
            clientes.Add(cliente);
            
        }
    }

    public Cliente ConsultarClientePorID(string numeroIdentificacao)
    {   
        
        var cliente = clientes.FirstOrDefault(c => c.NumeroIdentificacao == numeroIdentificacao); //Percorre até encontrar um numero de identificação que corresponde ao digitado.

    if (cliente == null) // Verifica se o cliente não foi encontrado
    {
        Console.WriteLine("Cliente não encontrado."); // Lança uma exceção
    }

    return cliente; // Retorna o cliente encontrado 
    }

    public void ListarClientes()
    {
        foreach (var cliente in clientes)
        {
            Console.WriteLine(cliente.ExibirInformacoes());
        }
    }

    // Gerenciamento de Pedidos
    public Pedido CriarPedido(Cliente cliente)
    {
    if (!clientes.Contains(cliente)) // Verifica se o cliente não está na lista
    {
        Console.WriteLine("Cliente não encontrado na lista de clientes."); 
    }

    var pedido = new Pedido(cliente);
    pedidos.Add(pedido);
    return pedido;
    }   

    public void FinalizarPedido(Pedido pedido)
    {
        pedido.FinalizarPedido();
        
    }

    public void ListarPedidos()
    {
        foreach (var pedido in pedidos)
        {
            Console.WriteLine($"Pedido de {pedido.Cliente.Nome} - Status: {pedido.Status} - Data: {pedido.DataPedido}");
        }
    }
}
