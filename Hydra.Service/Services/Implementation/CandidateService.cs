using AutoMapper;
using Hydra.DTO.Candidate;
using Hydra.Repository.Dtos;
using Hydra.Repository.Repositories.Interface;
using Hydra.Service.Services.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Service.Services.Implementation {
    internal class CandidateService : ICandidateService {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper) {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public void DeleteCandidateById(int id) {
            throw new NotImplementedException();
        }

        public CandidateDetailDto GetCandidateById(int id) {
            throw new NotImplementedException();
        }

        public PageGrid<CandidateGridDto> GetCandidates(int pageSize, int pageNumber, string name, int? bootcampClassId) {
            var candidates = _candidateRepository.FindAllByNameAndBatch(pageSize, pageNumber, name, bootcampClassId);
            var results = new PageGrid<CandidateGridDto>(
                    candidates.Data.ConvertAll(c => _mapper.Map<CandidateGridDto>(c)),
                    candidates.TotalData,
                    candidates.PageNumber,
                    candidates.PageSize
                 );
            return results;
        }

        public CandidateUpdateDto GetUpdateCandidate(int id) {
            throw new NotImplementedException();
        }

        public List<CandidateImportExcelDto> ImportExcel(ExcelPackage package) {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];

            List<CandidateImportExcelDto> objekList = new List<CandidateImportExcelDto>();

            // Baca data dari baris kedua hingga baris terakhir
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++) {
                CandidateImportExcelDto objek = new CandidateImportExcelDto();
                objek.FirstName = worksheet.Cells[row, 1].Value.ToString();
                objek.LastName = worksheet.Cells[row, 2].Value.ToString();
                // ...
                objekList.Add(objek);
            }
            return objekList;
        }

        public CandidateDetailDto SaveCandidate(CandidateInsertDto dto) {
            throw new NotImplementedException();
        }

        public CandidateDetailDto SaveCandidate(CandidateUpdateDto dto) {
            throw new NotImplementedException();
        }
    }
}
