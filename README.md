# Introdução

Solução BackEnd com webapis desenvolvida em Dot Net CORE

### Pré-requisitos

Antes de rodar o projeto é necessário executar os seguintes procedimentos:

- Entrar na pasta OPPI.WebApi onde está o projeto de Startup e executar o seguinte comando:

```
dotnet ef --project OPPI.Data database update
```

*IMPORTANTE* é necessário estar dentro da OPPI.WebApi e setar o projeto OPPI.Data. Isso é feito para separar os scripts do migration no projeto Data ao invés de ficar no projeto WebApi.

Comando criará um banco de dados postgree no caminho determinado na chave do appsettings.json "ConnectionStrings.DefaultConnection" 



### Após criar o banco de dados é só rodar o projeto. Abrirá uma página Swaggwer com todas as apis da solução.
