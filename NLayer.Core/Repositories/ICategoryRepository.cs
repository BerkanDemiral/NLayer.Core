using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        /// <summary>
        /// Verilen kategori id değerine göre Bağlı olduğu productları ve idsi verilen kategoriyi getirecek olan fonksiyon. 1 Categori 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<Category> GetSingleCategoryByIdWithProductAsync(int categoryId);
    }
}
