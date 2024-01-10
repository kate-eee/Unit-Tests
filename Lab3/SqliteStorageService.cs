namespace Lab3;

public class SqliteStorageService : IStorageService
{
    public void Save(string path, Notebook notebook)
    {
        using (var context = new NotebookContext(path))
        {
            context.Database.EnsureCreated();
            context.RemoveRange(context.Archive);
            context.SaveChanges();
            context.AddRange(notebook.Archive);
            context.SaveChanges();
        }
    }

    public Notebook Load(string path)
    {
        using (var context = new NotebookContext(path))
        {
            var archive = context.Archive.ToList();
            return new Notebook(archive);
        }
    }
}
