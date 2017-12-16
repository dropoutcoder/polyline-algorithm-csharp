//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests {
	using System;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="PolylineAlgorithmTest" />
	/// </summary>
	[TestClass]
	public class PolylineAlgorithmTest {
		#region Methods

		/// <summary>
		/// The Decode_EmptyInput
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Decode_EmptyInput() {
			Assert.ThrowsException<ArgumentException>(() => PolylineAlgorithm.Decode(String.Empty.ToCharArray()));
		}

		/// <summary>
		/// The Decode_InvalidInput
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Decode_InvalidInput() {
			var result = PolylineAlgorithm.Decode(Defaults.InvalidPolyline.ToCharArray());

			Assert.AreEqual(Defaults.InvalidCoordinates, result);
		}

		/// <summary>
		/// The Decode_NullInput
		/// </summary>
		[TestMethod]
		public void Decode_NullInput() {
			Assert.ThrowsException<ArgumentException>(() => PolylineAlgorithm.Decode(null));
		}

		/// <summary>
		/// The Decode_ValidInput
		/// </summary>
		[TestMethod]
		public void Decode_ValidInput() {
			var result = PolylineAlgorithm.Decode(Defaults.ValidPolyline.ToCharArray());

			CollectionAssert.AreEquivalent(Defaults.ValidCoordinates.ToList(), result.ToList());
		}

		/// <summary>
		/// The Encode_EmptyInput
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Encode_EmptyInput() {
			Assert.ThrowsException<ArgumentException>(() => PolylineAlgorithm.Encode(Defaults.EmptyCoordinates));
		}

		/// <summary>
		/// The Encode_InvalidInput
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Encode_InvalidInput() {
			var result = PolylineAlgorithm.Encode(Defaults.InvalidCoordinates);

			Assert.AreEqual(Defaults.InvalidPolyline, result);
		}

		/// <summary>
		/// The Encode_NullInput
		/// </summary>
		[TestMethod]
		public void Encode_NullInput() {
			Assert.ThrowsException<ArgumentException>(() => PolylineAlgorithm.Encode(Defaults.NullCoordinates));
		}

		/// <summary>
		/// The Encode_ValidInput
		/// </summary>
		[TestMethod]
		public void Encode_ValidInput() {
			var result = PolylineAlgorithm.Encode(Defaults.ValidCoordinates);

			Assert.AreEqual(Defaults.ValidPolyline, result);
		}

		#endregion
	}
}
