using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Endereco
    {
        public static Model.Endereco CriarEndereco(
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
            validarTelefoneEnderecoInformado(telefone);
            validarEmailEnderecoInformado(email);
            validarFormatoEmailEnderecoInformado(email);
            validarBairroEnderecoInformado(bairro);
            validarRuaEnderecoInformado(rua);
            validarNumeroEnderecoInformado(numero);
            validarCidadeEnderecoInformado(cidade);
            validarEstadoEnderecoInformado(estado);

            //Criar e retornar novo endereco criado
            return new Model.Endereco(
                telefone,
                email,
                bairro,
                rua,
                numero,
                complemento,
                cidade,
                estado
            );
        }

        public static Model.Endereco AlterarEndereco(
            string id,
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
                int idEndereco = Int32.Parse(id);

                validarTelefoneEnderecoInformado(telefone);
                validarEmailEnderecoInformado(email);
                validarFormatoEmailEnderecoInformado(email);
                validarBairroEnderecoInformado(bairro);
                validarRuaEnderecoInformado(rua);
                validarNumeroEnderecoInformado(numero);
                validarCidadeEnderecoInformado(cidade);
                validarEstadoEnderecoInformado(estado);

                return Model.Endereco.AlterarEndereco(
                    idEndereco,
                    telefone,
                    email,
                    bairro,
                    rua,
                    numero,
                    complemento,
                    cidade,
                    estado
                );
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirEndereco(
            string id
        )
        {
            try
            {
                int idEndereco = Int32.Parse(id);

                Model.Endereco.ExcluirEndereco(idEndereco);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Endereco> ListarEnderecos()
        {
            return Model.Endereco.ListarEnderecos();
        }

        public static Model.Endereco BuscarPorId(int idEndereco)
        {
            return Model.Endereco.BuscarEndereco(idEndereco);
        }

        private static void validarTelefoneEnderecoInformado(string telefone)
        {
            if (String.IsNullOrEmpty(telefone))
                throw new Exception("Informe o telefone do endereco!");
        }

        private static void validarEmailEnderecoInformado(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new Exception("Informe o email!");
        }

        private static void validarFormatoEmailEnderecoInformado(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
                throw new Exception("Email inválido");
        }

        private static void validarBairroEnderecoInformado(string bairro)
        {
            if (String.IsNullOrEmpty(bairro))
                throw new Exception("Informe o bairro do endereco!");
        }

        private static void validarRuaEnderecoInformado(string rua)
        {
            if (String.IsNullOrEmpty(rua))
                throw new Exception("Informe a rua do endereco!");
        }

        private static void validarNumeroEnderecoInformado(string numero)
        {
            if (String.IsNullOrEmpty(numero))
                throw new Exception("Informe o numero do endereco!");
        }

        private static void validarCidadeEnderecoInformado(string cidade)
        {
            if (String.IsNullOrEmpty(cidade))
                throw new Exception("Informe a cidade do endereco!");
        }

        private static void validarEstadoEnderecoInformado(string estado)
        {
            if (String.IsNullOrEmpty(estado))
                throw new Exception("Informe a estado do endereco!");
        }
    }
}