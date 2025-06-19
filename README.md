YALLAGAME - Mobile Game on Unity for Tiltan

Participants

Mikhail Nazarenko – Gameplay Mechanics
David Rubin – ScriptableObjects, JSON Saving System, Object Pooling, UI/UX


Project Description

YALLAGAME is a mobile arcade game developed in Unity. The player controls a rolling ball that avoids obstacles and collects coins. The game is optimized for mobile platforms, with adaptive UI, a JSON-based saving system, and background music that persists across scenes.

Core Features

Ball Control

Smooth forward and lateral movement
Virtual buttons for mobile devices
Jump system with touch swipe detection
Based on BallMovement and BallMovementWithJump scripts
Obstacle System

Dynamic obstacle spawning
Object pooling for performance optimization
Customizable spawn points and patterns
Save System

JSON-based save/load mechanism
Multiple save files with date, time, score, play duration, and screenshots
Scrollable save menu showing existing saves
Audio System

Volume control via AudioMixer and UI slider
Music playback persists across scene loads (using singleton pattern)
AudioSettingsManager script handles settings
User Interface

Main menu with Start, Load, Settings, and Exit buttons
Pause menu with resume and save buttons
Settings screen with music volume slider
Load screen with scrollable list of save entries
Mobile Adaptation

Touch screen and gyroscope support
Dynamic layout adjustment for different resolutions
Optimized for Android builds
Project Structure

Assets/
|-- Audio/
| |-- Music/
| |-- Mixer/
|-- Prefabs/
| |-- Obstacles/
| |-- UI/
| |-- SaveEntryButton.prefab
|-- Scenes/
| |-- MainMenu.unity
| |-- PlayScene.unity
| |-- SettingsMenu.unity
| |-- LoadMenu.unity
|-- Scripts/
| |-- Audio/
| | |-- AudioSettingsManager.cs
| |-- Ball/
| | |-- BallMovement.cs
| | |-- BallMovementWithJump.cs
| |-- Obstacles/
| | |-- Obstacle.cs
| | |-- ObstaclePooler.cs
| |-- SaveSystem/
| | |-- SaveManager.cs
| | |-- SaveData.cs
| | |-- GameDataTest.cs
| | |-- SaveEntryUI.cs
| |-- UI/
| | |-- MenuManager.cs
| | |-- PauseMenuMobile.cs
| | |-- ScreenOrientationDetector.cs
| | |-- VolumeSlider.cs

Setup Instructions

Open the project in Unity Editor (recommended version: 2022.3 LTS)
Install TextMeshPro if prompted
Add all scenes to Build Settings
Assign all necessary references in the Inspector:
AudioMixer to AudioSettingsManager
SaveManager to GameDataTest
UI objects to VolumeSlider and SaveEntryUI
In Canvas components, ensure "Render Mode" is set to "Screen Space - Overlay"
Save and Load System

Each save creates a separate JSON file in the persistent data path
Save data includes: player name, score, volume, play time, timestamp, screenshot path
Screenshots are generated when saving
The Load screen displays:
Screenshot thumbnail
Save time and date
Current score
Total playtime
Load functionality will be implemented in a later version
Building the Project

Go to File > Build Settings
Ensure all scenes are added
Select Android as target platform
Click Build or Build and Run
Platform Support

Android (currently tested and optimized)
Notes

Application.Quit only works in a build, not in the Unity Editor
Music player persists across scenes using DontDestroyOnLoad
Save files are located at:
macOS: ~/Library/Application Support/CompanyName/ProductName/
Windows: %AppData%/LocalLow/CompanyName/ProductName/
Planned Features

Coin collection mechanic
Full load system implementation
End-game screen and restart option
Difficulty scaling
More dynamic obstacles
