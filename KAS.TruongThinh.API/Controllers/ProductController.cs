using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KAS.EnterpriseLibrary.Authentication;
using KAS.TruongThinh.API.IControllers;
using KAS.TruongThinh.BusinessFunctions.IServices;
using KAS.TruongThinh.BusinessFunctions.Services;
using KAS.TruongThinh.Models.Entities;
using KAS.TruongThinh.Models.Structs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KAS.TruongThinh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : KASApiController, IDataAccessController<Product>
    {
        private readonly IDataAccessService<Product> _dataService;

        public ProductController(IConfiguration config)
        {
            _dataService = new TruongThinhDataService<Product>(config);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var resp = await _dataService.GetAll();
                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error get Product  " + e);
                return new OkObjectResult(null);
            }
            
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resp = await _dataService.Get(id);
            return new OkObjectResult(resp);
        }

        [HttpPost("GetWithProcedure/{storedProcedure}")]
        public async Task<IActionResult> GetWithProcedure(string storedProcedure, [FromBody] params ParameterDefinition[] parameters)
        {
            var dbParams = new DynamicParameters();
            if (parameters.Length > 0 && !string.IsNullOrEmpty(parameters[0].Key))
                foreach (var p in parameters)
                    dbParams.Add(p.Key, p.Value);

            var resp = await _dataService.GetDataWithProc(storedProcedure, dbParams);
            return new OkObjectResult(resp);
        }

        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] params ParameterDefinition[] parameters)
        {

            var resp = await _dataService.GetDataByFilter(parameters);
            return new OkObjectResult(resp);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Product request)
        {
            try
            {
                var resp = await _dataService.Insert(request);
                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create Product  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("InsertMany")]
        public async Task<IActionResult> InsertMany([FromBody] IEnumerable<Product> request)
        {
            try
            {
                var resp = await _dataService.Insert(request);
                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create Product  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Product request)
        {
            try
            {
                var resp = await _dataService.Update(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create Product  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("UpdateMany")]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<Product> request)
        {
            try
            {
                var resp = await _dataService.Update(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create Product  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Product request)
        {
            try
            {
                var resp = await _dataService.Delete(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create Product  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("DeleteMany")]
        public async Task<IActionResult> DeleteMany([FromBody] IEnumerable<Product> request)
        {
            try
            {
                var resp = await _dataService.Delete(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create Product  " + e);
                return new OkObjectResult(null);
            }
        }
    }
}