using System;

namespace InterfaceDemo
{
	/// <summary>
	/// владелец животного
	/// </summary>
	public class Owner
	{
		public string Name{ get;set;}
		public string Passport {get;set;}
		public override string ToString()
		{
			return String.Format("владелец "+Name+ " паспорт: " + Passport);
		}
		public Owner (string n, string p)
		{
			Name = n; Passport = p;
		}
	}
	
	/// <summary>
	/// класс животного, объекты которого можно клонировать и сортировать по полю вида животного
	/// </summary>
	public class Animal : ICloneable, IComparable<Animal>
	{
		public string Kind {get;set;}
		public Owner PetOwner {get;set;}
		
		public Animal(string k, Owner o)
		{
			Kind = k;
			PetOwner = o;
		}
		
		public Object Clone() //метод реализуемы из интерфейса IClonable
		{
			Animal anim = new Animal(Kind, new Owner(PetOwner.Name, PetOwner.Passport)); //глубокое копирование с о значение полей объектов класса PetOwner
		}
		
		public override string ToString()
		{
			return string.Format(Kind + PetOwner);
		}
		
		public int CompareTo(Animal anim) //метод реализуемы из интерфейса IComporable
		{
			//if (anim is null) throw ArgumentException("некорректное значение");
			return Kind.CompareTo(anim.Kind);
		}
 
	}
}
