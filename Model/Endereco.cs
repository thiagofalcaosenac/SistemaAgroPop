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

        public Endereco()
        {
        }

        public override string ToString()
        {
            return $"Id: {id}, Telefone: {telefone}, Email: {email}, Bairro: {bairro}, Rua: {rua}, Número: {numero}, Complemento: {complemento}, Cidade: {cidade}, Estado: {estado}";
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }
            if (obj == this) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            Endereco endereco = (Endereco) obj;
            return this.id == endereco.id;
        }

        public static Model.Endereco BuscarEndereco(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Endereco endereco = (from u in db.Enderecos
                                     where u.id == id
                                     select u).First();
                return endereco;
            } catch
            {
                throw new System.Exception("Endereco não encontrado");
            }
        }

        public static Endereco AlterarEndereco(
            int id,
            string telefone, 
            string email, 
            string bairro, 
            string rua, 
            string numero, 
            string complemento, 
            string cidade, 
            string estado
        )
        {
            try
            {
                Endereco endereco = BuscarEndereco(id);
                endereco.telefone = telefone;
                endereco.email = email;
                endereco.bairro = bairro;
                endereco.rua = rua;
                endereco.numero = numero;
                endereco.complemento = complemento;
                endereco.cidade = cidade;
                endereco.estado = estado;

                Database db = new Database();
                db.Enderecos.Update(endereco);
                db.SaveChanges();

                return endereco;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirEndereco(
            int id
        )
        {
            try
            {
                Model.Endereco endereco = BuscarEndereco(id);
                Database db = new Database();
                db.Enderecos.Remove(endereco);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Endereco> ListarEnderecos() {
            Database db = new Database();
            List<Model.Endereco> enderecos = (from u in db.Enderecos
                                            select u).ToList();
            return enderecos;
        }

        public static Model.Endereco BuscarPorCidade(string cidade) {
            try {
                Database db = new Database();
                Model.Endereco endereco = (from u in db.Enderecos
                                            where u.cidade == cidade
                                            select u).First();
                return endereco;
            } catch {
                throw new System.Exception("Endereco não encontrado");
            }
        }

        public static Model.Endereco BuscarPorEstado(string estado) {
            try {
                Database db = new Database();
                Model.Endereco endereco = (from u in db.Enderecos
                                            where u.estado == estado
                                            select u).First();
                return endereco;
            } catch {
                throw new System.Exception("Endereco não encontrado");
            }
        }
    }
    
}