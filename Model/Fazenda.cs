using Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class Fazenda
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int qtdLimiteAnimal { get; set; }

        //A fórmula desse campo qtdAtualAnimal irá ser feita após o Model Animal ser criado
        //public virtual int qtdAtualAnimal { get; set; }
        public Endereco endereco { get; set; }

        public Fazenda(string nome, int qtdLimiteAnimal, Endereco endereco)
        {
            this.nome = nome;
            this.qtdLimiteAnimal = qtdLimiteAnimal;
            this.endereco = endereco;

            Database db = new Database();
            db.Fazendas.Add(this);
            db.SaveChanges();
        }

        public Fazenda()
        {
        }

        public override string ToString()
        {
            return $"Id: {id}, Nome: {nome}, Quantidade Limite Animal: {qtdLimiteAnimal}";
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
            Fazenda fazenda = (Fazenda)obj;
            return this.id == fazenda.id;
        }

        public static Model.Fazenda BuscarFazenda(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Fazenda fazenda = (from u in db.Fazendas
                                          where u.id == id
                                          select u).First();
                return fazenda;
            }
            catch
            {
                throw new System.Exception("Fazenda não encontrado");
            }
        }

        public static Fazenda AlterarFazenda(
            int id,
            string nome,
            int qtdLimiteAnimal,
            Endereco endereco
        )
        {
            try
            {
                Fazenda fazenda = BuscarFazenda(id);
                fazenda.nome = nome;
                fazenda.qtdLimiteAnimal = qtdLimiteAnimal;
                fazenda.endereco = endereco;

                Database db = new Database();
                db.Fazendas.Update(fazenda);
                db.SaveChanges();

                return fazenda;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirFazenda(
            int id
        )
        {
            try
            {
                Model.Fazenda fazenda = BuscarFazenda(id);
                Database db = new Database();
                db.Fazendas.Remove(fazenda);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Fazenda> ListarFazendas()
        {
            Database db = new Database();
            List<Model.Fazenda> fazendas = (from u in db.Fazendas
                                             select u).ToList();
            return fazendas;
        }

        public static Model.Fazenda BuscarPorNome(string nome)
        {
            try
            {
                Database db = new Database();
                Model.Fazenda fazenda = (from u in db.Fazendas
                                          where u.nome == nome
                                          select u).First();
                return fazenda;
            }
            catch
            {
                throw new System.Exception("Fazenda não encontrado");
            }
        }
    }

}