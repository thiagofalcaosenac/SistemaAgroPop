using Model;
using NUnit.Framework;
using Repository;

namespace Controller.Test
{
    [TestFixture]
    public class Animal
    {
        private Database db;


        [SetUp]
        public void SetUp()
        {
            db = new Database();
        }

        [Test]
        public void dadoInformacoesCompletasDeveCriarUmAnimal()
        {
            DateOnly dataNascimento = new DateOnly(1999, 12, 28);
            string nroRegistro = "15623";
            EnumOrigem origem = EnumOrigem.PessoasCarentes;
            string cor = "rosa shock";
            int peso = 108;
            int raca = 1; // deve existir no banco
            int fazenda = 1;

            Model.Animal animal = Controller.Animal.CriarAnimal(dataNascimento.ToString(), nroRegistro, ((int)origem).ToString(), cor, peso.ToString(), raca.ToString(), fazenda.ToString());

            Assert.IsNotNull(animal);
            Assert.AreEqual(dataNascimento, animal.dataNascimento);
            Assert.AreEqual(nroRegistro, animal.nroRegistro);
            Assert.AreEqual(origem, animal.origem);
            Assert.AreEqual(cor, animal.cor);
            Assert.AreEqual(peso, animal.peso);
            Assert.AreEqual(raca, animal.racaid);
            Assert.AreEqual(fazenda, animal.fazendaid);

        }

        [Test]
        public void dadoUmaDataNascimentoNullNaoDeveCriarUmAnimal()
        {
            var ex = Assert.Throws<Exception>(() => Controller.Animal.CriarAnimal("", null, null, null, null, null, null));
            Assert.That(ex.Message, Is.EqualTo("Informe a data de Nascimento do animal!"));
        }

         [Test]
        public void dadoUmRegistroAnimalNullNaoDeveCriarUmAnimal()
        {
            var ex = Assert.Throws<Exception>(() => Controller.Animal.CriarAnimal("28/12/1999", null, "", null, null, null, null));
            Assert.That(ex.Message, Is.EqualTo("Informe o numero do Registro!"));
        }
    }
}