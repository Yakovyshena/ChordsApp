using System;
using System.Collections.Generic;

namespace ChordsWebApp
{
    public partial class Instrument
    {
        public Instrument()
        {
            SongAnalyses = new HashSet<SongAnalysis>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<SongAnalysis> SongAnalyses { get; set; }
    }
}
