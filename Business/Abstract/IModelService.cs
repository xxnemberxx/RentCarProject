using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IModelService
    {
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
        IDataResult<List<Model>> GetAll();
    }
}
