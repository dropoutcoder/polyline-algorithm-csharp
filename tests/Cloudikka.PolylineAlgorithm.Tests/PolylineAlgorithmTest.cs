//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="PolylineAlgorithmTest" />
	/// </summary>
	[TestClass]
	[TestCategory(nameof(PolylineAlgorithm))]
	public class PolylineAlgorithmTest {
		#region Methods

		/// <summary>
		/// The Decode_NullInput
		/// </summary>
		[TestMethod]
		public void Decode_NullInput() {
			// Arrange
			var nullPolylineCharArray = (char[])null;

			// Act
			void DecodeNullPolylineCharArray() {
				PolylineAlgorithm.Decode(nullPolylineCharArray);
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
			var emptyPolylineCharArray = Defaults.Polyline.Empty.ToCharArray();

			// Act
			void DecodeEmptyPolylineCharArray() {
				PolylineAlgorithm.Decode(emptyPolylineCharArray);
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
			var invalidPolylineCharrArray = Defaults.Polyline.Invalid.ToCharArray();

			// Act
			void DecodeInvalidPolylineCharArray() {
				PolylineAlgorithm.Decode(Defaults.Polyline.Invalid.ToCharArray());
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
			var validPolylineCharArray = Defaults.Polyline.Valid.ToCharArray();

			// Act
			var result = PolylineAlgorithm.Decode(validPolylineCharArray);

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
				PolylineAlgorithm.Encode(nullCoordinates);
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
				PolylineAlgorithm.Encode(emptyCoordinates);
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
				PolylineAlgorithm.Encode(invalidCoordinates);
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
			var result = PolylineAlgorithm.Encode(validCoordinates);

			// Assert
			Assert.AreEqual(Defaults.Polyline.Valid, result);
		}

		#endregion
	}
}
