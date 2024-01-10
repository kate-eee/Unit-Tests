using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.GetHelp();
        Console.Out.WriteLine("Введите путь к файлу с контактами или введите 0, если его нет");
        string path = Console.In.ReadLine(); ;
        Console.Out.WriteLine("Введите формат файла\n" +
                              "1 - json\n" +
                              "2 - xml\n" +
                              "3 - sqlite");
        int fileExt = Convert.ToInt32(Console.In.ReadLine());

        Notebook notebook;
        if (path != "0")
        {
            if (!File.Exists(path))
            {
                Console.Out.WriteLine("Нет файла с таким путем");
            }

            IStorageService storageService;
            if (fileExt == 1)
            {
                storageService = new JsonStorageService();
            }
            else if (fileExt == 2)
            {
                storageService = new XmlStorageService();
            }
            else if (fileExt == 3)
            {
                storageService = new SqliteStorageService();
            }
            else
            {
                return;
            }

            var saver = new NotebookSaver(storageService);
            notebook = saver.LoadFromFile(path);
        }
        else
        {
            notebook = new Notebook(new List<NotebookEntry>());
        }

        while (true)
        {
            Console.Out.WriteLine("Введите номер команды");
            int commandId = Convert.ToInt16(Console.ReadLine());
            if (commandId == 5)
            {
                break;
            }

            switch (commandId)
            {
                case 1:
                    // add contact
                    Console.Out.WriteLine("Введите имя:");
                    string name = Console.ReadLine();

                    Console.Out.WriteLine("Введите фамилию:");
                    string surname = Console.ReadLine();

                    Console.Out.WriteLine("Введите номер телефона:");
                    string phoneNumber = Console.ReadLine();

                    Console.Out.WriteLine("Введите электронную почту:");
                    string email = Console.ReadLine();

                    notebook.AddContact(name, surname, phoneNumber, email);
                    Console.Out.WriteLine();
                    break;

                case 2:
                    // find contact
                    /* todo: справка по критериям поиска
                    1 - name
                    2 - surname
                    3 - phone
                    4 - email
                    5 - all
                    */
                    int searchBy = Convert.ToInt16(Console.ReadLine());
                    NotebookEntry? found = null;
                    if (searchBy == 1)
                    {
                        Console.Out.WriteLine("Введите имя:");
                        string contactName = Console.In.ReadLine();
                        found = notebook.FindContactByName(contactName);
                    }
                    else if (searchBy == 2)
                    {
                        Console.Out.WriteLine("Введите фамилию:");
                        string contactSurname = Console.In.ReadLine();
                        found = notebook.FindContactBySurname(contactSurname);
                    }
                    else if (searchBy == 3)
                    {
                        Console.Out.WriteLine("Введите номер телефона:");
                        string contactPhoneNumber = Console.In.ReadLine();
                        found = notebook.FindContactByPhoneNumber(contactPhoneNumber);
                    }
                    else if (searchBy == 4)
                    {
                        Console.Out.WriteLine("Введите электронную почту:");
                        string contactEmail = Console.In.ReadLine();
                        found = notebook.FindContactByEmail(contactEmail);
                    }
                    else if (searchBy == 5)
                    {
                        Console.Out.WriteLine("Введите имя:");
                        string contactName = Console.In.ReadLine();
                        Console.Out.WriteLine("Введите фамилию:");
                        string contactSurname = Console.In.ReadLine();
                        Console.Out.WriteLine("Введите номер телефона:");
                        string contactPhoneNumber = Console.In.ReadLine();
                        Console.Out.WriteLine("Введите электронную почту:");
                        string contactEmail = Console.In.ReadLine();

                        found = notebook.FindContact(contactName, contactSurname, contactPhoneNumber, contactEmail);
                    }

                    if (found is not null)
                    {
                        ConsoleHelper.ShowContact(found);
                    }
                    else
                    {
                        Console.Out.WriteLine("Не существует такого контакта");
                    }

                    break;

                case 3:
                    // show all contacts
                    foreach (var entry in notebook.Archive)
                    {
                        ConsoleHelper.ShowContact(entry);
                    }
                    break;

                case 4:
                    // сохранение в файл
                    Console.Out.WriteLine("Введите путь к файлу, в который вы хотите сохранить базу:");
                    path = Console.In.ReadLine();
                    Console.Out.WriteLine("Введите, в каком формате вы хотите сохранить базу:\n" +
                                          "1 - JSON\n" +
                                          "2 - XML\n" +
                                          "3 - sqlite");
                    Int32.TryParse(Console.In.ReadLine(), out var mode);

                    IStorageService storageService;
                    if (mode == 1)
                    {
                        storageService = new JsonStorageService();
                    }
                    else if (mode == 2)
                    {
                        storageService = new XmlStorageService();
                    }
                    else if (mode == 3)
                    {
                        storageService = new SqliteStorageService();
                    }
                    else
                    {
                        return;
                    }

                    var saver = new NotebookSaver(storageService);
                    saver.Save(path, notebook);

                    break;
            }
        }

    }
}

