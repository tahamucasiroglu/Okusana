using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Okusana.Extensions
{
    static public class DateTimeExtension
    {
        static public bool IsSameCalenderDate(this DateTime date1, DateTime date2) => date1.Day == date2.Day && date1.Month == date2.Month && date1.Year == date2.Year;  //date başta kalsın en çok oradan hata yapılır direk ilk sorguda ayıklanır
        static public bool IsSameCalenderDate(this DateTime? date1, DateTime date2) => date1 == null ? false : date1?.Day == date2.Day && date1?.Month == date2.Month && date1?.Year == date2.Year;  //date başta kalsın en çok oradan hata yapılır direk ilk sorguda ayıklanır
        static public bool IsInRange(this DateTime date, DateTime startDate, DateTime EndDate) => date.CompareTo(startDate) == 1 && date.CompareTo(EndDate) == -1;
        static public bool IsInRange(this DateTime? date, DateTime startDate, DateTime EndDate) => date == null ? false : date?.CompareTo(startDate) == 1 && date?.CompareTo(EndDate) == -1;
        static public bool IsBiggerThan(this DateTime date, DateTime secondDate) => date.CompareTo(secondDate) == -1;
        static public bool IsBiggerThan(this DateTime? date, DateTime secondDate) => date == null ? false : date?.CompareTo(secondDate) == -1;
        static public bool IsLessThan(this DateTime date, DateTime secondDate) => date.CompareTo(secondDate) == 1;
        static public bool IsLessThan(this DateTime? date, DateTime secondDate) => date == null ? false : date?.CompareTo(secondDate) == 1;


    }
}
