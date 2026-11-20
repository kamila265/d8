using System;

public enum AccountType { Savings, Checking, Credit }

public class BankAccount
{
    private static int _nextNumber = 1000;
    private string _number;
    private decimal _balance;
    private AccountType _type;

    // 1. Конструктор по умолчанию
    public BankAccount()
    {
        GenerateNumber();
    }

    // 2. Конструктор только для баланса
    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
        GenerateNumber();
    }

    // 3. Конструктор только для типа
    public BankAccount(AccountType type)
    {
        _type = type;
        GenerateNumber();
    }

    // 4. Конструктор для баланса и типа
    public BankAccount(AccountType type, decimal initialBalance)
    {
        _type = type;
        _balance = initialBalance;
        GenerateNumber();
    }

    // Метод генерации номера (вызывается внутри каждого конструктора)
    private void GenerateNumber()
    {
        _nextNumber++;
        _number = "ACC-" + _nextNumber;
        Console.WriteLine("Создан счет: " + _number);
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount();
        BankAccount acc2 = new BankAccount(1500);
        BankAccount acc3 = new BankAccount(AccountType.Credit);
        BankAccount acc4 = new BankAccount(AccountType.Savings, 5000);
    }
}