using Hydra.Service.Services.Implementation;
using Hydra.Service.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Service {
    public class DependencyInjection {
        public static void AddServices(IServiceCollection services) {
            Hydra.Repository.DependencyInjection.AddRepositoryServices(services);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<ICandidateService, CandidateService>();
        }
    }
}
