//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Encoding {
	/// <summary>
	/// Defines the <see cref="TuplePolylineEncoding" />
	/// </summary>
	public sealed class TuplePolylineEncoding : PolylineEncoding<(double Latitude, double Longitude)> {
		#region Methods

		/// <summary>
		/// The CreateResult
		/// </summary>
		/// <param name="latitude">The <see cref="double"/></param>
		/// <param name="longitude">The <see cref="double"/></param>
		/// <returns>The <see cref="(double Latitude, double Longitude)"/></returns>
		protected override (double Latitude, double Longitude) CreateResult(double latitude, double longitude) {
			return (latitude, longitude);
		}

		/// <summary>
		/// The GetCoordinate
		/// </summary>
		/// <param name="source">The <see cref="(double Latitude, double Longitude)"/></param>
		/// <returns>The <see cref="(double Latitude, double Longitude)"/></returns>
		protected override (double Latitude, double Longitude) GetCoordinate((double Latitude, double Longitude) source) {
			return source;
		}

		#endregion
	}
}
