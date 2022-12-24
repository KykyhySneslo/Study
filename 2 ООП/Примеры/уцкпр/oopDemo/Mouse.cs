using System;

namespace oopDemo
{
	public enum ColorOfMouse{black=1, red, white, gray} //перечисление окраса
	
	public class Mouse
	{
		//поля класса
		private byte _age;
		private ColorOfMouse _color;
		
		//свойство возраста
		public byte Age
		{
			get {return _age;}
			set 
			{
				if (value <5)
				{
					_age = value;
				}
				else 
				{
					_age = 0;
					Console.WriteLine("Возраст в недопустимом диапазоне");
				}
			}
		}
		//свойство окраса
		public ColorOfMouse Color
		{
			get 
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}
		//свойство, собирающее данные с нескольких полей
		public string Data
		{
			get 
			{
				string res = "мышь возрастом "+_age+ " окрас " +_color;
				return res;
			}
		}
		//конструктор
		public Mouse()
		{
			Age = 0;
			Color = ColorOfMouse.gray;
		}
		//конструктор
		public Mouse(byte age, ColorOfMouse color)
		{
			Age = age;
			Color = color;
		}
		
		//метод ToString() переопределенный от базового класса object
		public override string ToString()
		{
			return string.Format("[Mouse Age={0}, Color={1}]", _age, _color);
		}
 
		//метод смены окраса мыша
		public void ChangeColor(ColorOfMouse col)
		{
			Color = col;
			Console.WriteLine("Цвет мыша был изменен");
			Console.WriteLine(Color);
		}

	}
}
