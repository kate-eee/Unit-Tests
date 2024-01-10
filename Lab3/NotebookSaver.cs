using System.Text.Json;
using System.Xml.Serialization;

namespace Lab3;

public class NotebookSaver
{
    private readonly IStorageService _storageService;

    public NotebookSaver(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Save(string path, Notebook notebook)
    {
        _storageService.Save(path, notebook);
    }

    public Notebook LoadFromFile(string path)
    {
        return _storageService.Load(path);
    }
}