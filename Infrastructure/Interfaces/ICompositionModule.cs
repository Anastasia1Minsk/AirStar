using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AirStar.Infrastructure.Interfaces
{
    public interface ICompositionModule
    {
        void RegisterTypes(IServiceCollection services);
    }
}
