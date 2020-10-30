using fptApi.Data.Collections;
using System;
using System.Collections.Generic;

namespace fptApi.Models
{
    public class EstudanteDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Turma { get; set; }
        public IEnumerable<CampanhaDto> Campanhas { get; set; }
    }
    public class CampanhaDto
    {
        public string id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
    public class DoadorDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }        
        public string Email { get; set; }
        public string Senha { get; set; }        
    }
}