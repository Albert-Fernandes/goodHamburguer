# GoodHamburguer
a Simple Good Burguer

# Good Hamburger - Desafio Técnico Desenvolvedor C#

Este repositório contém a solução para o desafio técnico da Good Hamburger. O projeto consiste em uma API REST para gestão de cardápio e pedidos, aplicando as regras de negócio exigidas (combos de desconto e limite de itens). Os diferenciais solicitados (frontend e testes automatizados) foram implementados.

## Tecnologias Utilizadas

* Back-end: .NET 8 (C#), ASP.NET Core Web API
* Front-end: Blazor WebAssembly, Bootstrap 5
* Banco de Dados: Entity Framework Core (In-Memory)
* Testes: xUnit, Moq

## Decisões de Arquitetura

* Domain-Driven Design (DDD): As regras de negócio (cálculo das 3 faixas de desconto e trava de duplicidade por categoria) foram encapsuladas no domínio da aplicação. 
* Separação de Responsabilidades: Utilização de DTOs para trafegar dados. Os Controllers atuam apenas como roteadores HTTP, delegando a lógica para serviços específicos.
* Tratamento de Erros: A API retorna HTTP Status Codes semânticos (400 BadRequest para violações de regra, 404 NotFound) com mensagens de erro claras para consumo do front-end.

## Instruções de Execução

A aplicação utiliza um banco de dados em memória e realiza um Data Seed automático ao iniciar, dispensando configurações externas.

**Pré-requisitos:** .NET 8 SDK e Visual Studio 2022 (ou VS Code).

1. Clone o repositório: `git clone [COLOQUE_SEU_LINK_AQUI]`
2. Abra a solução `GoodHamburger.sln` no Visual Studio.
3. Configure a solução para **"Vários projetos de inicialização"** (Start nas opções `GoodHamburger.Api` e `GoodHamburger.Frontend`).
4. Pressione `F5` para compilar e rodar. 

O navegador abrirá a interface visual em Blazor e a documentação do Swagger simultaneamente. 

Para rodar os testes unitários, abra o terminal na raiz do projeto e execute:
`dotnet test`

## O que deixei de fora (e o motivo)

Pensando em facilitar o processo de avaliação, algumas implementações comuns em produção foram omitidas:

* Banco de Dados Relacional Externo (SQL Server/PostgreSQL): Omitido para remover a complexidade de setup de containers ou connection strings. A troca para um banco real exigiria apenas alterar a injeção no `Program.cs` e criar as *Migrations*.
* Autenticação e Autorização (JWT): Omitido pois o foco do requisito era o PDV e as regras de negócio. Endpoints abertos agilizam os testes manuais dos avaliadores.
* Dockerfile/Containerização: Omitido para focar na execução simples e direta via Visual Studio ou CLI do .NET.