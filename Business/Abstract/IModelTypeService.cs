using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IModelTypeService
    {
        IResult Add(ModelType modelType);
        IResult Update(ModelType modelType);
        IResult Delete(ModelType modelType);
        IDataResult<List<ModelType>> GetAll();
    }
}
