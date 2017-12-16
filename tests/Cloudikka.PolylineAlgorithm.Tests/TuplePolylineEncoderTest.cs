//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests {
	using System;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="TuplePolylineEncoderTest" />
	/// </summary>
	[TestClass]
	public class TuplePolylineEncoderTest {
		#region Fields

		/// <summary>
		/// Defines the _encoder
		/// </summary>
		private TuplePolylineEncoder _encoder = new TuplePolylineEncoder();

		#endregion

		#region Methods

		/// <summary>
		/// The Encoder_Encode_EmptyInput
		/// </summary>
		[TestMethod]
		public void Encoder_Encode_EmptyInput() {
			Assert.ThrowsException<ArgumentException>(() => _encoder.Encode(Enumerable.Empty<(double, double)>()));
		}

		/// <summary>
		/// The Encoder_Encode_InvalidInput
		/// </summary>
		[TestMethod]
		public void Encoder_Encode_InvalidInput() {
			Assert.ThrowsException<InvalidOperationException>(() => _encoder.Encode(Defaults.InvalidCoordinates));
		}

		/// <summary>
		/// The Encoder_Encode_NullInput
		/// </summary>
		[TestMethod]
		public void Encoder_Encode_NullInput() {
			Assert.ThrowsException<ArgumentException>(() => _encoder.Encode(null));
		}

		/// <summary>
		/// The Encoder_Encode_ValidInput
		/// </summary>
		[TestMethod]
		public void Encoder_Encode_ValidInput() {
			var result = _encoder.Encode(Defaults.ValidCoordinates);

			Assert.AreEqual(Defaults.ValidPolyline, result);
		}

		#endregion
	}
}
