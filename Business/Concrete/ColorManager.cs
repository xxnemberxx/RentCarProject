using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public Task<IResult> AddAsync(Color color)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(IEnumerable<Color> colors)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Color>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<IDataResult<Color>> GetByIdAsync(byte colorId)
        {
            throw new NotImplementedException();
        }

        public IResult Remove(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult RemoveRange(IEnumerable<Color> colors)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRange(IEnumerable<Color> colors)
        {
            throw new NotImplementedException();
        }
    }
}
