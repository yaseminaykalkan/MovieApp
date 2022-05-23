namespace MovieApp.Core.Entities.Abstracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}