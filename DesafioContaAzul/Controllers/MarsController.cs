using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DesafioContaAzul.Models;

namespace DesafioContaAzul.Controllers
{
    public class MarsController : ApiController
    {
        private readonly Mars _marsRepository;

        public MarsController()
        {
            _marsRepository = new Mars();
        }

        // GET api/mars
        public IEnumerable<Robot> Get()
        {
            return _marsRepository.GetAllRobots();
        }

        // GET api/mars/0
        public Robot Get(int id)
        {
           var item = _marsRepository.GetAllRobots().FirstOrDefault(x => x.Index.Equals(id));
            return item;
        }

        // POST api/mars
        public HttpResponseMessage Post([FromBody]Robot robot)
        {
            if (_marsRepository.AddRobot(robot))
                return Request.CreateResponse<Robot>(System.Net.HttpStatusCode.Created, robot);
            else
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
