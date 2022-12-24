using System;

namespace oopDemo
{
	public class LaboratoryMouse : Mouse
	{
		private bool _isAlive;
		
		public bool IsAlive
		{
			get { return _isAlive;}
			set { _isAlive = value;}
		}
		public LaboratoryMouse()
		{
			
		}
		
		public LaboratoryMouse(byte age, ColorOfMouse color, bool isAl)
			:base(age, color)
		{
			IsAlive = isAl;
		}
		public void GetAlive()
		{
			IsAlive = true;
			Console.WriteLine("мышь жива");
		}
	}
}
