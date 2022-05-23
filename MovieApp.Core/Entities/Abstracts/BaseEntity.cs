using Microsoft.AspNetCore.Identity;

namespace MovieApp.Core.Entities.Abstracts
{
    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}