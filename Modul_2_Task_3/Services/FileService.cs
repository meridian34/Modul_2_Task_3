using System;
using System.IO;
using Modul_2_Task_3.Model;
using Modul_2_Task_3.Services.Abstract;

namespace Modul_2_Task_3.Services
{
    public class FileService : IFileService
    {
        private readonly DateTime _dateTimeOfRecording;
        public FileService()
        {
            _dateTimeOfRecording = DateTime.Now;
        }

        public void Write(string text, LogConfigData writeConfig)
        {
            var fileDirectory = AppDomain.CurrentDomain.BaseDirectory + writeConfig.DirectoryPath;
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            string[] files = Directory.GetFiles(fileDirectory, $"{writeConfig.FileNameTemplate}*");
            if (files.Length < writeConfig.CountStoredFiles)
            {
                var currentDate = DateTime.Now;
                var newFile = $"{fileDirectory}/{writeConfig.FileNameTemplate}{_dateTimeOfRecording.ToString(writeConfig.TimeTemplate)} " +
                    $"{currentDate.ToString(writeConfig.DateTemplate)}{writeConfig.FileExtension}";

                using (var stream = new FileStream(newFile, FileMode.Append, FileAccess.Write))
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(text);
                }
            }
            else
            {
                var curentFileDateCreation = DateTime.MinValue;
                string fileForDelete = null;
                foreach (var file in files)
                {
                    if (File.GetCreationTime(file) > curentFileDateCreation)
                    {
                        fileForDelete = file;
                    }
                }

                File.Delete(fileForDelete);
                Write(text, writeConfig);
            }
        }
    }
}
