using Microsoft.ML.Data;

namespace OBJ_detection_maui.Detection
{


    /// <summary>
    /// Represents the input data for the YOLO model.
    /// </summary>
    public class YoloOutput
    {
        [ColumnName(YoloConfig.Output.BoundingBoxes)]
        public float[] BoundingBoxes { get; set; } = null!;
    }

}
