using System;

class Song
{
    string name;
    string author;
    Song prev;

    // 1) Конструктор: название и автор. prev = null по умолчанию
    public Song(string n, string a)
    {
        name = n;
        author = a;
        prev = null;
    }

    // 2) Конструктор: название, автор и предыдущая песня
    public Song(string n, string a, Song p)
    {
        name = n;
        author = a;
        prev = p;
    }

    // ИСПРАВЛЕНИЕ ОШИБКИ: Конструктор без параметров (по умолчанию)
    public Song()
    {
        name = "Неизвестно";
        author = "Неизвестно";
        prev = null;
    }

    // Метод для вывода названия и автора
    public string Title()
    {
        return name + " - " + author;
    }
}

class Program
{
    static void Main()
    {
        // Создаем первую песню (используем конструктор 1)
        Song song1 = new Song("Bohemian Rhapsody", "Queen");

        // Создаем вторую песню, передавая ссылку на первую (используем конструктор 2)
        Song song2 = new Song("Imagine", "John Lennon", song1);

        // Тот самый вызов из задания, который вызывал бы ошибку без 3-го конструктора
        Song mySong = new Song(); 

        // Выводим результат, чтобы убедиться, что всё работает
        Console.WriteLine("Песня 1: " + song1.Title());
        Console.WriteLine("Песня 2: " + song2.Title());
        Console.WriteLine("mySong:  " + mySong.Title()); // Выведет "Неизвестно - Неизвестно"
        
        Console.ReadKey();
    }
}