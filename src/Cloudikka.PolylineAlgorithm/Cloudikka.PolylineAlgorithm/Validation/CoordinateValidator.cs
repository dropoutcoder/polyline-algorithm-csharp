//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Validation {
	/// <summary>
	/// Static class used to perform coordinate validation
	/// </summary>
	public static class CoordinateValidator {
		#region Methods

		/// <summary>
		/// Performs coordinate validation
		/// </summary>
		/// <param name="coordinate">Coordinate</param>
		/// <returns>Returns validation result</returns>
		public static bool IsValid((double Latitude, double Longitude) coordinate) {
			return IsValidLatitude(coordinate.Latitude) && IsValidLongitude(coordinate.Longitude);
		}

		/// <summary>
		/// Performs latitude validation
		/// </summary>
		/// <param name="latitude">A double precision number</param>
		/// <returns>Returns validation result</returns>
		public static bool IsValidLatitude(double latitude) {
			return latitude >= Constants.Coordinate.MinLatitude && latitude <= Constants.Coordinate.MaxLatitude;
		}

		/// <summary>
		/// Performs longitude validation
		/// </summary>
		/// <param name="longitude">A double precision number</param>
		/// <returns>Returns validation result</returns>
		public static bool IsValidLongitude(double longitude) {
			return longitude >= Constants.Coordinate.MinLongitude && longitude <= Constants.Coordinate.MaxLongitude;
		}

		#endregion
	}
}
