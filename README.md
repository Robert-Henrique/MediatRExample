# Projeto de Estudo: .NET 8 + MediatR + RavenDB

Este repositório é um projeto de estudo desenvolvido com **.NET 8**, utilizando **MediatR** para implementação do padrão **CQRS** e **RavenDB** como banco de dados NoSQL.

## Tecnologias Utilizadas

- **.NET 8** - Framework principal
- **MediatR 12.4.1** - Implementação do padrão CQRS
- **RavenDB.Client 7.0.0** - Cliente para interação com o RavenDB
- **Docker** (opcional) - Para executar o banco de dados localmente

## Configuração do Ambiente

### 1. Clonar o Repositório
```sh
git clone https://github.com/Robert-Henrique/MediatRExample.git
cd seu-repositorio
```

### 2. Configurar e Executar o RavenDB com Docker
Para iniciar um contêiner do **RavenDB** localmente:
```sh
docker run -d --name ravendb \
  -p 8080:8080 \
  -p 38888:38888 \
  -e RAVEN_Setup_Mode=Unsecured \
  ravendb/ravendb
```
Acesse a interface do banco em [http://localhost:8080](http://localhost:8080).

### 3. Configurar a Connection String no `appsettings.json`
```json
"RavenDb": {
  "Urls": ["http://localhost:8080"],
  "Database": "ProductsDb"
}
```

### 4. Restaurar Dependências e Executar o Projeto
```sh
dotnet restore
dotnet run
```

## Exemplo de Uso

### 1. Criando um Produto
#### Request (POST `/api/products`)
```json
{
  "name": "Produto Teste",
  "price": 100.0
}
```
#### Response
```json
{
  "id": "products/1-A",
  "name": "Produto Teste",
  "price": 100.0
}
```

## Autor
Desenvolvido por **Robert Henrique** - [LinkedIn](https://www.linkedin.com/in/robert-henrique-989134145/).

---

Esse projeto é apenas para fins de estudo e demonstração do uso do **MediatR** e **RavenDB** em um ambiente **.NET 8**.
