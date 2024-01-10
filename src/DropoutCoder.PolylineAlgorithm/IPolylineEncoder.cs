//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines base interface for all polyline encodings
    /// </summary>
    /// <typeparam name="T">Desired type used to decode to and encode from</typeparam>
    public interface IPolylineEncoder
    {
        #region Methods

        /// <summary>
        /// Method performs decoding from polyline encoded <see cref="string"/> to <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <param name="source">Encoded coordinates</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        IEnumerable<(double Latitude, double Longitude)> Decode(char[] value);

        /// <summary>
        /// Method performs encoding from generic type to polyline encoded <see cref="string"/>
        /// </summary>
        /// <param name="source">Coordinates to encode</param>
        /// <returns>Polyline encoded result</returns>
        string Encode(IEnumerable<(double Latitude, double Longitude)> collection);

        #endregion
    }
}
