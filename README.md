# Visual-Studio-Theme
As an application developer on windows, most of us are using Visual Studio to build their projects. It seems that Visual Studio has a fancinating look and it's enough for most of us to us it with it's pre-setting look. But, I'm not one of those people.
I always be tired of the pure-color background of my Visual Studio IDE. If the background could be an image that I love, wouldn't that be more interesting? It's easy for us to find an add-in that called *Kynnyun Background*.But it only can the image as the background of the text editor,  it's not enough.So how can we fill the whole IDE with our loved image? Then follow me.
### 1. Pre-Doing
	(1) Fork this project and then clone it with git on your computer.

	(2) Open your Visual Studio(my method requires Visual Studio 2012 or Visual Studio 2013), turn to *Extensions and Updates*(TOOLS->Extensions and Updates…).

	(3) Install Visual Studio 2012 SDK or Visual Studio 2013 SDK, that all depends on the version of your IDE. Method: In *TOOLS->Extensions and Updates…->Online*, then input *Visual Studio 201x SDK* in search box.
	
	(4)Install *Visual Studio Theme Editor*.

###2. Code Modify
Open the project you cloned before, find the source file *VSThemePackage.cs*, then modify the code in line 55
```
var rImageSource = BitmapFrame.Create(new Uri(@"C:\Users\煜\SkyDrive\图片\阿狸\阿狸9.jpeg"/*图片路径*/, UriKind.Absolute), BitmapCreateOptions.None , BitmapCacheOption.OnLoad);
```
Using the path of your favorite image to replace the original path in 
```
new Uri(@"C:\Users\煜\SkyDrive\图片\阿狸\阿狸9.jpeg"/*图片路径*/, UriKind.Absolute)
```
Then *Start Debugging* or *Start without Debugging* in Visual Studio, and then an *Experimental Initializer* will be running.

###3.Thank God
If all the steps are done successfully, then continue.

	(1) Stop debugging. Finding the *VSTheme.vsix* in the directory *bin/debug*, double click to install it. Then restart your Visual Studio IDE. Have you seen something?
	(2) Select *TOOLS->Customize Colors* in menubar(if you have downloaded and installed the Visual Studio Theme Editor), then it would look like below
![1](https://github.com/RainbowYou/Visual-Studio-Theme/tree/master/Images/1.png)

	(3) Select a theme you like or that fits your image. Click *Create Copy Of Theme* at top-right of the theme. Then the *Custom Theme* below will appear a Theme Copy, name it. Then click *Edit Theme* at top-right of the Theme Copy, then Visual Studio will look like that :
![2](https://github.com/RainbowYou/Visual-Studio-Theme/tree/master/Images/2.png)

	(4) Input *EnvironmentBackgroundGradient* *MainWindowActiveCaption* *MainWindowInactiveCaption* *CommandShelfBackgroundGradient* *CommandShelfHighlightGradient* *CommandBarGradient* *CommandBarToolBarBorder* in the search box in order, find the color value, replace the first two letters with *00*. For example, replace *FFE51400* with *00E51400*. Then input *environment*, find *environment background* *window* *treeview* in order, replace the first two letters with *00*. At last, click *save and apply theme* in the edit area.

###4.Hint
If you want to uninstall this add-in, in *TOOLS->Update and Extensions* find *VSTheme* and unistall it.
