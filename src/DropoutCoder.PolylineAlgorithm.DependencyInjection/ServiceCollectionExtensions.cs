//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPolylineEncoder(this IServiceCollection services)
        {
            return services
                .AddSingleton<IPolylineEncoder, PolylineEncoder>();
        }
    }
}
