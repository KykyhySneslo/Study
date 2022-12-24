using System;

namespace OOPDemo2
{
	public class Driver
	{
		public string Name{get;set;}
		public int UdNomer{get;set;}
		
		public override string ToString()
		{
			return string.Format("водитель: {0}, водительское удостоверение: {1}]", Name, UdNomer);
		}
		
		public Driver (string n, int x)
		{
			Name = n; UdNomer = x;
		}
 
	}
	
	public class Car
	{
		public string GosNomer {get;set;}
		public string Win {get;set;}
		public Driver Driver {get; set;}
		public int[] Koordinates {get;set;}
		
		Random rnd = new Random();
		public Car(string n, string w, Driver d)
		{
			GosNomer = n; Win = w; Driver = d; 
			Koordinates = new int[2];
			this.Koordinates[0] = rnd.Next(0,20);
			this.Koordinates[1] = rnd.Next(0,20);
				
		}
		
		public void PrintPosition()
		{
			int[,] map = new int[20,20];
			for (int i = 0; i< 20; i++)
			{
				for (int j =0; j< 20; j++)
				{
					if (i == Koordinates[0] && j == Koordinates[1] )
						map[i,j] = 1;
					else map[i,j] = 0;
					
					Console.Write(map[i,j]);
				}
				Console.WriteLine();
			}
		}
		
		public void ChangePosition(int x, int y)
		{
			this.Koordinates[0] = x;
			this.Koordinates[1] = y;
			PrintPosition();
		}
		
		
		
	}
}
