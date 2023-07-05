using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class Vacina
    {
        public int Id { get; set; }
        public TipoVacina Tipo { get; set; }

        public int Periodicidade { get; set; }
        public int QtdMinima { get; set; }

        public int NroDosesDisponiveis
        {
            get
            {
                return BuscarNroDosesDisponiveis(this.Id);
            }
        }

        public Vacina(int id, TipoVacina tipo, int periodicidade, int qtdMinima)
        {
            Id = id;
            this.Tipo = tipo;
            Periodicidade = periodicidade;
            QtdMinima = qtdMinima;

            Database db = new Database();
            db.Vacinas.Add(this);
            db.SaveChanges();
        }
        public Vacina()
        {
        }
        public static Vacina BuscarVacinaPorId(int id)
        {
            Database db = new Database();
            try
            {
                Vacina vacina = (from u in db.Vacinas
                                 where u.Id == id
                                 select u).First();
                return vacina;
            }
            catch
            {
                throw new System.Exception("Vacina não encontrado");
            }
        }

        public static Vacina AlterarVacina(int id, TipoVacina tipo, int periodicidade, int qtdMinima)
        {
            try
            {
                Vacina vacina = BuscarVacinaPorId(id);
                vacina.Tipo = tipo;
                vacina.Periodicidade = periodicidade;
                vacina.QtdMinima = qtdMinima;

                Database db = new Database();
                db.Vacinas.Update(vacina);
                db.SaveChanges();

                return vacina;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirVacina(int id)
        {
            try
            {
                Vacina vacina = BuscarVacinaPorId(id);
                Database db = new Database();
                db.Vacinas.Remove(vacina);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Vacina> ListarVacina()
        {
            Database db = new Database();
            List<Vacina> vacinas = (from u in db.Vacinas
                                    select u).ToList();
            return vacinas;
        }

        public static List<Vacina> BuscarVacinasPorTipo(TipoVacina tipo)
        {
            Database db = new Database();
            List<Vacina> vacinas = (from u in db.Vacinas
                                    where u.Tipo == tipo
                                    select u).ToList();
            return vacinas;
        }

        public static int BuscarNroDosesDisponiveis(int vacinaId)
        {
            Database db = new Database();

            List<VacinaFornecida> vacinaFornecida = (from vFornecidas in db.VacinaFornecidas
                                                     join vacina in db.Vacinas on vFornecidas.vacinaId equals vacina.Id
                                                     where vFornecidas.Vacina.Id == vacinaId
                                                     select vFornecidas).ToList();

            int nroDosesDisponiveis = vacinaFornecida.Select(item => item.Quantidade).Sum();

            return nroDosesDisponiveis;
        }

        public enum TipoVacina
        {
            FEBRE_AFTOSA, BRUCELOSE, RAIVA
        }

        public override string ToString()
        {
            return $"Id:{Id}, Tipo:{Tipo}, Periodicidade:{Periodicidade}, QtdMinima:{QtdMinima}";
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

            Vacina vacina = (Vacina)obj;
            return this.Id == vacina.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
