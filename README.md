#Documentação ADR

TITULO 
  - WebAPI

STATUS
  - Responsavel >> Roberto Meneghelli (Fullstack Developer C# NET)
  - Data >> 11/04/2024
  - Tempo de entrega >> Nenhum, projeto de escopo aberto

CONTEXTO
  - Esse software possui conhecimentos tecnicos e experiencias adquiridas profissionalmente pelo responsavel dessa documentação. A partir desse software, tenho um modelo de projeto a ser trabalhado no formato de REST API, caso seja necessario criar um projeto do zero.

DECISÃO
  - Para desenvolvimento desse software foi escolhido as seguintes tecnologias:
    - NET 8.0 e C# 12
    - Arquiterura >> REST API
    - Modelo de Dominio >> Domain Driven Design (DDD)
    - Banco de dados >> SQL Server 2018
    - Mensageria >> RabbitMQ
    - Linguagem de Programação >> C#
    - Repositorio de Codigo >> GitHub
    - Design Pattern >> Repository com UnitOfWork
    - Servidor >> IIS
    
  - Motivo da decisão
    - Devido ao contexto do software optei por decidir o desenvolvimento a partir de tecnologias e ferramentas em que tenho experiencia e conhecimento tecnico               aprimorado
    
  - Limitações
    - Não possui modelo de dominio TDD para testes unitarios das funcionalidades criadas
    - Não tem interação com nenhum frontend para testes visual do usuário, somente testes a partir da documentação Swagger
    
  - Consequencias Finais
    - Facilidade de entendimento de codigo
    - Facilidade de manutenção do banco de dados
