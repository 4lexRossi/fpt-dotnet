namespace fptApi.Data.Collections
{
    public class Doador
    {
        public Doador(
            string nome,
            string sobreNome,            
            string email,
            string direct,
            string id
            
            )
        {
            this.Id = id;
            this.Nome = nome;
            this.SobreNome = sobreNome;             
            this.Email = email;                        
            this.Direct = direct;
        }      
        
        public string Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }               
        public string Email { get; set; }
        public string Direct { get; set; }
    }
    
}