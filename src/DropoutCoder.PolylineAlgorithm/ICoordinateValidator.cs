//  
// Copyright (c) Petr Šrámek. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

namespace DropoutCoder.PolylineAlgorithm
{
    public interface ICoordinateValidator<T>
    {
        bool IsValid(T coordinate);
    }
}
