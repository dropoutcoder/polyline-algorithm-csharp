//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Cloudikka.PolylineAlgorithm.Validation;

	/// <summary>
	/// Defines the <see cref="PolylineAlgorithm" />
	/// </summary>
	public static class PolylineAlgorithm {
		#region Methods

		/// <summary>
		/// The Decode
		/// </summary>
		/// <param name="polyline">The <see cref="char[]"/></param>
		/// <returns>The <see cref="IEnumerable{(double Latitude, double Longitude)}"/></returns>
		public static IEnumerable<(double Latitude, double Longitude)> Decode(char[] polyline) {
			if (polyline == null || !polyline.Any()) {
				throw new ArgumentException(ExceptionMessageResource.SourcePolylineStringCannotBeNullOrEmpty, nameof(polyline));
			}

			int index = 0;
			int latitude = 0;
			int longitude = 0;
			var result = new List<(double Latitude, double Longitude)>();

			while (index < polyline.Length) {
				if (!TryCalculateNext(polyline, ref index, ref latitude)) {
					throw new InvalidOperationException(ExceptionMessageResource.SourcePolylineStringIsMalformed);
				}

				if (!TryCalculateNext(polyline, ref index, ref longitude)) {
					throw new InvalidOperationException(ExceptionMessageResource.SourcePolylineStringIsMalformed);
				}

				var coordinate = (GetPreciseNumber(latitude), GetPreciseNumber(longitude));

				if (!CoordinateValidator.IsValid(coordinate)) {
					throw new InvalidOperationException(ExceptionMessageResource.SourcePolylineStringIsMalformed);
				}

				result.Add(coordinate);
			}

			return result;
		}

		/// <summary>
		/// The Encode
		/// </summary>
		/// <param name="coordinates">The <see cref="IEnumerable{(double Latitude, double Longitude)}"/></param>
		/// <returns>The <see cref="string"/></returns>
		public static string Encode(IEnumerable<(double Latitude, double Longitude)> coordinates) {
			if (coordinates == null || !coordinates.Any()) {
				throw new ArgumentException(ExceptionMessageResource.SourceCharArrayCannotBeNullOrEmpty, nameof(coordinates));
			}

			if (coordinates.Any(c => !CoordinateValidator.IsValid(c))) {
				throw new InvalidOperationException(ExceptionMessageResource.SourceCoordinatesAreInvalid);
			}

			var sb = new StringBuilder();

			int lastLat = 0;
			int lastLng = 0;

			foreach (var coordinate in coordinates) {
				int latitude = GetRoundedNumber(coordinate.Latitude);
				int longitude = GetRoundedNumber(coordinate.Longitude);

				AppendChar(latitude - lastLat, ch => sb.Append(ch));
				AppendChar(longitude - lastLng, ch => sb.Append(ch));

				lastLat = latitude;
				lastLng = longitude;
			}

			return sb.ToString();
		}

		/// <summary>
		/// The AppendChar
		/// </summary>
		/// <param name="value">The <see cref="int"/></param>
		/// <param name="appendAction">The <see cref="Action{char}"/></param>
		private static void AppendChar(int value, Action<char> appendAction) {
			int shifted = value << 1;
			if (value < 0)
				shifted = ~shifted;

			int rem = shifted;

			while (rem >= Constants.ASCII.Space) {
				appendAction((char)((Constants.ASCII.Space | (rem & Constants.ASCII.UnitSeparator)) + Constants.ASCII.QuestionMark));

				rem >>= Constants.ShiftLength;
			}

			appendAction((char)(rem + Constants.ASCII.QuestionMark));
		}

		/// <summary>
		/// The GetPreciseNumber
		/// </summary>
		/// <param name="value">The <see cref="int"/></param>
		/// <returns>The <see cref="double"/></returns>
		private static double GetPreciseNumber(int value) {
			return Convert.ToDouble(value) / Constants.Precision;
		}

		/// <summary>
		/// The GetRoundedNumber
		/// </summary>
		/// <param name="value">The <see cref="double"/></param>
		/// <returns>The <see cref="int"/></returns>
		private static int GetRoundedNumber(double value) {
			return (int)Math.Round(value * Constants.Precision);
		}

		/// <summary>
		/// The TryCalculateNext
		/// </summary>
		/// <param name="polyline">The <see cref="char[]"/></param>
		/// <param name="index">The <see cref="int"/></param>
		/// <param name="value">The <see cref="int"/></param>
		/// <returns>The <see cref="bool"/></returns>
		private static bool TryCalculateNext(char[] polyline, ref int index, ref int value) {
			int chunk;
			int sum = 0;
			int shifter = 0;

			do {
				chunk = (int)polyline[index++] - Constants.ASCII.QuestionMark;
				sum |= (chunk & Constants.ASCII.UnitSeparator) << shifter;
				shifter += Constants.ShiftLength;
			} while (chunk >= Constants.ASCII.Space && index < polyline.Length);

			if (index >= polyline.Length && chunk >= Constants.ASCII.Space)
				return false;

			value += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

			return true;
		}

		#endregion
	}
}
