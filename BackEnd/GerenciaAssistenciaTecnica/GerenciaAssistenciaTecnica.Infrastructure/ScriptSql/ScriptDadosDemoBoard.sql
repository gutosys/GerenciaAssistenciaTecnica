SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @EntradaStatusId int;
DECLARE @EstadoId int;
DECLARE @CidadeId int;

SELECT @EntradaStatusId = Id
FROM dbo.EntradaAssistenciaTecnicaStatus
WHERE Descricao = N'Entrada';

SELECT @EstadoId = Id
FROM dbo.Estado
WHERE UF = N'SP';

SELECT @CidadeId = Id
FROM dbo.Cidade
WHERE Descricao = N'São Paulo'
  AND EstadoId = @EstadoId;

IF @EntradaStatusId IS NULL
    THROW 50001, 'O status Entrada nao existe. Execute a carga inicial da aplicacao antes deste script.', 1;

IF @EstadoId IS NULL OR @CidadeId IS NULL
    THROW 50003, 'O estado e a cidade de demonstracao nao existem. Execute a carga inicial da aplicacao antes deste script.', 1;

IF (SELECT COUNT(*)
    FROM dbo.EntradaAssistenciaTecnicaStatus
    WHERE Descricao = N'Entrada') <> 1
    THROW 50002, 'Existe mais de um status Entrada; os dados de demonstracao nao foram inseridos.', 1;

DECLARE @Demo TABLE
(
    Numero int NOT NULL PRIMARY KEY,
    Nome nvarchar(200) NOT NULL,
    Sobrenome nvarchar(150) NOT NULL,
    Email nvarchar(200) NOT NULL,
    Cpf nvarchar(11) NOT NULL,
    Rg nvarchar(20) NOT NULL,
    Rua nvarchar(250) NOT NULL,
    Bairro nvarchar(150) NOT NULL,
    NumeroEndereco nvarchar(30) NOT NULL,
    Cep nvarchar(30) NOT NULL,
    Modelo nvarchar(200) NOT NULL,
    MaquinaDescricao nvarchar(250) NOT NULL,
    NumeroRemessa nvarchar(250) NOT NULL,
    NumeroNF nvarchar(250) NOT NULL,
    NumeroSerie nvarchar(250) NOT NULL,
    NS nvarchar(100) NOT NULL,
    Descricao nvarchar(2000) NOT NULL
);

INSERT INTO @Demo
    (Numero, Nome, Sobrenome, Email, Cpf, Rg, Rua, Bairro, NumeroEndereco, Cep, Modelo, MaquinaDescricao,
     NumeroRemessa, NumeroNF, NumeroSerie, NS, Descricao)
