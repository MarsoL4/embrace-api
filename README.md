# Embrace API – Sistema de Apoio em Situações de Emergência Climática

## 📘 Visão Geral

A Embrace é uma plataforma que atua como um hub digital unificado para situações de emergência climática, conectando ONGs, coletivos, voluntários e comunidades afetadas. O Embrace.API representa o núcleo backend dessa solução: uma API REST desenvolvida em .NET 8 para gerenciar ações solidárias em desastres naturais.

- Cadastro de ONGs e ações solidárias
- Registro e consulta de doações
- Gerenciamento de voluntários
- Visualização de pontos de coleta de alimentos
- Integração com sistemas externos

---

## 🧱 Arquitetura do Projeto

### Arquitetura Atual (antes da modernização)
```
Usuário
   |
   v
[Embrace.API (.NET 8)]
   |
   v
[PostgreSQL]
```

### Arquitetura Futura (após Docker Compose)
```
Usuário
   |
   v
[Container: Embrace.API]
   |
   v
[Container: PostgreSQL]
```
Ambos conectados por uma rede Docker dedicada.

---

## Análise da Arquitetura

- **Serviços do projeto:**
  - Embrace.API (.NET 8)
  - PostgreSQL (banco de dados)

- **Dependências:**  
  A aplicação depende do banco de dados para persistência das informações (ONGs, doações, voluntários, pontos de coleta, etc).

- **Estratégia de containerização:**
  - API: Imagem oficial do .NET 8, utilizando Dockerfile próprio.
  - Banco: Imagem oficial do PostgreSQL, configurada por variáveis de ambiente.

---

## 📂 Estrutura de Pastas

```
Embrace.API/
├── AutoMapper/
├── Controllers/
├── DTOs/
├── Infrastructure/
│   ├── Contexts/
│   ├── Mappings/
│   ├── Persistence/
│   └── Repositories/
├── Migrations/
├── Properties/
├── Services/
├── appsettings.json
├── Dockerfile
├── Embrace.API.csproj
└── Program.cs
```

---

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- C#
- Entity Framework Core
- Npgsql (PostgreSQL)
- AutoMapper
- Swagger
- Docker e Docker Compose

---

## 🚀 Conteinerização com Docker Compose

O projeto foi modernizado e utiliza Docker Compose para orquestrar os containers de aplicação e banco de dados.

- 1 container para a API (.NET 8)
- 1 container para o PostgreSQL (imagem oficial)
- Usuário não-root para a aplicação
- Volume nomeado para persistência do banco
- Variáveis de ambiente para configuração
- Rede dedicada para comunicação interna
- Healthchecks para ambos serviços
- Políticas de restart apropriadas
- API exposta na porta 8080, banco na 5432

### Exemplo do arquivo `docker-compose.yml`:

```yaml
version: '3.9'

services:
  db:
    image: postgres:16
    container_name: embrace_db
    environment:
      POSTGRES_DB: embrace
      POSTGRES_USER: embraceuser
      POSTGRES_PASSWORD: embracestrongpass
    ports:
      - "5432:5432"
    networks:
      - embrace-net
    volumes:
      - db-data:/var/lib/postgresql/data
    restart: always
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U embraceuser"]
      interval: 20s
      timeout: 10s
      retries: 5

  api:
    build:
      context: ./Embrace.API
      dockerfile: Dockerfile
    container_name: embrace_api
    environment:
      - ConnectionStrings__DefaultConnection=Host=db;Database=embrace;Username=embraceuser;Password=embracestrongpass
      - ASPNETCORE_ENVIRONMENT=Production
    depends_on:
      db:
        condition: service_healthy
    ports:
      - "8080:80"
    networks:
      - embrace-net
    restart: always
    user: "1000:1000"
    healthcheck:
      test: ["CMD", "curl", "-f", "http://localhost/health"]
      interval: 30s
      timeout: 10s
      retries: 5

networks:
  embrace-net:

volumes:
  db-data:
```

---

## ⚙️ Como Executar o Projeto

### 1. Pré-requisitos

- Docker e Docker Compose instalados

### 2. Clonar o Repositório

```bash
git clone https://github.com/MarsoL4/embrace-api.git
cd embrace-api
```

### 3. Ajustar a string de conexão

No arquivo `Embrace.API/appsettings.json`, confirme que a string está assim:
```
"DefaultConnection": "Host=db;Database=embrace;Username=embraceuser;Password=embracestrongpass"
```

### 4. Subir os containers

```bash
docker compose up --build
```

### 5. Popular o banco (se necessário)

```bash
docker compose exec api dotnet ef database update
```

---

## ⛳ Comandos Essenciais Docker Compose

- Subir containers:  
  `docker compose up --build`
- Parar containers:  
  `docker compose down`
- Ver logs:  
  `docker compose logs -f`
- Acessar terminal do container:  
  `docker compose exec api /bin/bash`

---

## 🚀 Deploy Passo a Passo

1. Clone o repositório.
2. Ajuste variáveis de ambiente, se necessário.
3. Garanta que a string de conexão está correta no `appsettings.json`.
4. Suba os containers com `docker compose up --build`.
5. Popular o banco (opcional) com `docker compose exec api dotnet ef database update`.
6. Acesse a API via [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html).

---

## 🛠 Troubleshooting Básico

- **Erro de banco:** Confira usuário, senha e se a porta 5432 está livre.
- **API não sobe:** Veja logs com `docker compose logs api`.
- **Healthcheck falha:** Confirme se a rota `/health` está implementada.
- **Banco vazio:** Use o comando `dotnet ef database update`.

---

## 🧪 Testes (via Swagger)

- Após subir o projeto, acesse: [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)
- Realize operações CRUD em todos os recursos (ONGs, voluntários, doações, etc)

Exemplos de payloads em [`docs/swagger-examples.json`](docs/swagger-examples.json).

---

## 👨‍💻 Desenvolvido por

Time Embrace – GS 2025-1:

- **Enzo Giuseppe Marsola** – RM: 556310  
- **Cauan da Cruz Ferreira** – RM: 5558238  
- **Igor dias Barrocal** – RM: 555217

---
