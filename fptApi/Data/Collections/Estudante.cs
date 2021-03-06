using fptApi.Data.Enums;
using System;


namespace fptApi.Data.Collections
{
    public class Estudante
    {
        public Estudante(
            string id,
            string nome,
            string sobrenome,
            DateTime dataNascimento,
            string sexo,
            string email,
            string curso,
            string areaCurso,
            int semestre,
            string descricao,
            int valorMensal,
            ETipoUsuario tipoUsuario
            )
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;           
            this.Email = email;          
            this.Curso = curso;
            this.AreaCurso = areaCurso;
            this.Semestre = semestre;
            this.Descricao = descricao;
            this.ValorMensal = valorMensal;
            this.TipoUsuario = tipoUsuario;
        }

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
        public ETipoUsuario TipoUsuario { get; set; }
    
    }   
}