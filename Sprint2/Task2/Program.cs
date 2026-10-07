using System;
using System.Collections.Generic;

public static class Sprint2Task2Example
{
public abstract class Vehicle
{
    public string Name { get; set; }
    private int age;
    public int Age { get { return age; } set { if (value < 0) throw new ArgumentOutOfRangeException("Age"); age = value; } }
    public Vehicle(string name, int age) { Name = name; Age = age; }
    public virtual void DisplayInfo() { Console.WriteLine(Name + ", возраст: " + Age); }
    public abstract void Act();
}
public interface IMovable { void Move(); }
public interface IRestable { void Rest(); }
public class Car : Vehicle, IMovable, IRestable
{
    public string Model { get; set; }
    public Car(string name, int age) : base(name, age) { Model = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Car"); }
    public override void Act() { Console.WriteLine(Name + " едет."); }
    public void Move() { Console.WriteLine(Name + " двигается."); }
    public void Rest() { Console.WriteLine(Name + " отдыхает."); }
}
public class Motorcycle : Vehicle, IMovable, IRestable
{
    public string Model { get; set; }
    public Motorcycle(string name, int age) : base(name, age) { Model = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Motorcycle"); }
    public override void Act() { Console.WriteLine(Name + " разгоняется."); }
    public void Move() { Console.WriteLine(Name + " двигается."); }
    public void Rest() { Console.WriteLine(Name + " отдыхает."); }
}
public class SportsCar : Vehicle, IMovable, IRestable
{
    public string Model { get; set; }
    public SportsCar(string name, int age) : base(name, age) { Model = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: SportsCar"); }
    public override void Act() { Console.WriteLine(Name + " участвует в гонке."); }
    public void Move() { Console.WriteLine(Name + " двигается."); }
    public void Rest() { Console.WriteLine(Name + " отдыхает."); }
}
public static void Run()
{
Vehicle[] items = { new Car("Первый", 3), new Motorcycle("Второй", 2), new SportsCar("Третий", 1) };
foreach (Vehicle item in items) { item.DisplayInfo(); item.Act(); }
foreach (IMovable item in items) item.Move();
foreach (IRestable item in items) item.Rest();
}
}


public static class Sprint2Task2Solution
{
public abstract class Animal
{
    public string Name { get; set; }
    private int age;
    public int Age { get { return age; } set { if (value < 0) throw new ArgumentOutOfRangeException("Age"); age = value; } }
    public Animal(string name, int age) { Name = name; Age = age; }
    public virtual void DisplayInfo() { Console.WriteLine(Name + ", возраст: " + Age); }
    public abstract void Act();
}
public interface IMovable { void Move(); }
public interface IRestable { void Rest(); }
public class Dog : Animal, IMovable, IRestable
{
    public string Breed { get; set; }
    public Dog(string name, int age) : base(name, age) { Breed = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Dog"); }
    public override void Act() { Console.WriteLine(Name + " лает."); }
    public void Move() { Console.WriteLine(Name + " двигается."); }
    public void Rest() { Console.WriteLine(Name + " отдыхает."); }
}
public class Cat : Animal, IMovable, IRestable
{
    public string Breed { get; set; }
    public Cat(string name, int age) : base(name, age) { Breed = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Cat"); }
    public override void Act() { Console.WriteLine(Name + " мяукает."); }
    public void Move() { Console.WriteLine(Name + " двигается."); }
    public void Rest() { Console.WriteLine(Name + " отдыхает."); }
}
public class Bird : Animal, IMovable, IRestable
{
    public string Breed { get; set; }
    public Bird(string name, int age) : base(name, age) { Breed = "Обычная"; }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Тип: Bird"); }
    public override void Act() { Console.WriteLine(Name + " поёт."); }
    public void Move() { Console.WriteLine(Name + " двигается."); }
    public void Rest() { Console.WriteLine(Name + " отдыхает."); }
}
public static void Run()
{
Animal[] items = { new Dog("Первый", 3), new Cat("Второй", 2), new Bird("Третий", 1) };
foreach (Animal item in items) { item.DisplayInfo(); item.Act(); }
foreach (IMovable item in items) item.Move();
foreach (IRestable item in items) item.Rest();
}
}

public class Program { public static void Main() { Sprint2Task2Example.Run(); Sprint2Task2Solution.Run(); } }
