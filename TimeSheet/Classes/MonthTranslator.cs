using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Classes
{
    public static class MonthTranslator
    {
        private static List<string> months { get; set; }
        private static List<string> honapok { get; set; }

        static MonthTranslator()
        {
            months = new List<string>();
            months.Add("Months");
            months.Add("January");
            months.Add("February");
            months.Add("March");
            months.Add("April");
            months.Add("May");
            months.Add("June");
            months.Add("July");
            months.Add("August");
            months.Add("September");
            months.Add("October");
            months.Add("November");
            months.Add("December");
            honapok = new List<string>();
            honapok.Add("honapok");
            honapok.Add("január");
            honapok.Add("február");
            honapok.Add("március");
            honapok.Add("április");
            honapok.Add("május");
            honapok.Add("június");
            honapok.Add("július");
            honapok.Add("augusztus");
            honapok.Add("szeptember");
            honapok.Add("október");
            honapok.Add("november");
            honapok.Add("december");
        }


        public static string GetMonth(int monthNumber, bool hungarian)
        {
            if (hungarian)
                return honapok[monthNumber];
            else
                return months[monthNumber];
        }
    }
}
