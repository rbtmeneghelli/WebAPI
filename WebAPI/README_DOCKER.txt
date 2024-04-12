## Dicas importantes para subir projeto no docker

>> A Solution e o projeto não podem estar no mesmo diretorio!

- Criar arquivo DOCKER para o projeto
>> Botão direito em cima do projeto, Add, Container Orchestrator Support
>> Selecionar a opção Docker Compose, SO Linux

docker ps >> Lista os containuers que temos criados
docker images >> Lista as imagens que temos criadas
docker-compose up -d --build  >> Esse comando faz a geração da imagem quanto a subida para o container de uma vez só!
docker build -t WebApiImage . >> Cria a imagem a partir do arquivo DockerFile desse projeto
docker-compose down >> É feito a exclusão de todos os containers que foram criados
docker exec -it nome_container /bin/bash (Pode executar comandos dentro do container criado)

Imagem do SQL Server para baixar >> https://hub.docker.com/_/microsoft-mssql-server
Tem imagem para o Serilog e também para RabbitMQ

>> Para baixar a imagem, deve-se abrir o powershell na pasta em que nosso projeto se encontra!
- Aplicar o comando: docker pull mcr.microsoft.com/mssql/server:2019-latest

>> Após baixar a imagem, criar o container para a imagem
- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Numsey#2024" -p 1450:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest

>> Ao concluir a instalação, e possivel acessar pelo management do SQL o SQL Instalado no container
- Servidor: localhost:1450, Usuario: SA e Senha: Numsey#2024
