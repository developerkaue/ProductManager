# Product Management System

## Descrição
O Product Management System é uma aplicação ASP.NET Core MVC para gerenciar produtos e fornecedores. Permite realizar operações CRUD (Create, Read, Update, Delete) tanto para produtos quanto para fornecedores, utilizando Entity Framework Core para acesso ao banco de dados e Bootstrap para estilização.

## Funcionalidades Principais
- Listagem de produtos e fornecedores.
- Detalhamento individual de produtos.
- Criação, edição e exclusão de produtos e fornecedores.
- Associação de fornecedores aos produtos.
- Validação de dados tanto no lado do cliente quanto no lado do servidor.
- Responsividade garantida com o uso de Bootstrap.

## Requisitos do Sistema
- ASP.NET Core 3.1 ou superior
- Entity Framework Core
- SQLite (ou outro banco de dados local suportado)
- Bootstrap (ou outra framework CSS de escolha)

## Configuração do Banco de Dados
1. Certifique-se de ter o Entity Framework Core instalado.
2. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`.
3. Utilize as migrações do EF Core para criar o banco de dados e as tabelas necessárias.

Exemplo de string de conexão para SQLSERVER:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SeuDesktop;Database=SuaBaseDeDados;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```

## Instalação e Execução
1. Clone o repositório.
2. Abra o projeto no Visual Studio (ou outra IDE de sua preferência).
3. Configure a string de conexão conforme descrito acima.
4. Execute as migrações do EF Core para criar o banco de dados:
   ```
   dotnet ef database update
   ou
   Update-Database
   ```
5. Inicie a aplicação.

## Como Usar
- Acesse a aplicação via navegador.
- Navegue pelas diferentes funcionalidades:
  - **Produtos**: Listagem, detalhamento, criação, edição e exclusão.
  - **Fornecedores**: Listagem, criação, edição e exclusão.
  - **Associação de Fornecedor**: Ao criar ou editar um produto, é possível selecionar o fornecedor associado.
  - **Ao excluir um Fornecedor os produtos relacionados a ele serão excluidos.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para reportar problemas, sugerir novas funcionalidades ou enviar pull requests.

---
