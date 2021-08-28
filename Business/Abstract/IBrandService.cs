using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<IResult> AddAsync(Brand brand);
        Task<IResult> AddRangeAsync(IEnumerable<Brand> brands);
        IResult Update(Brand brand);
        IResult UpdateRange(IEnumerable<Brand> brands);
        IResult Remove(Brand brand);
        IResult RemoveRange(IEnumerable<Brand> brands);
        ValueTask<IDataResult<Brand>> GetByIdAsync(short brandId);
        Task<IDataResult<IEnumerable<Brand>>> GetAllAsync();
    }
}
