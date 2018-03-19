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
	/// Performs polyline algorithm decoding and encoding
	/// </summary>
	public static class PolylineAlgorithm {
		#region Methods

		/// <summary>
		/// Method decodes polyline encoded representation to coordinates.
		/// </summary>
		/// <param name="polyline">Encoded polyline char array to decode</param>
		/// <returns>Returns coordinates.</returns>
		/// <exception cref="ArgumentException">If polyline argument is null -or- empty char array.</exception>
		/// <exception cref="InvalidOperationException">If polyline representation is not in correct format.</exception>
		public static IEnumerable<(double Latitude, double Longitude)> Decode(char[] polyline) {
			// Checking null and at least one character
			if (polyline == null || !polyline.Any()) {
				throw new ArgumentException(ExceptionMessageResource.ArgumentCannotBeNullOrEmpty, nameof(polyline));
			}

			// Initialize local variables
			int index = 0;
			int latitude = 0;
			int longitude = 0;
			var result = new List<(double Latitude, double Longitude)>();

			// Looping through encoded polyline char array
			while (index < polyline.Length) {
				// Attempting to calculate next latitude value. If failed exception is thrown
				if (!TryCalculateNext(polyline, ref index, ref latitude)) {
					throw new InvalidOperationException(ExceptionMessageResource.PolylineCharArrayIsMalformed);
				}

				// Attempting to calculate next longitude value. If failed exception is thrown
				if (!TryCalculateNext(polyline, ref index, ref longitude)) {
					throw new InvalidOperationException(ExceptionMessageResource.PolylineCharArrayIsMalformed);
				}

				var coordinate = (GetDoubleRepresentation(latitude), GetDoubleRepresentation(longitude));

				if (!CoordinateValidator.IsValid(coordinate)) {
					throw new InvalidOperationException(ExceptionMessageResource.PolylineCharArrayIsMalformed);
				}

				result.Add(coordinate);
			}

			return result;
		}

		/// <summary>
		/// Method encodes coordinates to polyline encoded representation
		/// </summary>
		/// <param name="coordinates">Coordinates to encode</param>
		/// <returns>Polyline encoded representation</returns>
		/// <exception cref="ArgumentException">If coordinates parameter is null or empty enumerable</exception>
		/// <exception cref="AggregateException">If one or more coordinate is out of range</exception>
		public static string Encode(IEnumerable<(double Latitude, double Longitude)> coordinates) {
			if (coordinates == null || !coordinates.Any()) {
				throw new ArgumentException(ExceptionMessageResource.ArgumentCannotBeNullOrEmpty, nameof(coordinates));
			}

			// Ensuring coordinates are valid, otherwise throws an aggregate exception
			EnsureCoordinates(coordinates);

			// Initializing local variables
			int lastLat = 0;
			int lastLng = 0;
			var sb = new StringBuilder();

			// Looping over coordinates and building encoded result
			foreach (var coordinate in coordinates) {
				int latitude = GetIntegerRepresentation(coordinate.Latitude);
				int longitude = GetIntegerRepresentation(coordinate.Longitude);

				sb.Append(GetEncodedCharacters(latitude - lastLat).ToArray());
				sb.Append(GetEncodedCharacters(longitude - lastLng).ToArray());

				lastLat = latitude;
				lastLng = longitude;
			}

			return sb.ToString();
		}

		/// <summary>
		/// Method performs coordinates validation. Throws exception, if invalid coordinate is found
		/// </summary>
		/// <param name="coordinates">Coordinates to validate</param>
		/// <exception cref="AggregateException">If one or more coordinate is out of range -or- invalid</exception>
		private static void EnsureCoordinates(IEnumerable<(double Latitude, double Longitude)> coordinates) {
			// Selecting invalid coordinates
			var invalidCoordinates = coordinates
				.Where(c => !CoordinateValidator.IsValid(c));

			// If any invalid coordinates exists throw an aggregate exception with inner argument out of range exception
			if (invalidCoordinates.Any()) {
				throw new AggregateException(
					ExceptionMessageResource.AggregateExceptionCoordinatesAreInvalidErrorMessage,
					invalidCoordinates
						.Select(c =>
							new ArgumentOutOfRangeException(
								String.Format(
									ExceptionMessageResource.ArgumentExceptionCoordinateIsOutOfRangeErrorMessageFormat,
									c.Latitude,
									c.Longitude
								)
							)
						)
				);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Rounded integer representation of precise double value</param>
		/// <returns>Returns value with specific precision. See <see cref="Constants.Precision"/></returns>
		private static double GetDoubleRepresentation(int value) {
			return Convert.ToDouble(value) / Constants.Precision;
		}

		/// <summary>
		/// Method converts value to polyline encoded characters
		/// </summary>
		/// <param name="value">Difference between current and previous latitude or longitude value</param>
		private static IEnumerable<char> GetEncodedCharacters(int value) {
			int shifted = value << 1;
			if (value < 0)
				shifted = ~shifted;

			int rem = shifted;

			while (rem >= Constants.ASCII.Space) {
				yield return (char)((Constants.ASCII.Space | (rem & Constants.ASCII.UnitSeparator)) + Constants.ASCII.QuestionMark);

				rem >>= Constants.ShiftLength;
			}

			yield return (char)(rem + Constants.ASCII.QuestionMark);
		}

		/// <summary>
		/// Method 
		/// </summary>
		/// <param name="value">Precise double representation</param>
		/// <returns></returns>
		private static int GetIntegerRepresentation(double value) {
			return (int)Math.Round(value * Constants.Precision);
		}

		/// <summary>
		/// Tries to calculate next integer representation of encoded polyline part
		/// </summary>
		/// <param name="polyline">The <see cref="char[]"/></param>
		/// <param name="index">The <see cref="int"/></param>
		/// <param name="value">The <see cref="int"/></param>
		/// <returns>The <see cref="bool"/></returns>
		private static bool TryCalculateNext(char[] polyline, ref int index, ref int value) {
			// Local variable initialization
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
