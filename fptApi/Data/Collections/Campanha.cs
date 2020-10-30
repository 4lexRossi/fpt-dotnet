using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fptApi.Data.Collections
{
    public class Campanha
    {
        public Campanha(
            string nome,
            string descricao,
            string id
            )
        {        
            this.Nome = nome;
            this.Descricao = descricao;
        } 
        public string id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}