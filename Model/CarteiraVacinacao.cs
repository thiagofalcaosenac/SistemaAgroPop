using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class CarteiraVacinacao
    {
        public int Id { get; set; }
        public DateOnly DataVacinacao { get; set; }
        public DateOnly ProximaDose { get; set; }
        public int NroDose { get; set; }
        public Animal Animal {get; set;}
        public Vacina Vacina {get; set;}
        public Fornecedor Fornecedor {get; set;}

        public CarteiraVacinacao(int id, DateOnly dataVacinacao, DateOnly proximaDose, int nroDose, Animal animal, Vacina vacina, Fornecedor fornecedor)
        {
            Id = id;
            DataVacinacao = dataVacinacao;
            ProximaDose = proximaDose;
            NroDose = nroDose;
            Animal = animal;
            Vacina = vacina;
            Fornecedor = fornecedor;
            
            Database db = new Database();
            db.CarteiraVacinacoes.Add(this);
            db.SaveChanges();
        }
        public CarteiraVacinacao()
        {
        }

        public static CarteiraVacinacao BuscarPorId(int id)
        {
            Database db = new Database();
            try
            {
                CarteiraVacinacao carteiraVacinacao = (from u in db.CarteiraVacinacoes
                                                       where u.Id == id
                                                       select u).First();
                return carteiraVacinacao;
            }
            catch
            {
                throw new System.Exception("Endereco não encontrado");
            }
        }

        public static CarteiraVacinacao Alterar(int id, DateOnly dataVacinacao, DateOnly proximaDose, int nroDose)
        {
            try
            {
                CarteiraVacinacao carteiraVacinacao = BuscarPorId(id);
                carteiraVacinacao.NroDose = nroDose;
                carteiraVacinacao.DataVacinacao = dataVacinacao;
                carteiraVacinacao.ProximaDose = proximaDose;

                Database db = new Database();
                db.CarteiraVacinacoes.Update(carteiraVacinacao);
                db.SaveChanges();

                return carteiraVacinacao;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void Excluir(int id)
        {
            try
            {
                CarteiraVacinacao carteiraVacinacao = BuscarPorId(id);
                Database db = new Database();
                db.CarteiraVacinacoes.Remove(carteiraVacinacao);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<CarteiraVacinacao> Listar()
        {
            Database db = new Database();
            List<CarteiraVacinacao> carteiraVacinacoes = (from u in db.CarteiraVacinacoes
                                                          select u).ToList();
            return carteiraVacinacoes;
        }

        public static CarteiraVacinacao BuscarPorAnimal(Animal animal)
        {
            try
            {
                Database db = new Database();
                CarteiraVacinacao carteiraVacinacao = (from u in db.CarteiraVacinacoes
                                                       where u.Animal == animal
                                                       select u).First();
                return carteiraVacinacao;
            }
            catch
            {
                throw new System.Exception("CarteiraVacinal não encontrado");
            }
        }

        public static CarteiraVacinacao BuscarPorVacina(Vacina vacina)
        {
            try
            {
                Database db = new Database();
                CarteiraVacinacao carteiraVacinacao = (from u in db.CarteiraVacinacoes
                                                       where u.Vacina == vacina
                                                       select u).First();
                return carteiraVacinacao;
            }
            catch
            {
                throw new System.Exception("CarteiraVacinal não encontrado");
            }
        }

        public override bool Equals(object? obj)
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
            CarteiraVacinacao carteiraVacinacao = (CarteiraVacinacao)obj;
            return this.Id == carteiraVacinacao.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
