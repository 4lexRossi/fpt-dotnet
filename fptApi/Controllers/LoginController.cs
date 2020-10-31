using fptApi.Data;
using fptApi.Data.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace fptApi.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Doador> _doadoresCollection;

        public LoginController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _doadoresCollection = _mongoDB.DB.GetCollection<Doador>(typeof(Doador).Name.ToLower());
        }

        [HttpPost]
        public ActionResult Autenticar([FromBody] Login login)
        {
            var doador = _doadoresCollection.Find(Builders<Doador>.Filter
            .Where(_ => _.Email == login.email && _.Direct == login.direct)).FirstOrDefault();

            return Ok(doador);
        }
    }
}