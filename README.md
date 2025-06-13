# Speaker Identification System

A desktop application built with C# and .NET Framework 4.0 that identifies speakers using audio recordings. It applies **MFCC feature extraction**, **Dynamic Time Warping (DTW)** with and without pruning, and **parallel processing** to match test voices to a database of enrolled speakers.

---

## 📸 Screenshot

![App Screenshot](https://res.cloudinary.com/dazfkggzb/image/upload/v1748553047/Untitled_davmmh.png)

---

## 🎯 Features

- 🎙️ Record or upload audio samples
- 🎧 Extract MFCC features and remove silence
- 🔁 Match using DTW or DTW with pruning (Sakoe-Chiba band)
- 📦 Save and load audio datasets as JSON
- 📊 Display match distance, processing time, and accuracy
- ⚡ Fast matching using parallel processing

---

## 🧠 How It Works

### 🔍 MFCC Feature Extraction

We use **Mel-Frequency Cepstral Coefficients (MFCC)** to extract speaker-specific features from audio signals. Silence removal is applied before extraction to improve accuracy.

---

### 📐 Dynamic Time Warping (DTW)

DTW compares two sequences by computing an optimal alignment path between them.

#### ➤ DTW Without Pruning (Standard)
- Builds a full `N x M` cost matrix for two sequences.
- Calculates minimum-cost path from top-left to bottom-right.
- Time complexity: **O(N × M)**.

#### ➤ DTW With Pruning (Sakoe-Chiba Band)
- Restricts alignment to a diagonal band of width `w` around the main diagonal.
- Reduces number of computations and improves performance.
- Time complexity: **O(N × W)**.
- Example logic:
  ```csharp
  int l = Math.Max(1, i - (w / 2));
  int r = Math.Min(m, i + (w / 2));

# ⚙️ Parallel Processing
Matching the test voice against multiple enrolled users can be slow for large datasets. To speed this up, the application uses:

- Parallel.ForEach in C# to distribute DTW comparisons across CPU cores.

- Reduces processing time drastically in multi-speaker scenarios.



# Installation
1. Clone this repo
2. Open the solution in Visual Studio
3. Make sure .NET Framework 4.0 is installed
4. Build and run the project

# Folder Structure
```
MainFunctions/
├── AudioOperations.cs        // Extract features, remove silence
├── DataOperations.cs         // Load/save training/testing data
├── SequenceMatching.cs       // DTW logic
MFCC/                         // Feature extraction logic
Recorder/                     // Recording functions
GUI/                          // WinForms UI
```

## Documentation

[Documentation](https://docs.google.com/document/d/1HK331xjI0o-zQk0fHzW9iCw8dHYSEWPs/edit?usp=drive_link&ouid=117116383488577129694&rtpof=true&sd=true)

