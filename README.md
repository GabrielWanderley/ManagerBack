# API de Gerenciamento de Vendas e Produtos

Este projeto implementa uma API web para gerenciar vendas e produtos. Ele fornece pontos de extremidade para executar várias ações, como listar, criar, atualizar e excluir produtos e vendas, além de realizar operações específicas como marcação de vendas e upload de imagens.

## Sumário
- [Começando](#começando)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Pontos de Extremidade](#pontos-de-extremidade)
  - [SaleController](#salecontroller)
  - [ProductController](#productcontroller)
- [Mapeamento de Entidades](#mapeamento-de-entidades)
- [Bibliotecas](#bibliotecas)

---

## Começando

### Pré-requisitos
- [.NET 6.0 ou superior](https://dotnet.microsoft.com/)
- Banco de Dados configurado (por exemplo, SQL Server)
### Instalação
1. Clone este repositório:
   ```bash
   git clone https://github.com/GabrielWanderley/ManagerBack.git

2. Navegue até o diretório raiz do projeto:
cd ManagerBack

3. Execute o seguinte comando para iniciar a aplicação:
   dotnet run
4. A API estará acessível em https://localhost:7118 por padrão.

## Pontos de Extremidade

### SaleController
GET /Sale
Recupera uma lista de vendas, com suporte a paginação.

GET /Sale/{id}
Recupera uma venda específica pelo ID.

GET /Sale/Product/{id}
Recupera vendas relacionadas a um produto específico pelo ID.

POST /Sale
Adiciona uma nova venda. Valida o estoque do produto antes de criar a venda.

PUT /Sale/{id}
Atualiza os detalhes de uma venda existente pelo ID.

DELETE /Sale/{id}
Remove uma venda existente e ajusta os dados do produto relacionado (estoque, lucro, vendidos).

## ProductController
GET /Product
Recupera uma lista de produtos, com suporte a paginação.

GET /Product/{id}
Recupera um produto específico pelo ID.

GET /Product/name/{name}
Recupera produtos com nomes que contenham o texto especificado.

GET /Product/Category/{name}
Recupera produtos de uma categoria específica.

GET /Product/sold
Recupera produtos ordenados pelo número de vendas.

POST /Product
Cria um novo produto, incluindo upload de imagem em Base64.

PUT /Product/{id}
Atualiza os detalhes de um produto específico pelo ID.

PATCH /Product/{id}
Atualiza parcialmente os detalhes de um produto, permitindo o upload de uma nova imagem em Base64.

DELETE /Product/{id}
Remove um produto pelo ID.

Mapeamento de Entidades
A classe SalesMapping mapeia a entidade Sale para a tabela correspondente no banco de dados.
A classe ProductsMapping mapeia a entidade Product para a tabela correspondente no banco de dados.
Bibliotecas
O projeto utiliza as seguintes bibliotecas:

AutoMapper: Para mapear entidades e DTOs.
Entity Framework Core: ORM para manipulação do banco de dados.
Microsoft.AspNetCore.JsonPatch: Para operações de PATCH.
Serilog: Para logging de eventos.
Swashbuckle.AspNetCore: Para geração de documentação Swagger.
Sinta-se à vontade para contribuir ou explorar o código para personalizá-lo às necessidades do seu projeto. Se tiver dúvidas ou sugestões, entre em contato!   
