using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChordsWebApp
{
    public partial class Song
    {
        public Song()
        {
            AuthorsSongs = new HashSet<AuthorsSong>();
            SongAnalyses = new HashSet<SongAnalysis>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Пісня")]
        public string Name { get; set; } = null!;
        public int GenreId { get; set; }

        [Display(Name = "Жанр")]
        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<AuthorsSong> AuthorsSongs { get; set; }
        public virtual ICollection<SongAnalysis> SongAnalyses { get; set; }
    }
}
