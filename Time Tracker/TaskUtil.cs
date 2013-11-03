using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracker
{
    class TaskUtil
    {
        public const long SECONDS_IN_MINUTE = 60;
        public const long SECONDS_IN_HOUR = SECONDS_IN_MINUTE * 60;
        public const long SECONDS_IN_DAY = SECONDS_IN_HOUR * 8;

        public static long[] GetDurationComponents(long seconds)
        {
            long[] result = new long[4];
            result[0] = seconds / SECONDS_IN_DAY;
            seconds -= result[0] * SECONDS_IN_DAY;
            result[1] = seconds / SECONDS_IN_HOUR;
            seconds -= result[1] * SECONDS_IN_HOUR;
            result[2] = seconds / SECONDS_IN_MINUTE;
            seconds -= result[2] * SECONDS_IN_MINUTE;
            result[3] = seconds;
            return result;
        }

        public static String ConvertDurationInSecondsToDHM(long seconds)
        {
            long[] components = GetDurationComponents(seconds);

            String duration = "";
            if (components[0] > 0)
                duration = components[0] + "d";
            if (components[1] > 0)
                duration += components[1] + "h";
            if (components[2] > 0)
                duration += components[2] + "m";
            if (duration.Length == 0)
                duration = components[3] + "s";
            return duration;
        }

        public static long parseDuration(String durationStr)
        {
            char[] allowedChars = new char[] {'d', 'h', 'm', 's'};
            StringBuilder number = new StringBuilder();
            long result = 0;
            for (int i = 0; i < durationStr.Length; i++)
            {
                char ch = Char.ToLower(durationStr[i]);
                if (Char.IsDigit(ch))
                {
                    number.Append(ch);
                }
                else if (allowedChars.Contains(ch))
                {
                    long currentMultplr = 0;
                    switch (ch)
                    {
                        case 'd':
                            currentMultplr = SECONDS_IN_DAY;
                            break;
                        case 'h':
                            currentMultplr = SECONDS_IN_HOUR;
                            break;
                        case 'm':
                            currentMultplr = SECONDS_IN_MINUTE;
                            break;
                        case 's':
                            currentMultplr = 1;
                            break;
                    }
                    if (number.Length > 0)
                    {
                        result += long.Parse(number.ToString()) * currentMultplr;    
                    }
                    number.Clear();
                }
                else
                {
                    throw new ArgumentOutOfRangeException ("Bad duration format. Working example: \"1d12h30m15s\"");
                }                
            }
            return result;
        }
    }
}
