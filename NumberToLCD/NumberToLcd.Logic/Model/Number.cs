using System;
using System.Collections.Generic;

namespace NumberToLcd.Logic.Model
{
    public class Number
    {
        private const string Space = " ";
        private const string Underscore = "_";
        private const string Pipe = "|";

        private readonly Dictionary<NumberPart, string> _map;
        public int Value { get; }

        public Number(int value)
        {
            if (value < 0 || value > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value should be between 0 and 9");
            }
            Value = value;
            _map = CreateMapOfNumber();
        }

        public string GetNumberSection(NumberSection section, int widthFactor = 1)
        {
            switch (section)
            {
                case NumberSection.Top:
                    return _map[NumberPart.TopLeft] + GetCenterPartWithWidthFactor(_map[NumberPart.TopCenter], widthFactor) + _map[NumberPart.TopRight];
                case NumberSection.ScaledMiddleUpper:
                    //Special: Like middle but always a space in the middle
                    return _map[NumberPart.MiddleLeft] + GetCenterPartWithWidthFactor(Space, widthFactor) + _map[NumberPart.MiddleRight];
                case NumberSection.Middle:
                    return _map[NumberPart.MiddleLeft] + GetCenterPartWithWidthFactor(_map[NumberPart.MiddleCenter], widthFactor) + _map[NumberPart.MiddleRight];
                case NumberSection.ScaledMiddleLower:
                    //Special: Like bottom but always a space in the middle
                    return _map[NumberPart.BottomLeft] + GetCenterPartWithWidthFactor(Space, widthFactor) + _map[NumberPart.BottomRight];
                case NumberSection.Bottom:
                    return _map[NumberPart.BottomLeft] + GetCenterPartWithWidthFactor(_map[NumberPart.BottomCenter], widthFactor) + _map[NumberPart.BottomRight];
                default:
                    throw new ArgumentOutOfRangeException(nameof(section), section, null);
            }
        }

        private string GetCenterPartWithWidthFactor(string @string, int widthFactor)
        {
            return String.Empty.PadLeft(widthFactor, Convert.ToChar(@string));
        }

        private Dictionary<NumberPart, string> CreateMapOfNumber()
        {
            switch (Value)
            {
                case 0:
                    //  _        ._.
                    // | |   =   |.|
                    // |_|       |_|
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Pipe, Space, Pipe,
                        Pipe, Underscore, Pipe
                    );
                case 1:
                    //           ...   
                    //   |   =   ..|
                    //   |       ..|
                    return CreateMapForValue(
                        Space, Space, Space,
                        Space, Space, Pipe,
                        Space, Space, Pipe
                    );
                case 2:
                    //  _        ._.
                    //  _|   =   ._|
                    // |_        |_.
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Space, Underscore, Pipe,
                        Pipe, Underscore, Space
                    );
                case 3:
                    //  _        ._.
                    //  _|   =   ._|
                    //  _|       ._| 
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Space, Underscore, Pipe,
                        Space, Underscore, Pipe
                    );
                case 4:
                    //           ...    
                    // |_|   =   |_|
                    //   |       ..| 
                    return CreateMapForValue(
                        Space, Space, Space,
                        Pipe, Underscore, Pipe,
                        Space, Space, Pipe
                    );
                case 5:
                    //  _        ._.
                    // |_    =   |_.
                    //  _|       ._| 
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Pipe, Underscore, Space,
                        Space, Underscore, Pipe
                    );
                case 6:
                    //  _        ._.
                    // |_    =   |_.
                    // |_|       |_|
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Pipe, Underscore, Space,
                        Pipe, Underscore, Pipe
                    );
                case 7:
                    //   _        ._.
                    //    |   =   ..|    
                    //    |       ..|
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Space, Space, Pipe,
                        Space, Space, Pipe
                    );
                case 8:
                    //  _        ._.
                    // |_|   =   |_|
                    // |_|       |_|
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Pipe, Underscore, Pipe,
                        Pipe, Underscore, Pipe
                    );
                default: //9
                    //  _        ._.
                    // |_|   =   |_|
                    //  _|       ._|
                    return CreateMapForValue(
                        Space, Underscore, Space,
                        Pipe, Underscore, Pipe,
                        Space, Underscore, Pipe
                    );
            }

            Dictionary<NumberPart, string> CreateMapForValue(
                string topLeft, string topCenter, string topRight,
                string middleLeft, string middleCenter, string middleRight,
                string bottomLeft, string bottomCenter, string bottomRight)
            {
                return new Dictionary<NumberPart, string>
                {
                    {NumberPart.TopLeft, topLeft}, {NumberPart.TopCenter, topCenter}, {NumberPart.TopRight, topRight},
                    {NumberPart.MiddleLeft, middleLeft}, {NumberPart.MiddleCenter, middleCenter}, {NumberPart.MiddleRight, middleRight},
                    {NumberPart.BottomLeft, bottomLeft}, {NumberPart.BottomCenter, bottomCenter}, {NumberPart.BottomRight, bottomRight},
                };
            }
        }
    }
}