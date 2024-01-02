//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm.Implementation.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System;

    [MemoryDiagnoser]
    public class DecodePerformanceBenchmark
    {
        private Consumer _consumer = new Consumer();
        public static IEnumerable<(int, char[])> Polylines()
        {
            yield return (1, "mz}lHssngJj`gqSnx~lEcovfTnms{Zdy~qQj_deI".ToCharArray());
            yield return (2, "}vwdGjafcRsvjKi}pxUhsrtCngtcAjjgzEdqvtLrscbKj}nr@wetlUc`nq]}_kfCyrfaK~wluUl`u}|@wa{lUmmuap@va{lU~oihCu||bF`|era@wsnnIjny{DxamaScqxza@dklDf{}kb@mtpeCavfzGqhx`Wyzzkm@jm`d@dba~Pppkg@h}pxU|rtnHp|flA|~xaPuykyN}fhv[h}pxUx~p}Ymx`sZih~iB{edwB".ToCharArray());
            yield return (3, "}adrJh}}cVazlw@uykyNhaqeE`vfzG_~kY}~`eTsr{~Cwn~aOty_g@thapJvvoqKxt{sStfahDmtvmIfmiqBhjq|HujpgComs{Z}dhdKcidPymnvBqmquE~qrfI`x{lPf|ftGn~}d_@q}saAurjmu@bwr_DxrfaK~{rO~bidPwfduXwlioFlpum@twvfFpmi~VzxcsOqyejYhh|i@pbnr[twvfF_ueUujvbSa_d~ZkcnjZla~f[pmquEebxo[j}nr@xnn|H{gyiKbh{yH`oenn@y{mpIrbd~EmipgH}fuov@hjqtTp|flAttvkFrym_d@|eyCwn~aOfvdNmeawM??{yxdUcidPca{}D_atqGenzcAlra{@trgWhn{aZ??tluqOgu~sH".ToCharArray());
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Polylines))]
        public void Decode_V1((int, char[]) arg) => V1.Decode(arg.Item2).Consume(_consumer);

        [Benchmark]
        [ArgumentsSource(nameof(Polylines))]
        public void Decode_V2((int, char[]) arg) => V2.Decode(arg.Item2).Consume(_consumer);

        [Benchmark]
        [ArgumentsSource(nameof(Polylines))]
        public void Decode_V3((int, char[]) arg) => V3.Decode(arg.Item2).Consume(_consumer);

        private class V1
        {
            public static IEnumerable<(double Latitude, double Longitude)> Decode(char[] polyline)
            {
                if (polyline is null || polyline.Length == 0)
                {
                    throw new ArgumentException(nameof(polyline));
                }

                int index = 0;
                int latitude = 0;
                int longitude = 0;

                var result = new List<(double Latitude, double Longitude)>();

                while (index < polyline.Length)
                {
                    if (!TryCalculateNext(ref polyline, ref index, ref latitude))
                    {
                        throw new InvalidOperationException();
                    }

                    if (!TryCalculateNext(ref polyline, ref index, ref longitude))
                    {
                        throw new InvalidOperationException();
                    }

                    var coordinate = (GetDoubleRepresentation(latitude), GetDoubleRepresentation(longitude));

                    if (!CoordinateValidator.IsValid(coordinate))
                    {
                        throw new InvalidOperationException();
                    }

                    result.Add(coordinate);
                }

                return result;
            }

            private static bool TryCalculateNext(ref char[] polyline, ref int index, ref int value)
            {
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

            private static double GetDoubleRepresentation(int value)
            {
                return Convert.ToDouble(value) / Constants.Precision;
            }

            public static class CoordinateValidator
            {
                public static bool IsValid((double Latitude, double Longitude) coordinate)
                {
                    return IsValidLatitude(coordinate.Latitude) && IsValidLongitude(coordinate.Longitude);
                }

                public static bool IsValidLatitude(double latitude)
                {
                    return latitude >= Constants.Coordinate.MinLatitude && latitude <= Constants.Coordinate.MaxLatitude;
                }

                public static bool IsValidLongitude(double longitude)
                {
                    return longitude >= Constants.Coordinate.MinLongitude && longitude <= Constants.Coordinate.MaxLongitude;
                }
            }
        }

        private class V2
        {
            public static IEnumerable<(double Latitude, double Longitude)> Decode(char[] polyline)
            {
                if (polyline is null || polyline.Length == 0)
                {
                    throw new ArgumentException(nameof(polyline));
                }

                int offset = 0;
                int latitude = 0;
                int longitude = 0;

                while (offset < polyline.Length)
                {
                    if (!TryCalculateNext(ref polyline, ref offset, ref latitude))
                    {
                        throw new InvalidOperationException();
                    }

                    if (!TryCalculateNext(ref polyline, ref offset, ref longitude))
                    {
                        throw new InvalidOperationException();
                    }

                    var coordinate = (GetDoubleRepresentation(latitude), GetDoubleRepresentation(longitude));

                    if (!CoordinateValidator.IsValid(coordinate))
                    {
                        throw new InvalidOperationException();
                    }

                    yield return (latitude, longitude);
                }
            }

            private static bool TryCalculateNext(ref char[] polyline, ref int offset, ref int value)
            {
                int chunk;
                int sum = 0;
                int shifter = 0;

                do
                {
                    chunk = polyline[offset++] - Constants.ASCII.QuestionMark;
                    sum |= (chunk & Constants.ASCII.UnitSeparator) << shifter;
                    shifter += Constants.ShiftLength;
                } while (chunk >= Constants.ASCII.Space && offset < polyline.Length);

                if (offset >= polyline.Length && chunk >= Constants.ASCII.Space)
                    return false;

                value += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                return true;
            }

            private static double GetDoubleRepresentation(int value)
            {
                return value / Constants.Precision;
            }

            public static class CoordinateValidator
            {
                public static bool IsValid((double Latitude, double Longitude) coordinate)
                {
                    return IsValidLatitude(coordinate.Latitude) && IsValidLongitude(coordinate.Longitude);
                }

                public static bool IsValidLatitude(double latitude)
                {
                    return latitude >= Constants.Coordinate.MinLatitude && latitude <= Constants.Coordinate.MaxLatitude;
                }

                public static bool IsValidLongitude(double longitude)
                {
                    return longitude >= Constants.Coordinate.MinLongitude && longitude <= Constants.Coordinate.MaxLongitude;
                }
            }
        }

        private class V3
        {
            public static IEnumerable<(double Latitude, double Longitude)> Decode(char[] polyline)
            {
                // Checking null and at least one character
                if (polyline == null || polyline.Length == 0)
                {
                    throw new ArgumentException(nameof(polyline));
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
                        throw new InvalidOperationException();
                    }

                    // Attempting to calculate next longitude value. If failed exception is thrown
                    if (!TryCalculateNext(polyline, ref index, ref longitude))
                    {
                        throw new InvalidOperationException();
                    }

                    var coordinate = CreateResult(GetCoordinate(latitude), GetCoordinate(longitude));

                    if (!Validator.IsValid(coordinate))
                    {
                        throw new InvalidOperationException();
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

            protected static (double Latitude, double Longitude) CreateResult(double latitude, double longitude)
            {
                return (latitude, longitude);
            }

            public static class Validator
            {
                #region Methods

                /// <summary>
                /// Performs coordinate validation
                /// </summary>
                /// <param name="coordinate">Coordinate to validate</param>
                /// <returns>Returns validation result. If valid then true, otherwise false.</returns>
                public static bool IsValid((double Latitude, double Longitude) coordinate)
                {
                    return IsValidLatitude(ref coordinate.Latitude) && IsValidLongitude(ref coordinate.Longitude);
                }

                /// <summary>
                /// Performs latitude validation
                /// </summary>
                /// <param name="latitude">Latitude value to validate</param>
                /// <returns>Returns validation result. If valid then true, otherwise false.</returns>
                private static bool IsValidLatitude(ref readonly double latitude)
                {
                    return latitude >= Constants.Coordinate.MinLatitude && latitude <= Constants.Coordinate.MaxLatitude;
                }

                /// <summary>
                /// Performs longitude validation
                /// </summary>
                /// <param name="longitude">Longitude value to validate</param>
                /// <returns>Returns validation result. If valid then true, otherwise false.</returns>
                private static bool IsValidLongitude(ref readonly double longitude)
                {
                    return longitude >= Constants.Coordinate.MinLongitude && longitude <= Constants.Coordinate.MaxLongitude;
                }

                #endregion
            }
        }
    }
}
