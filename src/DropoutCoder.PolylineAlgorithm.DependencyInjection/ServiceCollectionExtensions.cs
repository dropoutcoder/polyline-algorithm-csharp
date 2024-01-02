//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDefaultPolylineEncoder(this IServiceCollection services)
        {
            return services
                .AddPolylineEncoder<DefaultPolylineEncoder, DefaultCoordinateValidator, (double Latitude, double Longitude)>();
        }

        public static IServiceCollection AddPolylineEncoder<TEncoder, TValidator, TCoordinate>(this IServiceCollection services)
            where TEncoder : class, IPolylineEncoder<TCoordinate>
            where TValidator : class, ICoordinateValidator<TCoordinate>
        {
            return services
                .AddSingleton<ICoordinateValidator<TCoordinate>, TValidator>()
                .AddSingleton<IPolylineEncoder<TCoordinate>, TEncoder>();
        }
    }
}
