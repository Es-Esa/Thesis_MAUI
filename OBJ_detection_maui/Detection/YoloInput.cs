using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;
using System.IO;
using System.Collections.Generic;


namespace OBJ_detection_maui.Detection
{


    /// <summary>
    /// Represents the input data for the YOLO model.
    /// </summary>
    public class YoloInput
    {
        [ImageType(YoloConfig.Input.Height, YoloConfig.Input.Width)]
        public MLImage Image { get; set; } = null!;

        public static YoloInput FromStream(Stream stream)
        {
            var image = MLImage.CreateFromStream(stream);
            return new YoloInput { Image = image };
        }
    }


}
