using Hydra.DTO.Candidate;
using Hydra.Repository.Dtos;

namespace Hydra.Web.UI.Models.Candidate {
    public class CandidateIndexViewModel {
        public PageGrid<CandidateGridDto> DataGrid { get; set; }
        public string Name { get; set; }
        public int? Bootcamp { get; set; }
    }
}
