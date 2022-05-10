using System;
using System.Collections.Generic;

namespace ChordsWebApp
{
    public partial class Author
    {
        public Author()
        {
            AuthorsSongs = new HashSet<AuthorsSong>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<AuthorsSong> AuthorsSongs { get; set; }
    }
}
