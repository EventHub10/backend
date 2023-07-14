#backend
# Como executar localmente a API

Dependências da API:
- [.NET CORE 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Postgres](https://www.postgresql.org/download/)

## Instalação
### Banco de dados
Após baixar e instalar o SDK do .NET e o postgres é necessário criar no postgres um banco de dados.
Referências:
[Criar um novo banco de dados](https://www.postgresql.org/docs/current/sql-createdatabase.html)
Também é possível criar o banco de dados pela interface do PGAdmin. 
### Migrações do banco de dados.
Após ter criado um banco de dados precisamos executar as migrações para criar as tabelas.
- Primeiramente devemos configurar a conexão da API com o banco de dados. 
O arquivo de configuração de conexão se encontra em backend/appsettings.development.json
Na chave 'defaultConnection' deve conter os dados para conexão com o banco criado. Conforme exemplo: 
 "Server=localhost;Port=5432;User Id=postgres;Password=123qwe;Database=event-hub;Timeout=1024;CommandTimeout=10000; Include Error Detail=True;"
- Após configurar a conexão podemos aplicar as migrações de banco, para isso precisamos executar na raiz do projeto: 
 ```dotnet tool install --global dotnet-ef```
e depois 
```dotnet ef database update```

### Iniciando a API
Para iniciar a api execute
```dotnet run``` na raiz do projeto.





