SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    DELETE ead
    FROM dbo.EntradaAssistenciaTecnicaDescricao AS ead
    INNER JOIN dbo.EntradaAssistenciaTecnica AS ea ON ea.Id = ead.EntradaAssistenciaTecnicaId
    WHERE ea.NumeroRemessa LIKE N'BOARD-DEMO-20261025-%';

    DELETE FROM dbo.EntradaAssistenciaTecnica
    WHERE NumeroRemessa LIKE N'BOARD-DEMO-20261025-%';

    DELETE pf
    FROM dbo.PessoaFisica AS pf
    INNER JOIN dbo.Cliente AS c ON c.Id = pf.ClienteId
    WHERE c.Email LIKE N'board.demo.%@example.invalid'
      AND pf.Cpf IN (N'00000000001', N'00000000002', N'00000000003', N'00000000004');

    DELETE FROM dbo.Cliente
    WHERE Email IN
    (
        N'board.demo.01@example.invalid',
        N'board.demo.02@example.invalid',
        N'board.demo.03@example.invalid',
        N'board.demo.04@example.invalid'
    );

    DELETE e
    FROM dbo.Endereco AS e
    WHERE e.Rua IN
    (
        N'BOARD-DEMO-20261025-01 - Rua Ficticia',
        N'BOARD-DEMO-20261025-02 - Rua Ficticia',
        N'BOARD-DEMO-20261025-03 - Rua Ficticia',
        N'BOARD-DEMO-20261025-04 - Rua Ficticia'
    )
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.Cliente AS c
          WHERE c.EnderecoId = e.Id
      );

    DELETE FROM dbo.Maquina
    WHERE Modelo IN
    (
        N'DEMO TIG-200',
        N'DEMO MIG-250',
        N'DEMO MMA-160',
        N'DEMO PLASMA-40'
    );

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
