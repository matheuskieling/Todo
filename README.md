# 📝 ToDo API com Autenticação (.NET 8.0)

Esta é uma aplicação ASP.NET 8.0 que fornece uma API REST para gerenciamento de tarefas (todos) com autenticação baseada em JWT. Os dados são armazenados em um banco PostgreSQL, orquestrado via Docker Compose.

---

## 🚀 Como Subir a Aplicação

### 1. Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker + Docker Compose](https://docs.docker.com/compose/install/)

### 2. Subir o banco de dados

Na raiz do projeto, execute:

```bash
docker compose -f compose.yaml up -d
```

Isso irá subir o container PostgreSQL na porta `5432`.

### 3. Rodar a aplicação

Com o banco no ar, execute:

```bash
dotnet run --project ./[CAMINHO_DA_API]
```

A API estará disponível em `https://localhost:5001` (ou conforme configurado no `launchSettings.json`).

---

## 🔐 Autenticação

A autenticação é feita via JWT. Primeiro, é necessário registrar um usuário e depois realizar login para obter o token.

### 📌 Registro

**Endpoint**: `POST /Auth/Register`  
**Body**:

```json
{
  "username": "seu_usuario",
  "password": "sua_senha"
}
```

### 🔑 Login

**Endpoint**: `POST /Auth/Login`  
**Body**:

```json
{
  "username": "seu_usuario",
  "password": "sua_senha"
}
```

**Resposta**:

```json
{
  "userId": "GUID_DO_USUARIO",
  "token": "TOKEN_JWT"
}
```

Utilize esse token como `Bearer` nas requisições seguintes:

```http
Authorization: Bearer SEU_TOKEN_JWT
```

---

## 📚 Endpoints da API

### 🧾 Tarefas (`/Todos`)

- `GET /Todos`: Lista todas as tarefas do usuário autenticado.
- `GET /Todos/{id}`: Retorna os detalhes de uma tarefa específica.
- `GET /Todos/Filter?category=Trabalho`: Filtra tarefas pela categoria.
- `POST /Todos`: Cria uma nova tarefa.

  **Body**:
  ```json
  {
    "title": "Estudar .NET",
    "description": "Praticar testes de integração",
    "categoryName": "Estudos"
  }
  ```

- `PUT /Todos/{id}`: Atualiza uma tarefa existente.
- `PATCH /Todos/Complete/{id}`: Marca uma tarefa como concluída.
- `DELETE /Todos/{id}`: Exclui uma tarefa.

### 🗂️ Categorias (`/Todos/Category`)

- `GET /Todos/Category`: Lista todas as categorias do usuário.
- `POST /Todos/Category`: Adiciona uma nova categoria.

  **Body**:
  ```json
  {
    "categoryName": "Pessoal"
  }
  ```

- `DELETE /Todos/Category/{id}`: Exclui uma categoria.

---

## 🧪 Testes

Recomenda-se utilizar ferramentas como [Postman](https://www.postman.com/) ou [httpie](https://httpie.io/) para explorar os endpoints da API durante o desenvolvimento.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8.0
- PostgreSQL
- Docker Compose
- Entity Framework Core
- JWT Authentication
- Testcontainers
- Xunit

---

