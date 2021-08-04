using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelTypesController : ControllerBase
    {
        private IModelTypeService _modelTypeService;
        public ModelTypesController(IModelTypeService modelTypeService)
        {
            _modelTypeService = modelTypeService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _modelTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(ModelType modelType)
        {
            var result = _modelTypeService.Add(modelType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(ModelType modelType)
        {
            var result = _modelTypeService.Update(modelType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(ModelType modelType)
        {
            var result = _modelTypeService.Delete(modelType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
