using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
	class Program
	{
		// Y - Indicates Yellow light in the output
		// R - Indicates red light in hours and in minutes it indicates past 15,30, and 45 minutes
		// O - Indicates that the light is off and not lit for the time given

		public class BerlinClock
		{
			public String convertTime(String aTime)
			{
				int[] parts = aTime.Split(':').Select(Int32.Parse).ToArray();

				StringBuilder time = new StringBuilder();

				return time.AppendLine(getSeconds(parts[2]))
						.AppendLine(getTopHours(parts[0]))
						.AppendLine(getBottomHours(parts[0]))
						.AppendLine(getTopMinutes(parts[1]))
						.AppendLine(getBottomMinutes(parts[1])).ToString();

			}
			private String getSeconds(int number)
			{
				if (number % 2 == 0)
					return "Y";
				else
					return "O";
			}
			private String getTopHours(int number)
			{
				return getOnOff(4, getTopNumberOfOnSigns(number));
			}
			private String getBottomHours(int number)
			{
				return getOnOff(4, number % 5);
			}
			private String getTopMinutes(int number)
			{
				return getOnOff(11, getTopNumberOfOnSigns(number), "Y").Replace("YYY", "YYR");
			}
			private String getBottomMinutes(int number)
			{
				return getOnOff(4, number % 5, "Y");
			}
			private String getOnOff(int lamps, int onSigns)
			{
				return getOnOff(lamps, onSigns, "R");
			}
			private String getOnOff(int lamps, int onSigns, String onSign)
			{
				string output = "";
				for (int i = 0; i < onSigns; i++)
				{
					output += onSign;
				}
				for (int i = 0; i < (lamps - onSigns); i++)
				{
					output += "O";
				}
				return output;
			}
			private int getTopNumberOfOnSigns(int number)
			{
				return (number - (number % 5)) / 5;
			}
			static void Main(string[] args)
			{
				BerlinClock berlinClock = new BerlinClock();
				Console.WriteLine(berlinClock.convertTime("13:15:40"));
				Console.ReadLine();

			}
		}
	}
}
