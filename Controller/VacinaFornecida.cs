using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Controller
{
    public class VacinaFornecida
    {
        public static Model.VacinaFornecida CriarVacinaFornecida(string dataFabricacao, string dataValidade, string dataCompra, int quantidade, float preco, Model.Fornecedor fornecedor, Model.Vacina vacina)
        {
            if (string.IsNullOrEmpty(dataFabricacao) || string.IsNullOrEmpty(dataValidade) || string.IsNullOrEmpty(dataCompra))
                throw new Exception("As datas de fabricação, validade e compra são obrigatórias.");

            DateTime parsedDataFabricacao;
            DateTime parsedDataValidade;
            DateTime parsedDataCompra;
            if (!DateTime.TryParse(dataFabricacao, out parsedDataFabricacao) || !DateTime.TryParse(dataValidade, out parsedDataValidade) || !DateTime.TryParse(dataCompra, out parsedDataCompra))
                throw new Exception("As datas devem estar em um formato válido.");

            if (fornecedor == null)
                throw new Exception("É necessário selecionar um fornecedor.");

            if (vacina == null)
                throw new Exception("É necessário selecionar uma vacina.");

            float valorTotal = quantidade * preco;

            Model.VacinaFornecida vacinaFornecida = new Model.VacinaFornecida(0, DateOnly.FromDateTime(parsedDataFabricacao), DateOnly.FromDateTime(parsedDataValidade), DateOnly.FromDateTime(parsedDataCompra), quantidade, preco, valorTotal, fornecedor, vacina);
            return vacinaFornecida;
        }

        public static Model.VacinaFornecida AlterarVacinaFornecida(int id, string dataFabricacao, string dataValidade, string dataCompra, int quantidade, float preco)
        {
            if (string.IsNullOrEmpty(dataFabricacao) || string.IsNullOrEmpty(dataValidade) || string.IsNullOrEmpty(dataCompra))
                throw new Exception("As datas de fabricação, validade e compra são obrigatórias.");

            DateTime parsedDataFabricacao;
            DateTime parsedDataValidade;
            DateTime parsedDataCompra;
            if (!DateTime.TryParse(dataFabricacao, out parsedDataFabricacao) || !DateTime.TryParse(dataValidade, out parsedDataValidade) || !DateTime.TryParse(dataCompra, out parsedDataCompra))
                throw new Exception("As datas devem estar em um formato válido.");

            Model.VacinaFornecida vacinaFornecida = Model.VacinaFornecida.BuscarPorId(id);
            vacinaFornecida.DataFabricacao = DateOnly.FromDateTime(parsedDataFabricacao);
            vacinaFornecida.DataValidade = DateOnly.FromDateTime(parsedDataValidade);
            vacinaFornecida.DataCompra = DateOnly.FromDateTime(parsedDataCompra);
            vacinaFornecida.Quantidade = quantidade;
            vacinaFornecida.Preco = preco;
            vacinaFornecida.ValorTotal = quantidade * preco;

            return Model.VacinaFornecida.Alterar(id, DateOnly.FromDateTime(parsedDataFabricacao), DateOnly.FromDateTime(parsedDataValidade), DateOnly.FromDateTime(parsedDataCompra), quantidade, preco, vacinaFornecida.ValorTotal);
        }

        public static void ExcluirVacinaFornecida(int id)
        {
            Model.VacinaFornecida.Excluir(id);
        }

        public static List<Model.VacinaFornecida> ListarVacinaFornecida()
        {
            return Model.VacinaFornecida.Listar();
        }

        public static Model.VacinaFornecida BuscarVacinaFornecidaPorId(int id)
        {
            return Model.VacinaFornecida.BuscarPorId(id);
        }

        public Model.VacinaFornecida BuscarVacinaFornecidaPorFornecedor(Model.Fornecedor fornecedor)
        {
            if (fornecedor == null)
                throw new Exception("É necessário selecionar um fornecedor.");

            return Model.VacinaFornecida.BuscarPorFornecedor(fornecedor);
        }

        public static Model.VacinaFornecida BuscarVacinaFornecidaPorVacina(Model.Vacina vacina)
        {
            if (vacina == null)
                throw new Exception("É necessário selecionar uma vacina.");

            return Model.VacinaFornecida.BuscarPorVacina(vacina);
        }

        public void VerificarVacinasFornecidasAVencer()
        {
            List<Model.VacinaFornecida> vacinasFornecidas = Model.VacinaFornecida.Listar();

            foreach (Model.VacinaFornecida vacinaFornecida in vacinasFornecidas)
            {
                double diasRestantes = (DateTime.Parse(vacinaFornecida.DataValidade.ToString()) - DateTime.Today).TotalDays;
                if (diasRestantes <= 30)
                {
                    Console.WriteLine($"A vacina fornecida de ID {vacinaFornecida.Id} está prestes a vencer em 30 dias.");
                }
            }
        }
    }

}