using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface ISeasonService
    {
        int Add(SeasonViewModel year);

        void Update(SeasonViewModel year);

        void Delete(int id);

        Task<List<SeasonViewModel>> GetAll();
    }
}
