# 📦 ProdutoAPI – Desafio Técnico C#

API RESTful desenvolvida em **C# (.NET 8)** que implementa um **CRUD de produtos**, com **autenticação JWT**, **BD PostgreSQL** e **testes com xUnit**.

---

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core 8**
- **PostgreSQL**
- **JWT**
- **Swagger**
- **xUnit**
---

## 📁 Estrutura do Projeto

```
ProdutoAPI.sln
├── src
│   └── ProdutoAPI
│       ├── Controllers
│       ├── Data
│       ├── Domain
│       │   └── Entities
│       ├── DTOs
│       ├── Services
│       ├── Program.cs
│       └── appsettings.json
│
└── tests
    └── ProdutoAPI.Tests
        └── Services
            └── ProdutoServiceTests.cs
```

---

## ⚙️ Configuração do Ambiente
- .NET 8 SDK
- PostgreSQL
- Visual Studio

---

### 🔌 Configuração do Banco de Dados

No arquivo `appsettings.json`, configure a *connection string*:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=produto;Username=postgres;Password=senha"
  }
}
```

Crie o banco de dados no PostgreSQL:

```sql
CREATE DATABASE produto_db;
```

Crie a tabela:

```sql
CREATE TABLE public."Produtos" (
	"Id" uuid NOT NULL,
	"Nome" varchar(200) NOT NULL,
	"Descricao" text NULL,
	"Preco" numeric(18, 2) NOT NULL,
	"QuantidadeEmEstoque" int4 NOT NULL,
	CONSTRAINT "Produtos_pkey" PRIMARY KEY ("Id")
);
```
---

## ▶️ Executando a Aplicação

Na raiz da *solution*, execute:

```bash
dotnet run --project src/ProdutoAPI
```

A API ficará disponível em:

```
https://localhost:PORT
```

---

## 📄 Documentação da API (Swagger)

A documentação dos endpoints pode ser acessada via Swagger:

```
https://localhost:PORT/swagger
```

---

## 🔐 Autenticação JWT

### Login

Endpoint responsável por gerar o token JWT:

```
POST /api/auth/login
```

Resposta de exemplo:

```json
{
  "token": "TOKEN_JWT"
}
```

---

### Autorização

Para acessar os endpoints protegidos, envie o header:

```
Authorization: Bearer TOKEN_JWT
```

Todos os endpoints de **Produto** exigem autenticação.

---

## 🧩 Endpoints Principais

### Produtos

- **POST** `/api/produtos` — Criar produto  
- **GET** `/api/produtos` — Listar produtos  
- **GET** `/api/produtos/{id}` — Obter produto por ID  
- **PUT** `/api/produtos/{id}` — Atualizar produto  
- **DELETE** `/api/produtos/{id}` — Excluir produto  

---

## 🧪 Testes Unitários

Os testes unitários validam as principais regras de negócio do CRUD de produtos, incluindo:

- Criação de produto válido
- Tentativa de criação com preço negativo
- Atualização de produto existente
- Exclusão de produto
- Consulta de produto inexistente

### Executar os testes

```bash
dotnet test
```

Os testes utilizam **EF Core InMemory**, não sendo necessário banco de dados real.

---
