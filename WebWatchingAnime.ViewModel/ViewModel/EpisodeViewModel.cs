using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public string Src { get; set; }

        public int STT { get; set; }

    }
}
