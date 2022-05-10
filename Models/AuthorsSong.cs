using System;
using System.Collections.Generic;

namespace ChordsWebApp
{
    public partial class AuthorsSong
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int SongId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Song Song { get; set; } = null!;
    }
}
