using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataNCalc;

namespace Varsity_Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /** Storing module data into a list **/
        static IList<Calculation> moduleInfo = new List<Calculation>();

        // Declare variables 
        static int weeks;
        static DateTime starts;
        static string code;
        static string name;
        static int credits;
        static int classHours;
        static int hoursSpent;
        static int selfStudyHours;
        static int hoursRemaining;
        private void Add_Dates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /** Converting User Input **/
                weeks = Convert.ToInt32(Dates_Num_Of_Weeks_TXT.Text);
                starts = Convert.ToDateTime(Start_Date_Date_Picker.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input Values");
            }

        }
        private void Add_Module_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculation cal = new Calculation();

                /** Converting User Input **/
                code = Convert.ToString(Add_Modules_Code_TXT.Text);
                name = Convert.ToString(Add_Modules_Name_TXT.Text);
                credits = Convert.ToInt32(Add_Modules_Credits_TXT.Text);
                classHours = Convert.ToInt32(Add_Modules_Class_Hours_TXT.Text);
                hoursSpent = Convert.ToInt32(Add_Modules_Hours_Spent_TXT.Text);

                selfStudyHours = (credits * 10 / weeks) - classHours;
                hoursRemaining = (selfStudyHours - hoursSpent);

                // Adding module information into a list
                moduleInfo.Add(new Calculation
                {
                    NumOfWeeks = weeks,
                    StartDate = starts,
                    ModuleCode = code,
                    ModuleName = name,
                    ModuleCredits = credits,
                    ModuleClassHours = classHours,
                    ModuleHoursSpent = hoursSpent,
                    SelfStudyHoursPerWeek = selfStudyHours,
                    HoursRemaining = hoursRemaining
                });


                cal.calcuate(selfStudyHours, hoursRemaining);

                // LINQ Query
                var display = from info in moduleInfo
                              select info;

                /** Displaying the list of modules with the number of hours of self-study required for each module per week.**/
                foreach (var list in display)
                {
                    Modules_Display.AppendText($"Module Code: {list.ModuleCode} "
                        + $" | Module Name: {list.ModuleName} "
                        + $" | Module Credits: {list.ModuleCredits}"
                        + $" | Class Hours: {list.ModuleClassHours}"
                        + $" | Hours Spent: {list.ModuleHoursSpent} "
                        + $" | Self-Study Hours: {list.SelfStudyHoursPerWeek}"
                        + $" | Hours Remaining: {list.HoursRemaining}\n");
                }

                /** Clearing textboxes once date button is clicked **/
                Dates_Num_Of_Weeks_TXT.Text = null;
                Start_Date_Date_Picker.Text = null;
                Add_Modules_Code_TXT.Text = null;
                Add_Modules_Name_TXT.Text = null;
                Add_Modules_Credits_TXT.Text = null;
                Add_Modules_Class_Hours_TXT.Text = null;
                Add_Modules_Hours_Spent_TXT.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input Values");
            }
        }

    }
}
