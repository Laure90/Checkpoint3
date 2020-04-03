using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NancyService
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Hello world");
            Get("/file/{pathFile}", parameter =>
            {
                string fp = "TestFile/" + parameter.FilePath;
                string readText = File.ReadAllText(fp);
                string jsonString;
                jsonString = System.Text.Json.JsonSerializer.Serialize(readText);
                return jsonString;
            });
            //Get("/delete/file/{pathFile}", parameter => DeleteFile(parameter.Path));
            //Get("/put/file/{pathFile}", parameters => CreateFile(parameters.Path, parameters.Name));
        }

        public dynamic ReturnFileData(string filePath)
        {
            string fp = "TestFile/" + filePath;
            string jsonString;
            if (!File.Exists(fp))
            {
                string readText = File.ReadAllText(fp);
                jsonString = System.Text.Json.JsonSerializer.Serialize(readText);
            }
            else
            {
                jsonString = System.Text.Json.JsonSerializer.Serialize("The file doesn't exist.");
            }
            return jsonString;
        }

        public dynamic DeleteFile(string filePath)
        {
            string fp = "@" + filePath;
            File.Delete(fp);
            return "File deleted";
        }

        public dynamic CreateFile(string filePath, string name)
        {
            string jsonString;
            string path = "@" + filePath;
            if (!File.Exists(path))
            {
                FilePath newFile = new FilePath();
                newFile.Path = filePath;
                newFile.Name = name + ".txt";
                File.Create(newFile.Path);
                jsonString = System.Text.Json.JsonSerializer.Serialize("File is created");
                return jsonString;
            }
            else
            {
                jsonString = System.Text.Json.JsonSerializer.Serialize("File already exists");
                return jsonString;
            }
        }
    }
}
