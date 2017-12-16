//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm {
	using System.Collections.Generic;

	#region Interfaces

	/// <summary>
	/// Defines the <see cref="IPolylineDecoder{TOut}" />
	/// </summary>
	/// <typeparam name="TOut"></typeparam>
	public interface IPolylineDecoder<TOut> {
		#region Methods

		/// <summary>
		/// The Decode
		/// </summary>
		/// <param name="source">The <see cref="string"/></param>
		/// <returns>The <see cref="IEnumerable{TOut}"/></returns>
		IEnumerable<TOut> Decode(string source);

		#endregion
	}

	#endregion
}
