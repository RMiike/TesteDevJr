# TesteDevJr

ETAPA 1
Criar um CRUD de Cliente utilizando ASP.NET MVC e persistência de dados utilizando (EF, Dapper).
 * Listar cliente
 * Incluir um cliente (Nome, Email, CPF)
 * Atualizar um cliente
 * Excluir um cliente

O que será avaliado
 * Conhecimento de ASP.NET MVC, SQL Server
 * Persistência de Dados (EF, Dapper)
 * Código Limpo

Diferencial
 * Refatoração
 * SOLID


ETAPA 2
Criar um CRUD de Produtos.
Ao cadastrar um novo cliente, tornar obrigatório relacioná-lo a um produto.
 * Listar produto
 * Incluir um produto (Nome, Ativo)
 * Atualizar um produto
 * Excluir um produto

Regras:
- Não permitir a inclusão de mais de um cliente com o mesmo CPF ou mesmo e-mail
- Não permitir relacionar mais de um cliente ao mesmo produto
- No cadastro de cliente, não listas produtos inativos para seleção
- Não permitir a exclusão de um produto que esteja relacionado a um cliente
