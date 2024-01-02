//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using DropoutCoder.PolylineAlgorithm.Internal;

namespace DropoutCoder.PolylineAlgorithm
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Performs coordinate validation
    /// </summary>
    public class DefaultCoordinateValidator : ICoordinateValidator<(double Latitude, double Longitude)>
    {
        #region Methods

        /// <summary>
        /// Performs coordinate validation
        /// </summary>
        /// <param name="coordinate">Coordinate to validate</param>
        /// <returns>Returns validation result. If valid then true, otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsValid((double Latitude, double Longitude) coordinate)
        {
            return Math.Abs(coordinate.Latitude) <= Constants.Coordinate.MaxLatitude && Math.Abs(coordinate.Longitude) <= Constants.Coordinate.MaxLongitude;
        }

        #endregion
    }
}
