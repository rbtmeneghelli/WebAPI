LEMBRETES IMPORTANTES!!!

- Para executar a migration pela library Data é necessario instalar os seguintes pacotes:
1 - Microsoft.EntityFrameworkCore
2 - Microsoft.EntityFrameworkCore.SqlServer ou Npgsql.EntityFrameworkCore.PostgreSQL ou Pomelo.EntityFrameworkCore.MySql
3 - Microsoft.EntityFrameworkCore.Tools

Comandos basicos do migration via package manager console:
1 - Abrir a janela do Package Manager Console
2 - Apontar para a library Data
3 - Criando banco de dados -> Add-Migration Initial ou Add-Migration Initial -Context ApplicationDbContext ou EntityFrameworkCore\Add-Migration InitialDb -Context WebsrvApiContext
4 - Criando banco de dados por camada de projeto -> dotnet ef migrations add "Nome_Migration" --project WebAPI.Infra.Data -s WebAPI -c WebsrvApiContext --verbose
5 - Aplicar o comando de atualização -> Update-Database ou Update-Database -Context ApplicationDbContext
6 - Aplicar o comando de atualização por camada de projeto -> dotnet ef database update "Nome_Migration" --project WebAPI.Infra.Data -s WebAPI -c WebsrvApiContext --verbose
7 - Remover Migration -> Remove-Migration ou Remove-Migration -Context ApplicationDbContext
8 - Listar as migrations existentes -> Get-Migration


Comandos do migration via terminal:
1 - Instalar o pacote (dotnet tool install --global dotnet-ef)
2 - Atualizar o pacote (dotnet tool update --global dotnet-ef)
3 - Verificar se o pacote esta instalado (dotnet ef)
4 - dotnet ef migrations add "mensagem"
5 - dotnet ef database update

DataAnnotation Importante!
[NotMapped] -> Serve para não criar a propriedade da classe como campo no bd ao efetuar migration!

Relacionamentos:
Tabela Cliente >> Tabela Venda (Relacionamento 1 para muitos)
Tabela Autor >> Tabela AutorBiografia (Relacionamento 1 para 1)
Tabela LivroCategoria >> Tabela Livro e Tabela Categoria (Relacionamento N para N)

Links Uteis:
https://www.learnentityframeworkcore.com/conventions/many-to-many-relationship
http://www.macoratti.net/19/10/ang7_apinc1.htm
http://www.macoratti.net/19/04/aspc_autom1.htm
https://material.angular.io/components/categories
http://www.macoratti.net/19/10/ang7_apinc2.htm
https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration
http://www.macoratti.net/19/07/c_utilweb4.htm
http://www.macoratti.net/19/09/efcore_mmr2.htm (Crud com relacionamento Many to Many)
https://www.c-sharpcorner.com/article/using-epplus-to-import-and-export-data-in-asp-net-core/
https://www.c-sharpcorner.com/article/import-and-export-data-using-epplus-core/
https://www.entityframeworktutorial.net/

Configuração do projeto API:
Botão direito Properties >> Debug >> Desmarcar opção "Enable SSL"

Exemplo de connectionString do PostgreSQL:
"BaseCotacoes": "Server=localhost;Database=ExemplosEFCore2;Port=5432;User Id=postgres;Password=PostgreSQL2017!;"

Bloquear acesso de APIS com roles:
https://balta.io/blog/aspnet-core-autenticacao-autorizacao
https://stackoverflow.com/questions/49426781/jwt-authentication-by-role-claims-in-asp-net-core-identity

Publicando Projeto .NET CORE no IIS:
http://carloscds.net/2017/08/publicando-uma-aplicao-asp-net-core-no-iis/
https://medium.com/@alexalvess/publicando-aplica%C3%A7%C3%A3o-net-core-no-iss-f4079c2f312

Adicionando Log dos comandos do EF core:
https://www.entityframeworktutorial.net/efcore/logging-in-entityframework-core.aspx

LEMBRETES IMPORTANTES!!!

- Links sobre geração de Token e API com EF Core 3.0
https://balta.io/blog/aspnetcore-3-autenticacao-autorizacao-bearer-jwt
https://balta.io/blog/apis-data-driven-com-aspnet-core-3-e-ef-core-3-parte-1

- Comandos de instalação de packages necessarios para funcionamento do EF Core 3.0 (Rodar no package manager console)
Install-Package Microsoft.EntityFrameworkCore.InMemory
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 3.1.0

- JSON para teste/geração do token via postman
{"username":"roberto","password":"roberto"}

