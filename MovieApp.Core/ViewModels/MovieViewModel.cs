namespace MovieApp.Core.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Year { get; set; }
        public string ImagePath { get; set; }
    }
}