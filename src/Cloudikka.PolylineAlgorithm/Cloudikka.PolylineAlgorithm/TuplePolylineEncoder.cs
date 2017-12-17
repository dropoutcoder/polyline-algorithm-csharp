//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm {
	using System.Collections.Generic;

	/// <summary>
	/// Defines the <see cref="TuplePolylineEncoder" />
	/// </summary>
	public sealed class TuplePolylineEncoder : PolylineEncoderBase<(double Latitude, double Longitude)> {
		#region Methods

		/// <summary>
		/// The GetGeoCoordinates
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{(double Latitude, double Longitude)}"/></param>
		/// <returns>The <see cref="IEnumerable{(double Latitude, double Longitude)}"/></returns>
		protected override IEnumerable<(double Latitude, double Longitude)> GetGeoCoordinates(IEnumerable<(double Latitude, double Longitude)> source) {
			return source;
		}

		#endregion
	}
}
