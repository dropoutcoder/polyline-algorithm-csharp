//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Encoding {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Defines the <see cref="PolylineEncoding{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class PolylineEncoding<T> : IPolylineEncoding<T> {
		#region Methods

		/// <summary>
		/// The Decode
		/// </summary>
		/// <param name="source">The <see cref="string"/></param>
		/// <returns>The <see cref="IEnumerable{T}"/></returns>
		public IEnumerable<T> Decode(string source) {
			if (String.IsNullOrEmpty(source)) {
				throw new ArgumentException(ExceptionMessageResource.SourcePolylineStringCannotBeNullOrEmpty, nameof(source));
			}

			char[] polyline = source.ToCharArray();

			return PolylineAlgorithm.Decode(polyline)
				.Select(c => CreateResult(c.Latitude, c.Longitude));
		}

		/// <summary>
		/// The Encode
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{T}"/></param>
		/// <returns>The <see cref="string"/></returns>
		public string Encode(IEnumerable<T> source) {
			if (source == null || !source.Any()) {
				throw new ArgumentException(ExceptionMessageResource.SourceCharArrayCannotBeNullOrEmpty, nameof(source));
			}

			var coordinates = source.Select(s => GetCoordinate(s));

			return PolylineAlgorithm.Encode(coordinates);
		}

		/// <summary>
		/// The CreateResult
		/// </summary>
		/// <param name="latitude">The <see cref="double"/></param>
		/// <param name="longitude">The <see cref="double"/></param>
		/// <returns>The <see cref="T"/></returns>
		protected abstract T CreateResult(double latitude, double longitude);

		/// <summary>
		/// The GetCoordinates
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{T}"/></param>
		/// <returns>The <see cref="IEnumerable{(double Latitude, double Longitude)}"/></returns>
		protected abstract (double Latitude, double Longitude) GetCoordinate(T source);

		#endregion
	}
}
