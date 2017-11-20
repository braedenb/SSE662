using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FactoryPattern.Tests
{
    [TestClass()]
    public class ConcreteEngineerFactoryTests
    {
        [TestMethod()]
        public void GetDisciplineTest()
        {
            EngineerFactory majorFactory = new ConcreteEngineerFactory();
            IMajor engineer;

            // Get Electrical Engineer
            engineer = majorFactory.GetDiscipline("Electrical");
            Assert.IsInstanceOfType(engineer, typeof(ElecE));
            engineer.DeclareGraduation(2017);
            
            // Get Computer Engineer
            engineer = majorFactory.GetDiscipline("Computer");
            Assert.IsInstanceOfType(engineer, typeof(CompE));
            engineer.DeclareGraduation(2017);

            // Get Industrial Engineer
            engineer = majorFactory.GetDiscipline("Industrial");
            Assert.IsInstanceOfType(engineer, typeof(InduE));
            engineer.DeclareGraduation(2017);

            // Get Software Engineer
            engineer = majorFactory.GetDiscipline("Software");
            Assert.IsInstanceOfType(engineer, typeof(SoftE));
            engineer.DeclareGraduation(2017);
        }
    }
}