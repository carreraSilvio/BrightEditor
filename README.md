# Bright Editing
A collection of wrappers for the Editor, EditorWindow and PropertyDrawer classes.

## Features
* Draw bold label easily calling DrawBoldLabel.
* Draw a button by calling DrawButton.
* Control indent level using IncreaseIndentLevel, DecreaseIndentLevel and ResetIndentLevel.
* Want to draw the script field like unity does? Call the DrawScriptField method.
* Draw properties as readly by calling StartGreyedOutArea before and then calling EndGreyedOutArea.
* No more getting lost between GUI, GUILayout, EditorGUI and EditorGUILayout searching for the method you need.

## Prerequisites
Unity 2018.3 and up

## Install

### Unity 2019.3
1. Open the package manager and point to the repo URL

![Imgur](https://i.imgur.com/iYGgINz.png)

### Before Unity 2019.3

#### Option A
1. Open the manifest
2. Add the repo URL either via https or ssh

#### Option B
1. Clone or download the project zip
2. Open your project assets folder
3. Copy the repo there

## Usage

### Extending
1. Create your custom editor class
2. Extend from BrightEditor instead of UnityEditor.Editor
3. Check the API and use the available methods for easier custom inspector class writing

Notes:
- Similar approach when making custom EditorWindow, use BrightEditorWindow.
- Similar approach when making custom PropertyDrawer, use BrightPropertyDrawer.
- If you don't want to extend those for some reason, use BrightEditorUtility. 