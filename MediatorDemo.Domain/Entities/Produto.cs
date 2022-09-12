using MediatorDemo.Domain.Validators;

namespace MediatorDemo.Domain.Entities;

public class Produto : Entity
{
    public Produto(Guid id, string? codigoBarras, string nomeProduto, decimal preco, DateTime criacao)
    {
        Id = id;
        CodigoBarras = codigoBarras;
        NomeProduto = nomeProduto;
        Preco = preco;
        Criacao = criacao;

        Validate(this, new ProdutoValidator());
    }

    public string? CodigoBarras { get; private set; }
    public string NomeProduto { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Preco { get; private set; }
}
