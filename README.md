# Unity Editor FPS Display

A lightweight Unity Editor extension that displays real-time FPS directly in the Scene view.
Useful for monitoring editor performance, custom tools, and editor-time rendering overhead.

## Features

- Displays FPS in the Scene view overlay
- Zero configuration, works out of the box
- Safe for Enter Play Mode with Domain Reload disabled
- Supports modern Unity editor lifecycle (assembly reloads, subsystem registration)

## Supported Unity Versions

- Unity **2020.3 LTS**
- Unity **2021+**
- Unity **6.x (6000.x)**

## Installation

### Via Git URL (recommended)

1. Open **Window → Package Manager**
2. Click **+**
3. Select **Add package from git URL**
4. Paste: ```https://github.com/RimuruDev/Unity-EditorFPSDisplay.git```
5. Click **Add**

## Usage

Once installed, the FPS counter will automatically appear in the Scene view.
No setup or configuration is required.

## Notes

- Designed to be safe with **Enter Play Mode Options**
- Properly handles editor domain reloads and assembly reloads
- Does not allocate per frame

## License

MIT License — see [LICENSE](LICENSE)

## Author

**RimuruDev**

GitHub: https://github.com/RimuruDev