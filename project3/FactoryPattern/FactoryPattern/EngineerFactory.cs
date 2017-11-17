using System;

namespace FactoryPattern
{
    
    public abstract class EngineerFactory
    {
        public abstract IMajor GetDiscipline(string discipline);
    }
    
    public class ConcreteEngineerFactory : EngineerFactory
    {
        public override IMajor GetDiscipline(string discipline)
        {
            switch (discipline)
            {
                case "Computer":
                    return new CompE();
                case "Electrical":
                    return new ElecE();
                case "Industrial":
                    return new InduE();
                case "Software":
                    return new SoftE();
                default:
                    throw new ApplicationException(string.Format("Discipline '{0}' cannot be created", discipline));
            }
        }
    }
}
