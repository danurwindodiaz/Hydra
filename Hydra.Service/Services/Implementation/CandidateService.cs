using AutoMapper;
using Hydra.DTO.Candidate;
using Hydra.Repository.Dtos;
using Hydra.Repository.Repositories.Interface;
using Hydra.Service.Services.Interface;
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

        public CandidateDetailDto SaveCandidate(CandidateInsertDto dto) {
            throw new NotImplementedException();
        }

        public CandidateDetailDto SaveCandidate(CandidateUpdateDto dto) {
            throw new NotImplementedException();
        }
    }
}
