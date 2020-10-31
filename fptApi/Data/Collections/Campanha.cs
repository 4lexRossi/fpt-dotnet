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