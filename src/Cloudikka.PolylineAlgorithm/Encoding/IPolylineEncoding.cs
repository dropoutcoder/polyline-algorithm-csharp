//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Encoding {
	using System.Collections.Generic;

	#region Interfaces

	/// <summary>
	/// Defines base interface for all polyline encodings
	/// </summary>
	/// <typeparam name="T">Desired type used to decode to and encode from</typeparam>
	public interface IPolylineEncoding<T> {
		#region Methods

		/// <summary>
		/// Method performs decoding from polyline encoded <see cref="System.String"/> to <see cref="IEnumerable{T}"/>
		/// </summary>
		/// <param name="source">The <see cref="System.String"/> as polyline encoded source</param>
		/// <returns>The <see cref="IEnumerable{T}"/></returns>
		IEnumerable<T> Decode(string source);

		/// <summary>
		/// Method performs encoding from generic type to polyline encoded <see cref="System.String"/>
		/// </summary>
		/// <param name="source">Coordinates to encode</param>
		/// <returns>Polyline encoded result</returns>
		string Encode(IEnumerable<T> source);

		#endregion
	}

	#endregion
}
