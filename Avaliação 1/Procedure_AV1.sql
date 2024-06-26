USE [AvaliacaoAV1]
GO
/****** Object:  StoredProcedure [dbo].[ProcessarCarga]    Script Date: 12/05/2024 17:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProcessarCarga]
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


