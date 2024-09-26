#Documentação ADR

TITULO 
  - WebAPI

STATUS
  - Responsavel >> Roberto Meneghelli (Fullstack Developer C# NET)
  - Criado em 06/12/2022
  - Atualizado em 19/08/2024
  - Tempo de entrega >> Nenhum, projeto de escopo aberto

CONTEXTO
  - O software possui conhecimentos tecnicos e experiencias adquiridas profissionalmente pelo responsavel dessa documentação.
  - A partir desse software, tenho um modelo de projeto a ser trabalhado no formato de REST API, caso seja necessario criar um projeto do zero.

DECISÃO
  - Para desenvolvimento desse software foi escolhido as seguintes tecnologias:
    - NET 6.0 e C# 10, Atualizado para NET 8.0 e C# 12
    - Arquiterura >> REST API
    - Modelo de Dominio >> Domain Driven Design (DDD) e Test Driven Design (TDD) 
    - Banco de dados >> SQL Server 2018
    - Mensageria >> RabbitMQ
    - Linguagem de Programação >> C#
    - Repositorio de Codigo >> GitHub
    - Design Pattern >> Strategy, Factory, Repository, UnitOfWork
    - Servidor >> IIS
    - Camadas do Projeto >> API, IoC, Application, Infra, Domain, DesignPatterns, WebJobs, Tests, Environment
    - Api Gateway >> Ocelot (Utilizo para poder utilizar duas ou mais API de forma simultanea... Ideal para Microserviços)
    
  - Motivo da decisão
    - Devido ao contexto do software optei por decidir o desenvolvimento a partir de tecnologias e ferramentas em que tenho experiencia e conhecimento tecnico aprimorado
    
  - Limitações
    - Não tem interação com nenhum frontend para testes visual do usuário, somente testes a partir da documentação Swagger
    - O projeto não está publicado em um servidor externo, impossibilitando seu acesso por outros usuarios
    
  - Consequencias Finais
    - Facilidade de entendimento de codigo
    - Facilidade de manutenção do banco de dados
    - Organização das camadas do projeto e pacotes utilizados
