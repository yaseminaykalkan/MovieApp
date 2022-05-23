using MovieApp.Core.Entities.Abstracts;

namespace MovieApp.Core.Entities
{
    public class Movie : BaseEntity<int>
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
