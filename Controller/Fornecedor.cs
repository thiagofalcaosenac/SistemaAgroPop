using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Fornecedor
    {
        public static Model.Fornecedor CriarFornecedor(
            string cnpj,
            string razaoSocial,
            string nomeFantasia,
            string endereco
        )
        /*Fornecedor

        idFornecedor -> int
        cnpj -> string
        razaoSocial -> string
        nomeFantasia -> string
        endereco -> Entidade Endereco

‌*/
        {
            validarCnpjFornecedorInformado(cnpj);
            validarRazaoSocialFornecedorInformado(razaoSocial);
            validarNomeFantasiaFornecedorInformado(nomeFantasia);
            validarEnderecoFornecedorInformado(endereco);
            int enderecoId = Int32.Parse(endereco);
            Model.Endereco enderecoBanco = Controller.Endereco.BuscarPorId(enderecoId);

            //Criar e retornar novo fornecedor criado
            return new Model.Fornecedor(
                cnpj,
                razaoSocial,
                nomeFantasia,
                enderecoBanco
            );
        }

        public static Model.Fornecedor AlterarFornecedor(
            string id,
            string cnpj,
            string razaoSocial,
            string nomeFantasia,
            string endereco
        )
        {
            try
            {
                int idFornecedor = Int32.Parse(id);

            validarCnpjFornecedorInformado(cnpj);
            validarRazaoSocialFornecedorInformado(razaoSocial);
            validarNomeFantasiaFornecedorInformado(nomeFantasia);
            validarEnderecoFornecedorInformado(endereco);
            int enderecoId = Int32.Parse(endereco);
            Model.Endereco enderecoBanco = Controller.Endereco.BuscarPorId(enderecoId);

                return Model.Fornecedor.AlterarFornecedor(
                    idFornecedor,
                    cnpj,
                    razaoSocial,
                    nomeFantasia,
                    enderecoBanco
                );
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirFornecedor(
            string id
        )
        {
            try
            {
                int idFornecedor = Int32.Parse(id);

                Model.Fornecedor.ExcluirFornecedor(idFornecedor);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

         /*Fornecedor

        idFornecedor -> int
        cnpj -> string
        razaoSocial -> string
        nomeFantasia -> string
        endereco -> Entidade Endereco

‌*/
   
        
        public static List<Model.Fornecedor> ListarFornecedors()
        {
            return Model.Fornecedor.ListarFornecedors();
        }

        public static Model.Fornecedor BuscarPorId(int idFornecedor)
        {
            return Model.Fornecedor.BuscarFornecedor(idFornecedor);
        }

        private static void validarCnpjFornecedorInformado(string telefone)
        {
            if (String.IsNullOrEmpty(telefone))
                throw new Exception("Informe o telefone do fornecedor!");
        }

        private static void validarRazaoSocialFornecedorInformado(string razaosocial)
        {
            if (String.IsNullOrEmpty(razaosocial))
                throw new Exception("Informe o razaosocial!");
        }

       
        private static void validarNomeFantasiaFornecedorInformado(string nome)
        {
            if (String.IsNullOrEmpty(nome))
                throw new Exception("Informe o nome!");
        }

        private static void validarEnderecoFornecedorInformado(string endereco)
        {
            if (String.IsNullOrEmpty(endereco))
                throw new Exception("Informe o endereco do fornecedor!");
        }

    }
}