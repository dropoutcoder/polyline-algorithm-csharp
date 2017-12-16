//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Defines the <see cref="Defaults" />
	/// </summary>
	public static class Defaults {
		#region Fields

		/// <summary>
		/// Defines the EmptyCoordinates
		/// </summary>
		public static readonly IEnumerable<(double Latitude, double Longitude)> EmptyCoordinates = Enumerable.Empty<(double Latitude, double Longitude)>();

		/// <summary>
		/// Defines the EmptyPolyline
		/// </summary>
		public static readonly string EmptyPolyline = String.Empty;

		/// <summary>
		/// Defines the InvalidCoordinates
		/// </summary>
		public static readonly IEnumerable<(double Latitude, double Longitude)> InvalidCoordinates = new[] {
			(99.47383, 180.06250)
		};

		/// <summary>
		/// Defines the InvalidPolyline
		/// </summary>
		public static readonly string InvalidPolyline = "mnc~Qsm_ja@";

		/// <summary>
		/// Defines the NullCoordinates
		/// </summary>
		public static readonly IEnumerable<(double Latitude, double Longitude)> NullCoordinates = null;

		/// <summary>
		/// Defines the NullPolyline
		/// </summary>
		public static readonly string NullPolyline = null;

		/// <summary>
		/// Defines the ValidCoordinates
		/// </summary>
		public static readonly IEnumerable<(double Latitude, double Longitude)> ValidCoordinates = new[] {
			(49.47383, 59.06250),
			(-58.37407, 25.31250),
			(52.99363, -120.93750),
			(-44.49024, -174.37500)
		};

		/// <summary>
		/// Defines the ValidPolyline
		/// </summary>
		public static readonly string ValidPolyline = "mz}lHssngJj`gqSnx~lEcovfTnms{Zdy~qQj_deI";

		#endregion
	}
}
