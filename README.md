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

## 🏛️ Configuração do Banco de Dados

Para utilizar a API, é necessário criar o banco de dados e suas tabelas. Siga os passos abaixo para configurar o ambiente no SQL Server.

### 📌 Passo 1: Criar o Banco de Dados

Abra o SQL Server Management Studio (SSMS) ou outro cliente SQL e execute o seguinte comando:

CREATE DATABASE GerenciamentoProcessos; 

### 📌 Passo 2: Selecionar o Banco de Dados

Após criar o banco, selecione-o para poder criar as tabelas:

USE GerenciamentoProcessos;

### 📌 Passo 3: Criar as Tabelas

Execute os comandos abaixo para criar as tabelas necessárias:

CREATE TABLE [Processo] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [numero] nvarchar(255) UNIQUE,
  [orgao_responsavel] nvarchar(255),
  [assunto] nvarchar(255),
  [status] int,
  [procurador_id] uniqueidentifier,
  [cliente_id] uniqueidentifier
)

CREATE TABLE [Prazo] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [processo_id] uniqueidentifier,
  [tipo] nvarchar(255),
  [data_vencimento] date,
  [status] int
)

CREATE TABLE [Documento] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [processo_id] uniqueidentifier,
  [nome] nvarchar(255),
  [tipo] nvarchar(50),
  [caminho_arquivo] nvarchar(255)
)

CREATE TABLE [Procurador] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [nome] nvarchar(255),
  [email] nvarchar(255) UNIQUE,
  [senha] nvarchar(255),
  [oab] nvarchar(255) UNIQUE
)

CREATE TABLE [Cliente] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [nome] nvarchar(255),
  [email] nvarchar(255) UNIQUE,
  [senha] nvarchar(255)
)

CREATE TABLE [DistribuicaoProcesso] (
  [id] uniqueidentifier PRIMARY KEY default NEWID(),
  [processo_id] uniqueidentifier,
  [procurador_origem_id] uniqueidentifier,
  [procurador_destino_id] uniqueidentifier,
  [data_transferencia] datetime
)

### 📌 Passo 4: Criar as Relações entre as Tabelas

Agora, adicione as chaves estrangeiras para garantir a integridade referencial:

ALTER TABLE [Processo] 
  ADD FOREIGN KEY ([procurador_id]) REFERENCES [Procurador] ([id]) ON DELETE NO ACTION  -- Ligação com procurador, não permite exclusão do procurador se associado a processo
GO

ALTER TABLE [Processo] 
  ADD FOREIGN KEY ([cliente_id]) REFERENCES [Cliente] ([id]) ON DELETE NO ACTION  -- Ligação com cliente, não permite exclusão do cliente se associado a processo

ALTER TABLE [Prazo] 
  ADD FOREIGN KEY ([processo_id]) REFERENCES [Processo] ([id]) ON DELETE NO ACTION  -- Ligação com processo, não permite exclusão do processo se houver prazo relacionado

ALTER TABLE [Documento] 
  ADD FOREIGN KEY ([processo_id]) REFERENCES [Processo] ([id]) ON DELETE NO ACTION  -- Ligação com processo, não permite exclusão do processo se houver documentos relacionados

ALTER TABLE [DistribuicaoProcesso] 
  ADD FOREIGN KEY ([processo_id]) REFERENCES [Processo] ([id]) ON DELETE NO ACTION  -- Ligação com processo, não permite exclusão do processo se distribuído

ALTER TABLE [DistribuicaoProcesso] 
  ADD FOREIGN KEY ([procurador_origem_id]) REFERENCES [Procurador] ([id]) ON DELETE NO ACTION  -- Ligação com procurador de origem, não permite exclusão se estiver em distribuição

ALTER TABLE [DistribuicaoProcesso] 
  ADD FOREIGN KEY ([procurador_destino_id]) REFERENCES [Procurador] ([id]) ON DELETE NO ACTION  -- Ligação com procurador de destino, não permite exclusão se estiver em distribuição

### ✅ Banco de Dados Criado com Sucesso!

## 📝 Script para popular o banco para testes!

-- Inserir Procuradores
INSERT INTO Procurador (id, nome, email, senha, oab) VALUES
  (NEWID(), 'João Silva', 'joao.silva@email.com', 'senha123', '12345/SP'),
  (NEWID(), 'Maria Oliveira', 'maria.oliveira@email.com', 'senha123', '67890/RJ');

-- Inserir Clientes
INSERT INTO Cliente (id, nome, email, senha) VALUES
  (NEWID(), 'Carlos Souza', 'carlos.souza@email.com', 'senha123'),
  (NEWID(), 'Ana Lima', 'ana.lima@email.com', 'senha123');

-- Inserir Processos
DECLARE @procurador_id UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM Procurador);
DECLARE @cliente_id UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM Cliente);

INSERT INTO Processo (id, numero, orgao_responsavel, assunto, status, procurador_id, cliente_id) VALUES
  (NEWID(), '2024001', 'Tribunal de Justiça', 'Ação Trabalhista', 1, @procurador_id, @cliente_id),
  (NEWID(), '2024002', 'Justiça Federal', 'Revisão de Benefício', 2, @procurador_id, @cliente_id);

-- Inserir Prazos
DECLARE @processo_id UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM Processo);

INSERT INTO Prazo (id, processo_id, tipo, data_vencimento, status) VALUES
  (NEWID(), @processo_id, 'Entrega de Documentos', '2024-10-01', 1);

-- Inserir Documentos
INSERT INTO Documento (id, processo_id, nome, tipo, caminho_arquivo) VALUES
  (NEWID(), @processo_id, 'Petição Inicial', 'PDF', '/documentos/peticao_inicial.pdf');

-- Inserir Distribuições de Processo
DECLARE @procurador_destino_id UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM Procurador WHERE id <> @procurador_id);

INSERT INTO DistribuicaoProcesso (id, processo_id, procurador_origem_id, procurador_destino_id, data_transferencia) VALUES
  (NEWID(), @processo_id, @procurador_id, @procurador_destino_id, GETDATE());

## 🔧 Configuração da Conexão com o Banco de Dados

No arquivo appsettings.json, localizado na raiz do projeto, configure a string de conexão para conectar ao banco de dados.

"ConnectionStrings": {
  "DefaultConnection": "Server=NOME_DO_SEU_SERVIDOR;Database=GerenciamentoProcessos;User Id=SEU_USUARIO;Password=SUA_SENHA;Encrypt=True;TrustServerCertificate=True"
}

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

