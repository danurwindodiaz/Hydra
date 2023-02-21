using Hydra.DataAccess.Models;
using Hydra.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Repository.Repositories.Interface {
    public interface ICandidateRepository {
        PageGrid<Candidate> FindAllByNameAndBatch(int pageSize, int pageNumber, string name, int? bootcampClassId);

        Candidate? FindById(int id);

        Candidate CreateCandidate(Candidate candidate);

        Candidate UpdateCandidate(Candidate candidate);

        bool Delete(Candidate candidate);

        List<Candidate> FindAllCandidateByPassed(bool? isPassed);
    }
}
