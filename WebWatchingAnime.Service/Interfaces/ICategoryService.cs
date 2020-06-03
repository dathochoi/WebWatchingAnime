using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.ViewModel.ViewModel;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface ICategoryService
    {
        int Add(CategoryViewModel year);

        void Update(CategoryViewModel year);

        void Delete(int id);

        Task<List<CategoryViewModel>> GetAll();
        CategoryViewModel GetById(int id);
    }
}
