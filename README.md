# Unity Tools v1

# CursorManager

- Singleton Monobehavior with methods to toggle the on-screen cursor.

# MouseRotatorController

- Monobehavior that rotates a GameObject using the mouse.
- Can toggle axis (horizontal/vertical rotations)
- Can clamp axis to min/max angles.
- Adjustable sensitivities.
- Includes a custom editor.
- Includes a test scene.

![alt text](https://github.com/JustinDLlacuna/unity-tools/blob/v1/Assets/Screenshots/MouseRotatorControllerEditor.png?raw=true)

# KeyRotatorController

- Child class of MouseRotatorController.
- Controls rotation using designated keys as opposed to the mouse.
- Includes a custom editor.
- Includes a test scene.

![alt text](https://github.com/JustinDLlacuna/unity-tools/blob/v1/Assets/Screenshots/KeyRotatorControllerEditor.png?raw=true)

# TankController

- Monobehavior that moves a CharacterController using WASD/arrow keys.
- Gravity implemented. 
- Adjustable moveSpeed.
- Includes a test scene.

![alt text](https://github.com/JustinDLlacuna/unity-tools/blob/v1/Assets/Screenshots/TankControllerEditor.png?raw=true)

# GridRenderer

- Monobehavior that draws a square grid based on the dimensions of a RectTransform.
- Automatically scales to any size, regardless of cell count.
- Colors of individual cells can be modified.
- Can fade/unfade cells.
- Includes a test scene.

![alt text](https://github.com/JustinDLlacuna/unity-tools/blob/v1/Assets/Screenshots/GridRendererEditor.png?raw=true)

# JSONSaveLoader

- Saves data/loads Serializable class data from a JSON file. 

# ScreenInput

- Detects swipes (up, left, down, right) from a screen.
- Can also detect input from WASD/arrows keys.
