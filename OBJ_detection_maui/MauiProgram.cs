using Microsoft.Maui;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OBJ_detection_maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            // Copy model file from "Resources/Raw/Models/" to AppDataDirectory
            CopyFileToAppData("Models/yolov4.onnx", "yolov4.onnx");
            CopyFileToAppData("test_image.jpg", "test_image.jpg");

            return builder.Build();
        }


        /// <summary>
        /// Copy file from "Resources/Raw/" to AppDataDirectory
        /// I had GIT Ignore them you need to download the model from https://github.com/onnx/models/blob/main/validated/vision/object_detection_segmentation/yolov4/model/yolov4.onnx
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destinationFileName"></param>
        private static void CopyFileToAppData(string sourceFileName, string destinationFileName)
        {
            string destinationPath = Path.Combine(FileSystem.AppDataDirectory, destinationFileName);

            if (!File.Exists(destinationPath))
            {
                using Stream sourceStream = FileSystem.OpenAppPackageFileAsync(sourceFileName).Result;
                using FileStream destinationStream = File.Create(destinationPath);
                sourceStream.CopyTo(destinationStream);
            }
        }
    }
}
