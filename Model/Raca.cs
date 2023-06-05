using Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class Raca
    {
        public int id { get; set; }
        public string especie { get; set; }
        public string nome { get; set; }
        public string porte { get; set; }

        public Endereco endereco { get; set; }

        public Raca(string nome, string especie, string porte)
        {
            this.nome = nome;
            this.especie = especie;
            this.porte = porte;

            Database db = new Database();
            db.Racas.Add(this);
            db.SaveChanges();
        }

        public Raca()
        {
        }

        public override string ToString()
        {
            return $"Id: {id}, Nome: {nome}, especie: {especie}";
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
            Raca raca = (Raca)obj;
            return this.id == raca.id;
        }

        public static Model.Raca BuscarRaca(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Raca raca = (from u in db.Racas
                                          where u.id == id
                                          select u).First();
                return raca;
            }
            catch
            {
                throw new System.Exception("Raca não encontrada");
            }
        }

        public static Raca AlterarRaca(
            int id,
            string nome,
            string especie,
            string porte
        )
        {
            try
            {
                Raca raca = BuscarRaca(id);
                raca.nome = nome;
                raca.especie = especie;
                raca.porte = porte;

                Database db = new Database();
                db.Racas.Update(raca);
                db.SaveChanges();

                return raca;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirRaca(
            int id
        )
        {
            try
            {
                Model.Raca raca = BuscarRaca(id);
                Database db = new Database();
                db.Racas.Remove(raca);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Raca> ListarRacas()
        {
            Database db = new Database();
            List<Model.Raca> racas = (from u in db.Racas
                                             select u).ToList();
            return racas;
        }

        public static Model.Raca BuscarPorNome(string nome)
        {
            try
            {
                Database db = new Database();
                Model.Raca raca = (from u in db.Racas
                                          where u.nome == nome
                                          select u).First();
                return raca;
            }
            catch
            {
                throw new System.Exception("Raca não encontrada");
            }
        }
    }

}