//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
// 

namespace Cloudikka.PolylineAlgorithm {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Defines the <see cref="PolylineDecoderBase{TOut}" />
	/// </summary>
	/// <typeparam name="TOut"></typeparam>
	public abstract class PolylineDecoderBase<TOut> : IPolylineDecoder<TOut> {
		#region Methods

		/// <summary>
		/// The Decode
		/// </summary>
		/// <param name="source">The <see cref="string"/></param>
		/// <returns>The <see cref="IEnumerable{TOut}"/></returns>
		public IEnumerable<TOut> Decode(string source) {
			if (String.IsNullOrEmpty(source)) {
				throw new ArgumentException(ExceptionMessageResource.SourcePolylineStringCannotBeNullOrEmpty, nameof(source));
			}

			char[] polyline = source.ToCharArray();

			return PolylineAlgorithm.Decode(polyline)
				.Select(c => CreateResult(c.Latitude, c.Longitude));
		}

		/// <summary>
		/// The CreateResult
		/// </summary>
		/// <param name="latitude">The <see cref="double"/></param>
		/// <param name="longitude">The <see cref="double"/></param>
		/// <returns>The <see cref="TOut"/></returns>
		protected abstract TOut CreateResult(double latitude, double longitude);

		#endregion
	}
}
