using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public static class Genel
    {
        public static string GetString(MySqlDataReader reader, String s)
        {
            if (reader.IsDBNull(reader.GetOrdinal(s)))
                return String.Empty;
            else
                return reader.GetString(reader.GetOrdinal(s));
        }

        public static DateTime GetDateTime(MySqlDataReader reader, String s)
        {
            if (reader.IsDBNull(reader.GetOrdinal(s)))
                return DateTime.MinValue;
            else
                return reader.GetDateTime(reader.GetOrdinal(s));
        }

        public static bool GetBoolean(MySqlDataReader reader, String s)
        {
            if (reader.IsDBNull(reader.GetOrdinal(s)))
                return false;
            else
                return reader.GetBoolean(reader.GetOrdinal(s));
        }

        public static decimal GetDecimal(MySqlDataReader reader, String s)
        {
            if (reader.IsDBNull(reader.GetOrdinal(s)))
                return 0.0M;
            else
                return reader.GetDecimal(reader.GetOrdinal(s));
        }

        public static int GetInteger(MySqlDataReader reader, String s)
        {
            if (reader.IsDBNull(reader.GetOrdinal(s)))
                return 0;
            else
                return reader.GetInt32(reader.GetOrdinal(s));
        }

        public static int GetTinyInteger(MySqlDataReader reader, String s)
        {
            if (reader.IsDBNull(reader.GetOrdinal(s)))
                return 0;
            else
                return reader.GetByte(reader.GetOrdinal(s));
        }

        public static string ToURL(this string s)
        {
            //s = oncul + id + "-" + s;
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length > 80)
                s = s.Substring(0, 80);
            s = s.Replace("þ", "s");
            s = s.Replace("Þ", "S");
            s = s.Replace("ð", "g");
            s = s.Replace("Ð", "G");
            s = s.Replace("Ý", "I");
            s = s.Replace("ý", "i");
            s = s.Replace("ç", "c");
            s = s.Replace("Ç", "C");
            s = s.Replace("ö", "o");
            s = s.Replace("Ö", "O");
            s = s.Replace("ü", "u");
            s = s.Replace("Ü", "U");
            s = s.Replace("'", "");
            s = s.Replace("\"", "");
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            //if (r.IsMatch(s))
            s = r.Replace(s, "-");
            if (!string.IsNullOrEmpty(s))
                while (s.IndexOf("--") > -1)
                    s = s.Replace("--", "-");
            if (s.StartsWith("-")) s = s.Substring(1);
            if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
            return s;
        }

    }
}

