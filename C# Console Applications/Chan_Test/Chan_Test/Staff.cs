using System;
namespace Chan_Test
{
	public class Staff
	{

		string nameOfStaff;
		const int hourlyRate = 30;
		private int hWorked;


		public int HoursWorked
		{
			get
			{
				return hWorked;
			}
			set
			{
				if (value > 0)
					hWorked = value;
				else
					hWorked = 0;
			}

		}
	}
}
