using Core.Utilities;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAll();
    }
}
