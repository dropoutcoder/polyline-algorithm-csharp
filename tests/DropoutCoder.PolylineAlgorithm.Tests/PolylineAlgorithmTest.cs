//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm.Tests
{
    /// <summary>
    /// Defines the <see cref="PolylineAlgorithmTest" />
    /// </summary>
    [TestClass]
    [TestCategory(nameof(PolylineAlgorithm))]
    public class PolylineAlgorithmTest
    {
        internal static DefaultPolylineEncoder Encoder { get; private set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Encoder = new DefaultPolylineEncoder(new DefaultCoordinateValidator());
        }

        #region Methods

        /// <summary>
        /// Method is testing <see cref="PolylineAlgorithm.Decode(char[])" /> method. Empty <see langword="char"/>[] is passed as parameter.
        /// Expected result is <see cref="ArgumentException"/>.
        /// </summary>
        [TestMethod]
        public void Decode_EmptyInput_ThrowsException()
        {
            // Arrange
            var emptyPolylineCharArray = Defaults.Polyline.Empty.ToCharArray();

            // Act
            void DecodeEmptyPolylineCharArray()
            {
                Encoder.Decode(emptyPolylineCharArray).ToArray();
            }

            // Assert
            Assert.ThrowsException<ArgumentException>(() => DecodeEmptyPolylineCharArray());
        }

        /// <summary>
        /// Method is testing <see cref="PolylineAlgorithm.Decode(char[])" /> method. <see langword="char"/>[] with invalid coordinates is passed as parameter.
        /// Expected result is <see cref="ArgumentException"/>.
        /// </summary>
        [TestMethod]
        public void Decode_InvalidInput_ThrowsException()
        {
            // Arrange
            var invalidPolylineCharrArray = Defaults.Polyline.Invalid.ToCharArray();

            // Act
            void DecodeInvalidPolylineCharArray()
            {
                Encoder.Decode(invalidPolylineCharrArray).ToArray();
            }

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => DecodeInvalidPolylineCharArray());
        }

        /// <summary>
        /// Method is testing <see cref="PolylineAlgorithm.Decode(char[])" /> method. <see langword="null" /> is passed as parameter.
        /// Expected result is <see cref="ArgumentException"/>.
        /// </summary>
        [TestMethod]
        public void Decode_NullInput_ThrowsException()
        {
            // Arrange
            var nullPolylineCharArray = (char[])null;

            // Act
            void DecodeNullPolylineCharArray()
            {
                Encoder.Decode(nullPolylineCharArray).ToArray();
            }

            // Assert
            Assert.ThrowsException<ArgumentException>(() => DecodeNullPolylineCharArray());
        }

        /// <summary>
        /// Method is testing <see cref="PolylineAlgorithm.Decode(char[])" /> method. <see langword="char"/>[] with valid coordinates is passed as parameter.
        /// Expected result is <see cref="CollectionAssert.AreEquivalent(System.Collections.ICollection, System.Collections.ICollection)"/>.
        /// </summary>
        [TestMethod]
        public void Decode_ValidInput_AreEquivalent()
        {
            // Arrange
            var validPolylineCharArray = Defaults.Polyline.Valid.ToCharArray();

            // Act
            var result = Encoder.Decode(validPolylineCharArray);

            // Assert
            CollectionAssert.AreEquivalent(Defaults.Coordinate.Valid.ToList(), result.ToList());
        }

        /// <summary>
        /// Method is testing <see cref="PolylineAlgorithm.Decode(char[])" /> method. Empty is passed as parameter.
        /// Expected result is <see cref="ArgumentException"/>.
        /// </summary>
        [TestMethod]
        public void Encode_EmptyInput_ThrowsException()
        {
            // Arrange
            var emptyCoordinates = Defaults.Coordinate.Empty;

            // Act
            void EncodeEmptyCoordinates()
            {
                Encoder.Encode(emptyCoordinates);
            }

            // Assert
            Assert.ThrowsException<ArgumentException>(() => EncodeEmptyCoordinates());
        }

        /// <summary>
        /// The Encode_InvalidInput
        /// </summary>
        [TestMethod]
        public void Encode_InvalidInput_ThrowsException()
        {
            // Arrange
            var invalidCoordinates = Defaults.Coordinate.Invalid;

            // Act
            void EncodeInvalidCoordinates()
            {
                Encoder.Encode(invalidCoordinates);
            }

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => EncodeInvalidCoordinates());
        }

        /// <summary>
        /// Method is testing <see cref="PolylineAlgorithm.Encode(IEnumerable{(double Latitude, double Longitude)})" /> method. <see langword="null" /> is passed as parameter.
        /// Expected result is <see cref="ArgumentException"/>.
        /// </summary>
        [TestMethod]
        public void Encode_NullInput_ThrowsException()
        {
            // Arrange
            var nullCoordinates = (IEnumerable<(double, double)>)null;

            // Act
            void EncodeNullCoordinates()
            {
                Encoder.Encode(nullCoordinates);
            }

            // Assert
            Assert.ThrowsException<ArgumentException>(() => EncodeNullCoordinates());
        }

        /// <summary>
        /// The Encode_ValidInput
        /// </summary>
        [TestMethod]
        public void Encode_ValidInput_AreEqual()
        {
            // Arrange
            var validCoordinates = Defaults.Coordinate.Valid;

            // Act
            var result = Encoder.Encode(validCoordinates);

            // Assert
            Assert.AreEqual(Defaults.Polyline.Valid, result);
        }

        #endregion
    }
}
