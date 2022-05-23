using Microsoft.AspNetCore.Identity;
using MovieApp.Core.Entities.Abstracts;
using System.Collections.Generic;

namespace MovieApp.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<Movie> Movies { get; set; }
        
    }
}
