//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests.Encoding {
	using System;
	using System.Linq;
	using Cloudikka.PolylineAlgorithm.Encoding;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="TuplePolylineEncodingTest" />
	/// </summary>
	[TestClass]
	public class TuplePolylineEncodingTest {
		#region Fields

		/// <summary>
		/// Defines the _encoding
		/// </summary>
		private TuplePolylineEncoding _encoding = new TuplePolylineEncoding();

		#endregion

		#region Methods

		/// <summary>
		/// The Encoding_Decode_EmptyInput
		/// </summary>
		[TestMethod]
		public void Encoding_Decode_EmptyInput() {
			Assert.ThrowsException<ArgumentException>(() => _encoding.Decode(Defaults.EmptyPolyline));
		}

		/// <summary>
		/// The Encoding_Decode_InvalidInput
		/// </summary>
		[TestMethod]
		public void Encoding_Decode_InvalidInput() {
			Assert.ThrowsException<InvalidOperationException>(() => _encoding.Decode(Defaults.InvalidPolyline));
		}

		/// <summary>
		/// The Encoding_Decode_NullInput
		/// </summary>
		[TestMethod]
		public void Encoding_Decode_NullInput() {
			Assert.ThrowsException<ArgumentException>(() => _encoding.Decode(null));
		}

		/// <summary>
		/// The Encoding_Decode_ValidInput
		/// </summary>
		[TestMethod]
		public void Encoding_Decode_ValidInput() {
			var result = _encoding.Decode(Defaults.ValidPolyline);

			CollectionAssert.AreEquivalent(Defaults.ValidCoordinates.ToList(), result.ToList());
		}

		/// <summary>
		/// The Encoding_Encode_EmptyInput
		/// </summary>
		[TestMethod]
		public void Encoding_Encode_EmptyInput() {
			Assert.ThrowsException<ArgumentException>(() => _encoding.Encode(Enumerable.Empty<(double, double)>()));
		}

		/// <summary>
		/// The Encoding_Encode_InvalidInput
		/// </summary>
		[TestMethod]
		public void Encoding_Encode_InvalidInput() {
			Assert.ThrowsException<InvalidOperationException>(() => _encoding.Encode(Defaults.InvalidCoordinates));
		}

		/// <summary>
		/// The Encoding_Encode_NullInput
		/// </summary>
		[TestMethod]
		public void Encoding_Encode_NullInput() {
			Assert.ThrowsException<ArgumentException>(() => _encoding.Encode(null));
		}

		/// <summary>
		/// The Encoding_Encode_ValidInput
		/// </summary>
		[TestMethod]
		public void Encoding_Encode_ValidInput() {
			var result = _encoding.Encode(Defaults.ValidCoordinates);

			Assert.AreEqual(Defaults.ValidPolyline, result);
		}

		#endregion
	}
}
