
namespace SistemaAgroPopTest.Controller
{
    public class Raca
    {
        public static void ValidarCadastroRaca(string nome, string especie, string porte)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new Exception("Informe o nome do raca!");
            }

            if (String.IsNullOrEmpty(especie))
            {
                throw new Exception("Informe a especie!");
            }

            if (String.IsNullOrEmpty(porte))
            {
                throw new Exception("Informe qual o porte raca!");
            }
        }
    }
}