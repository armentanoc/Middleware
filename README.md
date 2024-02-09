# Projeto Middleware Web API 

## Introdução

Este projeto é uma Web API construída usando ASP.NET Core, que fornece operações básicas para gerenciar usuários. 
Além disso, inclui dois middlewares essenciais para **autenticação** 🔐 e **tratamento de erros** 🐛.

https://github.com/armentanoc/Middleware/assets/88147887/ca733128-a67a-4c2a-a134-7269d635a829

## Controller de Usuário

O `UserController` gerencia as operações CRUD para usuários.

### Obter Todos os Usuários

- **Endpoint:** `GET /api/user`
- **Descrição:** Obtém todos os usuários cadastrados.
- **Resposta de Sucesso:** `200 OK` com a lista de usuários.
- **Exemplo de Uso:**
  ```bash
  curl -X GET -H "LoggedUser: admin" http://localhost:5000/api/user

### Adicionar Usuário

- **Endpoint:** `POST /api/user`
- **Descrição:** Adiciona um novo usuário.
- **Parâmetros:**
  - name (string, obrigatório): Nome do usuário.
  - email (string, obrigatório, formato de e-mail): Endereço de e-mail do usuário.
- **Resposta de Sucesso:** `200 OK` com os detalhes do usuário adicionado.
- **Resposta de Erro:** `400 Bad Request` se a adição falhar.
- **Exemplo de Uso:**
  ```bash
  curl -X POST -H "Content-Type: application/json" -H "LoggedUser: admin" -d '{"name": "John Doe", "email": "john.doe@example.com"}' http://localhost:5000/api/user

### Obter Usuário por ID
- **Endpoint**: `GET /api/user/{id}`
- **Descrição**: Obtém um usuário pelo ID.
- **Parâmetros**:
  - id (int, obrigatório): ID do usuário.
- **Resposta de Sucesso:** `200 OK` com os detalhes do usuário.
- **Resposta de Erro:** `404 Not Found` se o usuário não for encontrado.
- **Exemplo de Uso:**
  ```bash
  curl -X GET -H "LoggedUser: admin" http://localhost:5000/api/user/1

### Excluir Usuário por ID
- **Endpoint**: `DELETE /api/user/{id}`
- **Descrição**: Exclui um usuário pelo ID.
- **Parâmetros**:
  - id (int, obrigatório): ID do usuário a ser excluído.
- **Resposta de Sucesso:** `204 No Content` se a exclusão for bem-sucedida.
- **Resposta de Erro:** `400 Bad Request` se a exclusão falhar.
- **Exemplo de Uso:**
  ```bash
  curl -X DELETE -H "LoggedUser: admin" http://localhost:5000/api/user/1

## Middlewares

### 🔐 Middleware de Autenticação (AuthMiddleware)
Este middleware garante que a execução de qualquer operação na API exige a presença do header `LoggedUser` com o valor `admin`.

- **Uso**: O header `LoggedUser` é obrigatório e deve ter o valor "admin" para executar operações na API.
- **Resposta de Erro**: `401 Unauthorized` se o header não estiver presente ou o valor não for "admin".

### 🐛 Middleware de Tratamento de Erros (ErrorHandlingMiddleware)
Este middleware trata exceções durante a execução da API, retornando uma resposta JSON com a mensagem de erro correspondente.

- **Resposta de Erro**: `500 Internal Server Error` se ocorrer uma exceção não tratada.

## Como Contribuir
Sinta-se à vontade para contribuir para este projeto! Se você encontrar problemas, abra uma issue. Se desejar adicionar recursos, crie um pull request.
