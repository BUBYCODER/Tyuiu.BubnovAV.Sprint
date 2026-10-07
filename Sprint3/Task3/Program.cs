using System;
using System.Collections.Generic;
public static class Sprint3Task3
{
public class Item
{
    public string Name { get; set; }
    public decimal Price { get; private set; }
    public Item(string name, decimal price) { if (price < 0) throw new ArgumentOutOfRangeException("price"); Name = name; Price = price; }
}
public interface IPayable { void Pay(); }
public interface ITrackable { void Track(); }
public class Order
{
    public int OrderId { get; set; }
    public DateTime CreationDate { get; set; }
    public decimal TotalAmount { get { return CalculateTotal(); } }
    public string CustomerName { get; set; }
    public string Status { get; protected set; }
    public string Currency { get; set; }
    public string Comment { get; set; }
    private List<Item> items = new List<Item>();
    public Order(int id) { OrderId = id; CreationDate = DateTime.Today; Status = "Новый"; CustomerName = "Андрей"; Currency = "RUB"; Comment = ""; }
    public virtual decimal CalculateTotal() { decimal sum = 0; foreach (Item item in items) sum += item.Price; return sum; }
    public virtual void AddItem(Item item) { if (item == null) throw new ArgumentNullException("item"); items.Add(item); Console.WriteLine("Добавлен: " + item.Name); }
    public void AddItem(string name, decimal price) { AddItem(new Item(name, price)); }
    public void AddItem(Item item, int count) { if (count < 1) throw new ArgumentOutOfRangeException("count"); for (int i = 0; i < count; i++) AddItem(item); }
    public decimal CalculateTotal(decimal deliveryCost) { if (deliveryCost < 0) throw new ArgumentOutOfRangeException("deliveryCost"); return CalculateTotal() + deliveryCost; }
    public virtual void RemoveItem(Item item) { if (items.Remove(item)) Console.WriteLine("Удалён: " + item.Name); else Console.WriteLine("Товар не найден"); }
    protected bool HasItem(Item item) { return items.Contains(item); }
    public void ChangeCustomer(string name) { CustomerName = name; }
    public void SetComment(string text) { Comment = text; }
    public void Cancel() { Status = "Отменён"; }
    public virtual void DisplayInfo() { Console.WriteLine("Заказ " + OrderId + ": " + CustomerName + ", " + Status + ", сумма " + TotalAmount + " " + Currency); }
}
public class OnlineOrder : Order, IPayable, ITrackable
{
    public string CustomerEmail { get; set; }
    public string DeliveryMethod { get; set; }
    public string TrackingNumber { get; set; }
    public string PaymentMethod { get; set; }
    public string Website { get; set; }
    public bool IsPaid { get; private set; }
    public OnlineOrder(int id, string email) : base(id) { CustomerEmail = email; DeliveryMethod = "Курьер"; TrackingNumber = "Не назначен"; PaymentMethod = "Карта"; Website = "shop.example.com"; }
    public override void AddItem(Item item) { base.AddItem(item); Console.WriteLine("Доставка: " + DeliveryMethod + ", email: " + CustomerEmail); }
    public void ChangeDelivery(string method) { DeliveryMethod = method; }
    public void SendConfirmation() { Console.WriteLine("Подтверждение заказа для " + CustomerEmail); }
    public void Pay() { if (Status == "Отменён") throw new InvalidOperationException("Заказ отменён"); IsPaid = true; Status = "Оплачен"; Console.WriteLine("Оплата: " + PaymentMethod); }
    public void Track() { Console.WriteLine("Номер отслеживания: " + TrackingNumber); }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Онлайн: " + Website + ", " + DeliveryMethod); }
}
public class PhysicalOrder : Order
{
    public string DeliveryAddress { get; set; }
    public string StoreName { get; set; }
    public string SellerName { get; set; }
    public DateTime PickupDate { get; set; }
    public string ReceiptNumber { get; set; }
    public PhysicalOrder(int id, string address) : base(id) { DeliveryAddress = address; StoreName = "Книги"; SellerName = "Иван"; PickupDate = DateTime.Today; ReceiptNumber = "Не выдан"; }
    public override void RemoveItem(Item item) { bool found = HasItem(item); base.RemoveItem(item); if (found) Console.WriteLine("Возврат товара. Адрес: " + DeliveryAddress); }
    public void ChangeAddress(string address) { DeliveryAddress = address; }
    public void SetPickupDate(DateTime date) { PickupDate = date; }
    public void PrintReceipt() { Console.WriteLine("Чек " + ReceiptNumber + ", сумма: " + TotalAmount); }
    public void ShowStore() { Console.WriteLine(StoreName + ", продавец: " + SellerName); }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Адрес: " + DeliveryAddress); }
}
public class SpecializedOrder : Order
{
    public string SpecialConditions { get; private set; }
    public string Category { get; set; }
    public string ManagerName { get; set; }
    public DateTime Deadline { get; set; }
    public bool RequiresApproval { get; set; }
    private decimal discount;
    public decimal Discount { get { return discount; } }
    public SpecializedOrder(int id, decimal value) : base(id) { Category = "Учебные товары"; ManagerName = "Ольга"; Deadline = DateTime.Today.AddDays(7); RequiresApproval = true; SetDiscount(value); }
    public void SetDiscount(decimal value) { if (value < 0 || value > 100) throw new ArgumentOutOfRangeException("value"); discount = value; SpecialConditions = "Скидка " + value + "%"; }
    public override decimal CalculateTotal() { return base.CalculateTotal() * (1 - discount / 100); }
    public void ExtendDeadline(int days) { if (days < 0) throw new ArgumentOutOfRangeException("days"); Deadline = Deadline.AddDays(days); }
    public void Approve() { RequiresApproval = false; Status = "Согласован"; }
    public void ShowConditions() { Console.WriteLine(SpecialConditions + ", категория: " + Category); }
    public override void DisplayInfo() { base.DisplayInfo(); ShowConditions(); }
}
public class ExpressOnlineOrder : OnlineOrder
{
    public int DeliveryHours { get; set; }
    public string CourierName { get; set; }
    public string CourierPhone { get; set; }
    public bool IsDispatched { get; private set; }
    public ExpressOnlineOrder(int id, string email) : base(id, email) { DeliveryHours = 2; CourierName = "Павел"; CourierPhone = "Не указан"; DeliveryMethod = "Экспресс"; }
    public void AssignCourier(string name) { CourierName = name; }
    public void SetDeliveryHours(int hours) { if (hours <= 0) throw new ArgumentOutOfRangeException("hours"); DeliveryHours = hours; }
    public void Dispatch() { if (!IsPaid) throw new InvalidOperationException("Сначала оплатите заказ"); IsDispatched = true; Status = "Отправлен"; }
    public void ShowCourier() { Console.WriteLine("Курьер: " + CourierName + ", " + CourierPhone); }
    public override void DisplayInfo() { base.DisplayInfo(); Console.WriteLine("Доставка за " + DeliveryHours + " ч."); }
}
public class OrderCollection<T> where T : Order
{
    private List<T> orders = new List<T>();
    public int Count { get { return orders.Count; } }
    public void Add(T order) { if (order == null) throw new ArgumentNullException("order"); orders.Add(order); }
    public bool Remove(T order) { return orders.Remove(order); }
    public void DisplayOrders() { foreach (T order in orders) order.DisplayInfo(); }
    public decimal CalculateTotal() { decimal total = 0; foreach (T order in orders) total += order.CalculateTotal(); return total; }
}
public static void Run()
{
Item book = new Item("Книга", 500);
Item pen = new Item("Ручка", 100);
OnlineOrder online = new OnlineOrder(1, "andrey@example.com");
PhysicalOrder physical = new PhysicalOrder(2, "Тюмень, ул. Республики, 1");
SpecializedOrder special = new SpecializedOrder(3, 10);
ExpressOnlineOrder express = new ExpressOnlineOrder(4, "andrey@example.com");
Order[] orders = { online, physical, special, express };
foreach (Order order in orders) { order.AddItem(book); order.AddItem(pen); order.DisplayInfo(); }
physical.RemoveItem(pen);
physical.RemoveItem(pen);
physical.PrintReceipt();
online.ChangeDelivery("Пункт выдачи"); online.SendConfirmation();
IPayable payment = express; payment.Pay();
ITrackable tracking = express; tracking.Track();
express.AssignCourier("Сергей"); express.SetDeliveryHours(3); express.Dispatch(); express.ShowCourier();
special.ExtendDeadline(2); special.Approve(); special.ShowConditions();
online.ChangeCustomer("Андрей Бубнов"); online.SetComment("После занятий"); online.DisplayInfo();
online.AddItem("Тетрадь", 50);
special.AddItem(new Item("Карандаш", 50), 2);
Console.WriteLine("Со стоимостью доставки: " + special.CalculateTotal(100));
OrderCollection<Order> collection = new OrderCollection<Order>();
foreach (Order order in orders) collection.Add(order);
collection.DisplayOrders();
Console.WriteLine("Общая сумма: " + collection.CalculateTotal());
collection.Remove(physical);
Console.WriteLine("Заказов после удаления: " + collection.Count);
OrderCollection<OnlineOrder> onlineOrders = new OrderCollection<OnlineOrder>();
onlineOrders.Add(online); onlineOrders.Add(express); onlineOrders.DisplayOrders();
}
}

public class Program { public static void Main() { Sprint3Task3.Run(); } }
