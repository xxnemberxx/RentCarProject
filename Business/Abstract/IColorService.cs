using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        Task<IResult> AddAsync(Color color);
        Task<IResult> AddRangeAsync(IEnumerable<Color> colors);
        IResult Update(Color color);
        IResult UpdateRange(IEnumerable<Color> colors);
        IResult Remove(Color color);
        IResult RemoveRange(IEnumerable<Color> colors);
        ValueTask<IDataResult<Color>> GetByIdAsync(byte colorId);
        Task<IDataResult<IEnumerable<Color>>> GetAllAsync();
    }
}