- Dicas:
A tag [fromService] realiza a injeção de dependencia de forma automatica, sem necessidade de construtor.

-> Referência virtual faz que uma propriedade, objeto ou metodo possa ser substituido por uma dos tres argumentos que o herde.

RODAR SCRIPT SQL VIA MIGRATION!!!

-> Abrir o Package Manager Console
-> Rodar o comando Add-Migration "Nome do script SQL"
-> Assim que gerar o arquivo C# da migration, criar um arquivo com extensao ".SQL" dentro da pasta migrations.
-> Editar o metodo UP com um dos codigos abaixo

Ex:
protected override void Up(MigrationBuilder migrationBuilder)
{
   var schema = "starter_core";
   migrationBuilder.Sql($"INSERT INTO [{schema}].[Roles] ([Name]) VALUES ('transporter')");
}

OU 

public override void Up()
{
    string sqlResName = typeof(RunSqlScript).Namespace  + ".201801310940543_RunSqlScript.sql";
    this.SqlResource(sqlResName );
}

OU 

protected override void Up(MigrationBuilder migrationBuilder)
{
    var assembly = Assembly.GetExecutingAssembly();
    string resourceName = typeof(RunSqlScript).Namespace + ".20191220105024_RunSqlScript.sql";
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
    using (StreamReader reader = new StreamReader(stream))
    {
        string sqlResult = reader.ReadToEnd();
        migrationBuilder.Sql(sqlResult);
    }
}

Referência:
-> https://stackoverflow.com/questions/32125937/can-we-run-sql-script-using-code-first-migrations
-> https://stackoverflow.com/questions/45035754/how-to-run-migration-sql-script-using-entity-framework-core

EFETUAR RELACIONAMENTO ENTRE TABELAS DE FORMA MANUAL

No metodo OnModelCreating da classe WebSrvContext, os relacionamentos podem ser feitos da seguinte forma:
-> Exemplo de configurar relacionamento 1 para muitos
	modelBuilder.Entity<Student>()
    .HasOne<Grade>(s => s.Grade)
    .WithMany(g => g.Students)
    .HasForeignKey(s => s.CurrentGradeId);

-> Exemplo de configurar relacionamento 1 para 1
	modelBuilder.Entity<Student>()
    .HasOne<StudentAddress>(s => s.Address)
    .WithOne(ad => ad.Student)
    .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

-> Exemplo de configurar relacionamento muitos para muitos
	
	modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.SId, sc.CId });

	modelBuilder.Entity<StudentCourse>()
    .HasOne<Student>(sc => sc.Student)
    .WithMany(s => s.StudentCourses)
    .HasForeignKey(sc => sc.SId);

	modelBuilder.Entity<StudentCourse>()
    .HasOne<Course>(sc => sc.Course)
    .WithMany(s => s.StudentCourses)
    .HasForeignKey(sc => sc.CId);

    * Aplicando Predicate em Campos de data e Hora (Tipo DateTime) 
  return p =>
                   (string.IsNullOrWhiteSpace(filter.User) || p.User.Name.Trim().ToUpper().Contains(filter.User.Trim().ToUpper()))
                   &&
                   ((!filter.BeginCreatedDateAt.HasValue && !filter.EndCreatedDateAt.HasValue) ||
                   (filter.BeginCreatedDateAt.HasValue && !filter.EndCreatedDateAt.HasValue && filter.BeginCreatedDateAt.Value.Date == p.CreatedAt.Date) ||
                   (!filter.BeginCreatedDateAt.HasValue && filter.EndCreatedDateAt.HasValue && filter.EndCreatedDateAt.Value.Date == p.CreatedAt.Date) ||
                   ((filter.BeginCreatedDateAt.HasValue && filter.EndCreatedDateAt.HasValue && (p.CreatedAt.Date >= filter.BeginCreatedDateAt.Value.Date && p.CreatedAt.Date <= filter.EndCreatedDateAt.Value.Date))))
                   &&
                   ((!filter.BeginCreatedTimeAt.HasValue && !filter.EndCreatedTimeAt.HasValue) ||
                   (filter.BeginCreatedTimeAt.HasValue && !filter.EndCreatedTimeAt.HasValue && filter.BeginCreatedTimeAt.Value.TimeOfDay == p.CreatedAt.TimeOfDay) ||
                   (!filter.BeginCreatedTimeAt.HasValue && filter.EndCreatedTimeAt.HasValue && filter.EndCreatedTimeAt.Value.TimeOfDay == p.CreatedAt.TimeOfDay) ||
                   ((filter.BeginCreatedTimeAt.HasValue && filter.EndCreatedTimeAt.HasValue && (p.CreatedAt.TimeOfDay >= filter.BeginCreatedTimeAt.Value.TimeOfDay && p.CreatedAt.TimeOfDay <= filter.EndCreatedTimeAt.Value.TimeOfDay))))
                   &&
                   (filter.Success == null || p.Success == filter.Success);

