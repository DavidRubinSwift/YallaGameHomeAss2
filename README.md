# YALLAGAME

A mobile arcade game developed in Unity as part of a Tiltan project.

## Table of Contents

1. [Participants](#participants)  
2. [Project Description](#project-description)  
3. [Core Features](#core-features)  
4. [Project Structure](#project-structure)  
5. [Setup Instructions](#setup-instructions)  
6. [Save & Load System](#save--load-system)  
7. [Building the Project](#building-the-project)  
8. [Platform Support](#platform-support)  
9. [Planned Features](#planned-features)  

## Participants

- **David Rubin** – UI, settings, save system (JSON)  
- **Mikhail Nazarenko** – mobile input, scene setup, gameplay tracking  

## Project Description

YALLAGAME is an Android arcade game in which the player controls a rolling ball, avoids obstacles, and collects coins. The game features:
- Mobile-optimized UI  
- JSON-based save/load with screenshots  
- Persistent background music across scenes  

## Core Features

### Ball Control
- Smooth forward and lateral movement  
- On-screen buttons for touch input  
- Swipe-based jump mechanic  
- Scripts: `BallMovement.cs`, `BallMovementWithJump.cs`  

### Obstacle System
- Dynamic obstacle spawning  
- Object pooling for performance  
- Configurable spawn points and patterns  
- Scripts: `Obstacle.cs`, `ObstaclePooler.cs`  

### Save System
- JSON files stored in `persistentDataPath`  
- Multiple save slots containing: name, score, volume, play time, timestamp, screenshot path  
- Scrollable load menu with thumbnails  
- Scripts: `SaveManager.cs`, `SaveData.cs`, `GameDataTest.cs`, `SaveEntryUI.cs`  

### Audio System
- Music persists across scenes via `DontDestroyOnLoad`  
- Volume control through `AudioMixer` and UI slider  
- Script: `AudioSettingsManager.cs`  

### User Interface
- **Main Menu**: Start | Load | Settings | Exit  
- **Pause Menu**: Resume | Save  
- **Settings Screen**: Volume slider  
- **Load Screen**: Scrollable list of saves with metadata  

### Mobile Adaptation
- Touch and gyroscope support  
- Responsive layouts for various resolutions  
- Optimized for Android  

## Project Structure

Assets/ ├── Audio/ │ ├── Music/ │ └── Mixer/ ├── Prefabs/ │ ├── Obstacles/ │ └── UI/ │ └── SaveEntryButton.prefab  ├── Scenes/ │ ├── MainMenu.unity  │ ├── PlayScene.unity  │ ├── SettingsMenu.unity  │ └── LoadMenu.unity  ├── Scripts/ │ ├── Audio/ │ │ └── AudioSettingsManager.cs  │ ├── Ball/ │ │ ├── BallMovement.cs  │ │ └── BallMovementWithJump.cs  │ ├── Obstacles/ │ │ ├── Obstacle.cs  │ │ └── ObstaclePooler.cs  │ ├── SaveSystem/ │ │ ├── SaveManager.cs  │ │ ├── SaveData.cs  │ │ ├── GameDataTest.cs  │ │ └── SaveEntryUI.cs  │ └── UI/ │ ├── MenuManager.cs  │ ├── PauseMenuMobile.cs  │ ├── ScreenOrientationDetector.cs  │ └── VolumeSlider.cs

## Setup Instructions

1. Open the project in Unity (2022.3 LTS recommended).  
2. Install TextMeshPro if prompted.  
3. Add all scenes to **File > Build Settings**.  
4. In the Inspector, assign references:  
   - **AudioMixer** → `AudioSettingsManager`  
   - **SaveManager** → `GameDataTest`  
   - UI elements → `VolumeSlider`, `SaveEntryUI`  
5. Ensure each Canvas uses **Screen Space – Overlay**.

## Save & Load System

- Saves generate individual JSON files in the persistent data path:  
  - macOS: `~/Library/Application Support/CompanyName/ProductName/`  
  - Windows: `%AppData%/LocalLow/CompanyName/ProductName/`  
- Each save includes an auto-captured screenshot.  
- Load menu displays thumbnail, date/time, score, and playtime.

## Building the Project

1. Open **File > Build Settings**.  
2. Verify that all scenes are listed.  
3. Select **Android** as the target platform.  
4. Click **Build** or **Build and Run**.

## Platform Support

- Android (tested and optimized)

## Planned Features

- Coin collection mechanics  
- Complete load functionality  
- End-game screen and restart option  
- Difficulty scaling  
- New dynamic obstacle types  
