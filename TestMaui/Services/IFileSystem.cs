
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMaui.Services;

[assembly: Dependency(typeof(IOSFileSystem))]
namespace TestMaui.Services
{
    public interface IFileSystem
    {
        Task WriteTextAsync(string filename, string text);
    }

    public class IOSFileSystem : IFileSystem
    {
        public async Task WriteTextAsync(string filename, string text)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docsPath, filename);
            using (var writer = File.CreateText(path)) 
            {
                await writer.WriteAsync(text);
            }
        }
    }

    public class WinFileSystem : IFileSystem
    {
        public async Task WriteTextAsync(string filename, string text)
        {
            //var docsPath = ApplicationData.Current.LocalFolder;
            //var storage = await docsPath..createFileAsync(filename);
            //await FileIO.writetextsync(storage,text)
        }
    }
}
