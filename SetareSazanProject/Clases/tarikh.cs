using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace SetareSazanProject
{   
  
    public class tarikh
    {
        public string EslahTarikh(string Date)
        {
            string garn = ClsContol.dater.Substring(0, 2);
            string y = "", m = "", d = "";
            string date = "";
            string[] eslash = Date.Trim().Split('/');
            string[] dash = Date.Trim().Split('-');
            string[] backeslash = Date.Trim().Split('\\');
            if (eslash.Length >=3)
            {
                y = eslash[0].Trim();
                 m = eslash[1].Trim();
                 d = eslash[2].Trim();
            }
            else if (dash.Length >= 3)
            {
                y = dash[0].Trim();
                m = dash[1].Trim();
                d = dash[2].Trim();
            }
            else if (backeslash.Length >= 3)
            {
                y = backeslash[0].Trim();
                m = backeslash[1].Trim();
                d = backeslash[2].Trim();
            }
            else
            {
                if (Date.Trim().Length == 6)
                {
                    y = Date.Trim().Substring(0, 2);
                    m = Date.Trim().Substring(2, 2);
                    d = Date.Trim().Substring(4, 2);
                }
                else if (Date.Trim().Length == 8)
                {
                    y = Date.Trim().Substring(0, 4);
                    m = Date.Trim().Substring(4, 2);
                    d = Date.Trim().Substring(6, 2);
                }
                else
                {
                    y = "0000";
                    m = "00";
                    d = "00";
                }

            }
            switch (y.Length)
            {
                case 0:
                    y = garn + "00";
                    break;
                case 1:
                    y = garn + "0" + y;
                    break;
                case 2:
                    y = garn + y;
                    break;
                case 3:
                    y = garn.Substring(0, 1) + y;
                    break;
            }
            switch (m.Length)
            {
                case 0:
                    m = "00";
                    break;
                case 1:
                    m = "0" + m;
                    break;
            }
            switch (d.Length)
            {
                case 0:
                    d = "00";
                    break;
                case 1:
                    d = "0" + d;
                    break;
            }
            date = y + "/" + m + "/" + d;
            return date;
        }
        public string  month(int i)
        {
            String[] monthNames = new String[12];
            monthNames[0] = "فروردين";
            monthNames[1] = "ارديبهشت";
            monthNames[2] = "خرداد";
            monthNames[3] = "تير";
            monthNames[4] = "مرداد";
            monthNames[5] = "شهريور";
            monthNames[6] = "مهر";
            monthNames[7] = "آبان";
            monthNames[8] = "آذر";
            monthNames[9] = "دی";
            monthNames[10] = "بهمن";
            monthNames[11] = "اسفند";
            if (i > 0 && i < 13)
                return monthNames[i - 1].ToString();
            else
                return "خطا در ماه";
        }
        public string days(string dayofweek)
        {
            string s = "";

            switch (dayofweek)
            {
                case "Friday":
                    s="جمعه";
                    break;
                case "Saturday":
                    s="شنبه";
                    break;
                case "Sunday":
                    s = "یکشنبه";
                    break;
                case "Monday":
                    s = "دوشنبه";
                    break;
                case "Tuesday":
                    s = "سه شنبه";
                    break;
                case "Wednesday":
                    s = "چهارشنبه";
                    break;
                case "Thursday":
                    s = "پنجشنبه";
                    break;
            }
            return s;
           
        }
        public string GetPersianDay(string PersianDateString)
        {
            string[] PersianDay = new string[7] { "یک‌شنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };
            string[] result = PersianDateString.Split("/".ToCharArray());
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return PersianDay[Convert.ToByte((pc.ToDateTime(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]), Convert.ToInt32(result[2]), 0, 0, 0, 0)).DayOfWeek)];
        }
        public string today()
        {
            ClsContol.dater = todaysys();
            return ClsContol.dater;

        }
        public string todaysys()
        {
            DateTime _date = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            StringBuilder sb = new StringBuilder();
            sb.Append(pc.GetYear(_date).ToString("0000"));
            sb.Append("/");
            sb.Append(pc.GetMonth(_date).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetDayOfMonth(_date).ToString("00"));
            return sb.ToString();
       

        }

       
    }
    
}
