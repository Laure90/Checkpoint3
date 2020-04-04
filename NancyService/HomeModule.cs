using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using Microsoft.Win32;
using System.IO;
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
            Get("/file/{pathFile}", parameter => ReturnFileContent(parameter.pathFile));
            Put("/file/{pathFile}", parameter => CreateFile(parameter.pathFile));
            Delete("/file/{pathFile}", parameter => DeleteFile(parameter.pathFile));
        }

        public dynamic ReturnFileContent(string filePath)
        {
            string fp = "TestFile/" + filePath;
            string jsonString;
            if (File.Exists(fp))
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
            string fp = "TestFile/" + filePath;
            string jsonString;
            if (File.Exists(fp))
            {
                File.Delete(fp);
                jsonString = System.Text.Json.JsonSerializer.Serialize("File deleted");
            }
            else
            {
                jsonString = System.Text.Json.JsonSerializer.Serialize("The file doesn't exist.");
            }            
            return jsonString;
        }

        public dynamic CreateFile(string filePath)
        {
            string jsonString;
            string path = "TestFile/" + filePath;
            if (!File.Exists(path))
            {
                FilePath newFile = new FilePath();
                newFile.Path = path;
               
                FileStream currentFIle = File.Create(newFile.Path);
                currentFIle.Close();
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
