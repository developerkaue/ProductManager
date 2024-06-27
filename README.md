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

## Estrutura do Projeto

## Interfaces
- Interfaces definem contratos que especificam os métodos que uma classe deve implementar, sem fornecer a implementação real.

## Por que usar:

- **Abstração**: Permite abstrair a funcionalidade, ocultando detalhes da implementação.
- **Flexibilidade**: Facilita a troca de implementações diferentes sem alterar o código que depende da interface.
- **Testabilidade**: Permite a criação de mocks ou stubs para testes unitários.
- **Repositório**: O padrão de repositório abstrai a lógica de acesso a dados, fornecendo uma camada entre a aplicação e a fonte de dados.

- **Encapsulamento**: Centraliza a lógica de acesso a dados em um único local.
- **Facilita a manutenção**: Mudanças na lógica de acesso a dados não afetam o restante da aplicação.
- **Testabilidade**: Permite simular operações de banco de dados em testes unitários.
- **DTO (Data Transfer Object)**: Um DTO é um objeto que transporta dados entre processos, ajudando a encapsular a forma de transporte dos dados.


- **Segurança**: Evita a exposição de entidades de banco de dados diretamente.
- **Desempenho**: Reduz a quantidade de dados transferidos pela rede.
- **Desacoplamento**: Desacopla a camada de apresentação da camada de dados, permitindo mudanças independentes em ambas.
- **Serviço**: Uma classe de serviço encapsula a lógica de negócios da aplicação, utilizando repositórios para acessar os dados.


- **Organização**: Separa a lógica de negócios do código do controlador.
- **Reutilização**: Facilita a reutilização da lógica de negócios em diferentes partes da aplicação.
- **Testabilidade**: Permite testar a lógica de negócios de forma isolada.

## Benefícios da Estrutura
- **Modularidade**: Cada componente da aplicação tem uma responsabilidade única, tornando o código mais organizado.
- **Facilidade de Testes**: Componentes isolados permitem testes unitários mais eficazes.
- **Manutenibilidade**: Alterações em uma parte da aplicação (como a lógica de negócios ou a lógica de acesso a dados) não afetam outras partes.
- **Escalabilidade**: A aplicação pode crescer em complexidade sem se tornar incontrolável, graças à separação de responsabilidades.
- **Reusabilidade**: A lógica de negócios e acesso a dados pode ser facilmente reutilizada em diferentes partes da aplicação ou em outras aplicações.


## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para reportar problemas, sugerir novas funcionalidades ou enviar pull requests.

---
