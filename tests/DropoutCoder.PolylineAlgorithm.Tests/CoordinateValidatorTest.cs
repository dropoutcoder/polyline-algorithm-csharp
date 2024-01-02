//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm.Tests
{
    /// <summary>
    /// Defines the <see cref="CoordinateValidatorTest" />
    /// </summary>
    [TestClass]
    [TestCategory(nameof(DefaultCoordinateValidator))]
    public class CoordinateValidatorTest
    {
        internal static DefaultCoordinateValidator Validator { get; private set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Validator = new DefaultCoordinateValidator();
        }

        #region Methods

        /// <summary>
        /// The IsValid_InvalidInput
        /// </summary>
        [TestMethod]
        public void IsValid_InvalidInput_IsFalse()
        {
            // Act
            var invalidCoordinateCollection = Defaults.Coordinate.Invalid;

            foreach (var item in invalidCoordinateCollection)
            {
                // Arrange
                var result = Validator.IsValid(item);

                // Assert
                Assert.IsFalse(result);
            }
        }

        /// <summary>
        /// The IsValid_ValidInput
        /// </summary>
        [TestMethod]
        public void IsValid_ValidInput_IsTrue()
        {
            // Act
            var validCoordinateCollection = Defaults.Coordinate.Valid;

            foreach (var item in validCoordinateCollection)
            {
                // Arrange
                var result = Validator.IsValid(item);

                // Assert
                Assert.IsTrue(result);
            }
        }

        #endregion
    }
}
