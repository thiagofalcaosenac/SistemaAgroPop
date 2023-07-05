namespace SistemaAgroPopTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TryInsertBreedWithNameNull()
    {
        try
        {
            SistemaAgroPopTest.Controller.Raca.ValidarCadastroRaca(null, null, null);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Informe o nome do raca!", e.Message);
        }
    }

    [TestMethod]
    public void TryInsertBreedWithSpeciesNull()
    {
        try
        {
            SistemaAgroPopTest.Controller.Raca.ValidarCadastroRaca("Thiago", null, null);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Informe a especie!", e.Message);
        }
    }

    [TestMethod]
    public void TryInsertBreedWithBearingNull()
    {
        try
        {
            SistemaAgroPopTest.Controller.Raca.ValidarCadastroRaca("Thiago", "Bovino", null);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Informe qual o porte raca!", e.Message);
        }
    }

}