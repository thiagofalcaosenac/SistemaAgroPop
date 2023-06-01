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

        public Endereco(string telefone, string email)
        {
            this.telefone = telefone;
            this.email = email;
            Database db = new Database();
            db.Enderecos.Add(this);
            db.SaveChanges();
        }        
    }
    
}