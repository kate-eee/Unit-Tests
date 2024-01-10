using Lab3;
using Moq;
using Xunit;

namespace Lab3Tests;

public class NotebookSaverTests
{
    [Fact]
    void Save_ShouldCallServiceMethod()
    {
        var mock = new Mock<IStorageService>();
        var saver = new NotebookSaver(mock.Object);

        var notebook = new Notebook(new List<NotebookEntry>());
        var path = "path";

        saver.Save(path, notebook);

        mock.Verify(m => m.Save(path, notebook), Times.Once);
    }

    [Fact]
    void LoadFromFile_ShouldCallServiceMethod()
    {
        var mock = new Mock<IStorageService>();
        var saver = new NotebookSaver(mock.Object);

        var path = "path";

        saver.LoadFromFile(path);

        mock.Verify(m => m.Load(path), Times.Once);
    }
}