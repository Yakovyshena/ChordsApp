using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChordsWebApp
{
    public partial class Genre
    {
        public Genre()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Поле необхідно заповнити")]
        [Display(Name="Жанр")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Song> Songs { get; set; }
    }
}
