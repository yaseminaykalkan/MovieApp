using System;

namespace MovieApp.Core.Entities.Abstracts
{
    public interface IAuditable
    {
        string CreatedUser { get; set; }
        string UpdatedUser { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}