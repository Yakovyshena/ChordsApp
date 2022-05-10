using System;
using System.Collections.Generic;

namespace ChordsWebApp
{
    public partial class SongAnalysis
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public int InstrumentId { get; set; }
        public string Chords { get; set; } = null!;
        public DateTime AddingDate { get; set; }

        public virtual Instrument Instrument { get; set; } = null!;
        public virtual Song Song { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
