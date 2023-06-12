using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using Model;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Raca
    {
        public static Model.Raca CriarRaca(string nome,string especie,string porte)
        {
            validarNomeRacaInformado(nome);
            validarEspecieRacaInformado(especie);
            EnumEspecie especieEnum = (EnumEspecie)Enum.Parse(typeof(EnumEspecie), especie);
            validarEspecieRacaExistente(especieEnum);
            validarPorteRacaInformado(porte);
            EnumPorte porteEnum = (EnumPorte)Enum.Parse(typeof(EnumPorte), porte);
            validarPorteRacaExistente(porteEnum);
           

            return new Model.Raca(
               nome,
               especieEnum,
               porteEnum
            );
        }

        public static Model.Raca AlterarRaca(
            string id,
            string nome,
            string especie,
            string porte
        )
        {
            try
            {
             int idRaca = Int32.Parse(id);

             validarNomeRacaInformado(nome);
            validarEspecieRacaInformado(especie);
            EnumEspecie especieEnum = (EnumEspecie)Enum.Parse(typeof(EnumEspecie), especie);
            validarEspecieRacaExistente(especieEnum);
            validarPorteRacaInformado(porte);
            EnumPorte porteEnum = (EnumPorte)Enum.Parse(typeof(EnumPorte), porte);
            validarPorteRacaExistente(porteEnum);

                return Model.Raca.AlterarRaca(
                    idRaca,
                    nome,
                    especieEnum,
                    porteEnum
                );
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirRaca(
            string id
        )
        {
            try
            {
                int idRaca = Int32.Parse(id);

                Model.Raca.ExcluirRaca(idRaca);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Raca> ListarRacas()
        {
            return Model.Raca.ListarRacas();
        }

        public static Model.Raca BuscarPorId(int idRaca)
        {
            return Model.Raca.BuscarRaca(idRaca);
        }

        private static void validarNomeRacaInformado(string raca)
        {
            if (String.IsNullOrEmpty(raca))
                throw new Exception("Informe o nome do raca!");
        }

        private static void validarEspecieRacaInformado(string especie)
        {
            if (String.IsNullOrEmpty(especie))
                throw new Exception("Informe a especie!");
        }

        private static void validarPorteRacaInformado(string porte)
        {
            if (String.IsNullOrEmpty(porte))
                throw new Exception("Informe qual o porte raca!");
        }

         private static void validarEspecieRacaExistente(EnumEspecie especie)
        {
           if (!Enum.IsDefined(typeof(EnumEspecie), especie))
            {
                throw new ArgumentException("Especie informada inválida!.");
            }
        }
         private static void validarPorteRacaExistente(EnumPorte porte)
        {
           if (!Enum.IsDefined(typeof(EnumPorte), porte))
            {
                throw new ArgumentException("Porte informado inválido!.");
            }
        }
    }
}