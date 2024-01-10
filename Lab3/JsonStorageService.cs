using System.Text.Json;

namespace Lab3;

public class JsonStorageService : IStorageService
{
    public void Save(string path, Notebook notebook)
    {
        StreamWriter writetext = new StreamWriter(File.Create(path));
        string jsonString = JsonSerializer.Serialize(notebook.Archive);
        writetext.Write(jsonString);
        writetext.Flush();
        writetext.Close();
    }

    public Notebook Load(string path)
    {
        TextReader reader = new StreamReader(path);
        string input = reader.ReadToEnd();
        var archive = JsonSerializer.Deserialize<List<NotebookEntry>>(input);
        reader.Close();

        return new Notebook(archive);
    }
}