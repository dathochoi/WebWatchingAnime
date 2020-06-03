using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface IYearService
    {
        int Add(YearViewModel year);

        void Update(YearViewModel year);

        void Delete(int id);

        Task<List<YearViewModel>> GetAll();
        YearViewModel GetById(int id);
    }
}
