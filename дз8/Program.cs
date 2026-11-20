using System;
using System.Collections.Generic; // Нужно для Queue

public enum AccountType { Savings, Checking, Credit }

// Новый класс для транзакции
public class BankTransaction
{
    public readonly DateTime Date;
    public readonly decimal Amount;

    public BankTransaction(decimal amount)
    {
        Date = DateTime.Now; // Запоминаем текущее время
        Amount = amount;     // Запоминаем сумму
    }
}

public class BankAccount
{
    private string _number;
    private decimal _balance;
    
    // Очередь транзакций (как в задании)
    private Queue<BankTransaction> _transactions = new Queue<BankTransaction>();

    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
        _number = "ACC-1000";
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        
        // Создаем транзакцию и кладем в очередь
        BankTransaction trans = new BankTransaction(amount);
        _transactions.Enqueue(trans); 
    }

    public bool Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            
            // Создаем транзакцию (с минусом) и кладем в очередь
            BankTransaction trans = new BankTransaction(-amount);
            _transactions.Enqueue(trans);
            return true;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount(1000);
        acc.Deposit(500);
        acc.Withdraw(200);
        
        Console.WriteLine("Транзакции добавлены в очередь.");
    }
}