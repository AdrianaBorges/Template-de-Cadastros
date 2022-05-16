CREATE TABLE [dbo].[Pessoa] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Codigo]       NVARCHAR (40) NOT NULL,
    [Nome]         NVARCHAR (80) NOT NULL,
    [Cpf]          NVARCHAR (30) NOT NULL,
    [Sexo]         INT           NOT NULL,
    [Status]       INT           NOT NULL,
    [DtNascimento] DATE          NOT NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED ([Id] ASC)
);
