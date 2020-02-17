# Eve.TapToClick
This is a simple program that enables tap-to-click on the touchpad when running Windows 10 on a Google Pixelbook.

<img src="Eve.TapToClick/ExampleScreenshot.png" width="600">

Thanks to MrChromebox's efforts, Windows 10 can now be installed and works pretty well on the Pixelbook. One of the few issues is that native tap-to-click does not work. This is a temporary workaround, at least until something more robust works.

This app uses Windows' [raw input API](https://docs.microsoft.com/en-us/windows/win32/inputdev/raw-input) to access the touchpad's raw data, such as the pressure and X/Y readings. Using this data, it determines when a tap has occurred then injects the click input.

It allows some configuration, such as the pressure thresholds as well as the maximum time/distance for an input to be considered a tap.

Currently, only single-finger tap (for left click) and double-finger tap (for right click) are implemented. Other gestures, such as double-tap-and-drag do not work.

If you have issues or questions, open an issue and I'll try to help you out. If you want to improve it, feel free to open a pull request.

## How to use
Currently, there is no installer. Just [download the latest release](https://github.com/megabytefisher/Eve.TapToClick/releases), then unzip and run Eve.TapToClick.exe. 

## Important
**For best results, run this program as administrator.** Otherwise, some applications (I think ones that are run as administrator) will ignore the injected inputs.

**It is possible anti-virus apps may block the app from injecting mouse clicks.** This is because some malware uses the same method to maliciously control a victim PC. You may need to "allow" this program in your anti-virus software.

**I do not recommend using this when playing games that use anti-cheat features**. While I can't be completely sure, I suspect some anti-cheat software will flag the injected inputs as macroing software. If you get a ban because of this, I'm not responsible.
