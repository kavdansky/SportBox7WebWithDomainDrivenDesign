namespace SportBox7.Domain.Factories
{
    using SportBox7.Domain.Common;

    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
