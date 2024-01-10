using System.Xml.Serialization;
using System.Xml.Serialization;

namespace Lab3;

public class XmlStorageService : IStorageService
{
    public void Save(string path, Notebook notebook)
    {
        StreamWriter writetext = new StreamWriter(File.Create(path));
        var xmlSerializer = new XmlSerializer(typeof(List<NotebookEntry>));
        xmlSerializer.Serialize(writetext, notebook.Archive);
        writetext.Flush();
        writetext.Close();
    }

    public Notebook Load(string path)
    {
        var mySerializer = new XmlSerializer(typeof(List<NotebookEntry>), new XmlRootAttribute("ArrayOfNotebookEntry"));
        var myFileStream = new FileStream(path, FileMode.Open);
        var archive = (List<NotebookEntry>)mySerializer.Deserialize(myFileStream);
        myFileStream.Close();

        return new Notebook(archive);
    }
}