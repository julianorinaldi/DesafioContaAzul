using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace DesafioContaAzul.Models
{
    // Marte
    public class Mars : Plataform
    {
        private const string CacheKey = "MarsKey";

        public Mars()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var robots = new Robot[] { };

                    ctx.Cache[CacheKey] = robots;
                }
            }
        }

        public override string Name
        {
            get { return "Marte"; }
        }

        public override int Width
        {
            get { return 5; }
        }

        public override int Height
        {
            get { return 5; }
        }

        public Robot[] GetAllRobots()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Robot[])ctx.Cache[CacheKey];
            }

            return new Robot[] { };
        }

        public int CountRobots()
        {
            return GetAllRobots().Length;
        }

        public bool AddRobot(Robot robot)
        {
            if (!ValidateRobotPosition(robot))
                return false;

            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Robot[])ctx.Cache[CacheKey]).ToList();
                    robot.Index = currentData.Count;
                    currentData.Add(robot);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        public bool ValidateRobotPosition(Robot robot)
        {
            #region Validações
            if ((robot.CoordX > Width - 1) || (robot.CoordX < 0))
                return false;
            else if ((robot.CoordY > Height - 1) || (robot.CoordY < 0))
                return false;

            switch (robot.Orientation)
            {
                case "N":
                case "E":
                case "W":
                case "S":
                    break;
                default:
                    return false;
            }
            #endregion

            return true;
        }
    }
}
