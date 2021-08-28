using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Task<IResult> AddAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(IEnumerable<Brand> brands)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Brand>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<IDataResult<Brand>> GetByIdAsync(short brandId)
        {
            throw new NotImplementedException();
        }

        public IResult Remove(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IResult RemoveRange(IEnumerable<Brand> brands)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRange(IEnumerable<Brand> brands)
        {
            throw new NotImplementedException();
        }
    }
}
