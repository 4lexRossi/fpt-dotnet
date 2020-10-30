using fptApi.Data.Collections;
using fptApi.Models;
using System;
using System.Collections.Generic;

namespace fptApi.Data.Collections
{
    public class Doador
    {
        public Doador(
            string nome,
            string sobreNome,            
            string email,
            string senha,
            string id
            
            )
        {
            this.Id = id;
            this.Nome = nome;
            this.SobreNome = sobreNome;             
            this.Email = email;                        
            this.Senha = senha;
        }      
        
        public string Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }               
        public string Email { get; set; }
        public string Senha { get; set; }
    }
    
}