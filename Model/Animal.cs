using Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class Animal
    {
        public int id { get; set; }
        public DateOnly dataNascimento { get; set; }
        public string nroRegistro { get; set; }
        public EnumOrigem origem { get; set; }
        public string cor { get; set; }
        public int peso { get; set; }
        public Raca raca { get; set; }
        public int racaid { get; set; }
        public Fazenda fazenda { get; set; }
        public int fazendaid { get; set; }

        public Animal(DateOnly dataNascimento, string nroRegistro, EnumOrigem origem, string cor, int peso, Raca raca, Fazenda fazenda)
        {
            try
            {
                this.dataNascimento = dataNascimento;
                this.nroRegistro = nroRegistro;
                this.origem = origem;
                this.cor = cor;
                this.peso = peso;
                this.racaid = raca.id;
                this.fazendaid = fazenda.id;

                Database db = new Database();
                db.Animals.Add(this);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public Animal()
        {
        }

        public override string ToString()
        {
            return $"Id: {id}, Data Nascimento: {dataNascimento}, numero Registro: {nroRegistro}," +
            $"origem: {origem}" +
            $"Data Nascimento: {dataNascimento}" +
            $"cor: {cor}" +
            $"peso: {peso}" +
            $"raca: {raca.id}" +
            $"fazenda: {fazenda.id}" +
            "";
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
            Animal fazenda = (Animal)obj;
            return this.id == fazenda.id;
        }

        public static Model.Animal BuscarAnimal(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Animal fazenda = (from u in db.Animals
                                        where u.id == id
                                        select u).First();
                return fazenda;
            }
            catch
            {
                throw new System.Exception("Animal não encontrado");
            }
        }

        public static Animal AlterarAnimal(
            int id,
            DateOnly dataNascimento,
            string nroRegistro,
            EnumOrigem origem,
            string cor,
            int peso,
            Raca raca,
            Fazenda fazenda
        )
        {
            try
            {
                Animal animal = BuscarAnimal(id);
                animal.dataNascimento = dataNascimento;
                animal.nroRegistro = nroRegistro;
                animal.origem = origem;
                animal.cor = cor;
                animal.peso = peso;
                animal.raca = raca;
                animal.fazenda = fazenda;

                Database db = new Database();
                db.Animals.Update(animal);
                db.SaveChanges();

                return animal;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirAnimal(
            int id
        )
        {
            try
            {
                Model.Animal animal = BuscarAnimal(id);
                Database db = new Database();
                db.Animals.Remove(animal);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Animal> ListarAnimals()
        {
            Database db = new Database();
            List<Model.Animal> animal = (from u in db.Animals
                                         select u).ToList();
            return animal;
        }

        public static Model.Animal BuscarPorId(int Id)
        {
            try
            {
                Database db = new Database();
                Model.Animal animal = (from u in db.Animals
                                       where u.id == Id
                                       select u).First();
                return animal;
            }
            catch
            {
                throw new System.Exception("Animal não encontrado");
            }
        }
        public static Model.Animal BuscarPornroRegistro(string nroRegistro)
        {
            try
            {
                Database db = new Database();
                Model.Animal animal = (from u in db.Animals
                                       where u.nroRegistro == nroRegistro
                                       select u).First();
                return animal;
            }
            catch
            {
                throw new System.Exception("Animal não encontrado");
            }
        }
        public static Model.Animal BuscarPorRaca(int raca)
        {
            try
            {
                Database db = new Database();
                Model.Animal animal = (from u in db.Animals
                                       where u.raca.id == raca
                                       select u).First();
                return animal;
            }
            catch
            {
                throw new System.Exception("Animal não encontrado");
            }
        }
        public static List<Model.Animal> BuscarPorFazenda(int parametroFazendaId)
        {
            try
            {
                Database db = new Database();
                List<Model.Animal> listAnimais = (from u in db.Animals
                                                  join fazenda in db.Fazendas on u.fazendaid equals fazenda.id
                                                  where u.fazenda.id == parametroFazendaId
                                                  select u).ToList();
                return listAnimais;
            }
            catch
            {
                throw new System.Exception("Animal não encontrado");
            }
        }
    }

}