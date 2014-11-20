# Little Braces
A Visual Studio editor extension that shrinks lines of C, C++ and C# code that contain only curly braces.  

UPDATE: An update to the [Productivity Power Tools](https://visualstudiogallery.msdn.microsoft.com/dbcb8670-889e-4a54-a226-a48a15e4cace) extension added a similar feature for VS 2013. They've called it 'Syntactic Line Compression'.  

![](http://lukesdm.github.com/little-braces/media/screenshot1.png)

###Requirements
Visual Studio 2010. 2012 should also work, but is untested.

### Download/Installation
[Download](http://github.com/lukesdm/little-braces/raw/master/Output/LittleBraces.vsix), then double-click/activate the VSIX file in Explorer.

### Usage
Once installed, the effect is enabled immediately. Note: lines containing only ```};``` are also shrunk, e.g. object initializers.

By default, the lines are shrunk to 0.3x the standard size. If this isn't satisfactory, you can edit the 'BraceLineScale.txt' file in the extension's install directory - it contains just the scale factor as a decimal. Changes will be applied the next time Visual Studio is started.

### Caveats
* If line numbers are visible, they look a bit messy for the shrunken lines.
* The same goes for breakpoints on those lines
* As the lines are shrunken, selecting them is tricker.

### Uninstallation
In VS, open the Extension Manager, select Little Braces, then click uninstall. A restart of VS is required.

### Development Info
This is a very simple extension. There's just a single 69-line source file. It uses a LineTransformSource.

### License
Eclipse Public License v1.0. See [license text](http://github.com/lukesdm/little-braces/raw/master/License.txt) for details.
