using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Interfaces
{
    public interface IGenericService<TRequest,TResponse,TEntity>
    {
        int Create(TRequest request);
        IEnumerable<TResponse> GetAll();
        TResponse GetById(int id);
        int Delete(int id);
        int Update(int id, TRequest request);
        bool ToggleStatus(int id);
    }
}
