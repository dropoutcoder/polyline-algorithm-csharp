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
		/// Defines the Precision
		/// </summary>
		public const double Precision = 1E5;

		/// <summary>
		/// Defines the ShiftLength
		/// </summary>
		public const int ShiftLength = 5;

		#endregion

		/// <summary>
		/// Defines the <see cref="ASCII" />
		/// </summary>
		public static class ASCII {
			#region Constants

			/// <summary>
			/// Defines the QuestionMark
			/// </summary>
			public const int QuestionMark = 63;

			/// <summary>
			/// Defines the Space
			/// </summary>
			public const int Space = 32;

			/// <summary>
			/// Defines the UnitSeparator
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
			/// Defines the MaxLatitude
			/// </summary>
			public const int MaxLatitude = 90;

			/// <summary>
			/// Defines the MaxLongitude
			/// </summary>
			public const int MaxLongitude = 180;

			/// <summary>
			/// Defines the MinLatitude
			/// </summary>
			public const int MinLatitude = -MaxLatitude;

			/// <summary>
			/// Defines the MinLongitude
			/// </summary>
			public const int MinLongitude = -MaxLongitude;

			#endregion
		}
	}
}
