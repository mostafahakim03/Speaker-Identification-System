# Speaker Identification System

A desktop application built with C# and .NET Framework 4.0 that identifies speakers using audio recordings. It applies DTW (with and without pruning) and MFCC feature extraction to match test voices to a database of known recordings.

#  Features
- Record or upload audio
- Extract MFCC features and remove silence
- Match using DTW or DTW with pruning
- Load/save data as CSV or JSON
- Show match distance, processing time, and accuracy


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
## Screenshots

![App Screenshot](https://res.cloudinary.com/dazfkggzb/image/upload/v1748553047/Untitled_davmmh.png)


## Documentation

[Documentation](https://docs.google.com/document/d/1HK331xjI0o-zQk0fHzW9iCw8dHYSEWPs/edit?usp=drive_link&ouid=117116383488577129694&rtpof=true&sd=true)

