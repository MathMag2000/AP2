        Loja loja = new Loja();

        // Cadastro de Produtos
        Dimensoes dimensaoSmartphone = new Dimensoes
        {
            Altura = 15,
            Largura = 7,
            Profundidade = 0.8
        };

        Produto produtoFisico = new ProdutoFisico(
            nome: "Smartphone",
            codigo: "SP123",
            preco: 1500.00m,
            dimensao: dimensaoSmartphone, // dimensão do smartphone aqui
            quantidadeEstoque: 10 
        )
        {
            Peso = 0.2,
            Categoria = "Eletrônicos"
        };
        
        Produto produtoDigital = new ProdutoDigital
        (
            nome: "Curso de C#",
            codigo: "CURSO456",
            preco: 29.90m
        )
        {
            
            TamanhoArquivo = 2.5,
            Formato = "PDF"
        };

        loja.CadastrarProduto(produtoFisico);
        loja.CadastrarProduto(produtoDigital);

        // Cadastro de Clientes
        Cliente cliente1 = new Cliente("João Silva", "123.456.789-00", "Rua das Flores, 123", "joao@email.com")
        {
            Nome = "João Silva",
            NumeroIdentificacao = "123.456.789-00",
            Endereco = "Rua das Flores, 123",
            Contato = "joao@email.com"
        };

        loja.CadastrarCliente(cliente1);

        //Pedidos
        Pedido pedido = loja.CriarPedido(cliente1);
        pedido.AdicionarProduto(produtoFisico);
        pedido.AdicionarProduto(produtoDigital);

        // Calcular total
        decimal total = pedido.CalcularTotal();
        Console.WriteLine($"Total do pedido: {total:C}");

        // Finalização do Pedido
        loja.FinalizarPedido(pedido);
        Console.WriteLine($"Status do pedido: {pedido.Status}");

        // Consulta de Dados
        Console.WriteLine("\nLista de Produtos:");
        loja.ListarProdutos();

        Console.WriteLine("\nLista de Clientes:");
        loja.ListarClientes();

        Console.WriteLine("\nLista de Pedidos:");
        loja.ListarPedidos();

