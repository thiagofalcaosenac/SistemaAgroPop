
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Controller
{
    public class CarteiraVacinacao
    {
        public Model.CarteiraVacinacao CriarCarteiraVacinacao(int id, string dataVacinacao, string proximaDose, int nroDose, Model.Animal animal, Model.Vacina vacina, Model.Fornecedor fornecedor)
        {
            if (string.IsNullOrEmpty(dataVacinacao) || string.IsNullOrEmpty(proximaDose))
                throw new Exception("Data de vacinação e próxima dose são obrigatórias.");

            DateOnly parsedDataVacinacao;
            DateOnly parsedProximaDose;
            if (!DateOnly.TryParse(dataVacinacao, out parsedDataVacinacao) || !DateOnly.TryParse(proximaDose, out parsedProximaDose))
                throw new Exception("As datas devem estar em um formato válido.");

            if (animal == null)
                throw new Exception("É necessário selecionar um animal.");

            if (vacina == null)
                throw new Exception("É necessário selecionar uma vacina.");

            if (fornecedor == null)
                throw new Exception("É necessário selecionar um fornecedor.");

            Model.CarteiraVacinacao carteiraVacinacao = new Model.CarteiraVacinacao(id, parsedDataVacinacao, parsedProximaDose, nroDose, animal, vacina, fornecedor);
            return carteiraVacinacao;
        }

        public Model.CarteiraVacinacao AlterarCarteiraVacinacao(int id, string dataVacinacao, string proximaDose, int nroDose)
        {
            if (string.IsNullOrEmpty(dataVacinacao) || string.IsNullOrEmpty(proximaDose))
                throw new Exception("Data de vacinação e próxima dose são obrigatórias.");

            DateOnly parsedDataVacinacao;
            DateOnly parsedProximaDose;
            if (!DateOnly.TryParse(dataVacinacao, out parsedDataVacinacao) || !DateOnly.TryParse(proximaDose, out parsedProximaDose))
                throw new Exception("As datas devem estar em um formato válido.");

            Model.CarteiraVacinacao carteiraVacinacao = Model.CarteiraVacinacao.BuscarPorId(id);
            carteiraVacinacao.NroDose = nroDose;
            carteiraVacinacao.DataVacinacao = parsedDataVacinacao;
            carteiraVacinacao.ProximaDose = parsedProximaDose;

            return Model.CarteiraVacinacao.Alterar(id, parsedDataVacinacao, parsedProximaDose, nroDose);
        }

        public void ExcluirVacinaCarteiraVacinacao(int id)
        {
            Model.CarteiraVacinacao.Excluir(id);
        }

        public List<Model.CarteiraVacinacao> ListarCarteiraVacinacao()
        {
            return Model.CarteiraVacinacao.Listar();
        }

        public Model.CarteiraVacinacao BuscarPorId(int id)
        {
            return Model.CarteiraVacinacao.BuscarPorId(id);
        }

        public static void VerificarVacinasProximasDoFim()
        {
            Database db = new Database();
            List<Model.Vacina> vacinas = (from v in db.Vacinas
                                          join vf in db.VacinaFornecidas on v.Id equals vf.Vacina.Id
                                          where (vf.Quantidade - v.QtdMinima) <= 10
                                          select v).ToList();

            foreach (Model.Vacina vacina in vacinas)
            {
                Console.WriteLine($"A vacina {vacina.Tipo} está com o número de doses disponíveis próximo da quantidade mínima.");
            }
        }

        public static void VerificarVacinasFornecidasAVencer()
        {
            Database db = new Database();   
            List<Model.VacinaFornecida> vacinasFornecidas = (from vf in db.VacinaFornecidas
                                                             where(DateTime.Parse(vf.DataValidade.ToString()) - DateTime.Today).TotalDays <= 30
                                                             select vf).ToList();

            foreach (Model.VacinaFornecida vacinaFornecida in vacinasFornecidas)
            {
                Console.WriteLine($"A vacina fornecida de ID {vacinaFornecida.Id} está prestes a vencer em 30 dias.");
            }
        }

        public static void VerificarCarteirasProximaDose()
        {
            Database db = new Database();
            List<Model.CarteiraVacinacao> carteirasVacinacao = (from cv in db.CarteiraVacinacoes
                                                                where (DateTime.Parse(cv.ProximaDose.ToString()) - DateTime.Today).TotalDays <= 30
                                                                select cv).ToList();

            foreach (Model.CarteiraVacinacao carteiraVacinacao in carteirasVacinacao)
            {
                Console.WriteLine($"A carteira de vacinação de ID {carteiraVacinacao.Id} está com a próxima dose agendada para daqui a 30 dias.");
            }
        }
    }
}