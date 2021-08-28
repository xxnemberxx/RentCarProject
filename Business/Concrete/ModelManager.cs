using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public Task<IResult> AddAsync(Model model)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(IEnumerable<Model> models)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Model>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<IDataResult<Model>> GetByIdAsync(short modelId)
        {
            throw new System.NotImplementedException();
        }

        public IResult Remove(Model model)
        {
            throw new System.NotImplementedException();
        }

        public IResult RemoveRange(IEnumerable<Model> models)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Model model)
        {
            throw new System.NotImplementedException();
        }

        public IResult UpdateRange(IEnumerable<Model> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
