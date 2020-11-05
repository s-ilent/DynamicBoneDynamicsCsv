# DynamicBoneDynamicsCsv
Editor extension to save/load Dynamic Bone settings to CSV

![sample1](Documents/sample1.png)  
![sample2](Documents/sample2.png)

## Overview
DynamicBone is an easy to use script for swaying bones.
However, it doesn't have the convenient features that UnitychanSpringBone has, like saving or loading settings from a CSV file.
So, CIFER created an extension to the editor that allows you to save your DynamicBone settings to a CSV file, or load a predefined setup.

## Usage
1. Download and import the UnityPackage from [Booth](https://cifertech.booth.pm/items/1962923).
2. Change the project's Scripting Runtime Version to __.NET4.x (or higher)__.
3. Select __Tools -> CIFER.Tech -> DynamicBoneDynamicsCsv__ from the menu bar. 
4. Assign the object for which you want to rear or apply settings to.
5. Click the "Save" or "Load" buttons at the bottom.

## System Requirements
- Unity 2018.4.20f1
- Scripting Runtime Version Experimental(.NET 4.6 Equivaient)
- [Dynamic Bone](https://assetstore.unity.com/packages/tools/animation/dynamic-bone-16743)

## FAQ
### Can I save/load colliders too?
Yes. Check the Collider checkbox in the settings window.  
Then the collider settings will be saved/loaded.

### Will it still work if you load settings from a model with a different structure?
Yes. However, if objects with the same name as saved objects are not found, their settings will be skipped without being restored.

## License
This repository is published under the [MIT License](LICENSE).
