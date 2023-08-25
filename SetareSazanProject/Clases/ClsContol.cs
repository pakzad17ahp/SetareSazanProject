using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetareSazanProject
{
    public static class ClsContol
    {
        public static string dater = ToShamsi(DateTime.Now);

        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" +
                   pc.GetMonth(date) + "/" +
                   pc.GetDayOfMonth(date);
        }

    }
}
