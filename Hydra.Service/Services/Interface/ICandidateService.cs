using Hydra.DTO.Candidate;
using Hydra.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Service.Services.Interface {
    public interface ICandidateService {
        PageGrid<CandidateGridDto> GetCandidates(int pageSize, int pageNumber, string name, int? bootcampClassId);
        CandidateDetailDto GetCandidateById(int id);
        CandidateUpdateDto GetUpdateCandidate(int id);
        void DeleteCandidateById(int id);
        CandidateDetailDto SaveCandidate(CandidateInsertDto dto);
        CandidateDetailDto SaveCandidate(CandidateUpdateDto dto);
    }
}
