# YOLO Object Detection in .NET MAUI

This project is a **proof of concept** developed as part of a thesis. It demonstrates how to integrate **YOLOv4** object detection into a .NET MAUI application using **ML.NET** and ONNX.

## 🚀 Features
- Runs **YOLOv4** object detection on an image.
- Uses **Microsoft ML.NET** to process images.
- Asynchronous execution for smooth UI operation.
- Portable cross-platform **.NET MAUI** implementation.

## 📂 Project Structure
```
📁 OBJ_detection_maui
│── 📄 YoloConfig.cs         # Model configuration (paths, input size, etc.)
│── 📄 YoloDetector.cs       # ML.NET pipeline for running YOLOv4
│── 📄 YoloInput.cs          # Input image processing
│── 📄 YoloOutput.cs         # Detection output representation
│── 📄 MauiProgram.cs        # App initialization, model file handling
│── 📄 MainPage.xaml.cs      # UI interaction and detection logic
│── 📄 OBJ_detection_maui.csproj # Project configuration
```

## 🛠️ Setup & Installation

### 1️⃣ Prerequisites
- .NET 9 SDK
- Visual Studio 2022 (with .NET MAUI workload)
- [YOLOv4 ONNX Model](https://github.com/onnx/models/blob/main/validated/vision/object_detection_segmentation/yolov4/model/yolov4.onnx)

### 2️⃣ Clone Repository
```sh
git clone https://github.com/YOUR_GITHUB_USERNAME/YOUR_REPO_NAME.git
cd YOUR_REPO_NAME
```

### 3️⃣ Download YOLOv4 ONNX Model
Since the model is ignored in Git, download it manually and place it in:
```
(https://github.com/onnx/models/blob/main/validated/vision/object_detection_segmentation/yolov4/model/yolov4.onnx
Resources/Raw/Models/yolov4.onnx
```

### 4️⃣ Build and Run
```sh
dotnet build
```
Run the project in Visual Studio or via:
```sh
dotnet run
```

## 📸 Running Object Detection
- The app looks for a test image in the `AppDataDirectory`.
- You can replace `test_image.jpg` in `AppDataDirectory` with your own image.
- The detection results (bounding box coordinates) are displayed on the screen.

## 🏗️ How It Works
1. **Model File Handling**
   - The model is copied from `Resources/Raw/Models/` to `AppDataDirectory` on startup.

2. **Detection Process**
   - Reads an image file.
   - Runs it through a YOLOv4 ONNX model using **ML.NET**.
   - Extracts and displays bounding box coordinates on console.

## 🛠️ Future Improvements
- 🏷️ Display object labels (e.g., "Person", "Car").
- ⚡ Improve performance with hardware acceleration.
- 📱 Enhance UI with bounding box overlays.

## 📜 License
This project is for educational and research purposes. Feel free to use and modify it.

## 📬 Contact
For questions, reach out via **GitHub Issues**.

---
🚀 *This proof of concept was developed for a thesis project in AI-based object detection by Henrik Viljanen.*

