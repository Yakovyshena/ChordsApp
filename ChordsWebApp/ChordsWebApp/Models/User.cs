using System;
using System.Collections.Generic;

namespace ChordsWebApp
{
    public partial class User
    {
        public User()
        {
            SongAnalyses = new HashSet<SongAnalysis>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Info { get; set; }

        public virtual ICollection<SongAnalysis> SongAnalyses { get; set; }
    }
}
