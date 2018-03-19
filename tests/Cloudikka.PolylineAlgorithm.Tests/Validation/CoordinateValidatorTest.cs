//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace Cloudikka.PolylineAlgorithm.Tests.Validation {
	using Cloudikka.PolylineAlgorithm.Validation;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Defines the <see cref="CoordinateValidatorTest" />
	/// </summary>
	[TestClass]
	[TestCategory(nameof(CoordinateValidator))]
	public class CoordinateValidatorTest {
		#region Methods

		/// <summary>
		/// The IsValid_InvalidInput
		/// </summary>
		[TestMethod]
		public void IsValid_InvalidInput() {
			foreach (var item in Defaults.Coordinate.Invalid) {
				var result = CoordinateValidator.IsValid(item);

				Assert.IsFalse(result);
			}
		}

		/// <summary>
		/// The IsValid_ValidInput
		/// </summary>
		[TestMethod]
		public void IsValid_ValidInput() {
			foreach (var item in Defaults.Coordinate.Valid) {
				var result = CoordinateValidator.IsValid(item);

				Assert.IsTrue(result);
			}
		}

		/// <summary>
		/// The IsValidLatitude_InvalidInput
		/// </summary>
		[TestMethod]
		public void IsValidLatitude_InvalidInput() {
			foreach (var item in Defaults.Coordinate.Invalid) {
				var result = CoordinateValidator.IsValidLatitude(item.Latitude);

				Assert.IsFalse(result);
			}
		}

		/// <summary>
		/// The IsValidLatitude_ValidInput
		/// </summary>
		[TestMethod]
		public void IsValidLatitude_ValidInput() {
			foreach (var item in Defaults.Coordinate.Valid) {
				var result = CoordinateValidator.IsValidLatitude(item.Latitude);

				Assert.IsTrue(result);
			}
		}

		/// <summary>
		/// The IsValidLongitude_InvalidInput
		/// </summary>
		[TestMethod]
		public void IsValidLongitude_InvalidInput() {
			foreach (var item in Defaults.Coordinate.Invalid) {
				var result = CoordinateValidator.IsValidLongitude(item.Longitude);

				Assert.IsFalse(result);
			}
		}

		/// <summary>
		/// The IsValidLongitude_ValidInput
		/// </summary>
		[TestMethod]
		public void IsValidLongitude_ValidInput() {
			foreach (var item in Defaults.Coordinate.Valid) {
				var result = CoordinateValidator.IsValidLongitude(item.Longitude);

				Assert.IsTrue(result);
			}
		}

		#endregion
	}
}
