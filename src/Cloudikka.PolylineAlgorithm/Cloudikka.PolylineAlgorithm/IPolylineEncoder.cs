//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm {
	using System.Collections.Generic;

	#region Interfaces

	/// <summary>
	/// Defines the <see cref="IPolylineEncoder{TIn}" />
	/// </summary>
	/// <typeparam name="TIn"></typeparam>
	public interface IPolylineEncoder<TIn> {
		#region Methods

		/// <summary>
		/// The Encode
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{TIn}"/></param>
		/// <returns>The <see cref="string"/></returns>
		string Encode(IEnumerable<TIn> source);

		#endregion
	}

	#endregion
}
