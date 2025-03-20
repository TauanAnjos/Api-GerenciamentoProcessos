# Api-GerenciamentoProcessos
Bem-vindo(a) ao repositório da API de Gerenciamento de Processos! 🚀

Este projeto foi desenvolvido como parte de uma prova prática para uma vaga de estágio em desenvolvimento backend. O objetivo principal da API é gerenciar processos de forma eficiente, oferecendo endpoints organizados para criação, consulta, atualização e remoção de processos.

A API foi construída com .NET (C#) e utiliza SQL Server como banco de dados. Além disso, o Swagger foi integrado para facilitar a documentação e os testes dos endpoints.

## Arquitetura do Projeto
Para garantir organização, escalabilidade e facilidade de manutenção, a API segue um modelo baseado no padrão MVC (Model-View-Controller), organizado da seguinte forma:

🔹 Models → Representam as entidades do sistema, refletindo a estrutura dos dados no banco.

🔹 Repositories → Responsáveis por interagir diretamente com o banco de dados.

🔹 Services → Contêm as regras de negócio e processam as informações antes de enviá-las ao controller.

🔹 Controllers → Gerenciam as requisições HTTP, acionam os serviços e retornam as respostas.

Essa separação permite um código mais limpo e facilita futuras expansões da aplicação.

## Tecnologias Utilizadas
🛠 Backend → .NET (C#)

🗄 Banco de Dados → SQL Server

📄 Documentação da API → Swagger

🎯 Arquitetura → Padrão MVC

##🏛️ Configuração do Banco de Dados

Para utilizar a API, é necessário criar o banco de dados e suas tabelas. Siga os passos abaixo para configurar o ambiente no SQL Server.

##📌 Passo 1: Criar o Banco de Dados

Abra o SQL Server Management Studio (SSMS) ou outro cliente SQL e execute o seguinte comando:

CREATE DATABASE GerenciamentoProcessos; 

##📌 Passo 2: Selecionar o Banco de Dados

Após criar o banco, selecione-o para poder criar as tabelas:

USE GerenciamentoProcessos;

##📌 Passo 3: Criar as Tabelas

Execute os comandos abaixo para criar as tabelas necessárias:

CREATE TABLE [Processo] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [numero] nvarchar(255) UNIQUE,
  [orgao_responsavel] nvarchar(255),
  [assunto] nvarchar(255),
  [status] nvarchar(255),
  [procurador_id] uniqueidentifier,
  [cliente_id] uniqueidentifier
)
GO

CREATE TABLE [Prazo] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [processo_id] uniqueidentifier,
  [tipo] nvarchar(255),
  [data_vencimento] date,
  [status] nvarchar(255)
)
GO

CREATE TABLE [Documento] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [processo_id] uniqueidentifier,
  [nome] nvarchar(255),
  [tipo] nvarchar(50),
  [caminho_arquivo] nvarchar(255)
)
GO

CREATE TABLE [Procurador] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [nome] nvarchar(255),
  [email] nvarchar(255) UNIQUE,
  [senha] nvarchar(255),
  [oab] nvarchar(255) UNIQUE
)
GO

CREATE TABLE [Cliente] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [nome] nvarchar(255),
  [email] nvarchar(255) UNIQUE,
  [senha] nvarchar(255)
)
GO

CREATE TABLE [DistribuicaoProcesso] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [processo_id] uniqueidentifier,
  [procurador_origem_id] uniqueidentifier,
  [procurador_destino_id] uniqueidentifier,
  [data_transferencia] datetime
)
GO

##📌 Passo 4: Criar as Relações entre as Tabelas

Agora, adicione as chaves estrangeiras para garantir a integridade referencial:

ALTER TABLE [Processo] 
  ADD FOREIGN KEY ([procurador_id]) REFERENCES [Procurador] ([id]) ON DELETE NO ACTION  -- Ligação com procurador, não permite exclusão do procurador se associado a processo
GO

ALTER TABLE [Processo] 
  ADD FOREIGN KEY ([cliente_id]) REFERENCES [Cliente] ([id]) ON DELETE NO ACTION  -- Ligação com cliente, não permite exclusão do cliente se associado a processo
GO

ALTER TABLE [Prazo] 
  ADD FOREIGN KEY ([processo_id]) REFERENCES [Processo] ([id]) ON DELETE NO ACTION  -- Ligação com processo, não permite exclusão do processo se houver prazo relacionado
GO

ALTER TABLE [Documento] 
  ADD FOREIGN KEY ([processo_id]) REFERENCES [Processo] ([id]) ON DELETE NO ACTION  -- Ligação com processo, não permite exclusão do processo se houver documentos relacionados
GO

ALTER TABLE [DistribuicaoProcesso] 
  ADD FOREIGN KEY ([processo_id]) REFERENCES [Processo] ([id]) ON DELETE NO ACTION  -- Ligação com processo, não permite exclusão do processo se distribuído
GO

ALTER TABLE [DistribuicaoProcesso] 
  ADD FOREIGN KEY ([procurador_origem_id]) REFERENCES [Procurador] ([id]) ON DELETE NO ACTION  -- Ligação com procurador de origem, não permite exclusão se estiver em distribuição
GO

ALTER TABLE [DistribuicaoProcesso] 
  ADD FOREIGN KEY ([procurador_destino_id]) REFERENCES [Procurador] ([id]) ON DELETE NO ACTION  -- Ligação com procurador de destino, não permite exclusão se estiver em distribuição
GO

##✅ Banco de Dados Criado com Sucesso!

## Testando a API

Após iniciar a API, abra no navegador:

https://localhost:7113/swagger/index.html

🔹 Endpoints Principais

Método	Rota	Descrição

GET	/api/v1/processos	Lista todos os processos

GET	/api/v1/processos/{id}	Consulta um processo específico

POST	/api/v1/processos	Cria um novo processo

PUT	/api/v1/processos/{id}	Atualiza um processo existente

DELETE	/api/v1/processos/{id}	Remove um processo

## Estrutura do Projeto

/src

  /Controllers
  
    - ProcessosController.cs
    
  /Models
  
    - Processo.cs
  /Repositories
  
    - ProcessoRepository.cs
  /Services
  
    - ProcessoService.cs

