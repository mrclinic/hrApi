using hiastHRApi.Areas.HR.Models;
using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class EmpDocController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpDocController> _logger;
        private readonly IEmpDocService _empDocService;
        public EmpDocController(IUnitOfWork unitOfWork, ILogger<EmpDocController> logger, IEmpDocService empDocService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empDocService = empDocService;
        }
        // GET: api/<EmpDocs>
        [HttpGet(nameof(GetEmpDocs))]
        [DisplayActionName(DisplayName = "استعلام وثائق الموظفين")]
        public IActionResult GetEmpDocs([FromQuery] SieveModel sieveModel) => Ok(_empDocService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpDocsInfo))]
        [DisplayActionName(DisplayName = "استعلام وثائق الموظفين وتفاصيلها")]
        public IActionResult GetEmpDocsInfo([FromQuery] SieveModel sieveModel) => Ok(_empDocService.Get(sieveModel, includeProperties: "DocType"));

        [HttpPost(nameof(CreateEmpDoc))]
        [DisplayActionName(DisplayName = "إنشاء وثيقة")]
        public async Task<IActionResult> CreateEmpDoc(EmpDocDto empDoc)
        {
            if (ModelState.IsValid)
            {
                await _empDocService.Add(empDoc);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empDoc };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPost(nameof(UploadEmpDoc))]
        [DisplayActionName(DisplayName = "إرفاق وثيقة")]
        public async Task<IActionResult> UploadEmpDoc([FromForm] UploadDocModel uploadItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<EmpDocDto> docs = new List<EmpDocDto>();
                    foreach (var file in uploadItem.Files)
                    {
                        if (file != null)
                        {
                            if (file.Length > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var fileExtension = Path.GetExtension(fileName);
                                var fileModel = new EmpDocDto
                                {
                                    DocDate = uploadItem.DocDate,
                                    DocDescription = uploadItem.DocDescription,
                                    DocNumber = uploadItem.DocNumber,
                                    DocSrc = uploadItem.DocSrc,
                                    DocTypeId = uploadItem.DocTypeId,
                                    Note = uploadItem.Note,
                                    RefId = uploadItem.RefId,
                                    EmployeeId = uploadItem.PersonId,
                                    FileType = file.ContentType,
                                    Extension = fileExtension,
                                    Name = fileName

                                };
                                using (var target = new MemoryStream())
                                {
                                    file.CopyTo(target);
                                    fileModel.Content = target.ToArray();
                                }
                                docs.Add(fileModel);
                            }
                        }
                    }
                    await _empDocService.AddRange(docs);
                    await _unitOfWork.CompleteAsync();
                    return new JsonResult("Success") { StatusCode = 200, Value = true };
                }
                catch (Exception e)
                {
                    return new JsonResult("Failed") { StatusCode = 500, Value = false };
                }
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpDoc))]
        [DisplayActionName(DisplayName = "تعديل وثيقة موظف")]
        public async Task<IActionResult> UpdateEmpDoc(EmpDocDto empDoc)
        {
            if (ModelState.IsValid)
            {
                await _empDocService.Update(empDoc);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empDoc };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpDoc))]
        [DisplayActionName(DisplayName = "حذف وثيقة موظف")]
        public async Task<IActionResult> DeleteEmpDoc(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empDocService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpGet(nameof(DownloadEmpDoc))]
        [DisplayActionName(DisplayName = "عرض وثيقة")]
        public async Task<FileResult> DownloadEmpDoc(Guid id)
        {
            var fileToRetrieve = await _empDocService.Get(id);
            var file = File(fileToRetrieve.Content, fileToRetrieve.FileType, fileToRetrieve.Name);
            return file;
        }
    }
}
