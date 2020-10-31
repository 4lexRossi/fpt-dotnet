using fptApi.Data.Collections;
using fptApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace fptApi.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class DoadorController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Doador> _doadoresCollection;

        public DoadorController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _doadoresCollection = _mongoDB.DB.GetCollection<Doador>(typeof(Doador).Name.ToLower());
        }

        [HttpGet]
        public ActionResult ObterDoadores()
        {
            var doador = _doadoresCollection.Find(Builders<Doador>.Filter.Empty).ToList();

            return Ok(doador);
        }


        [HttpPost]
        public ActionResult RegistrarDoador([FromBody] DoadorDto dto)
        {
            var doador = new Doador(
                dto.Nome,
                dto.SobreNome,                
                dto.Email,               
                dto.Direct,
                dto.Id
                );

            _doadoresCollection.InsertOne(doador);
            
            return StatusCode(201, "Cadastro adicionado com sucesso");
        }



        [HttpGet("{id}")]
        public ActionResult ObterDoador(string id)
        {
            var doador = _doadoresCollection.Find(Builders<Doador>.Filter
            .Where(_ => _.Id == id)).FirstOrDefault();

            return Ok(doador);
        }

        [HttpPut]
        public ActionResult AtualizarDoador([FromBody] DoadorDto dto)
        {
            _doadoresCollection.UpdateOne(Builders<Doador>.Filter
            .Where(_ => _.Id == dto.Id),
             Builders<Doador>.Update.Set("nome", dto.Nome)
                                       .Set("SobreNome", dto.SobreNome)
                                       .Set("email", dto.Email)                                       
                                       .Set("senha", dto.Direct));
            
             return Ok("Cadastro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarDoador(string id)
        {
            _doadoresCollection.DeleteOne(Builders<Doador>.Filter
            .Where(_ => _.Id == id));            
            
             return Ok("Cadastro deletado com sucesso");
        }
        
      
    }
}