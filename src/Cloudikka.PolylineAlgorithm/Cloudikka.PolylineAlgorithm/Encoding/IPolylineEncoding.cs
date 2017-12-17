//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Encoding {
	using System.Collections.Generic;

	#region Interfaces

	/// <summary>
	/// Defines the <see cref="IPolylineEncoding{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IPolylineEncoding<T> {
		#region Methods

		/// <summary>
		/// The Decode
		/// </summary>
		/// <param name="source">The <see cref="string"/></param>
		/// <returns>The <see cref="IEnumerable{T}"/></returns>
		IEnumerable<T> Decode(string source);

		/// <summary>
		/// The Encode
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{T}"/></param>
		/// <returns>The <see cref="string"/></returns>
		string Encode(IEnumerable<T> source);

		#endregion
	}

	#endregion
}
