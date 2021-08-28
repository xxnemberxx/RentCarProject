using Business.Abstract;
using Core.Utilities.Helpers;
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
    public class VehicleImagesController : ControllerBase
    {
        private IVehicleImageService _vehicleImageService;
        public VehicleImagesController(IVehicleImageService vehicleImageService)
        {
            _vehicleImageService = vehicleImageService;
        }
        [HttpPost("upload")]
        public IActionResult Upload([FromForm(Name = ("Image"))] IFormFile file, [FromForm] VehicleImage vehicleImage)
        {
            var result = _vehicleImageService.AddAsync(file, vehicleImage);

            if (result.Result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("CarImageId"))] int id)
        {
            var carImage = _vehicleImageService.GetById(id).Data;
            var result = _vehicleImageService.Delete(carImage);
            if (result.Success && carImage != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(short vehicleId)
        {
            var result = _vehicleImageService.GetImagesByCarId(vehicleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
