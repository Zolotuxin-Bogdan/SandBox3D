using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public class FileBrowser
{
    protected string currentDirectory;
    protected string title;
    protected Rect screenRect;
    protected Vector2 scrollPosition;
    protected GUIStyle centeredText;
    protected GUIStyle CenteredText
    {
        get 
        {
            if (centeredText == null)
            {
                centeredText = new GUIStyle(GUI.skin.label);
                centeredText.alignment = TextAnchor.MiddleLeft;
                centeredText.fixedHeight = GUI.skin.button.fixedHeight;
            }
            return centeredText;
        }
    }
    
    protected Texture2D directoryIcon;
    public Texture2D DirectoryIcon
    {
        get => directoryIcon;
        set 
        {
            directoryIcon = value;
            BuildContent();
        }
    }
    
    protected Texture2D fileIcon;
    public Texture2D FileIcon
    {
        get => fileIcon;
        set 
        {
            fileIcon = value;
            BuildContent();
        }
    }
    
    protected string[] directories; 
    protected GUIContent[] directoriesWithIcons;
    protected int selectedDirectory;

    protected string[] files;
    protected GUIContent[] filesWithIcons;
    protected int selectedFile;    


    /// <summary>
    /// FileBrowser constructor
    /// </summary>
    /// <param name="title">window title</param>
    /// <param name="screenRect">window rect</param>
    public FileBrowser(string title, Rect screenRect)
    {
        this.title = title;
        this.screenRect = screenRect;
        currentDirectory = Directory.GetCurrentDirectory();
    }

    protected void SwitchDirectory([NotNull]string directory)
    {
        if (currentDirectory == directory)
            return;
        scrollPosition = Vector2.zero;
        ReadDirectoryContents();
    }

    protected void ReadDirectoryContents()
    {
        throw new NotImplementedException();
    }

    protected void BuildContent()
    {
        List<GUIContent> bufferList = new List<GUIContent>();
        
        foreach (var dir in directories)
        {
            bufferList.Add(new GUIContent{text = dir, image = DirectoryIcon});
        }
        directoriesWithIcons = bufferList.ToArray();
        bufferList.Clear();

        foreach (var file in files)
        {
            bufferList.Add(new GUIContent{text = file, image = FileIcon});
        }
        filesWithIcons = bufferList.ToArray();
        bufferList.Clear();
    }

    public void OnGUI() 
    {

    }
}