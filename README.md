# AR Treasure Race

AR board game project created in Unity with Vuforia.

## Description
The application recognizes multiple image markers placed on cards.
Each marker triggers a specific game action such as:
- dice roll
- player movement
- heal
- trap
- restart

The main board marker visualizes the game board in augmented reality.
The goal of the player is to reach the finish tile with the highest possible score.

## Technologies
- Unity 6
- C#
- Vuforia Engine

## How it works
The camera is pointed at printed marker cards.
When a marker is recognized, the application performs the corresponding in-game action.
The project can be demonstrated in Unity using a webcam and can also be built for Android.

## Project structure
- Assets
- Packages
- ProjectSettings

## Notes
The Vuforia package `.tgz` file is not included in the repository because of GitHub file size limits.
If needed, Vuforia should be installed separately in Unity.
