//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Defines the <see cref="PolylineEncoderBase{TIn}" />
	/// </summary>
	/// <typeparam name="TIn"></typeparam>
	public abstract class PolylineEncoderBase<TIn> : IPolylineEncoder<TIn> {
		#region Methods

		/// <summary>
		/// The Encode
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{TIn}"/></param>
		/// <returns>The <see cref="string"/></returns>
		public string Encode(IEnumerable<TIn> source) {
			if (source == null || !source.Any()) {
				throw new ArgumentException(ExceptionMessageResource.SourceCharArrayCannotBeNullOrEmpty, nameof(source));
			}

			var coordinates = GetGeoCoordinates(source);

			return PolylineAlgorithm.Encode(coordinates);
		}

		/// <summary>
		/// The GetGeoCoordinates
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{TIn}"/></param>
		/// <returns>The <see cref="IEnumerable{(double Latitude, double Longitude)}"/></returns>
		protected abstract IEnumerable<(double Latitude, double Longitude)> GetGeoCoordinates(IEnumerable<TIn> source);

		#endregion
	}
}
