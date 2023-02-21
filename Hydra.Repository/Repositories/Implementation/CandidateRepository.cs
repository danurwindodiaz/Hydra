using Hydra.DataAccess.Models;
using Hydra.Repository.Dtos;
using Hydra.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Repository.Repositories.Implementation {
    internal class CandidateRepository : ICandidateRepository {
        private readonly HydraContext _dbContext;

        public CandidateRepository(HydraContext dbContext) {
            _dbContext = dbContext;
        }
        public Candidate CreateCandidate(Candidate candidate) {
            _dbContext.Add(candidate);
            _dbContext.SaveChanges();
            return candidate;
        }

        public bool Delete(Candidate candidate) {
            _dbContext.Remove(candidate);
            _dbContext.SaveChanges();
            return !_dbContext.Candidates.Any(c => c == candidate);
        }

        public PageGrid<Candidate> FindAllByNameAndBatch(int pageSize, int pageNumber, string name, int? bootcampClassId) {
            IQueryable<Candidate> query = from c in _dbContext.Candidates
                                          where (c.FirstName + " " + c.LastName).Contains(name ?? "")
                                          && (bootcampClassId == null || c.BootcampClassId == bootcampClassId)
                                          select c;
            return new PageGrid<Candidate>(query.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize).ToList(), query.Count(), pageNumber, pageSize);
        }

        public List<Candidate> FindAllCandidateByPassed(bool? isPassed) {
            IQueryable<Candidate> query = from c in _dbContext.Candidates
                                          where (isPassed == null || c.HasPassed == isPassed)
                                          select c;
            return query.ToList();
        }

        public Candidate? FindById(int id) {
            var candidate = _dbContext.Candidates.FirstOrDefault(c => c.Id == id);
            return candidate;
        }

        public Candidate UpdateCandidate(Candidate candidate) {
            _dbContext.Update(candidate);
            _dbContext.SaveChanges();
            return candidate;
        }
    }
}
