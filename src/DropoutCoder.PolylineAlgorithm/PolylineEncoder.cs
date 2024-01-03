//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm
{
    using DropoutCoder.PolylineAlgorithm.Internal;
    using Microsoft.Extensions.ObjectPool;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public sealed class PolylineEncoder : IPolylineEncoder
    {
        private readonly CoordinateValidator _validator = new CoordinateValidator();
        private readonly ObjectPool<StringBuilder> _pool = new DefaultObjectPoolProvider().CreateStringBuilderPool(5, 250);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<(double Latitude, double Longitude)> Decode(char[] polyline)
        {
            // Checking null and at least one character
            if (polyline == null || polyline.Length == 0)
            {
                throw new ArgumentException(ExceptionMessageResource.ArgumentCannotBeNullOrEmpty, nameof(polyline));
            }

            // Initialize local variables
            int index = 0;
            int latitude = 0;
            int longitude = 0;

            // Looping through encoded polyline char array
            while (index < polyline.Length)
            {
                // Attempting to calculate next latitude value. If failed exception is thrown
                if (!TryCalculateNext(polyline, ref index, ref latitude))
                {
                    throw new InvalidOperationException(ExceptionMessageResource.PolylineCharArrayIsMalformed);
                }

                // Attempting to calculate next longitude value. If failed exception is thrown
                if (!TryCalculateNext(polyline, ref index, ref longitude))
                {
                    throw new InvalidOperationException(ExceptionMessageResource.PolylineCharArrayIsMalformed);
                }

                var coordinate = (GetCoordinate(latitude), GetCoordinate(longitude));

                if (!_validator.IsValid(coordinate))
                {
                    throw new InvalidOperationException(ExceptionMessageResource.PolylineCharArrayIsMalformed);
                }

                yield return coordinate;

                #region Local functions

                bool TryCalculateNext(char[] polyline, ref int index, ref int value)
                {
                    // Local variable initialization
                    int chunk;
                    int sum = 0;
                    int shifter = 0;

                    do
                    {
                        chunk = polyline[index++] - Constants.ASCII.QuestionMark;
                        sum |= (chunk & Constants.ASCII.UnitSeparator) << shifter;
                        shifter += Constants.ShiftLength;
                    } while (chunk >= Constants.ASCII.Space && index < polyline.Length);

                    if (index >= polyline.Length && chunk >= Constants.ASCII.Space)
                        return false;

                    value += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                    return true;
                }

                double GetCoordinate(int value)
                {
                    return Convert.ToDouble(value) / Constants.Precision;
                }

                #endregion
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(IEnumerable<(double Latitude, double Longitude)> coordinates)
        {
            if (coordinates == null || !coordinates.GetEnumerator().MoveNext())
            {
                throw new ArgumentException(ExceptionMessageResource.ArgumentCannotBeNullOrEmpty, nameof(coordinates));
            }

            // Validate collection of coordinates
            if (!TryValidate(coordinates, out var exceptions))
            {
                throw new AggregateException(exceptions);
            }

            // Initializing local variables
            int previousLatitude = 0;
            int previousLongitude = 0;
            var sb = _pool.Get();

            // Looping over coordinates and building encoded result
            foreach (var coordinate in coordinates)
            {
                int latitude = Round(coordinate.Latitude);
                int longitude = Round(coordinate.Longitude);

                sb.Append(GetSequence(latitude - previousLatitude).ToArray());
                sb.Append(GetSequence(longitude - previousLongitude).ToArray());

                previousLatitude = latitude;
                previousLongitude = longitude;
            }

            var result = sb.ToString();

            _pool.Return(sb);

            return result;

            #region Local functions
            bool TryValidate(IEnumerable<(double Latitude, double Longitude)> collection, out ICollection<CoordinateValidationException> exceptions)
            {
                exceptions = new List<CoordinateValidationException>(collection.Count());

                foreach (var item in collection)
                {
                    if (!_validator.IsValid(item))
                    {
                        exceptions.Add(new CoordinateValidationException(item.Latitude, item.Longitude));
                    }
                }

                return !exceptions.GetEnumerator().MoveNext();
            }

            int Round(double value)
            {
                return (int)Math.Round(value * Constants.Precision);
            }

            IEnumerable<char> GetSequence(int value)
            {
                int shifted = value << 1;
                if (value < 0)
                    shifted = ~shifted;

                int rem = shifted;

                while (rem >= Constants.ASCII.Space)
                {
                    yield return (char)((Constants.ASCII.Space | rem & Constants.ASCII.UnitSeparator) + Constants.ASCII.QuestionMark);

                    rem >>= Constants.ShiftLength;
                }

                yield return (char)(rem + Constants.ASCII.QuestionMark);
            }
        }
        #endregion
    }
}
