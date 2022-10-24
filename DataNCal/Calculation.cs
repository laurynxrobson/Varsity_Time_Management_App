using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataNCalc
{
    public class Calculation
    {
        public int NumOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int ModuleCredits { get; set; }
        public int ModuleClassHours { get; set; }
        public int ModuleHoursSpent { get; set; }
        public int SelfStudyHoursPerWeek { get; set; }
        public int HoursRemaining { get; set; }

        public void calcuate(int selfStudyHoursPerWeek, int hoursRemaining)
        {
            try
            {
                SelfStudyHoursPerWeek = (ModuleCredits * 10 / NumOfWeeks) - ModuleClassHours;
                HoursRemaining = SelfStudyHoursPerWeek - ModuleHoursSpent;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