Obs: TimeStamp pode ser comparado direto sem necessidade do TimeOfDay

* Aplicando Predicate em Campos, onde tenha uma lista de MultiSelect no front
return p =>
                   (string.IsNullOrWhiteSpace(filter.City) || p.City.Name.Trim().ToUpper().Contains(filter.City.Trim().ToUpper()))
                   &&
                   (!filter.State.HasValue || p.City.State == filter.State)
                   &&
                   (!filter.ExternalCode.HasValue || filter.ExternalCode == p.ExternalCode)
                   &&
                   ((filter.IdConsortium == null || filter.IdConsortium.Count() == 0) || p.CityHallConsortiumSet.Any(x=> filter.IdConsortium.Contains(x.IdConsortium)));

-- Gerador de PDF
https://medium.com/@erikthiago/gerador-de-pdf-no-asp-net-core-e494650eb3c9 (Rotativa ou DinkToPdf)

-- Reciclagem C#

>> Membros static são acessados diretamente pela classe do tipo static
>> Partial class serve para dividir uma classe muito grande em 2 ou mais partes
>> Classe abstrata e um modelo de classe que pode ser herdada por outras classes, porem nao pode ser instanciada a partir de um objeto
>> Metodo abstract so fica a assinatura, sem necessidade de implementação
>> Metodo virtual tem implementação na classe abstrata, sem necessidade de ter sua assinatura nas outras classes
>> Classe sealed pode herdar outras classes, mas ninguem pode herdar a classe sealed

-- Implementando criptografia dos dados na base de dados, devido ao padrão LGPD
NET CORE 2.1 ou 3.1 >> https://entityframeworkcore.com/knowledge-base/50993914/implementing-encryption-in-entity-framework-model-classes
NET CORE 5.0 ou superior >> https://sd.blackball.lv/articles/read/18805
NET CORE 5.0 ou superior >> https://emrekizildas.medium.com/encrypt-your-database-columns-with-entityframework-1f129b19bdf8

>> A PARTIR DO EF CORE 5.0 E POSSIVEL FAZER O MAPEAMENTO DE UMA VIEW PARA DENTRO DE UMA ENTIDADE C#
exemplo: Dentro do metodo override OnModelCreating, fazemos o codigo abaixo:
modelBuilder.Entity<Classe>(x => { x.ToSqlQuery("SELECT * FROM VWTESTE")})

-- Passo para criação de um chat ou envio de notificações a aplicação com SignalR
>> https://www.c-sharpcorner.com/article/real-time-angular-11-application-with-signalr-and-net-5/
>> npm install @microsoft/signalr (Biblioteca para instalar no front e configurar em seguida)
>> Tem exemplo de seu uso no projeto WebNotes (Front quanto Back)

-- Gerar diagrama de classe 
>> Verificar se o pacote class designer está instalado, caso não esteja efetuar o passo abaixo:
>> Menu Tools >> Get Tools and Features
>> Na opção menu Individual components >> Selecionar a opção class designer

-- Realizando Globalização e Localização de idioma
>> Adicionar o serviço abaixo na classe startup
services.AddLocalization()
>> Adicionar a aplicação abaixo na classe startup
var supportedCultures = new [] {"pt-BR", "en-US", "it"};
var localizationOptions = new RequestLocalizationOptions()
.SetDefaultCulture(supportedCultures[0])
.AddSupportedCultures(supportedCultures)
.AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

-- Criar o Resource para que o StringLocalizer possa pegar o valor do idioma definido
Exemplo de nome de arquivo: Nomedoarquivo.idioma.resx (Criar um arquivo padrao sem o idioma especificado, somente Nomedoarquivo.resx)
Obs:
Configurar na propriedade do arquivo .resx
Custom Tool >> PublicResXFileCodeGenerator

-- Gerar excel EPPLUS ou NPOI
http://www.macoratti.net/21/03/c_xlsplus1.htm

-- Gerar excel sem biblioteca de terceiros
https://github.com/rsantosdev/aspnetcore-report-export-samples

-- Tratamento de erros com UseExceptionHandler
http://www.macoratti.net/21/04/aspc_errglobl1.htm

