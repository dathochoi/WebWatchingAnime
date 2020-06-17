using System;
using System.Collections.Generic;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel.Client
{
    public class SearchViewModel
    {
        public int CategoryId { get; set; }
        public int YearId { get; set; }
        public string TextSearch { get; set; }
        public int Animes { get; set; }
        public int Films { get; set; }
    }
}
