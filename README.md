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
git clone https://github.com/Es-Esa/Thesis_MAUI
cd OBJ_detection_maui
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
## Console
```
[DOTNET] Model successfully loaded! Ready to detect objects.
[DOTNET] Image received. Running detection...
[ProfileInstaller] Installing profile for com.companyname.obj_detection_maui
[_detection_maui] Explicit concurrent copying GC freed 282(49KB) AllocSpace objects, 0(0B) LOS objects, 49% free, 4362KB/8724KB, paused 261us,73us total 8.057ms
[DOTNET] Detection complete! Results: -0.02291147, 0.11408712, -0.13978714, -0.20035952, 0.00014963746, 0.43315744, 0.0010646582, 0.012585193, 0.0008813441, 0.0015263557, 0.00040462613, 0.000174433, 0.0018456578, 0.00078320503, 0.0018142462, 0.00032114983, 0.0005476177, 0.0003581047, 0.0053786337, 0.006828338, 0.00044435263, 0.00402236, 0.0010222197, 0.002124846, 0.0016703904, 0.00028923154, 0.0002885759, 0.0011192262, 0.0006136596, 0.017986894, 0.0018561184, 0.005639434, 0.0028770566, 0.0003132224, 0.038462043, 0.0133937, 0.0022892356, 0.05007702, 0.020822734, 0.01339668, 0.05904448, 0.009262711, 0.0035251975, 0.010507017, 0.0030199587, 0.0004339218, 0.000962615, 0.0006773472, 0.0002734661, 0.0003438592, 0.00018641353, 0.00034609437, 0.00011271238, 0.0004580617, 0.00016590953, 0.00016868114, 0.00024798512, 0.00079244375, 0.0015332103, 0.00041115284, 0.0002989471, 0.0017774701, 0.0002040267, 0.0002876222, 0.00016957521, 0.0002696216, 0.00014799833, 0.00014129281, 0.00029152632, 0.00012257695, 0.0006389916, 0.00017896
```
![kuva](https://github.com/user-attachments/assets/70085c6c-496b-468e-910c-c961fdcf03f2)

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

