using Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class Endereco
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }        
        public string cidade { get; set; }
        public string estado { get; set; }

        public Endereco(string telefone, string email, string bairro, string rua, string numero, 
                            string complemento, string cidade, string estado)
        {
            this.telefone = telefone;
            this.email = email;
            this.bairro = bairro;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.cidade = cidade;
            this.estado = estado;
            
            Database db = new Database();
            db.Enderecos.Add(this);
            db.SaveChanges();
        }        
    }
    
}