using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KAS.EnterpriseLibrary.Authentication;
using KAS.TruongThinh.API.IControllers;
using KAS.TruongThinh.BusinessFunctions.IServices;
using KAS.TruongThinh.BusinessFunctions.Services;
using KAS.TruongThinh.Models.Structs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static KAS.TruongThinh.Models.Entities.AuditTrail;

namespace KAS.TruongThinh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditTrailController : KASApiController,IDataAccessController<AuditTrails>
    {
        private readonly IDataAccessService<AuditTrails> _dataService;

        public AuditTrailController(IConfiguration config)
        {
            _dataService = new TruongThinhDataService<AuditTrails>(config);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var resp = await _dataService.GetAll();
            return new OkObjectResult(resp);
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
        public async Task<IActionResult> Insert([FromBody] AuditTrails request)
        {
            try
            {
                var resp = await _dataService.Insert(request);
                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create AuditTrails  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("InsertMany")]
        public async Task<IActionResult> InsertMany([FromBody] IEnumerable<AuditTrails> request)
        {
            try
            {
                var resp = await _dataService.Insert(request);
                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create AuditTrails  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] AuditTrails request)
        {
            try
            {
                var resp = await _dataService.Update(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create AuditTrails  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("UpdateMany")]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<AuditTrails> request)
        {
            try
            {
                var resp = await _dataService.Update(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create AuditTrails  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] AuditTrails request)
        {
            try
            {
                var resp = await _dataService.Delete(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create AuditTrails  " + e);
                return new OkObjectResult(null);
            }
        }

        [HttpPost("DeleteMany")]
        public async Task<IActionResult> DeleteMany([FromBody] IEnumerable<AuditTrails> request)
        {
            try
            {
                var resp = await _dataService.Delete(request);

                return new OkObjectResult(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error create AuditTrails  " + e);
                return new OkObjectResult(null);
            }
        }
    }
}