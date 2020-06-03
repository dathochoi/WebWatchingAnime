using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface IAnimeCategoryService
    {
        AnimeCategoryViewModel Add(AnimeCategoryViewModel vm);

       // void Update(AnimeCategoryViewModel vm);

        void Delete(AnimeCategoryViewModel vm);

        Task<List<AnimeCategoryViewModel>> GetAll();
    }
}
