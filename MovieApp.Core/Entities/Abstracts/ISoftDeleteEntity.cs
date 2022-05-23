using System;

namespace MovieApp.Core.Entities.Abstracts
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
        public string DeletedUser { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
