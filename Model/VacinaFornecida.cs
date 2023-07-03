
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Model
{
    public class VacinaFornecida
    {
        public int Id { get; set; }
        public DateOnly DataFabricacao { get; set; }
        public DateOnly DataValidade { get; set; }
        public DateOnly DataCompra { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }
        public float ValorTotal { get; set; } //qtd * preco
        public Fornecedor Fornecedor { get; set; }
        public Vacina Vacina { get; set; }

        public VacinaFornecida(int id, DateOnly dataFabricacao, DateOnly dataValidade, DateOnly dataCompra,
        int quantidade,
        float preco,
        float valorTotal,
        Fornecedor fornecedor,
        Vacina vacina)
        {
            Id = id;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            DataCompra = dataCompra;
            Quantidade = quantidade;
            Preco = preco;
            ValorTotal = valorTotal;
            Fornecedor = fornecedor;
            Vacina = vacina;

            Database db = new Database();
            db.VacinaFornecidas.Add(this);
            db.SaveChanges();
        }

        public VacinaFornecida()
        {
        }


        public static VacinaFornecida BuscarPorId(int id)
        {
            Database db = new Database();
            try
            {
                VacinaFornecida vacina = (from u in db.VacinaFornecidas
                                          where u.Id == id
                                          select u).First();
                return vacina;
            }
            catch
            {
                throw new System.Exception("Vacina não encontrado");
            }
        }

        public static VacinaFornecida Alterar(int id, DateOnly dataFabricacao, DateOnly dataValidade, DateOnly dataCompra,
        int quantidade,
        float preco,
        float valorTotal)
        {
            try
            {
                VacinaFornecida vacina = BuscarPorId(id);
                vacina.DataFabricacao = dataFabricacao;
                vacina.DataValidade = dataValidade;
                vacina.DataCompra = dataCompra;
                vacina.Quantidade = quantidade;
                vacina.Preco = preco;
                vacina.ValorTotal = valorTotal;

                Database db = new Database();
                db.VacinaFornecidas.Update(vacina);
                db.SaveChanges();

                return vacina;
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
                VacinaFornecida vacina = BuscarPorId(id);
                Database db = new Database();
                db.VacinaFornecidas.Remove(vacina);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<VacinaFornecida> Listar()
        {
            Database db = new Database();
            List<VacinaFornecida> vacinas = (from u in db.VacinaFornecidas
                                             select u).ToList();
            return vacinas;
        }



        public static VacinaFornecida BuscarPorFornecedor(Fornecedor fornecedor)
        {
            try
            {
                Database db = new Database();
                VacinaFornecida vacina = (from u in db.VacinaFornecidas
                                          where u.Fornecedor == fornecedor
                                          select u).First();
                return vacina;
            }
            catch
            {
                throw new System.Exception("CarteiraVacinal não encontrado");
            }
        }

        public static VacinaFornecida BuscarPorVacina(Vacina vacina)
        {
            try
            {
                Database db = new Database();
                VacinaFornecida vacinaFornecida = (from u in db.VacinaFornecidas
                                                   where u.Vacina == vacina
                                                   select u).First();
                return vacinaFornecida;
            }
            catch
            {
                throw new System.Exception("CarteiraVacinal não encontrado");
            }
        }

        public void AtualizarNrDoses(int nroDoseUtilizadas)
        {
            this.Quantidade -= nroDoseUtilizadas;
            Database db = new Database();
            db.VacinaFornecidas.Update(this);
            db.SaveChanges();

        }

        public override string ToString()
        {
            return $"Id: {Id}, dataFabricacao: {DataFabricacao}, DataValidade: {DataValidade},DataCompra: {DataCompra}, Quantidade:{Quantidade}, Preco: {Preco}, ValorTotal: {ValorTotal}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
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
            VacinaFornecida vacinaFornecida = (VacinaFornecida)obj;
            return this.Id == vacinaFornecida.Id;
        }

    }
}