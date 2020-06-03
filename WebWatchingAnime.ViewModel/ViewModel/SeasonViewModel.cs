using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel
{
    public class SeasonViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Status { get; set; }

        public ICollection<AnimeViewModel> Amimes { get; set; }
    }
}
