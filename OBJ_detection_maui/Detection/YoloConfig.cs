using Microsoft.Maui.Storage;

namespace OBJ_detection_maui.Detection
{
    /// <summary>
    /// Model configuration for YOLO.
    /// </summary>
    public static class YoloConfig
    {
        public static string ModelPath => Path.Combine(FileSystem.AppDataDirectory, "yolov4.onnx");

        public static class Input
        {
            public const int Width = 416;
            public const int Height = 416;
            public const int Channels = 3;
            public const string Name = "input_1:0";
        }

        public static class Output
        {
            public const string BoundingBoxes = "Identity:0";
        }
    }


}
