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
