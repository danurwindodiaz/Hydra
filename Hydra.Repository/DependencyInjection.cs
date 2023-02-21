using Hydra.DataAccess.Models;
using Hydra.Repository.Repositories.Implementation;
using Hydra.Repository.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Repository {
    public class DependencyInjection {
        public static void AddRepositoryServices(IServiceCollection services) {
            services.AddDbContext<HydraContext>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
        }
    }
}
