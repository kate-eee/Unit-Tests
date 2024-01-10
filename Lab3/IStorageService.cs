namespace Lab3;

public interface IStorageService
{
    void Save(string path, Notebook notebook);
    Notebook Load(string path);
}