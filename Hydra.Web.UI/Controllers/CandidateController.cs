using Hydra.DTO.Candidate;
using Hydra.Service.Services.Interface;
using Hydra.Web.UI.Models.Candidate;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Hydra.Web.UI.Controllers {
    [Route("[Controller]")]
    public class CandidateController : Controller {
        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateService _service;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService service) {
            _logger = logger;
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index(int pageSize = 10, int page = 1, string name = "", int? bootcamp = null) {
            var dataGrid = _service.GetCandidates(pageSize, page, name, bootcamp);
            var viewModel = new CandidateIndexViewModel {
                DataGrid = dataGrid,
                Name = name,
                Bootcamp = bootcamp
            };
            return View(viewModel);
        }

        [HttpPost("import")]
        public async Task<IActionResult> Insert(IFormFile file) {
            List<CandidateImportExcelDto> listCandidate;
            using (var stream = new MemoryStream()) {
                await file.CopyToAsync(stream);
                using (ExcelPackage package = new ExcelPackage(stream)) {
                    listCandidate = _service.ImportExcel(package);
                }
            }            
            return Ok(listCandidate);
        }
    }
}
