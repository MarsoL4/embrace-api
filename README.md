# Embrace API – Sistema de Apoio em Situações de Emergência Climática

## 📘 Visão Geral

A Embrace é uma plataforma que atua como um hub digital unificado para situações de emergência climática, conectando ONGs, coletivos, voluntários e comunidades afetadas. Em vez de esforços isolados, ela centraliza comunicação, cadastro de demandas e oferta de recursos em uma só interface — garantindo que campanhas e chamados de socorro sejam visíveis e atendidos com agilidade, reduzindo lacunas e sobreposições nas ações solidárias.

O Embrace.API representa um dos núcleos de backend dessa solução: uma API REST desenvolvida em .NET 8, voltada a viabilizar e organizar ações solidárias em contextos de desastre como enchentes, ondas de calor ou frio extremo. A solução permite:

- Cadastro de ONGs e ações solidárias;
- Registro e consulta de doações;
- Gerenciamento de voluntários;
- Visualização de pontos de coleta de alimentos;
- Integração com mapa e sistemas externos para gestão comunitária.

## 🧱 Arquitetura do Projeto

📄 [Clique aqui para visualizar o Diagrama de Arquitetura (PDF)](docs/ArquiteturaEmbrace.pdf)

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
└── appsettings.json           # Configurações de conexão
```

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- C#
- Entity Framework Core
- Npgsql (PostgreSQL)
- AutoMapper
- Swagger (Swashbuckle.AspNetCore)
- Docker e Docker Compose
- Visual Studio 2022

## 🚀 Conteinerização (Cloud)

A aplicação foi conteinerizada com Docker, atendendo aos requisitos de infraestrutura como código:

- 📦 1 container para a API (.NET 8)
- 🗄️ 1 container PostgreSQL via Dockerfile personalizado
- 👤 Usuário não-root no banco
- 📁 Volume nomeado para persistência de dados
- 🔄 Modo background com logs visíveis via terminal
- 🔐 Variáveis de ambiente para credenciais
- 🌐 Porta da API: 8080 | Porta do DB: 5432

## ⚙️ Como Executar o Projeto

Este projeto foi conteinerizado com Docker. Você só precisa do Docker instalado e seguir os passos abaixo:

### 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/embrace-api.git
```
```bash
cd embrace-api
```

### 2. Subir os containers da API e do banco PostgreSQL

```bash
docker-compose up --build -d
```

Isso irá:

- Criar a imagem do banco PostgreSQL com volume nomeado e usuário customizado.

- Criar a imagem da API .NET.

- Executar ambos em containers interligados via rede.

- Tornar a API acessível via porta 8080.

📌 O banco será iniciado vazio. Para popular com as tabelas necessárias, execute a migration manualmente usando linha de comando na pasta do projeto:
```bash
cd Embrace.API
```
```bash
dotnet ef database update
```

## 🧪 Testes (via Swagger)

- Após subir o projeto, acesse no navegador: http://localhost:8080/swagger/index.html

✅ Exemplos de json para testes podem ser encontrados no arquivo:

📁 [`docs/swagger-examples.json`](docs/swagger-examples.json)

Inclui exemplos para:

- POST /api/ongs
- POST /api/voluntarios
- POST /api/doacoes
- POST /api/acaoSolidaria
- POST /api/pontodealimento

---
## 👨‍💻 Desenvolvido por

Time Embrace – GS 2025-1:

- **Enzo Giuseppe Marsola** – RM: 556310, Turma: 2TDSPK  
- **Rafael de Souza Pinto** – RM: 555130, Turma: 2TDSPY  
- **Luiz Paulo F. Fernandes** – RM: 555497, Turma: 2TDSPF
