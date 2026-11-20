using System;
using System.Collections.Generic;
using System.IO; // Нужно для работы с файлами

public class BankTransaction
{
    public readonly DateTime Date;
    public readonly decimal Amount;

    public BankTransaction(decimal amount)
    {
        Date = DateTime.Now;
        Amount = amount;
    }
}

// Наследуемся от IDisposable, чтобы использовать Dispose
public class BankAccount : IDisposable 
{
    private decimal _balance;
    private Queue<BankTransaction> _transactions = new Queue<BankTransaction>();

    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        _transactions.Enqueue(new BankTransaction(amount));
    }

    public bool Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            _transactions.Enqueue(new BankTransaction(-amount));
            return true;
        }
        return false;
    }

    // Тот самый метод Dispose
    public void Dispose()
    {
        // Открываем файл для записи
        using (StreamWriter writer = new StreamWriter("transactions.txt"))
        {
            // Достаем всё из очереди, пока она не опустеет
            while (_transactions.Count > 0)
            {
                BankTransaction t = _transactions.Dequeue();
                writer.WriteLine("Дата: " + t.Date + " | Сумма: " + t.Amount);
            }
        }
        
        // Говорим системе не вызывать финализатор
        GC.SuppressFinalize(this);
        Console.WriteLine("Все данные сохранены в файл transactions.txt");
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount(1000);
        acc.Deposit(500);
        acc.Withdraw(200);

        // Вызываем Dispose вручную, чтобы сохранить в файл
        acc.Dispose(); 
    }
}