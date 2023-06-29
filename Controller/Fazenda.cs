using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Fazenda
    {
        public static Model.Fazenda CriarFazenda(
            string nome,
            string qtdLimiteAnimal,
            string telefone,
            string email,
            string bairro,
            string rua,
            string numero,
            string complemento,
            string cidade,
            string estado
        )
        {
            validarNomeFazendaInformado(nome);
            validarQtdLimiteAnimalFazendaInformado(qtdLimiteAnimal);

            Model.Endereco novoEndereco = Controller.Endereco.CriarEndereco(
                                                            telefone,
                                                            email,
                                                            bairro,
                                                            rua,
                                                            numero,
                                                            complemento,
                                                            cidade,
                                                            estado
            );

            //Criar e retornar novo fazenda criado
            return new Model.Fazenda(
                nome,
                Int32.Parse(qtdLimiteAnimal),
                novoEndereco
            );
        }

        public static Model.Fazenda AlterarFazenda(
            string id,
            string nome,
            string qtdLimiteAnimal,
            string telefone,
            string email,
            string bairro,
            string rua,
            string numero,
            string complemento,
            string cidade,
            string estado
        )
        {
            try
            {
                validarNomeFazendaInformado(nome);
                validarQtdLimiteAnimalFazendaInformado(qtdLimiteAnimal);                

                int idFazenda = Int32.Parse(id);
                Model.Fazenda fazendaAtual = Controller.Fazenda.BuscarPorId(idFazenda);

                Model.Endereco endereco = Controller.Endereco.BuscarPorId(fazendaAtual.enderecoId);
                endereco = Controller.Endereco.AlterarEndereco(endereco.id.ToString(),
                                                                telefone,
                                                                email,
                                                                bairro,
                                                                rua,
                                                                numero,
                                                                complemento,
                                                                cidade,
                                                                estado
                                                                );


                return Model.Fazenda.AlterarFazenda(
                    idFazenda,
                    nome,
                    Int32.Parse(qtdLimiteAnimal),
                    endereco
                );
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirFazenda(
            string id
        )
        {
            try
            {
                int idFazenda = Int32.Parse(id);

                Model.Fazenda.ExcluirFazenda(idFazenda);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Fazenda> ListarFazendas()
        {
            return Model.Fazenda.ListarFazendas();
        }

        public static Model.Fazenda BuscarPorId(int idFazenda)
        {
            return Model.Fazenda.BuscarFazenda(idFazenda);
        }

        private static void validarNomeFazendaInformado(string nome)
        {
            if (String.IsNullOrEmpty(nome))
                throw new Exception("Informe o nome da fazenda!");
        }

        private static void validarQtdLimiteAnimalFazendaInformado(string qtdLimiteAnimal)
        {
            if (String.IsNullOrEmpty(qtdLimiteAnimal) || Int32.Parse(qtdLimiteAnimal) <= 0)
                throw new Exception("Informe o Quantidade Limite de Animal na fazenda!");
        }        
    }
}