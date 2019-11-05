# BanheiroLivre

Projeto interno para controle de banheiro, horários de limpeza, aviso de falta de papel, etc

## Banco de dados SQLite

Apagar banco de dados:

```sh
dotnet ef database drop
```

Executar comando para adicionar Migrations:

```sh
dotnet ef migrations add Initial
```

Executar comando para atualizar banco de dados:

```sh
dotnet ef database update
```

## Heroku .NET Core Buildpack

### Buildpacks

Adicionar buildpack do `.NET Core` no heroku.

```sh
heroku buildpacks:set jincod/dotnetcore
```