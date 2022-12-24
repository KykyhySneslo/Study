using System;

namespace OOPDemo2
{
	class Program
	{
		public static void Main()
		{
			Car car1 = new Car("56 000 YU", "FD545546", new Driver("Иванов Иван", 54658612));
			car1.PrintPosition();
			int x=car1.Koordinates[0];
			int y=car1.Koordinates[1];
			while(x != -1)
			{
				Console.WriteLine("введите новые координаты:");
				x = Convert.ToInt32(Console.ReadLine());
				y = Convert.ToInt32(Console.ReadLine());
				
				car1.ChangePosition(x,y);
			}
			Console.Read();
		}
		
	}
}