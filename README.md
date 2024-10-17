#Documentação ADR

TITULO 
  - WebAPI

STATUS
  - Responsável >> Roberto Meneghelli
  - Criado em 06/12/2022
  - Atualizado em 17/10/2024
  - Tempo de entrega >> Nenhum, projeto de escopo aberto

CONTEXTO
  - O software possui conhecimentos tecnicos e experiencias adquiridas profissionalmente pelo responsavel dessa documentação.
  - A partir desse software, tenho um modelo de projeto a ser trabalhado no formato de REST API, caso seja necessario criar um projeto do zero.

DECISÃO
  - Para desenvolvimento desse software foi escolhido as seguintes tecnologias:
    - NET 6.0 e C# 10, Atualizado para NET 8.0 e C# 12
    - Arquiterura >> REST API
    - Modelo de Dominio >> Domain Driven Design (DDD) e Test Driven Design (TDD) 
    - Banco de dados >> SQL Server 2017
    - Mensageria >> RabbitMQ
    - Linguagem de Programação >> C#
    - Repositorio de Codigo >> GitHub
    - Design Pattern >> Strategy, Factory, Repository, UnitOfWork
    - Servidor >> IIS
    - Camadas do Projeto >> API, IoC, Application, Infra, Domain, DesignPatterns, WebJobs, Tests, Environment
    - Api Gateway >> Ocelot (Utilizo para poder utilizar duas ou mais API de forma simultanea... Ideal para Microserviços)
    
MOTIVO DA DECISÂO
  - Devido ao contexto do software optei por decidir o desenvolvimento a partir de tecnologias e ferramentas em que tenho experiencia e conhecimento tecnico aprimorado
    
LIMITAÇÔES
  - Não possui integração com projeto frontend para teste visual do usuário, somente testes a partir da documentação Swagger
  - O projeto não está publicado em um servidor externo, impossibilitando seu acesso por outros usuarios
  - Camada de proteção de acesso as API integradas ao API Gateway Ocelot não está implementado no momento...
    
CONSEQUÊNCIAS FINAIS
  - Facilidade de entendimento de codigo
  - Facilidade de manutenção do banco de dados
  - Organização das camadas do projeto e pacotes utilizados

PASSOS PARA UTILIZAR
  - Utilizar uma IDE da sua escolha, recomendo a utilização do VISUAL STUDIO 2022 ou superior
  - Utilizar um SGDB da sua escolha compativel com SQLSERVER, recomendo a utilização do MICROSOFT MANAGEMENT STUDIO 2017 ou superior
  - Instalar o serviço de mensageria RABBIT MQ
  - Ao baixar o projeto por uma ferramenta de repositorio GIT, efetuar um build para validar que tudo esteja OK
  - Substituir a configuração padrão das variaveis de ambiente do arquivo DEV.BAT, com os dados correspondentes aos softwares instalados em sua maquina
  - Efetuar a execução do arquivo DEV.BAT para instalação das variaveis de ambiente do sistema em sua maquina
  - Ao concluir a execução do arquivo DEV.BAT, efetuar a execução do projeto (Ao executar o projeto, o banco de dados será criado automaticamento via migrations do EF CORE)
  - Dados ficticios para geração de TOKEN para liberar endpoints restritos são:
    - Login >> admin@DefaultAPI.com.br
    - Senha >> 123mudar

PRINTS DO SISTEMA

![image](https://github.com/user-attachments/assets/c1d0822e-d38f-47ef-849d-5c6cf86de45a)

![image](https://github.com/user-attachments/assets/b7ee00c9-5b94-4047-9cd5-0380df71c685)

![image](https://github.com/user-attachments/assets/eab1b29c-869e-4d0f-adb4-19eab68f881b)

![image](https://github.com/user-attachments/assets/83a0bb88-86ff-456d-9687-7a95a8e60137)

![image](https://github.com/user-attachments/assets/b7a7c033-b052-46f8-97ec-fcab3e46fda3)