-- Trabalhando com SeriLog e Seq (Exibindo Log de erro em aplicação externa)
https://rafaelcruz.azurewebsites.net/2016/11/08/criando-log-estruturados-com-seq-e-serilog/
https://balta.io/blog/aspnet-serilog?utm_source=LinkedIn&utm_campaign=social-to-blog&utm_content=aspnet-serilog&utm_medium=social
>> Se precisar trabalhar com variaveis de ambiente ou Serilog, seguir modelo do Webnotes

-- Realizando BulkInsert para adicionar 1000 ou mais registros de forma mais otimizada do que com AddRange
https://macoratti.net.br/21/05/ef_bulkinsert1.htm

-- Criptografar parametros da URL como ID e outros campos...
http://www.macoratti.net/21/05/aspnc_urlprot1.htm

-- Implementando Rate Limiting (Limitador de requisições) aos endpoints numa API
https://www.c-sharpcorner.com/article/implement-rate-limiting-in-asp-net-core-web-api/
https://github.com/stefanprodan/AspNetCoreRateLimit/wiki
https://macoratti.net/22/12/vda191222.htm (RESTRITO AO NET 7 ou SUPERIOR)

-- Fazendo MultiThreads de requests serem processadas uma por vez
>> Utilizar o comando Lock para que seja efetuada tal ação (http://www.macoratti.net/10/09/c_thd1.htm)

-- Utilizando o banco não relacional REDIS com C#
>> https://renatogroffe.medium.com/net-core-3-1-redis-do-cache-distribu%C3%ADdo-ao-uso-como-banco-nosql-a88d6da39e0
>> https://tutexchange.com/using-distributed-redis-cache-with-asp-net-core-3-1/
>> SGDB (Redis Desktop Manager ou Redis Manager)

-- Trabalhando com Cache nos Endpoints de WEBAPIS
>> Configurar na classe startup as duas funcionalidades abaixo:
>> services.AddResponseCaching();
>> app.UseResponseCaching();

-- Problemas ao gravar dados com caracteres especiais (%,^)
>> Isso ocorre porque o firewall entende como uma ameaça.
>> Nesse caso devemos torna-lo como byte e grava-lo, depois converte-lo ao normal ao resgatarmos a informação.

-- Implementação de HealthCheck
>> https://balta.io/blog/aspnet-health-check
>> https://dotnetthoughts.net/implementing-health-check-aspnetcore/
>> Para acessar o HealthCheck desse projeto, basta acessar a url: https://localhost:44344/dashboard#/healthchecks

-- Implementando UnitOfWork com padrão Repository e DDD
>> https://macoratti.net/21/06/aspnc_repuow1.htm
>> Tem no projeto WebAPI

-- Implementando simple factory
https://macoratti.net/21/06/c_simpfact1.htm
https://macoratti.net/19/09/c_factory1.htm
https://macoratti.net/21/07/c_factory2.htm
>> Tem nesse projeto um exemplo, so procurar o comentario!

-- O IHTTPCLIENTFACTORY E MELHOR SER UTILIZADO DO QUE O HTTPCLIENT, POIS O HTTPCLIENT DA PROBLEMAS DE MEMORIA...
>> Tem um exemplo no projeto WebNotes

-- CLIENT: 535-5.7.8 Username and Password not accepted. Learn more at
>> Tem que ativar a segurança em duas etapas, gerar uma senha de APP e utiliza-la, ao invés da senha do email

-- Feito funcionalidade para interceptar dados base64 para string, devido a bloqueio de firewall quando string tem caractere especial
>> Tem a interface e o service chamado ReadPropertyValue (Projeto WebAPI tem exemplo)

-- Metodos utilizando os novos operadores condicionais do C#9
>> https://macoratti.net/21/09/c10_isnot1.htm

List or Array Pattern (Retorno true ou false)
>> .. (E um range de valores do array)
>> _ (Pula o valor X da posição do array)
>> var nomeVariavel (Captura o valor X do array, a partir da posição solicitada)

Exemplo:
var array = {1, 2, 3, 4, 5 };
bool result = array is [1,..]; (Se o primeiro valor do array for 1, retorna true senao false)
bool result2 = array is [_,_,3,..] (Se na terceira posição o valor do array for 3, retorna true senao false)
if(array is [.., var antepenultimovalor,_,_]) (Se na terceira posição existir valor preenchido, retorna true a condição 
e o valor sera armazenado na variavel antepenultimovalor, senao ele cai no else e nao adiciona nada na variavel)

-- Usando Reflection, Generics e Custom Attributes para montar Scripts SQL de Insert/Update
>> https://help.market.com.br/csharp/usando_reflection__generics_e_.htm

-- Funcionalidade ExecuteUpdate e ExecuteDelete vem da Extensão da LINQ, onde pode-se executar comandos direto no banco de dados.
>> IMPORTANTE PASSAR UMA CONDICIONAL PARA ELE SEMPRE (TEM EXEMPLO NO WEBNOTES E NO MACORATTI TBM)

-- Preferir utilizar interpolação de String com $ para juntar strings, pois o desempenho e alocação de memoria e melhor.
-- Evitar usar string.Format, pois tem um desempenho ruim e alocação de memoria alta

-- Biblioteca BenchmarkDotNet >> Avaliação de desempenho de codigo
>> utilizar a data annotation[Benchmark]

-- Trabalhando com tabelas temporal (Historico) - Só e possivel a partir do NET 6 ou superior
>> https://macoratti.net/22/01/efcore_temptable1.htm

-- Aprimorando a documentação do Swagger para apresentar mais detalhes
>> https://learn.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio

-- Angular versão 12 ou superior com Node 18 ou superior
>> Para executar o projeto, deve-se ser via prompt de comando a partir do comando abaixo para que os comandos NG ou NPM funcionem!
set NODE_OPTIONS=--openssl-legacy-provider

-- Caso precise de uma base de dados de estados e cidades, utilizar o backup do banco DefaultAPI que tenho

-- Criando View pelo EF Core e a utilizando
>> https://macoratti.net/22/07/efc_criaviews1.htm

-- Funcionalidade Keyed Dependency Injection (Multiplas injeções de Dependência), A partir do NET 8
-- Exemplo utilizando a mesma interface, porém com diferente Services:
>> builder.Services.AddKeyedScoped<InterfaceXPTO,ServiceA>("ChaveA")
>> builder.Services.AddKeyedSingleton<InterfaceXPTO,ServiceB>("ChaveB")
>> builder.Services.AddKeyedTransient<InterfaceXPTO,ServiceC>("ChaveC")
>>> Ao fazer a injeção de dependencia para uso na controller ou service, basta aplicar o codigo abaixo.
>> No construtor fazer a injection da ServiceProvider
var serviceA = _serviceProvider.GetRequiredKeyedService<InterfaceXPTO>("ChaveA");
var serviceB = _serviceProvider.GetRequiredKeyedService<InterfaceXPTO>("ChaveB");
var serviceC = _serviceProvider.GetRequiredKeyedService<InterfaceXPTO>("ChaveC");

-- O middleware de Authenticação na config do startup vem primeiro e a autorização vem em segundo
app.UseAuthentication();
app.UseAuthorization();

-- Configurando variavel de ambiente no servidor IIS
Abrir o IIS
No servidor principal procurar a opção chamada editor de configuração
acessar a opção chamada variaveis de ambiente
adicionar as variaveis de ambiente
Parar o IIS e Iniciar o IIS novamente

-- ConnectionString (https://www.connectionstrings.com/)
>> server=.\\SQLExpress;database=myDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;trustservercertificate=true; (Windows)
>> Server=.\\SQLEXPRESS;Database=myDatabase;User Id=sa;Password=senha;MultipleActiveResultSets=true;trustservercertificate=true; (Sql Authentication)

-- Resetar a SEED de uma chave Primaria
>> DBCC CHECKIDENT ('Tabela', RESEED, ProximoID)

-- Trocando o padrão Ligth do swagger para Dark
>> https://github.com/Amoenus/SwaggerDark/
>> https://amoenus.dev/swagger-dark-theme

-- O projeto de VerticalSliceArchiteture é valido para projetos com constante alteração

-- Passos para publicar APP Front e Back + Banco de dados pelo Azure
>> No projeto T-SQL do meu github tem um guia do passo a passo dentro da pasta Azure
>> https://youtu.be/9dqAOc2rJHw ou https://macoratti.net/24/09/vda160924.htm

-- O framework MASSTRANSIT é valido para rotear mensagens para serviços de mensageria como RabbitMQ, Azure Service Bus, SQS e bus de serviço ActiveMQ.
>> Sua utilização é ideal para projetos que trabalham com Microserviço
>> https://macoratti.net/21/04/net_masstrans1.htm

-- Biblioteca MediatR Pipeline Behaviour
>> Essa biblioteca faz que as requisições sejam validadas via fluentValidation, antes do CQRS ser acionado para efetuar um command ou uma query.
>> https://macoratti.net/23/04/aspc_cqrsmediat1.htm
>> https://macoratti.net/23/04/aspc_cqrsmediat2.htm