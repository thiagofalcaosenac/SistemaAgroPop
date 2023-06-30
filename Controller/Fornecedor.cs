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
            string telefone,
            string email,
            string rua,
            string bairro,
            string numero,
            string complemento,
            string cidade,
            string estado
        )
        /*Fornecedor

        idFornecedor -> int
        cnpj -> string
        razaoSocial -> string
        nomeFantasia -> string
        endereco -> Entidade Endereco

‌*/
        {
            validarCnpjFornecedorInformado(cnpj); //valida se é numero
            validarRazaoSocialFornecedorInformado(razaoSocial);
            validarNomeFantasiaFornecedorInformado(nomeFantasia);
            validarTelefoneFornecedorInformado(telefone); //valida se é numero
            validarEmailFornecedorInformado(email);
            validarRuaFornecedorInformado(rua); 
            validarBairroFornecedorInformado(bairro);
            validarNumeroFornecedorInformado(numero); //valida se é numero
            validarComplementoFornecedorInformado(complemento);
            validarCidadeFornecedorInformado(cidade);
            validarEstadoFornecedorInformado(estado);
          
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
            //Criar e retornar novo fornecedor criado
            return new Model.Fornecedor(
                cnpj,
                razaoSocial,
                nomeFantasia,
                novoEndereco
            );
        }

        public static Model.Fornecedor AlterarFornecedor(
            string id,
            string cnpj,
            string razaoSocial,
            string nomeFantasia,
            string telefone,
            string email, 
            string rua,
            string bairro,
            string numero,
            string complemento,
            string cidade,
            string estado
        )
        {
            try
            {
            int idFornecedor = Int32.Parse(id);
            Model.Fornecedor fornecedorAtual = Controller.Fornecedor.BuscarPorId(idFornecedor);
            validarCnpjFornecedorInformado(cnpj);
            validarRazaoSocialFornecedorInformado(razaoSocial);
            validarNomeFantasiaFornecedorInformado(nomeFantasia);
            validarTelefoneFornecedorInformado(telefone);
            validarEmailFornecedorInformado(email);
            validarRuaFornecedorInformado(rua);
            validarBairroFornecedorInformado(bairro);
            validarNumeroFornecedorInformado(numero);
            validarComplementoFornecedorInformado(complemento);
            validarCidadeFornecedorInformado(cidade);
            validarEstadoFornecedorInformado(estado);
            Model.Endereco endereco = Controller.Endereco.BuscarPorId(fornecedorAtual.enderecoId);
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

                return Model.Fornecedor.AlterarFornecedor(
                    idFornecedor,
                    cnpj,
                    razaoSocial,
                    nomeFantasia,
                    endereco
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
         private static void validarTelefoneFornecedorInformado(string telefone)
        {
            if (String.IsNullOrEmpty(telefone))
                throw new Exception("Informe o Telefone do fornecedor!");
        }
         private static void validarEmailFornecedorInformado(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new Exception("Informe o Email do fornecedor!");
        }
         private static void validarRuaFornecedorInformado(string rua)
        {
            if (String.IsNullOrEmpty(rua))
                throw new Exception("Informe a rua!");
        }
         private static void validarBairroFornecedorInformado(string bairro)
        {
            if (String.IsNullOrEmpty(bairro))
                throw new Exception("Informe o Bairro!");
        }
          private static void validarNumeroFornecedorInformado(string numero)
        {
            if (String.IsNullOrEmpty(numero))
                throw new Exception("Informe o numero do fornecedor!");
        }
        private static void validarComplementoFornecedorInformado(string complemento)
        {
            if (String.IsNullOrEmpty(complemento))
                throw new Exception("Informe o complemento!");
        }
        private static void validarCidadeFornecedorInformado(string cidade)
        {
            if (String.IsNullOrEmpty(cidade))
                throw new Exception("Informe a cidade!");
        }
        private static void validarEstadoFornecedorInformado(string estado)
        {
            if (String.IsNullOrEmpty(estado))
                throw new Exception("Informe o estado!");
        }

    }
}