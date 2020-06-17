using System;
using System.Collections.Generic;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel.Client
{
    public class AnimeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public string EpisodeName { get; set; }
        public string Image { get; set; }
        public string SubName { get; set; }

        public string Details { get; set; }

        public string MaxEps { get; set; }
        public List<int> EpsId { get; set; }
        public List<string> EpsName { get; set; }
        public string OrtherName { get; set; }
        public int YearId { get; set; }
        public string YearName { get; set; }
        public ICollection<string> CategoryId { get; set; }
        public List<string> CategoryName { get; set; }
    }
}
