using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trackings.Application.Queries
{
    public interface IBrandQuery
    {
        Task<IEnumerable<BrandViewModel>> findAll();
        Task<IEnumerable<BrandViewModel>> findByMall(int malId);
        Task<BrandViewModel> findById(int brandId);  
    }
}
