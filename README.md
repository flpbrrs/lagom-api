# Lagom

## Configuração do ambiente de desenvolvimento

### 1. Banco de dados (SQL Server via Docker)

Copie `.env.example` para `.env` e defina uma senha:

```bash
cp .env.example .env
```

Suba o container:

```bash
docker compose up -d
```

### 2. Connection string (user-secrets)

A connection string não fica no `appsettings.Development.json` nem em nenhum arquivo do repositório — ela é local a cada máquina, via [user-secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) do .NET.

Configure a sua, a partir da pasta `Lagom.API`:

```bash
cd Lagom.API
dotnet user-secrets set "ConnectionStrings:URL" "Server=localhost,1433;Database=LagomDb;User Id=sa;Password=<mesma senha do seu .env>;TrustServerCertificate=True;"
```

Sem esse passo, `GetConnectionString("URL")` retorna vazio e a API falha ao subir.

### 3. Migrations

Com o container rodando e o secret configurado, aplique as migrations:

```bash
dotnet ef database update --project Lagom.Infrastructure --startup-project Lagom.API
```
