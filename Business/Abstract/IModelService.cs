using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        Task<IResult> AddAsync(Model model);
        Task<IResult> AddRangeAsync(IEnumerable<Model> models);
        IResult Update(Model model);
        IResult UpdateRange(IEnumerable<Model> models);
        IResult Remove(Model model);
        IResult RemoveRange(IEnumerable<Model> models);
        ValueTask<IDataResult<Model>> GetByIdAsync(short modelId);
        Task<IDataResult<IEnumerable<Model>>> GetAllAsync();
    }
}
