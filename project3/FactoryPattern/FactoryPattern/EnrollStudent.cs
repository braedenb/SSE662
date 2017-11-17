using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class EnrollStudent
    {
        static void Main(string[] args)
        {
            EngineerFactory majorFactory = new ConcreteEngineerFactory();

        //Get Electrical Engineer and call its grad year function
            IMajor elecEng = majorFactory.GetDiscipline("Electrical");
            elecEng.DeclareGraduation(2017);

        //Get Computer Engineer and call its grad year function
            IMajor compEng = majorFactory.GetDiscipline("Computer");
            compEng.DeclareGraduation(2017);

        //Get Industrial Engineer and call its grad year function
            IMajor induEng = majorFactory.GetDiscipline("Industrial");
            induEng.DeclareGraduation(2017);

        //Get Software Engineer and call its grad year function
            IMajor softEng = majorFactory.GetDiscipline("Software");
            softEng.DeclareGraduation(2017);

        }
    }
}
