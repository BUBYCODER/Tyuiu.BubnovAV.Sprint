using System;
using System.Collections.Generic;

public static class Sprint3Task0Example
{
public class Vehicle
{
    public string Name { get; set; }
    private int age;
    public int Age { get { return age; } set { if (value < 0) throw new ArgumentOutOfRangeException("Age"); age = value; } }
    public Vehicle(string name, int age) { Name = name; Age = age; }
    public virtual void DisplayInfo() { Console.WriteLine(Name + ", возраст: " + Age); }
    public virtual void Act() { Console.WriteLine(Name + " двигается."); }
}
public class Car : Vehicle
{
    public string Model { get; set; }
    public Car(string name, int age) : base(name, age) { Model = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Car"); }
    public override void Act() { Console.WriteLine(Name + " едет."); }
}
public class Motorcycle : Vehicle
{
    public string Model { get; set; }
    public Motorcycle(string name, int age) : base(name, age) { Model = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Motorcycle"); }
    public override void Act() { Console.WriteLine(Name + " разгоняется."); }
}
public class SportsCar : Vehicle
{
    public string Model { get; set; }
    public SportsCar(string name, int age) : base(name, age) { Model = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: SportsCar"); }
    public override void Act() { Console.WriteLine(Name + " участвует в гонке."); }
}
public static void Run()
{
Vehicle[] items = { new Car("Первый", 3), new Motorcycle("Второй", 2), new SportsCar("Третий", 1) };
foreach (Vehicle item in items) { item.DisplayInfo(); item.Act(); }
}
}


public static class Sprint3Task0Solution
{
public class Animal
{
    public string Name { get; set; }
    private int age;
    public int Age { get { return age; } set { if (value < 0) throw new ArgumentOutOfRangeException("Age"); age = value; } }
    public Animal(string name, int age) { Name = name; Age = age; }
    public virtual void DisplayInfo() { Console.WriteLine(Name + ", возраст: " + Age); }
    public virtual void Act() { Console.WriteLine(Name + " двигается."); }
}
public class Dog : Animal
{
    public string Breed { get; set; }
    public Dog(string name, int age) : base(name, age) { Breed = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Dog"); }
    public override void Act() { Console.WriteLine(Name + " лает."); }
}
public class Cat : Animal
{
    public string Breed { get; set; }
    public Cat(string name, int age) : base(name, age) { Breed = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Cat"); }
    public override void Act() { Console.WriteLine(Name + " мяукает."); }
}
public class Bird : Animal
{
    public string Breed { get; set; }
    public Bird(string name, int age) : base(name, age) { Breed = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Bird"); }
    public override void Act() { Console.WriteLine(Name + " поёт."); }
}
public static void Run()
{
Animal[] items = { new Dog("Первый", 3), new Cat("Второй", 2), new Bird("Третий", 1) };
foreach (Animal item in items) { item.DisplayInfo(); item.Act(); }
}
}

public class Program { public static void Main() { Sprint3Task0Example.Run(); Sprint3Task0Solution.Run(); } }
