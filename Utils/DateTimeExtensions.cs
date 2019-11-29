using System;

namespace ProjetoWebVale.Utils
{
    public static class DateTimeExtensions
    {
        public static string ToString_ddMMyyyy(this DateTime? d)
        {
            if (d == null)
                return string.Empty;

            return d.Value.ToString_ddMMyyyy();
        }
        public static string ToString_ddMMyyyy(this DateTime d)
        {
            return String.Format("{0:dd/MM/yyyy}", d);
        }
    }
}