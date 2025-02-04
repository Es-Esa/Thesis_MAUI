using Microsoft.Maui.Controls;
using OBJ_detection_maui.Detection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OBJ_detection_maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(() => RunYoloDetection()); // Run detection in background
        }

        private void RunYoloDetection()
        {
            try
            {
                //Run on the copied image
                string imagePath = Path.Combine(FileSystem.AppDataDirectory, "test_image.jpg");

                if (!File.Exists(imagePath))
                {
                    Dispatcher.Dispatch(() => ResultLabel.Text = "Error: Test image not found!");
                    return;
                }

                
                using Stream imageStream = File.OpenRead(imagePath);
                YoloDetector detector = new();
                float[] detections = detector.Detect(imageStream);

                Dispatcher.Dispatch(() =>
                {
                    //Printing Detections coordinates
                    ResultLabel.Text = $"Detections: {string.Join(", ", detections)}";
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Dispatch(() => ResultLabel.Text = $"Error: {ex.Message}");
            }
        }
    }
}