VALUES
    (1, N'Ana', N'Demonstracao', N'board.demo.01@example.invalid', N'00000000001', N'DEMO-RG-01',
     N'BOARD-DEMO-20261025-01 - Rua Ficticia', N'Bairro Demonstracao', N'101', N'00000-001',
     N'DEMO TIG-200', N'Inversora de solda TIG 200 A - demonstracao',
     N'BOARD-DEMO-20261025-01', N'NF-DEMO-001', N'SERIE-DEMO-001', N'NS-BOARD-DEMO-001',
     N'Item ficticio para testar a movimentacao de entrada no Board.'),
    (2, N'Bruno', N'Demonstracao', N'board.demo.02@example.invalid', N'00000000002', N'DEMO-RG-02',
     N'BOARD-DEMO-20261025-02 - Rua Ficticia', N'Bairro Demonstracao', N'202', N'00000-002',
     N'DEMO MIG-250', N'Soldadora MIG 250 A - demonstracao',
     N'BOARD-DEMO-20261025-02', N'NF-DEMO-002', N'SERIE-DEMO-002', N'NS-BOARD-DEMO-002',
     N'Item ficticio para testar a movimentacao de entrada no Board.'),
    (3, N'Carla', N'Demonstracao', N'board.demo.03@example.invalid', N'00000000003', N'DEMO-RG-03',
     N'BOARD-DEMO-20261025-03 - Rua Ficticia', N'Bairro Demonstracao', N'303', N'00000-003',
     N'DEMO MMA-160', N'Inversora de solda MMA 160 A - demonstracao',
     N'BOARD-DEMO-20261025-03', N'NF-DEMO-003', N'SERIE-DEMO-003', N'NS-BOARD-DEMO-003',
     N'Item ficticio para testar a movimentacao de entrada no Board.'),
    (4, N'Diego', N'Demonstracao', N'board.demo.04@example.invalid', N'00000000004', N'DEMO-RG-04',
     N'BOARD-DEMO-20261025-04 - Rua Ficticia', N'Bairro Demonstracao', N'404', N'00000-004',
     N'DEMO PLASMA-40', N'Cortadora plasma 40 A - demonstracao',
     N'BOARD-DEMO-20261025-04', N'NF-DEMO-004', N'SERIE-DEMO-004', N'NS-BOARD-DEMO-004',
     N'Item ficticio para testar a movimentacao de entrada no Board.');

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO dbo.Endereco (Rua, Bairro, Numero, Cep, CidadeId, EstadoId)
    SELECT d.Rua, d.Bairro, d.NumeroEndereco, d.Cep, @CidadeId, @EstadoId
    FROM @Demo AS d
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.Endereco AS e
        WHERE e.Rua = d.Rua
    );

    INSERT INTO dbo.Cliente (Email, TipoPessoa, EnderecoId)
    SELECT d.Email, N'F', e.Id
    FROM @Demo AS d
    INNER JOIN dbo.Endereco AS e ON e.Rua = d.Rua
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.Cliente AS c
        WHERE c.Email = d.Email
    );

    UPDATE c
    SET EnderecoId = e.Id
    FROM dbo.Cliente AS c
    INNER JOIN @Demo AS d ON d.Email = c.Email
    INNER JOIN dbo.Endereco AS e ON e.Rua = d.Rua
    WHERE c.EnderecoId IS NULL;

    INSERT INTO dbo.PessoaFisica (ClienteId, Nome, Sobrenome, Cpf, Rg)
    SELECT c.Id, d.Nome, d.Sobrenome, d.Cpf, d.Rg
    FROM @Demo AS d
    INNER JOIN dbo.Cliente AS c ON c.Email = d.Email
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.PessoaFisica AS pf
        WHERE pf.Cpf = d.Cpf
    );

    INSERT INTO dbo.Maquina (Descricao, Modelo)
    SELECT d.MaquinaDescricao, d.Modelo
    FROM @Demo AS d
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.Maquina AS m
        WHERE m.Modelo = d.Modelo
    );

    INSERT INTO dbo.EntradaAssistenciaTecnica
        (PessoaFisicaId, NumeroRemessa, NumeroNF, MaquinaId, NumeroSerie,
         EntradaAssistenciaStatusId, NumeroComprovanteCompra, TrocaJaEfetuada,
         NS, DataEntrada)
    SELECT pf.Id, d.NumeroRemessa, d.NumeroNF, m.Id, d.NumeroSerie,
           @EntradaStatusId, N'DEMO-SEM-COMPROVANTE', 0,
           d.NS, DATEADD(DAY, -d.Numero, GETDATE())
    FROM @Demo AS d
    INNER JOIN dbo.PessoaFisica AS pf ON pf.Cpf = d.Cpf
    INNER JOIN dbo.Maquina AS m ON m.Modelo = d.Modelo
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.EntradaAssistenciaTecnica AS ea
        WHERE ea.NumeroRemessa = d.NumeroRemessa
    );

    INSERT INTO dbo.EntradaAssistenciaTecnicaDescricao
        (Descricao, EntradaAssistenciaStatusId, EntradaAssistenciaTecnicaId, DataGravacao)
    SELECT d.Descricao, @EntradaStatusId, ea.Id, GETDATE()
    FROM @Demo AS d
    INNER JOIN dbo.EntradaAssistenciaTecnica AS ea ON ea.NumeroRemessa = d.NumeroRemessa
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.EntradaAssistenciaTecnicaDescricao AS ead
        WHERE ead.EntradaAssistenciaTecnicaId = ea.Id
          AND ead.Descricao = d.Descricao
    );

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
