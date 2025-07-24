using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services
{
    public interface iCategoryService
    {
        int CreateCategory(CategoryRequest request);
        IEnumerable<CategoryResponse> GetAllCategories();
        CategoryResponse GetCategoryById(int id);
        int DeleteCategry(int id);
        int UpdateCategory(int id,CategoryRequest request);
        bool ToggleStatus(int id);
    }
}
