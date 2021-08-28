using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModelTypeManager : IModelTypeService
    {
        private IModelTypeDal _modelTypeDal;
        public ModelTypeManager(IModelTypeDal modelTypeDal)
        {
            _modelTypeDal = modelTypeDal;
        }

        public Task<IResult> AddAsync(ModelType modelType)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(IEnumerable<ModelType> modelTypes)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<ModelType>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<IDataResult<ModelType>> GetByIdAsync(byte typeId)
        {
            throw new System.NotImplementedException();
        }

        public IResult Remove(ModelType modelType)
        {
            throw new System.NotImplementedException();
        }

        public IResult RemoveRange(IEnumerable<ModelType> modelTypes)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(ModelType modelType)
        {
            throw new System.NotImplementedException();
        }

        public IResult UpdateRange(IEnumerable<ModelType> modelTypes)
        {
            throw new System.NotImplementedException();
        }
    }
}
