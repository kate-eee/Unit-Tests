using Lab2;
using Xunit;

namespace Lab2Tests;

public class NotebookTests
{
    public static IEnumerable<object[]> TestAddContactData()
    {
        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
            },
            new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {

            },
            new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
        };
    }

    public static IEnumerable<object[]> TestFindContactByNameData()
    {
        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
                new NotebookEntry("Nick", "White", "+79997772343", "nw@gmail.com"),
            },
            "Nick",
            new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
            },
            "Ronald",
            null
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {

            },
            "Smb",
            null
        };
    }

    public static IEnumerable<object[]> TestFindContactBySurnameData()
    {
        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
                new NotebookEntry("Ronald", "Smirnov", "+79997772343", "rs@gmail.com"),
            },
            "Smirnov",
            new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
            },
            "Brown",
            null
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {

            },
            "Smb",
            null
        };
    }

    public static IEnumerable<object[]> TestFindContactByPhoneNumberData()
    {
        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
                new NotebookEntry("Ronald", "Smirnov", "+79997778866", "rs@gmail.com"),
            },
            "+79997778866",
            new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
            },
            "+79997778865",
            null
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {

            },
            "+79997778866",
            null
        };
    }

    public static IEnumerable<object[]> TestFindContactByEmailData()
    {
        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
                new NotebookEntry("Ronald", "Smirnov", "+79997778866", "ns@gmail.com"),
            },
            "ns@gmail.com",
            new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
            },
            "qwerty@gmail.com",
            null
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {

            },
            "ns@gmail.com",
            null
        };
    }

    public static IEnumerable<object[]> TestFindContactData()
    {
        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
                new NotebookEntry("Ronald", "Smirnov", "+79997778866", "ns@gmail.com"),
            },
            new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
            new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {
                new NotebookEntry("Andrew", "Petrov", "+79998887766", "ap@gmail.com"),
                new NotebookEntry("Nick", "Smirnov", "+79997778866", "ns@gmail.com"),
                new NotebookEntry("Mike", "Kozlov", "+79996667788", "mk@gmail.com"),
                new NotebookEntry("Sam", "Alt", "+79994443322", "sa@gmail.com"),
            },
            new NotebookEntry("Nick", "Smirnovich", "+79997778866", "ns@gmail.com"),
            null
        };

        yield return new object[]
        {
            new List<NotebookEntry>() {

            },
            new NotebookEntry("Nick", "Smirnovich", "+79997778866", "ns@gmail.com"),
            null
        };
    }

    [Theory]
    [MemberData(nameof(TestAddContactData))]
    public void AddContact_ShouldAddEntryCorrectly(
        List<NotebookEntry> list,
        NotebookEntry entryToAdd)
    {
        var notebook = new Notebook(list);
        int len = list.Count;

        notebook.AddContact(
            entryToAdd.Name,
            entryToAdd.Surname,
            entryToAdd.PhoneNumber,
            entryToAdd.Email);

        Assert.Equal(len + 1, notebook.Archive.Count);

        var last = notebook.Archive.Last();
        Assert.Equal(entryToAdd.Name, last.Name);
        Assert.Equal(entryToAdd.Surname, last.Surname);
        Assert.Equal(entryToAdd.PhoneNumber, last.PhoneNumber);
        Assert.Equal(entryToAdd.Email, last.Email);
    }

    [Theory]
    [MemberData(nameof(TestFindContactByNameData))]
    public void FindContactByName_ShouldFindCorrectEntry(
        List<NotebookEntry> list,
        string nameToFindBy,
        NotebookEntry? entryToBeFound)
    {
        var notebook = new Notebook(list);

        var entry = notebook.FindContactByName(nameToFindBy);

        if (entryToBeFound is null)
        {
            Assert.Null(entry);
            return;
        }

        Assert.NotNull(entry);

        Assert.Equal(entryToBeFound.Name, entry.Name);
        Assert.Equal(entryToBeFound.Surname, entry.Surname);
        Assert.Equal(entryToBeFound.PhoneNumber, entry.PhoneNumber);
        Assert.Equal(entryToBeFound.Email, entry.Email);
    }

    [Theory]
    [MemberData(nameof(TestFindContactBySurnameData))]
    public void FindContactBySurname_ShouldFindCorrectEntry(
        List<NotebookEntry> list,
        string surnameToFindBy,
        NotebookEntry? entryToBeFound)
    {
        var notebook = new Notebook(list);

        var entry = notebook.FindContactBySurname(surnameToFindBy);

        if (entryToBeFound is null)
        {
            Assert.Null(entry);
            return;
        }

        Assert.NotNull(entry);

        Assert.Equal(entryToBeFound.Name, entry.Name);
        Assert.Equal(entryToBeFound.Surname, entry.Surname);
        Assert.Equal(entryToBeFound.PhoneNumber, entry.PhoneNumber);
        Assert.Equal(entryToBeFound.Email, entry.Email);
    }

    [Theory]
    [MemberData(nameof(TestFindContactByPhoneNumberData))]
    public void FindContactByPhoneNumber_ShouldFindCorrectEntry(
        List<NotebookEntry> list,
        string phoneNumberToFindBy,
        NotebookEntry? entryToBeFound)
    {
        var notebook = new Notebook(list);

        var entry = notebook.FindContactByPhoneNumber(phoneNumberToFindBy);

        if (entryToBeFound is null)
        {
            Assert.Null(entry);
            return;
        }

        Assert.NotNull(entry);

        Assert.Equal(entryToBeFound.Name, entry.Name);
        Assert.Equal(entryToBeFound.Surname, entry.Surname);
        Assert.Equal(entryToBeFound.PhoneNumber, entry.PhoneNumber);
        Assert.Equal(entryToBeFound.Email, entry.Email);
    }

    [Theory]
    [MemberData(nameof(TestFindContactByEmailData))]
    public void FindContactByPhoneEmail_ShouldFindCorrectEntry(
        List<NotebookEntry> list,
        string emailToFindBy,
        NotebookEntry? entryToBeFound)
    {
        var notebook = new Notebook(list);

        var entry = notebook.FindContactByEmail(emailToFindBy);

        if (entryToBeFound is null)
        {
            Assert.Null(entry);
            return;
        }

        Assert.NotNull(entry);

        Assert.Equal(entryToBeFound.Name, entry.Name);
        Assert.Equal(entryToBeFound.Surname, entry.Surname);
        Assert.Equal(entryToBeFound.PhoneNumber, entry.PhoneNumber);
        Assert.Equal(entryToBeFound.Email, entry.Email);
    }

    [Theory]
    [MemberData(nameof(TestFindContactData))]
    public void FindContact_ShouldFindCorrectEntry(
        List<NotebookEntry> list,
        NotebookEntry entryToFindBy,
        NotebookEntry? entryToBeFound)
    {
        var notebook = new Notebook(list);

        var entry = notebook.FindContact(
            entryToFindBy.Name,
            entryToFindBy.Surname,
            entryToFindBy.PhoneNumber,
            entryToFindBy.Email);

        if (entryToBeFound is null)
        {
            Assert.Null(entry);
            return;
        }

        Assert.NotNull(entry);

        Assert.Equal(entryToBeFound.Name, entry.Name);
        Assert.Equal(entryToBeFound.Surname, entry.Surname);
        Assert.Equal(entryToBeFound.PhoneNumber, entry.PhoneNumber);
        Assert.Equal(entryToBeFound.Email, entry.Email);
    }
}