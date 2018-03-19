//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests.Encoding {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Cloudikka.PolylineAlgorithm.Encoding;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="PolylineEncodingTest" />
	/// </summary>
	[TestClass]
	[TestCategory(nameof(PolylineEncoding<char[]>))]
	public class PolylineEncodingTest : PolylineEncoding<(double latitude, double longitude)> {
		#region Methods

		/// <summary>
		/// The Decode_NullInput
		/// </summary>
		[TestMethod]
		public void Decode_NullInput() {
			// Arrange
			var nullPolylineString = (string)null;

			// Act
			void DecodeNullPolylineCharArray() {
				this.Decode(nullPolylineString);
			}

			// Assert
			Assert.ThrowsException<ArgumentException>(() => DecodeNullPolylineCharArray());
		}

		/// <summary>
		/// The Decode_EmptyInput
		/// </summary>
		[TestMethod]
		public void Decode_EmptyInput() {
			// Arrange
			var emptyPolylineString = Defaults.Polyline.Empty;

			// Act
			void DecodeEmptyPolylineCharArray() {
				this.Decode(emptyPolylineString);
			}

			// Assert
			Assert.ThrowsException<ArgumentException>(() => DecodeEmptyPolylineCharArray());
		}

		/// <summary>
		/// The Decode_InvalidInput
		/// </summary>
		[TestMethod]
		public void Decode_InvalidInput() {
			// Arrange
			var invalidPolylineString = Defaults.Polyline.Invalid;

			// Act
			void DecodeInvalidPolylineCharArray() {
				this.Decode(Defaults.Polyline.Invalid);
			}

			// Assert
			Assert.ThrowsException<InvalidOperationException>(() => DecodeInvalidPolylineCharArray());
		}

		/// <summary>
		/// The Decode_ValidInput
		/// </summary>
		[TestMethod]
		public void Decode_ValidInput() {
			// Arrange
			var validPolylineString = Defaults.Polyline.Valid;

			// Act
			var result = this.Decode(validPolylineString);

			// Assert
			CollectionAssert.AreEquivalent(Defaults.Coordinate.Valid.ToList(), result.ToList());
		}

		/// <summary>
		/// The Encode_NullInput
		/// </summary>
		[TestMethod]
		public void Encode_NullInput() {
			// Arrange
			var nullCoordinates = (IEnumerable<(double, double)>)null;

			// Act
			void EncodeNullCoordinates() {
				this.Encode(nullCoordinates);
			}

			// Assert
			Assert.ThrowsException<ArgumentException>(() => EncodeNullCoordinates());
		}

		/// <summary>
		/// The Encode_EmptyInput
		/// </summary>
		[TestMethod]
		public void Encode_EmptyInput() {
			// Arrange
			var emptyCoordinates = Defaults.Coordinate.Empty;

			// Act
			void EncodeEmptyCoordinates() {
				this.Encode(emptyCoordinates);
			}

			// Assert
			Assert.ThrowsException<ArgumentException>(() => EncodeEmptyCoordinates());
		}

		/// <summary>
		/// The Encode_InvalidInput
		/// </summary>
		[TestMethod]
		public void Encode_InvalidInput() {
			// Arrange
			var invalidCoordinates = Defaults.Coordinate.Invalid;

			// Act
			void EncodeInvalidCoordinates() {
				this.Encode(invalidCoordinates);
			}

			// Assert
			Assert.ThrowsException<AggregateException>(() => EncodeInvalidCoordinates());
		}

		/// <summary>
		/// The Encode_ValidInput
		/// </summary>
		[TestMethod]
		public void Encode_ValidInput() {
			// Arrange
			var validCoordinates = Defaults.Coordinate.Valid;

			// Act
			var result = this.Encode(validCoordinates);

			// Assert
			Assert.AreEqual(Defaults.Polyline.Valid, result);
		}

		#region Overriden methods

		/// <summary>
		/// The CreateResult
		/// </summary>
		/// <param name="latitude">The <see cref="double"/></param>
		/// <param name="longitude">The <see cref="double"/></param>
		/// <returns>The <see cref="(double latitude, double longitude)"/></returns>
		protected override (double latitude, double longitude) CreateResult(double latitude, double longitude) {
			return (latitude, longitude);
		}

		/// <summary>
		/// The GetCoordinate
		/// </summary>
		/// <param name="source">The <see cref="(double latitude, double longitude)"/></param>
		/// <returns>The <see cref="(double Latitude, double Longitude)"/></returns>
		protected override (double Latitude, double Longitude) GetCoordinate((double latitude, double longitude) source) {
			return source;
		}

		#endregion

		#endregion
	}
}
