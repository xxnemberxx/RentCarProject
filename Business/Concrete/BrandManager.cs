using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Message.Added);
        }

        public IDataResult<List<Brand>> GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Message.SelectedList);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Message.Added);
        }
    }
}
