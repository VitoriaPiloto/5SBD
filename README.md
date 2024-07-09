# Projeto 5SBD - Bazar Tem Tudo 

- Tabela Clientes: É criada dinamicamente após a criação do pedido ou é alimentada pelo endpoint "/clientes"
- Tabela Produtos: Segue a mesma lógica da anterior
- Tabela Pedidos: No projeto inicial, era carregada por carga. Atualmente, na versão da API é carregada pelo POST ("/pedidos") que alimenta as outras tabelas secundárias, as quais se relacionam.
- Tabela Itens Pedidos: Recebe todos os itens comprados no pedido. No mundo real, pode ser considerada como o "carrinho". É alimentado ao realizar um POST em "/pedidos"
- Tabela Atendimentos: Recebe toda a informação geral dos pedidos, como valor total e se o pedido conteve todos os itens solicitados. Segue a mesma lógica de alimentação da anterior.
- Tabela Estoque: É atualizada dinamicamente de acordo com a entrada e saída de produtos. Ou seja, através dos endpoints "/pedidos" ou "/comprasEstoque"
- Tabela Compras Estoque: Remete aos produtos não disponíveis no estoque, que necessitam ser comprados para que os pedidos possam sair. Ao realizar um post em "/comprasEstoque", o estoque é atualizado com a compra realizada.

## Modelo da API no swagger:

![Swagger](/swagger.jpeg)

## Modelo de requisição POST:

- Clientes:

```
{
  "cpf": "string",
  "nome": "string",
  "email": "string",
  "telefone": "string",
  "logradouro": "string",
  "cidade": "string",
  "estado": "string",
  "cep": "string",
  "pais": "string"
}
```

- Compras Estoque:

```
{
  "quantidade": 0,
  "codigoProduto": "string"
}
```

- Pedidos:

```
{
  "dataCompra": "string",
  "dataPagamento": "string",
  "cpf": "string",
  "itensPedidos": [
    {
      "idProduto": "string",
      "quantidade": 0
    }
  ]
}
```

- Produto:

```
{
  "sku": "string",
  "nomeProduto": "string",
  "moeda": "string",
  "preco": 0
}
```

## Tecnologias utilizadas:

- C#
- Entity Framework
- Arquitetura MVC / DDD
- AutoMapper
