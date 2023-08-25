using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SetareSazanProject
{
    public class PersianDateTime
    {

        public PersianDateTime()
        {
            _year = 1;
            _month = MonthOfYear.فروردین;
            _day = 3;
            _hour = 0;
            _minutes = 0;
            _second = 0;
            _milisecond = 0;
            PersianCalendar pc = new PersianCalendar();

            _dayofweek = (DayOfWeek)pc.GetDayOfWeek(ToDateTime());
            _dayofyear = pc.GetDayOfYear(ToDateTime());
            _weekofyear = pc.GetWeekOfYear(ToDateTime(), CalendarWeekRule.FirstFullWeek, System.DayOfWeek.Saturday);
        }
        public int GetDayInMounth(string date)
        {
            if (date.Length == 10)
            {
                int s = 0, m = 0, d = 0;
                s = int.Parse(date.Substring(0, 4));
                m = int.Parse(date.Substring(5, 2));
                PersianCalendar pc = new PersianCalendar();
                return pc.GetDaysInMonth(s, m);
            }
            else
                return 0;
        }
        public PersianDateTime(int year, MonthOfYear month, int day)
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = 0;
            _minutes = 0;
            _second = 0;
            _milisecond = 0;
            PersianCalendar pc = new PersianCalendar();
            _dayofweek = (DayOfWeek)pc.GetDayOfWeek(ToDateTime());
            _dayofyear = pc.GetDayOfYear(ToDateTime());
            _weekofyear = pc.GetWeekOfYear(ToDateTime(), CalendarWeekRule.FirstFullWeek, System.DayOfWeek.Saturday);

        }
        public PersianDateTime(int year, MonthOfYear month, int day, int hour, int minutes, int second, int milisecond)
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minutes = minutes;
            _second = second;
            _milisecond = milisecond;
            PersianCalendar pc = new PersianCalendar();
            _dayofweek = (DayOfWeek)pc.GetDayOfWeek(ToDateTime());
            _dayofyear = pc.GetDayOfYear(ToDateTime());
            _weekofyear = pc.GetWeekOfYear(ToDateTime(), CalendarWeekRule.FirstFullWeek, System.DayOfWeek.Saturday);
        }
        public PersianDateTime(int year, int month, int day)
        {
            _year = year;
            _month = (MonthOfYear)month;
            _day = day;
            _hour = 0;
            _minutes = 0;
            _second = 0;
            _milisecond = 0;
            PersianCalendar pc = new PersianCalendar();
            _dayofweek = (DayOfWeek)pc.GetDayOfWeek(ToDateTime());
            _dayofyear = pc.GetDayOfYear(ToDateTime());
            _weekofyear = pc.GetWeekOfYear(ToDateTime(), CalendarWeekRule.FirstFullWeek, System.DayOfWeek.Saturday);
        }
        public PersianDateTime(int year, int month, int day, int hour, int minutes, int second, int milisecond)
        {
            _year = year;
            _month = (MonthOfYear)month;
            _day = day;
            _hour = hour;
            _minutes = minutes;
            _second = second;
            _milisecond = milisecond;
            PersianCalendar pc = new PersianCalendar();
            _dayofweek = (DayOfWeek)pc.GetDayOfWeek(ToDateTime());
            _dayofyear = pc.GetDayOfYear(ToDateTime());
            _weekofyear = pc.GetWeekOfYear(ToDateTime(), CalendarWeekRule.FirstFullWeek, System.DayOfWeek.Saturday);
        }
        /// <summary>
        /// تبدیل تاریخ خورشیدی به تاریخ میلادی
        /// </summary>
        /// <returns>تاریخ میلادی بر می گرداند</returns>
        public DateTime ToDateTime()
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(Year, (int)Month, Day, Hour, Minutes, Second, MiliSecond);
        }
        public string Me()
        {

            PersianCalendar p = new PersianCalendar();
            DateTime dt = DateTime.Now;
            int y, m, d,h,min;
            y = p.GetYear(dt);
            m = p.GetMonth(dt);
            d = p.GetDayOfMonth(dt);
            h = p.GetHour(dt);
            min = p.GetMinute(dt);
            var date = y.ToString()+ m.ToString()+ d.ToString()+"-"+h.ToString()+min.ToString();
            return date;
        }
        public string ToDateTimeString()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime d = pc.ToDateTime(Year, (int)Month, Day, Hour, Minutes, Second, MiliSecond);
            return ZeroBeforeNumber(d.Year ,true)+ "/" + ZeroBeforeNumber(d.Month,false) + "/" + ZeroBeforeNumber(d.Day, false) + " " + ZeroBeforeNumber(d.Hour, false) + ":" + ZeroBeforeNumber(d.Minute, false);
        }
        /// <summary>
        /// تبدیل تاریخ میلادی به تاریخ خورشیدی
        /// </summary>
        /// <param name="d">تاریخ میلادی دریافت می کند</param>
        /// <returns>تاریخ خورشیدی بر می گرداند</returns>
        public PersianDateTime ToPersianDateTime(DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            PersianDateTime p = new PersianDateTime(pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), d.Hour, d.Minute, d.Second, d.Millisecond);
            return p;
        }
        /// <summary>
        /// تبدیل تاریخ میلادی به تاریخ خورشیدی
        /// </summary>
        /// <param name="d">تاریخ میلادی به صورت رشته دریافت می کند</param>
        /// <returns>تاریخ خورشیدی بر می گرداند</returns>
        public PersianDateTime ToPersianDateTime(string d)
        {
            PersianDateTime p = new PersianDateTime();
            if (d.Trim() != "")
            {
                if (d.Length == 10)
                    p = new PersianDateTime(int.Parse(d.Substring(0, 4)), int.Parse(d.Substring(5, 2)), int.Parse(d.Substring(8, 2)));
                else if (d.Length == 15)
                    p = new PersianDateTime(int.Parse(d.Substring(0, 4)), int.Parse(d.Substring(5, 2)), int.Parse(d.Substring(8, 2)), int.Parse(d.Substring(10, 2)), int.Parse(d.Substring(13, 2)), 0, 0);
                else if (d.Length == 18)
                    p = new PersianDateTime(int.Parse(d.Substring(0, 4)), int.Parse(d.Substring(5, 2)), int.Parse(d.Substring(8, 2)), int.Parse(d.Substring(10, 2)), int.Parse(d.Substring(13, 2)), int.Parse(d.Substring(16, 2)), 0);
                else
                    p = new PersianDateTime(int.Parse(ClsContol.dater.Substring(0, 4)), 01, 01);
                return p;
            }
            else
            {
                //MessageBoxFarsi.ShowWarning("قالب تاریخ صحیح نمی باشد");
                return null;
            }
        }
        int _weekofyear;
        /// <summary>
        /// هفته از سال
        /// </summary>
        public int WeekOfYear { get { return _weekofyear; } }

        DayOfWeek _dayofweek;
        /// <summary>
        /// روز از هفته
        /// </summary>
        public DayOfWeek DayOfWeek { get { return _dayofweek; } }

        int _dayofyear;
        /// <summary>
        /// روز از سال
        /// </summary>
        public int DayOfYear { get { return _dayofyear; } }

        int _milisecond;
        /// <summary>
        /// میلی ثانیه
        /// </summary>
        public int MiliSecond { get { return _milisecond; } }

        int _second;
        /// <summary>
        /// ثانیه
        /// </summary>
        public int Second { get { return _second; } }

        int _minutes;
        /// <summary>
        /// دقیقه
        /// </summary>
        public int Minutes { get { return _minutes; } }

        int _hour;
        /// <summary>
        /// ساعت
        /// </summary>
        public int Hour { get { return _hour; } }

        int _day;
        /// <summary>
        /// روز
        /// </summary>
        public int Day { get { return _day; } }


        MonthOfYear _month;
        /// <summary>
        /// ماه
        /// </summary>
        public MonthOfYear Month { get { return _month; } }

        int _year;
        /// <summary>
        /// سال
        /// </summary>
        public int Year { get { return _year; } }

        /// <summary>
        /// تاریخ
        /// </summary>
        public PersianDateTime Date
        {
            get
            {
                PersianDateTime p = new PersianDateTime(_year, _month, _day, _hour, _minutes, _second, _milisecond);
                return p;
            }
        }
        /// <summary>
        /// کوچکترین مقدار تاریخ
        /// </summary>
        public static PersianDateTime MinValue
        {
            get
            {
                PersianDateTime p = new PersianDateTime();
                return p;
            }
        }
        /// <summary>
        /// تاریخ امروز
        /// </summary>
        public static PersianDateTime Today
        {
            get
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime d = DateTime.Today;
                PersianDateTime p = new PersianDateTime();
                return p.ToPersianDateTime(d);

            }
        }
        /// <summary>
        /// بیشترین مقدار ناریخ
        /// </summary>
        public static PersianDateTime MaxValue
        {
            get
            {
                PersianDateTime p = new PersianDateTime(9377, 12, 30, 23, 59, 59, 999);
                return p;
            }
        }
        /// <summary>
        /// تاریخ و زمان اکنون
        /// </summary>
        public static PersianDateTime Now
        {
            get
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime d = DateTime.Now;
                PersianDateTime p = new PersianDateTime();
                return p.ToPersianDateTime(d);
            }
        }
        private string ZeroBeforeNumber(int value, bool year)
        {
            string res = "";
            if (!year)
            {
                if (value < 10)
                    res = "0" + value.ToString();
                else
                    res = value.ToString();
            }
            else
            {
                if (value >= 0 && value < 10)
                    res = "0" + "0" + "0" + value.ToString();
                else if (value >= 10 && value < 100)
                    res = "0" + "0" + value.ToString();
                else if (value >= 100 && value < 1000)
                    res = "0" + value.ToString();
                else
                    res = value.ToString();
            }
            return res;
        }
        /// <summary>
        /// مقدار تاریخ و زمان را به بلندترین رشته تاریخ تبدیل می کند
        /// </summary>
        /// <returns></returns>
        public string ToLongDateString()
        {
            tarikh ta = new tarikh();
            return ta.days(DayOfWeek.ToString()) + " " + ZeroBeforeNumber(Day, false) + " " + Month + " " + ZeroBeforeNumber(Year, true);
        }
        /// <summary>
        /// مقدار تاریخ و زمان را به کوتاه ترین رشته تاریخ تبدیل می کند
        /// </summary>
        /// <returns></returns>
        public string ToShortDateString()
        {
            return ZeroBeforeNumber(Year, true) + "/" + ZeroBeforeNumber((int)Month, false) + "/" + ZeroBeforeNumber(Day, false);
        }
        /// <summary>
        /// مقدار تاریخ و زمان را به بلندترین رشته زمان تبدیل می کند
        /// </summary>
        /// <returns></returns>
        public string ToLongTimeString()
        {
            int hour = Hour;
            string AmPm = "قبل از ظهر";
            if (Hour >= 12)
            {
                hour = hour - 12;
                AmPm = "بعد از ظهر";

            }
            if (hour == 0) hour = 12;
            return ZeroBeforeNumber(hour, false) + ":" + ZeroBeforeNumber(Minutes, false) + ":" + ZeroBeforeNumber(Second, false) + ":" + ZeroBeforeNumber(MiliSecond, false) + " " + AmPm;
        }
        /// <summary>
        /// مقدار تاریخ و زمان را به کوتاه ترین رشته زمان تبدیل می کند
        /// </summary>
        /// <returns></returns>
        public string ToShortTimeString()
        {
            int hour = Hour;
            string AmPm = "قبل از ظهر";
            if (Hour >= 12)
            {
                hour = hour - 12;
                AmPm = "بعد از ظهر";
            }
            if (hour == 0) hour = 12;
            return ZeroBeforeNumber(hour, false) + ":" + ZeroBeforeNumber(Minutes, false) + " " + AmPm;
        }
        public string ToTimeString()
        {
            return ZeroBeforeNumber(Hour, false) + ":" + ZeroBeforeNumber(Minutes, false) + ":" + ZeroBeforeNumber(Second, false);
        }
        /// <summary>
        /// مقدار تاریخ و زمان را به   رشته  تبدیل می کند
        /// </summary>
        /// <returns></returns>
        public string ToStrings()
        {
            return ToShortDateString() + "   " + ToLongTimeString();
        }
        public string ToDateHorofString()
        {
            AdadToHoroof.AdadToHoroof ah = new AdadToHoroof.AdadToHoroof();
            return ah.adad(_day) + " " + _month.ToString() + " " + ah.adad(_year);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public PersianDateTime AddMonths(int months)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddMonths(d, months));
        }
        public PersianDateTime AddDays(int days)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddDays(d, days));
        }
        public PersianDateTime AddHours(int hours)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddHours(d, hours));
        }
        public PersianDateTime AddMilliseconds(double MiliSeconds)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddMilliseconds(d, MiliSeconds));
        }
        public PersianDateTime AddMinutes(int minutes)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddMinutes(d, minutes));
        }
        public PersianDateTime AddSeconds(int seconds)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddSeconds(d, seconds));
        }
        public PersianDateTime AddYears(int years)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddYears(d, years));
        }
        public PersianDateTime AddWeeks(int weeks)
        {
            DateTime d = ToDateTime();
            PersianCalendar pc = new PersianCalendar();
            return ToPersianDateTime(pc.AddWeeks(d, weeks));
        }

        public static TimeSpan operator -(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() - p2.ToDateTime();
        }

        public static bool operator !=(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() != p2.ToDateTime();
        }

        public static PersianDateTime operator +(PersianDateTime p, TimeSpan t)
        {
            PersianDateTime res = new PersianDateTime();
            return res.ToPersianDateTime(p.ToDateTime() + t);
        }
        public static bool operator <(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() < p2.ToDateTime();
        }
        public static bool operator <=(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() <= p2.ToDateTime();
        }

        public static bool operator ==(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() == p2.ToDateTime();
        }
        public static bool operator >(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() > p2.ToDateTime();
        }
        public static bool operator >=(PersianDateTime p1, PersianDateTime p2)
        {
            return p1.ToDateTime() >= p2.ToDateTime();
        }
        PersianCalendar pc = new PersianCalendar();
        public DateTime ToDateTime(string TextDate)
        {
            return pc.ToDateTime(int.Parse(TextDate.Substring(0, 4)), int.Parse(TextDate.Substring(5, 2)), int.Parse(TextDate.Substring(8, 2)), 0, 0, 0, 0);
        }
        public string ToTextDate(DateTime DateTime)
        {
            string d = pc.GetDayOfMonth(DateTime).ToString();
            if (d.Length != 2) d = "0" + d;

            string m = pc.GetMonth(DateTime).ToString();
            if (m.Length != 2) m = "0" + m;

            string y = pc.GetYear(DateTime).ToString();
            return y + "/" + m + "/" + d;
        }
        public string AddDays(string DT, double value)
        {
            DateTime d = new DateTime();
            d = ToDateTime(DT);
            d = d.AddDays(value);
            return ToTextDate(d);

        }
        /// <summary>
        /// اختلاف بین 2 تاریخ را به صورت به ترتیب سال,ماه,روز,ساعت,دقیقه,ثانیه,میلی ثانیه بر می گرداند
        /// </summary>
        /// <param name="p1">تاریخ کوچک</param>
        /// <param name="p2">تاریخ بزرگ</param>
        /// <returns></returns>
        public static int[] ToYearMonthDay(PersianDateTime p1, PersianDateTime p2)
        {
            int[] res = new int[7];
            PersianDateTime p = p1;
            int m = 0;
            if (p1 < p2)
            {
                while (p <= p2)
                {
                    p = p.AddMonths(1);
                    m += 1;
                }
                m--;
                p = p.AddMonths(-1);
                if (m == -1) m = 0;
                int y = m / 12;
                m = m % 12;
                TimeSpan ts = new TimeSpan();
                ts = p2 - p;

                res[0] = y;
                res[1] = m;
                res[2] = ts.Days;
                res[3] = ts.Hours;
                res[4] = ts.Minutes;
                res[5] = ts.Seconds;
                res[6] = ts.Milliseconds;
            }
            else
            {
                res[0] = 0;
                res[1] = 0;
                res[2] = 0;
            }
            return res;
        }
    }

}
