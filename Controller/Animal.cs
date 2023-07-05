using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using Model;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Animal
    {
        public static Model.Animal CriarAnimal(string dataNascimento, string nroRegistro, string origem, string cor, string peso, string raca, string fazenda)
        {
            validardataNascimentoAnimalInformado(dataNascimento);
            validarnroRegistroAnimalInformado(nroRegistro);
            EnumOrigem enumOrigem = (EnumOrigem)Enum.Parse(typeof(EnumOrigem), origem);
            validarOrigemAnimalExistente(enumOrigem);
            validarCorAnimalInformado(cor);
            validarPesoAnimalInformado(peso);
            validarRacaAnimalInformado(raca);
            validarFazendaAnimalInformado(fazenda);


            /*idAnimal -> int
             dataNascimento -> Date
             nroRegistro -> string
             origem -> EnumOrigem → (Própria, Comunitário, ONG, Pessoas Carentes, Rua)
             cor -> string
             peso -> float
             raca -> Entidade Raca
             fazenda -> Entidade Fazenda*/
            int racaId = Int32.Parse(raca);
            int fazendaId = Int32.Parse(fazenda);
            int pesoInt = Int32.Parse(peso);
            DateOnly dataDeNascimento = DateOnly.FromDateTime(DateTime.Parse(dataNascimento));
            Model.Raca racaBanco = Controller.Raca.BuscarPorId(racaId);
            Model.Fazenda fazendaBanco = Controller.Fazenda.BuscarPorId(fazendaId);

            validarQtdLimiteAnimalPorFazenda(fazendaBanco);

            return new Model.Animal(
               dataDeNascimento,
               nroRegistro,
               enumOrigem,
               cor,
               pesoInt,
               racaBanco,
               fazendaBanco
            );
        }

        public static Model.Animal AlterarAnimal(
            string id,
            string dataNascimento,
            string nroRegistro,
            string origem,
            string cor,
            string peso,
            string raca,
            string fazenda
        )
        {
            try
            {
                int idAnimal = Int32.Parse(id);

                validardataNascimentoAnimalInformado(dataNascimento);
                validarnroRegistroAnimalInformado(nroRegistro);
                EnumOrigem enumOrigem = (EnumOrigem)Enum.Parse(typeof(EnumOrigem), origem);
                validarOrigemAnimalExistente(enumOrigem);
                validarCorAnimalInformado(cor);
                validarPesoAnimalInformado(peso);
                validarRacaAnimalInformado(raca);
                validarFazendaAnimalInformado(fazenda);

                DateOnly dataDeNascimento = DateOnly.FromDateTime(DateTime.Parse(dataNascimento));
                int racaId = Int32.Parse(raca);
                int fazendaId = Int32.Parse(fazenda);
                int pesoInt = Int32.Parse(peso);
                Model.Raca racaBanco = Controller.Raca.BuscarPorId(racaId);
                Model.Fazenda fazendaBanco = Controller.Fazenda.BuscarPorId(fazendaId);

                validarQtdLimiteAnimalPorFazenda(fazendaBanco);

                return Model.Animal.AlterarAnimal(
                    idAnimal,
                    dataDeNascimento,
                    nroRegistro,
                    enumOrigem,
                    cor,
                    pesoInt,
                    racaBanco,
                    fazendaBanco
                );
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirAnimal(
            string id
        )
        {
            try
            {
                int idAnimal = Int32.Parse(id);

                Model.Animal.ExcluirAnimal(idAnimal);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Animal> ListarAnimals()
        {
            return Model.Animal.ListarAnimals();
        }

        public static Model.Animal BuscarPorId(int idAnimal)
        {
            return Model.Animal.BuscarAnimal(idAnimal);
        }


        private static void validardataNascimentoAnimalInformado(string dataNascimento)
        {
            if (String.IsNullOrEmpty(dataNascimento))
                throw new Exception("Informe a data de Nascimento do animal!");
        }

        private static void validarnroRegistroAnimalInformado(string nroRegistro)
        {
            if (String.IsNullOrEmpty(nroRegistro))
                throw new Exception("Informe o numero do Registro!");
        }

        private static void validarOrigemAnimalInformado(string origem)
        {
            if (String.IsNullOrEmpty(origem))
                throw new Exception("Informe qual é a origem do animal!");
        }

        private static void validarOrigemAnimalExistente(EnumOrigem origem)
        {
            if (!Enum.IsDefined(typeof(EnumOrigem), origem))
            {
                throw new ArgumentException("Origem informada inválida!.");
            }
        }
        private static void validarCorAnimalInformado(string cor)
        {
            if (String.IsNullOrEmpty(cor))
                throw new Exception("Informe a cor do animal!");
        }

        private static void validarPesoAnimalInformado(string peso)
        {
            if (String.IsNullOrEmpty(peso))
                throw new Exception("Informe qual o peso do animal!");
        }

        private static void validarRacaAnimalInformado(string raca)
        {
            if (String.IsNullOrEmpty(raca))
                throw new Exception("Informe a Raca do animal!");
        }

        private static void validarFazendaAnimalInformado(string fazenda)
        {
            if (String.IsNullOrEmpty(fazenda))
                throw new Exception("Informe de qual fazenda e o animal!");
        }

        private static void validarQtdLimiteAnimalPorFazenda(Model.Fazenda fazenda)
        {
            int qtdLimiteAnimalFazenda = fazenda.qtdLimiteAnimal;
            int qtdAtualAnimaisPorFazenda = Model.Animal.BuscarPorFazenda(fazenda.id).Count();

            if (qtdAtualAnimaisPorFazenda >= qtdLimiteAnimalFazenda)
                throw new Exception("A quantidade de animais já chegou no limite na fazenda selecionada!");
        }

    }
}
