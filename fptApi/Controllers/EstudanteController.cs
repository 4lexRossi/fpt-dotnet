using fptApi.Data.Enums;
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
    public class EstudanteController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Estudante> _estudantesCollection;

        public EstudanteController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _estudantesCollection = _mongoDB.DB.GetCollection<Estudante>(typeof(Estudante).Name.ToLower());
        }

        [HttpGet]
        public ActionResult ObterEstudantes()
        {
            var estudantes = _estudantesCollection.Find(Builders<Estudante>.Filter.Empty).ToList();

            return Ok(estudantes);
        }


        [HttpPost]
        public ActionResult SalvarEstudante([FromBody] EstudanteDto dto)
        {
            var estudante = new Estudante(
                dto.Id,
                dto.Nome,
                dto.Sobrenome,
                dto.DataNascimento,
                dto.Sexo,
                dto.Email,
                dto.Curso,
                dto.AreaCurso,
                dto.Semestre,
                dto.Descricao,
                dto.ValorMensal,
                dto.ETipoUsuario                
                );

            _estudantesCollection.InsertOne(estudante);
            
            return StatusCode(201, "Estudante adicionado com sucesso");
        }

       

        [HttpGet("{id}")]
        public ActionResult ObterEstudante(string id)
        {
            var estudante = _estudantesCollection.Find(Builders<Estudante>.Filter
            .Where(_ => _.Id == id)).FirstOrDefault();            

            return Ok(estudante);
        }

        [HttpPut]
        public ActionResult AtualizarEstudante([FromBody] EstudanteDto dto)
        {
            _estudantesCollection.UpdateOne(Builders<Estudante>.Filter
            .Where(_ => _.Id == dto.Id),
             Builders<Estudante>.Update.Set("nome", dto.Nome)                                                                              
                                       .Set("nomeResponsavel", dto.Sobrenome)  
                                       .Set("email", dto.Email)                                     
                                       .Set("curso", dto.Curso)
                                       .Set("areaCurso", dto.AreaCurso)
                                       .Set("semestre", dto.Semestre)
                                       .Set("descricao", dto.Descricao)
                                       .Set("valorMensal", dto.ValorMensal)                                       
                                       );

             return Ok("Cadastro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarEstudante(string id)
        {
            _estudantesCollection.DeleteOne(Builders<Estudante>.Filter
            .Where(_ => _.Id == id));            
            
             return Ok("Cadastro deletado com sucesso");
        }
       
    }
}