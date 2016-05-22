using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Entity
{
    public class GameColor
    {
        public string ColorCode { get; set; }

        public string ColorName { get; set; }

        public GameColor(string colorCode, string colorName)
        {
            ColorCode = colorCode;
            ColorName = colorName;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to GameColor return false.
            GameColor gc = obj as GameColor;
            if ((System.Object)gc == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ColorCode == gc.ColorCode);
        }

        public bool Equals(GameColor gc)
        {
            // If parameter is null return false:
            if ((object)gc == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ColorCode == gc.ColorCode);
        }

        public override int GetHashCode()
        {
            return ColorCode.Length;
        }
    }
}
