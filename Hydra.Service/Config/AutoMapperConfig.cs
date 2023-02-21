using AutoMapper;
using Hydra.DataAccess.Models;
using Hydra.DTO.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Service.Config {
    internal class AutoMapperConfig : Profile {
        public AutoMapperConfig() {
            CreateMap<Candidate, CandidateGridDto>()
               .ForMember(dto => dto.BootcampClass,
               opt => opt.MapFrom(c => $"ITC {c.BootcampClassId}"))
               .ForMember(dto => dto.FullName,
               opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"));
        }
    }
}
