USE [AvaliacaoAV1]
GO
/****** Object:  Table [dbo].[Atendimentos]    Script Date: 12/05/2024 17:53:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atendimentos](
	[order-id] [varchar](50) NOT NULL,
	[total-price] [float] NOT NULL,
	[possuiTodosItens] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carga]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carga](
	[order-id] [varchar](50) NOT NULL,
	[order-item-id] [varchar](50) NOT NULL,
	[purchase-date] [varchar](50) NOT NULL,
	[payments-date] [varchar](50) NOT NULL,
	[buyer-email] [varchar](50) NOT NULL,
	[buyer-name] [varchar](50) NOT NULL,
	[cpf] [varchar](50) NOT NULL,
	[buyer-phone-number] [varchar](50) NOT NULL,
	[sku] [varchar](50) NOT NULL,
	[product-name] [varchar](50) NOT NULL,
	[quantity-purchased] [int] NOT NULL,
	[currency] [varchar](50) NOT NULL,
	[item-price] [varchar](50) NOT NULL,
	[ship-service-level] [varchar](50) NOT NULL,
	[recipient-name] [varchar](50) NOT NULL,
	[ship-address-1] [varchar](50) NULL,
	[ship-address-2] [varchar](50) NULL,
	[ship-address-3] [varchar](50) NULL,
	[ship-city] [varchar](50) NULL,
	[ship-state] [varchar](50) NULL,
	[ship-postal-code] [varchar](50) NULL,
	[ship-country] [varchar](50) NULL,
	[ioss-number] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[buyer-email] [varchar](50) NOT NULL,
	[buyer-name] [varchar](50) NOT NULL,
	[cpf] [varchar](50) NOT NULL,
	[buyer-phone-number] [varchar](50) NOT NULL,
	[ship-address-1] [varchar](50) NULL,
	[ship-city] [varchar](50) NULL,
	[ship-state] [varchar](50) NULL,
	[ship-postal-code] [varchar](50) NULL,
	[ship-country] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes_1] PRIMARY KEY CLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras_Estoque]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras_Estoque](
	[sku] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estoque]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estoque](
	[quantity] [int] NULL,
	[sku] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itens_Pedido]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itens_Pedido](
	[order-id] [varchar](50) NOT NULL,
	[order-item-id] [varchar](50) NOT NULL,
	[sku] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_Itens_Pedido] PRIMARY KEY CLUSTERED 
(
	[order-item-id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[order-id] [varchar](50) NOT NULL,
	[purchase-date] [varchar](50) NOT NULL,
	[payments-date] [varchar](50) NOT NULL,
	[cpf] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[order-id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[sku] [varchar](50) NOT NULL,
	[product-name] [varchar](50) NOT NULL,
	[currency] [varchar](50) NOT NULL,
	[item-price] [float] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Pedidos] FOREIGN KEY([order-id])
REFERENCES [dbo].[Pedidos] ([order-id])
GO
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_Pedidos]
GO
ALTER TABLE [dbo].[Compras_Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Estoque_Produtos] FOREIGN KEY([sku])
REFERENCES [dbo].[Produtos] ([sku])
GO
ALTER TABLE [dbo].[Compras_Estoque] CHECK CONSTRAINT [FK_Compras_Estoque_Produtos]
GO
ALTER TABLE [dbo].[Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Estoque_Produtos] FOREIGN KEY([sku])
REFERENCES [dbo].[Produtos] ([sku])
GO
ALTER TABLE [dbo].[Estoque] CHECK CONSTRAINT [FK_Estoque_Produtos]
GO
ALTER TABLE [dbo].[Itens_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Itens_Pedido_Pedidos] FOREIGN KEY([order-id])
REFERENCES [dbo].[Pedidos] ([order-id])
GO
ALTER TABLE [dbo].[Itens_Pedido] CHECK CONSTRAINT [FK_Itens_Pedido_Pedidos]
GO
ALTER TABLE [dbo].[Itens_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Itens_Pedido_Produtos] FOREIGN KEY([sku])
REFERENCES [dbo].[Produtos] ([sku])
GO
ALTER TABLE [dbo].[Itens_Pedido] CHECK CONSTRAINT [FK_Itens_Pedido_Produtos]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY([cpf])
REFERENCES [dbo].[Clientes] ([cpf])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes]
GO
/****** Object:  StoredProcedure [dbo].[ProcessarCarga]    Script Date: 12/05/2024 17:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcessarCarga]
AS
BEGIN
    -- Inserir clientes novos
    INSERT INTO Clientes(cpf, [buyer-name], [buyer-phone-number], [buyer-email], [ship-address-1], [ship-city], [ship-state], [ship-postal-code], [ship-country])
    SELECT DISTINCT cpf, [buyer-name], [buyer-phone-number], [buyer-email], [ship-address-1], [ship-city], [ship-state], [ship-postal-code], [ship-country]
    FROM Carga
    WHERE cpf NOT IN (SELECT cpf FROM Clientes);

    -- Inserir produtos novos
    INSERT INTO Produtos(sku, [product-name], [currency], [item-price])
    SELECT DISTINCT sku, [product-name], currency, [item-price]
    FROM Carga
    WHERE sku NOT IN (SELECT sku FROM Produtos);

    -- Inserir pedidos
    INSERT INTO Pedidos([order-id], [purchase-date], [payments-date], cpf)
    SELECT [order-id], [purchase-date], [payments-date], cpf
    FROM Carga
    GROUP BY [order-id], [purchase-date], [payments-date], cpf

    -- Inserir itens de pedido
    INSERT INTO Itens_Pedido ([order-id], [sku], [quantity], [order-item-id])
    SELECT [order-id], sku, [quantity-purchased], [order-item-id]
    FROM Carga;

	-- Atualizar estoque
		-- Atualizar estoque se quantidade for positiva
		UPDATE Estoque
		SET quantity = E.quantity - IP.quantity
		FROM Estoque AS E
		JOIN Itens_Pedido AS IP ON IP.sku = E.sku
		WHERE E.quantity > 0;

		-- Inserir itens com estoque zero na tabela Compras_Estoque
		INSERT INTO Compras_Estoque (sku, quantity)
		SELECT ip.sku, ip.quantity 
		FROM Itens_Pedido AS IP
		LEFT JOIN Estoque AS E ON IP.sku = E.sku
		WHERE E.quantity IS NULL OR E.quantity = 0
		GROUP BY ip.sku, ip.quantity;

    -- Atualizar tabela de atendimentos
	INSERT INTO Atendimentos ([order-id], [total-price], [possuiTodosItens])
	SELECT
    p.[order-id],
    SUM(ip.quantity * pr.[item-price]) AS [total-price],
    MIN(CASE WHEN e.quantity >= ip.quantity THEN 1 ELSE 0 END) AS possuiTodosItens
	FROM Pedidos P
	JOIN Itens_Pedido IP
	ON P.[order-id] = IP.[order-id]
	JOIN Produtos PR
	ON IP.sku = PR.sku
	JOIN Estoque E
	ON IP.sku = E.sku
	GROUP BY p.[order-id]
	ORDER BY possuiTodosItens DESC, SUM(ip.quantity * pr.[item-price])DESC;


END;


GO
