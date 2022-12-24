using System;

namespace InterfaceDemo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Animal a1 = new Animal("кошка", new Owner("иванов иван", "4565 8595545"));
			Animal a2 = (Animal)a1.Clone();
			
//			Console.WriteLine(a1);
//			Console.WriteLine(a2);
			
			
			a2.PetOwner.Name = "петров петр";
			a2.Kind = "собака";
//			Console.WriteLine(a1);
//			Console.WriteLine(a2);
//			
			
			Animal[] animals = new Animal[2];
			animals[0] = a2;
			animals[1] = a1;
			foreach(Animal a in animals) Console.Write(a+" ");
			
			Array.Sort(animals);
			Console.WriteLine();
			foreach(Animal a in animals) Console.Write(a+" ");
			
			Console.ReadLine();
		}
	}
}