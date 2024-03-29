# BanheiroLivre

Projeto interno para controle de banheiro, horários de limpeza, aviso de falta de papel, etc

## Banco de dados SQLite

Apagar banco de dados:

```sh
dotnet ef database drop
```

Adicionar Migrations:

```sh
dotnet ef migrations add Initial
```

Atualizar banco de dados:

```sh
dotnet ef database update
```

Para atualizá-las, adicione outra migração:

```sh
dotnet ef migrations add AdicionarNovoCampo
dotnet ef database update
```

Para remover a última migração, use este comando:

```sh
dotnet ef migrations remove
```

Se você já tiver aplicado uma migração (ou várias migrações) no banco de dados, mas precisar revertê-la, poderá usar o mesmo comando usado para aplicar as migrações, mas especificando o nome da migração para a qual você deseja reverter.

```sh
dotnet ef database update LastGoodMigration
```

## Heroku .NET Core Buildpack

### Buildpacks

Adicionar buildpack do `.NET Core` no heroku.

```sh
heroku buildpacks:set jincod/dotnetcore
```