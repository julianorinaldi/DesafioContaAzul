using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioContaAzul.Models
{
    public class Robot
    {
        public Robot()
        {
            CoordX = 0;
            CoordY = 0;
            Orientation = "N";
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public string Orientation { get; set; }
        public string Command { get; set; }

        public void Rotate(string direction)
        {
            string directions = "WNES";
            if (!String.IsNullOrEmpty(direction))
            {
                int index = directions.IndexOf(this.Orientation);
                if (direction.ToUpper().Equals("R"))
                {
                    if (++index <= directions.Length - 1)
                        this.Orientation = directions[index].ToString();
                    else
                        this.Orientation = directions[0].ToString();
                }
                else if (direction.ToUpper().Equals("L"))
                {
                    if (--index >= 0)
                        this.Orientation = directions[index].ToString();
                    else
                        this.Orientation = directions[directions.Length - 1].ToString();
                }
            }
        }
    }
}
