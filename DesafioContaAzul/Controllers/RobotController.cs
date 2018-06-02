using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DesafioContaAzul.Models;

namespace DesafioContaAzul.Controllers
{
    public class RobotController : ApiController
    {
        // GET api/robot/M
        public HttpResponseMessage Get(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

            Mars mars = new Mars();
            Robot robot = new Robot()
            {
                Name = "Robot " + mars.CountRobots(),
                CoordX = 0,
                CoordY = 0,
                Index = mars.CountRobots(),
                Orientation = "N",
                Command = id.ToUpper()
            };

            char[] commandValids = new[] { 'M', 'R', 'L'};
            foreach (char command in id.ToUpper())
            {
                if (!commandValids.Contains(command))
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

                switch (command)
                {
                    case 'M':
                        switch (robot.Orientation)
                        {
                            case "N":
                                robot.CoordY++;
                                break;
                            case "E":
                                robot.CoordX++;
                                break;
                            case "W":
                                robot.CoordX--;
                                break;
                            case "S":
                                robot.CoordY--;
                                break;
                        }
                        break;
                    case 'L':
                    case 'R':
                        robot.Rotate(command.ToString());
                        break;
                }

                if (!mars.ValidateRobotPosition(robot))
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }

            mars.AddRobot(robot);
            return Request.CreateResponse<Robot>(System.Net.HttpStatusCode.Created, robot);
        }
    }
}
