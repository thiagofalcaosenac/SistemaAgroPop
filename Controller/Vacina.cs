using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Vacina
    {
        public static Model.Vacina CriarVacina(int id, Model.Vacina.TipoVacina tipo, int periodicidade, int qtdMinima)
        {
            validaCamposObrigatorios(tipo, periodicidade, qtdMinima);

            Model.Vacina vacina = new Model.Vacina(id, tipo, periodicidade, qtdMinima);
            return vacina;
        }

        public static Model.Vacina AlterarVacina(int id, Model.Vacina.TipoVacina tipo, int periodicidade, int qtdMinima)
        {
            Model.Vacina vacina = Model.Vacina.BuscarVacinaPorId(id);

            if (vacina == null)
            {
                throw new Exception("Vacina não encontrada.");
            }

            validaCamposObrigatorios(tipo, periodicidade, qtdMinima);

            vacina.Tipo = tipo;
            vacina.Periodicidade = periodicidade;
            vacina.QtdMinima = qtdMinima;

            return Model.Vacina.AlterarVacina(id, tipo, periodicidade, qtdMinima);
        }

        public static void ExcluirVacina(int id)
        {
            Model.Vacina vacina = Model.Vacina.BuscarVacinaPorId(id);

            if (vacina == null)
            {
                throw new Exception("Vacina não encontrada.");
            }

            Model.Vacina.ExcluirVacina(id);
        }


        public static List<Model.Vacina> ListarVacina()
        {
            return Model.Vacina.ListarVacina();
        }

        public static Model.Vacina BuscarPorId(int id)
        {
            Model.Vacina vacina = Model.Vacina.BuscarVacinaPorId(id);

            if (vacina == null)
            {
                throw new Exception("Vacina não encontrada.");
            }

            return vacina;
        }

        private static void validaCamposObrigatorios(Model.Vacina.TipoVacina tipo, int periodicidade, int qtdMinima)
        {
            if (string.IsNullOrEmpty(tipo.ToString()))
            {
                throw new ArgumentException("O tipo da vacina é obrigatório.");
            }

            if (int.IsNegative(periodicidade))
            {
                throw new ArgumentException("A periodicidade é obrigatória.");
            }

            if (int.IsNegative(qtdMinima))
            {
                throw new ArgumentException("A quantidade minima é obrigatória.");
            }
        }
    }
}