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
    public class CampanhaController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Campanha> _campanhasCollection;

        public CampanhaController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _campanhasCollection = _mongoDB.DB.GetCollection<Campanha>(typeof(Campanha).Name.ToLower());
        }

        [HttpGet]
        public ActionResult ObterCampanhas()
        {
            var campanhas = _campanhasCollection.Find(Builders<Campanha>.Filter.Empty).ToList();

            return Ok(campanhas);
        }


        [HttpPost]
        public ActionResult SalvarCampanha([FromBody] CampanhaDto dto)
        {
            var campanha = new Campanha(
                dto.Nome,
                dto.Descricao,
                dto.id);

            _campanhasCollection.InsertOne(campanha);
            
            return StatusCode(201, "Campanha criada com sucesso");
        }

       

        [HttpGet("{id}")]
        public ActionResult ObterEstudante(string id)
        {
            var estudante = _campanhasCollection.Find(Builders<Campanha>.Filter
            .Where(_ => _.id == id)).FirstOrDefault();            

            return Ok(estudante);
        }

        [HttpPut]
        public ActionResult AtualizarCampanha([FromBody] CampanhaDto dto)
        {
            _campanhasCollection.UpdateOne(Builders<Campanha>.Filter
            .Where(_ => _.id == dto.id),
             Builders<Campanha>.Update.Set("nome", dto.Nome)
                                       .Set("descricao", dto.Descricao)
                                        );
            
             return Ok("Campanha atualizada com sucesso");
        }

       [HttpDelete("{id}")]
        public ActionResult DeletarCampanha(string id)
        {
            _campanhasCollection.DeleteOne(Builders<Campanha>.Filter
            .Where(_ => _.id == id));            
            
             return Ok("Campanha deletada com sucesso");
        }
    }
}