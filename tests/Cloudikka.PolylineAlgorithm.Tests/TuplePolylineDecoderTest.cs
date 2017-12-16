//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests {
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="TuplePolylineDecoderTest" />
	/// </summary>
	[TestClass]
	public class TuplePolylineDecoderTest {
		#region Fields

		/// <summary>
		/// Defines the _decoder
		/// </summary>
		private TuplePolylineDecoder _decoder = new TuplePolylineDecoder();

		#endregion

		#region Methods

		/// <summary>
		/// The Decoder_Decode_EmptyInput
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Decoder_Decode_EmptyInput() {
			Assert.ThrowsException<ArgumentException>(() => _decoder.Decode(Defaults.EmptyPolyline));
		}

		/// <summary>
		/// The Decoder_Decode_InvalidInput
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Decoder_Decode_InvalidInput() {
			var result = _decoder.Decode(Defaults.InvalidPolyline);

			Assert.AreEqual(Defaults.InvalidCoordinates, result);
		}

		/// <summary>
		/// The Decoder_Decode_NullInput
		/// </summary>
		[TestMethod]
		public void Decoder_Decode_NullInput() {
			Assert.ThrowsException<ArgumentException>(() => _decoder.Decode(Defaults.NullPolyline));
		}

		/// <summary>
		/// The Decoder_Decode_ValidInput
		/// </summary>
		[TestMethod]
		public void Decoder_Decode_ValidInput() {
			var result = _decoder.Decode(Defaults.ValidPolyline);

			Assert.AreEqual(Defaults.ValidPolyline, result);
		}

		#endregion
	}
}
