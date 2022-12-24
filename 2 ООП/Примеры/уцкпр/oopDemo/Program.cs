using System;

namespace oopDemo
{
	class Program
	{
		public static void Main(string[] args)
		{
			LaboratoryMouse m1 = new LaboratoryMouse(2, ColorOfMouse.black, false);
			Console.WriteLine(m1.ToString());
			m1.ChangeColor(ColorOfMouse.white);
			m1.GetAlive();
			
			
			Console.Read();
		}
	}
}