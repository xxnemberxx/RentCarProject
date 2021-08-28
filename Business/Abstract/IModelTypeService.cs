using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelTypeService
    {
        Task<IResult> AddAsync(ModelType modelType);
        Task<IResult> AddRangeAsync(IEnumerable<ModelType> modelTypes);
        IResult Update(ModelType modelType);
        IResult UpdateRange(IEnumerable<ModelType> modelTypes);
        IResult Remove(ModelType modelType);
        IResult RemoveRange(IEnumerable<ModelType> modelTypes);
        ValueTask<IDataResult<ModelType>> GetByIdAsync(byte typeId);
        Task<IDataResult<IEnumerable<ModelType>>> GetAllAsync();
    }
}
