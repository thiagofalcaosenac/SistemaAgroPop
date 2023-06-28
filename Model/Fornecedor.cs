using Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class Fornecedor
    {
        public int id { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public Endereco endereco { get; set; }
        public int enderecoId { get; set; }

        public Fornecedor(string cnpj, string razaoSocial,string nomeFantasia, Endereco endereco)
        {
            this.cnpj = cnpj;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.enderecoId = endereco.id;

            Database db = new Database();
            db.Fornecedors.Add(this);
            db.SaveChanges();
        }

        public Fornecedor()
        {
        }

        public override string ToString()
        {
            return $"Id: {id}, cnpj: {cnpj}, razao Social: {razaoSocial}" + 
            $"nome Fantasia: {nomeFantasia},"+
            $"endereco: {endereco}";
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Fornecedor fornecedor = (Fornecedor)obj;
            return this.id == fornecedor.id;
        }

        public static Model.Fornecedor BuscarFornecedor(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Fornecedor fornecedor = (from u in db.Fornecedors
                                          where u.id == id
                                          select u).First();
                return fornecedor;
            }
            catch
            {
                throw new System.Exception("Fornecedor não encontrado");
            }
        }

        public static Fornecedor AlterarFornecedor(
            int id,
            string cnpj,
            string razaoSocial,
            string nomeFantasia,
            Endereco endereco
        )
        {
            try
            {
                Fornecedor fornecedor = BuscarFornecedor(id);
                fornecedor.cnpj = cnpj;
                fornecedor.razaoSocial = razaoSocial;
                fornecedor.nomeFantasia = nomeFantasia;
                fornecedor.endereco = endereco;

                Database db = new Database();
                db.Fornecedors.Update(fornecedor);
                db.SaveChanges();

                return fornecedor;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirFornecedor(
            int id
        )
        {
            try
            {
                Model.Fornecedor fornecedor = BuscarFornecedor(id);
                Database db = new Database();
                db.Fornecedors.Remove(fornecedor);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Fornecedor> ListarFornecedors()
        {
            Database db = new Database();
            List<Model.Fornecedor> fornecedor = (from u in db.Fornecedors
                                             select u).ToList();
            return fornecedor;
        }

        public static Model.Fornecedor BuscarPorcnpj(string cnpj)
        {
            try
            {
                Database db = new Database();
                Model.Fornecedor fornecedor = (from u in db.Fornecedors
                                          where u.cnpj == cnpj
                                          select u).First();
                return fornecedor;
            }
            catch
            {
                throw new System.Exception("Fornecedor não encontrado");
            }
        }
             public static Model.Fornecedor BuscarPorNomeFantasia(string nomeFantasia)
        {
            try
            {
                Database db = new Database();
                Model.Fornecedor fornecedor = (from u in db.Fornecedors
                                          where u.nomeFantasia == nomeFantasia
                                          select u).First();
                return fornecedor;
            }
            catch
            {
                throw new System.Exception("Fornecedor não encontrado");
            }
        }
    }

}