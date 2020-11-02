using fptApi.Data.Enums;
using System;

namespace fptApi.Models
{
    public class EstudanteDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public string AreaCurso { get; set; }
        public int Semestre { get; set; }
        public string Descricao { get; set; }
        public int ValorMensal { get; set; }
        public ETipoUsuario ETipoUsuario { get; set; }
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
        public string Direct { get; set; }        
    }
}