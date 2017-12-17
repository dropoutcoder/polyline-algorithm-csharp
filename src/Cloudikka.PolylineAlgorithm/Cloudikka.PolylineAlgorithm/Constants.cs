//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm {
	/// <summary>
	/// Defines the <see cref="Constants" />
	/// </summary>
	public static class Constants {
		#region Constants

		/// <summary>
		/// Defines the coordinate precision
		/// </summary>
		public const double Precision = 1E5;

		/// <summary>
		/// Defines the shift length
		/// </summary>
		public const int ShiftLength = 5;

		#endregion

		/// <summary>
		/// Defines the <see cref="ASCII" />
		/// </summary>
		public static class ASCII {
			#region Constants

			/// <summary>
			/// Defines the ASCII QuestionMark
			/// </summary>
			public const int QuestionMark = 63;

			/// <summary>
			/// Defines the ASCII Space
			/// </summary>
			public const int Space = 32;

			/// <summary>
			/// Defines the ASCII UnitSeparator
			/// </summary>
			public const int UnitSeparator = 31;

			#endregion
		}

		/// <summary>
		/// Defines the <see cref="Coordinate" />
		/// </summary>
		public static class Coordinate {
			#region Constants

			/// <summary>
			/// Defines the maximum value for Latitude
			/// </summary>
			public const int MaxLatitude = 90;

			/// <summary>
			/// Defines the maximum value for longitude
			/// </summary>
			public const int MaxLongitude = 180;

			/// <summary>
			/// Defines the minimum value for latitude
			/// </summary>
			public const int MinLatitude = -MaxLatitude;

			/// <summary>
			/// Defines the minimum value for longitude
			/// </summary>
			public const int MinLongitude = -MaxLongitude;

			#endregion
		}
	}
}
