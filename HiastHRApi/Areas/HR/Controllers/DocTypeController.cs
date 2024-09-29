using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class DocTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DocTypeController> _logger;
        private readonly IDocTypeService _docTypeService;
        public DocTypeController(IUnitOfWork unitOfWork, ILogger<DocTypeController> logger, IDocTypeService docTypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _docTypeService = docTypeService;
        }
        // GET: api/<DocTypes>
        [HttpGet(nameof(GetDocTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع الوثائق")]
        public IActionResult GetDocTypes([FromQuery] SieveModel sieveModel) => Ok(_docTypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDocType))]
        [DisplayActionName(DisplayName = "إضافة نوع وثيقة جديد")]
        public async Task<IActionResult> CreateDocType(DocTypeDto docType)
        {
            if (ModelState.IsValid)
            {
                await _docTypeService.Add(docType);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = docType };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDocType))]
        [DisplayActionName(DisplayName = "تعديل نوع وثيقة")]
        public async Task<IActionResult> UpdateDocType(DocTypeDto docType)
        {
            if (ModelState.IsValid)
            {
                await _docTypeService.Update(docType);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = docType };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDocType))]
        [DisplayActionName(DisplayName = "حذف نوع وثيقة")]
        public async Task<IActionResult> DeleteDocType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _docTypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
