namespace Lab3;

public static class ConsoleHelper
{
    public static void GetHelp()
    {
        Console.Out.WriteLine("Список команд:");
        Console.Out.WriteLine("1) Чтобы создать новый контакт, нажмите 1");
        Console.Out.WriteLine("2) Чтобы найти контакт по 1 признаку, нажмите 2");
        Console.Out.WriteLine("3) Чтобы создать найти контакт по всем признакам, нажмите 3");
        Console.Out.WriteLine("4) Чтобы сохранить контакт в файл, нажмите 4");
    }

    public static void GetAddContactInformation()
    {
        Console.Out.WriteLine("Введите имя, фамилию, номер телефона и почту");
    }

    public static void GetFindContactInformation()
    {
        Console.Out.WriteLine("Введитя имя/фамилию/телефон/почту, чтобы найти контакт");
    }

    public static void GetListContactInformation()
    {
        Console.Out.WriteLine("Введитя имя, фамилию, телефон, почту, чтобы найти контакт");
    }

    public static void ShowContact(NotebookEntry entry)
    {
        // выводим информацию об одном контакте 
        Console.WriteLine("Имя: " + entry.Name);
        Console.WriteLine("Фамилия: " + entry.Surname);
        Console.WriteLine("Номер телефона: " + entry.PhoneNumber);
        Console.WriteLine("Электронная почта: " + entry.Email);

        Console.Out.WriteLine();
    }
}