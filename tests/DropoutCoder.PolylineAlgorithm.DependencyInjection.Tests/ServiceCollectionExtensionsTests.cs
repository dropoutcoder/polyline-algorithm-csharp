//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm.DependencyInjection.Tests
{
    using Microsoft.Extensions.DependencyInjection;

    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        internal static IServiceCollection Services { get; private set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Services = new ServiceCollection()
                .AddDefaultPolylineEncoder();
        }

        [TestMethod]
        public void AddDefaultCoordinateValidatorEncoderTest()
        {
            // Arrange
            var provider = Services
                .BuildServiceProvider();

            // Act
            var encoder = provider
                .GetRequiredService<ICoordinateValidator<(double, double)>>();

            // Assert
            Assert.IsInstanceOfType<ICoordinateValidator<(double, double)>>(encoder);
        }

        [TestMethod]
        public void AddDefaultPolylineEncoderTest()
        {
            // Arrange
            var provider = Services
                .BuildServiceProvider();

            // Act
            var encoder = provider
                .GetRequiredService<IPolylineEncoder<(double, double)>>();

            // Assert
            Assert.IsInstanceOfType<IPolylineEncoder<(double, double)>>(encoder);
        }
    }
}