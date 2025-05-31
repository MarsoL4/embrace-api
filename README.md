# Embrace API – Sistema de Apoio em Situações de Emergência Climática

## 📘 Visão Geral

O **Embrace.API** é uma API REST desenvolvida em .NET 8 que visa auxiliar comunidades em momentos críticos causados por desastres naturais, como enchentes, ondas de frio ou calor extremo. A solução permite:

- Cadastro de ONGs e ações solidárias;
- Registro e consulta de doações;
- Gerenciamento de voluntários;
- Visualização de pontos de coleta de alimentos;
- Integração com mapa e sistemas externos para gestão comunitária.

<!--
---

## 🧱 Arquitetura do Projeto

DIAGRAMA DA ARQUITETURA AQUI
[INSERIR DIAGRAMA DE CAMADAS AQUI]

---
-->

## 📂 Estrutura de Pastas

```
Embrace.API/
├── Controllers/                # Endpoints REST
├── DTOs/                       # Objetos de Transferência de Dados
├── Infrastructure/
│   ├── Contexts/               # DbContext do projeto
│   ├── Mappings/               # EntityTypeConfiguration (EF)
│   └── Persistence/            # Entidades (Models)
├── Repositories/
│   ├── Interfaces/             # Interfaces dos repositórios
│   └── (Repositórios)         # Implementações dos repositórios
├── Services/                   # Lógica de negócio
├── AutoMapper/                # Perfil de mapeamento DTO <-> entidade
├── Program.cs                 # Configuração principal
└── appsettings.json           # Configuração da conexão com Oracle
```

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- C#
- Entity Framework Core
- Oracle EF Core (ODP.NET)
- AutoMapper
- Swagger (Swashbuckle.AspNetCore)
- Visual Studio 2022

## ⚙️ Instruções de Uso

### 1. Configurar o Banco de Dados Oracle

Edite o arquivo `appsettings.json` com suas credenciais:

```
"ConnectionStrings": {
  "Oracle": "Data Source=xxx.xxx.xxx:xxxx/xxxx;User ID=xxxx;Password=xxx;"
}
```

### 2. Aplicar Migrations

```bash
dotnet ef database update
```

### 3. Rodar o Projeto

```bash
dotnet run
```

### 4. Acessar o Swagger

Acesse a documentação e teste da API pelo navegador:

```
https://localhost:{porta}/swagger
```

## 🧪 Exemplos de Testes (via Swagger ou Postman)

### ✅ Cadastrar uma ONG

```
POST /api/Ong
```

```json
{
  "nome": "Ajuda Sul",
  "email": "contato@ajudasul.org",
  "cnpj": "12.345.678/0001-00",
  "telefone": "(11) 99999-9999"
}
```

---

### ✅ Cadastrar uma Ação Solidária

```
POST /api/AcaoSolidaria
```

```json
{
  "nome": "Campanha do Agasalho",
  "tipoEvento": "Frio",
  "cidade": "Santo André",
  "estado": "SP",
  "descricao": "Arrecadação de agasalhos e cobertores.",
  "metaItens": 200,
  "ongId": 1
}
```

---

### ✅ Consultar todos os pontos de alimentos

```
GET /api/PontoDeAlimento
```

## 👨‍💻 Desenvolvido por

Time Embrace – GS 2025-1:

- **Enzo Giuseppe Marsola** – RM: 556310, Turma: 2TDSPK  
- **Rafael de Souza Pinto** – RM: 555130, Turma: 2TDSPY  
- **Luiz Paulo F. Fernandes** – RM: 555497, Turma: 2TDSPF

---
