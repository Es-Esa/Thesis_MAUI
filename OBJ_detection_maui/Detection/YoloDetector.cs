using Microsoft.ML;
using Microsoft.ML.Transforms.Image;
using System.Collections.Generic;
using System.IO;

namespace OBJ_detection_maui.Detection
{

    /// <summary>
    /// Represents the input data for the YOLO model.
    /// </summary>
    public class YoloDetector
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<YoloInput, YoloOutput> _engine;


        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public YoloDetector()
        {
            Console.WriteLine($"Looking for model at: {YoloConfig.ModelPath}");

            if (!File.Exists(YoloConfig.ModelPath))
            {
                Console.WriteLine($"ERROR: Model file NOT FOUND at {YoloConfig.ModelPath}");
                throw new FileNotFoundException($"Model file not found: {YoloConfig.ModelPath}");
            }

            Console.WriteLine("Model file found. Loading YOLO model...");

            _mlContext = new MLContext();

            try
            {
                _engine = CreatePredictionEngine();
                Console.WriteLine("Model successfully loaded! Ready to detect objects.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR loading model: {ex.Message}");
            }
        }


        /// <summary>
        /// Creates a prediction engine for the YOLO model. and returns a PredictionEngine object.
        /// </summary>
        /// <returns></returns>
        private PredictionEngine<YoloInput, YoloOutput> CreatePredictionEngine()
        {
            IDataView data = _mlContext.Data.LoadFromEnumerable(new List<YoloInput>());

            var pipeline = _mlContext.Transforms.ResizeImages(
                    resizing: ImageResizingEstimator.ResizingKind.IsoPad,
                    inputColumnName: nameof(YoloInput.Image),
                    outputColumnName: YoloConfig.Input.Name,
                    imageWidth: YoloConfig.Input.Width,
                    imageHeight: YoloConfig.Input.Height
                )
                .Append(_mlContext.Transforms.ExtractPixels(
                    inputColumnName: YoloConfig.Input.Name,
                    outputColumnName: YoloConfig.Input.Name,
                    interleavePixelColors: true,
                    scaleImage: 1f / 255f
                ))
                .Append(_mlContext.Transforms.ApplyOnnxModel(
                    modelFile: YoloConfig.ModelPath,
                    inputColumnNames: new[] { YoloConfig.Input.Name },
                    outputColumnNames: new[] { YoloConfig.Output.BoundingBoxes }
                ));

            var model = pipeline.Fit(data);
            return _mlContext.Model.CreatePredictionEngine<YoloInput, YoloOutput>(model);
        }


        /// <summary>
        /// Detects objects in the image stream and returns the bounding boxes (coordinates).
        /// </summary>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        public float[] Detect(Stream imageStream)
        {
            try
            {
                Console.WriteLine("Image received. Running detection...");

                var input = YoloInput.FromStream(imageStream);
                var output = _engine.Predict(input);

                Console.WriteLine($"Detection complete! Results: {string.Join(", ", output.BoundingBoxes)}");

                return output.BoundingBoxes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR during detection: {ex.Message}");
                return new float[0];
            }
        }
    }
}
