using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;


/*
 * SandBox3D.Assets.UI.DirectoryBrowser
 *
 * Info:
 *  the idea of ​​implementation was partially borrowed from http://wiki.unity3d.com/index.php?title=ImprovedFileBrowser
 *
 * Simple example:
 *
 *  //another code
 *  
 *  DirectoryBrowser explorer;
 *  bool drawExplorer;
 *  public string path;
 *  public Texture2D directoryIcon;
 *  
 *  private void SomeButtonCallback()
 *  {
 *     drawExplorer = true;
 *  }
 *  
 *  private void OnGUI()
 *  {
 *     if (explorer != null)
 *         explorer.OnGUI();
 *     else
 *         OnGUIMain();
 *  }
 *  
 *  private void OnGUIMain()
 *  {
 *      if (drawExplorer)
 *      {
 *          explorer = new DirectoryBrowser(
 *              "Choose folder...",
 *              new Rect(100, 100, 600, 500),
 *              FileSelectCallback
 *          );
 *      }
 *  }
 *  
 *  private void FileSelectCallback(string path)
 *  {
 *      explorer = null;
 *      this.path = path;
 *  }
 *
 */


public class DirectoryBrowser
{
    public delegate void FinishedCallback(string path);
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

    protected string[] currentDirectoryParts;
    protected string[] directories; 
    protected GUIContent[] directoriesWithIcons;
    protected int selectedDirectory;
    protected FinishedCallback callback;

    /// <summary>
    /// FileBrowser constructor
    /// </summary>
    /// <param name="title">window title</param>
    /// <param name="screenRect">window rect</param>
    public DirectoryBrowser(string title, Rect screenRect, FinishedCallback callback)
    {
        this.title = title;
        this.screenRect = screenRect;
        this.callback = callback;
        SwitchDirectory(Directory.GetCurrentDirectory());
    }

    protected void SwitchDirectory([NotNull]string directory)
    {
        if (currentDirectory == directory)
            return;
        currentDirectory = directory;
        scrollPosition = Vector2.zero;
        selectedDirectory = -1;
        ReadDirectoryContents();
    }

    protected void ReadDirectoryContents()
    {
        if (currentDirectory == "/") {
			currentDirectoryParts = new string[] {""};
        }else {
			currentDirectoryParts = currentDirectory.Split(Path.DirectorySeparatorChar);           
        }
        directories = Directory.GetDirectories(currentDirectory);
        Array.Sort(directories);
        BuildContent();
    }

    protected void BuildContent()
    {
        List<GUIContent> bufferList = directories.Select(dir => new GUIContent {text = dir, image = DirectoryIcon}).ToList();

        directoriesWithIcons = bufferList.ToArray();
        bufferList.Clear();
    }

    public void OnGUI() 
    {
        string parentDirectoryName = "";
        GUILayout.BeginArea(
            screenRect,
            title,
            GUI.skin.window
        );
            GUILayout.BeginHorizontal();
                for (int parentIndex = 0; parentIndex < currentDirectoryParts.Length; ++parentIndex) {
		        	if (parentIndex == currentDirectoryParts.Length - 1) {
		        		GUILayout.Label(currentDirectoryParts[parentIndex], CenteredText);
		        	} else if (GUILayout.Button(currentDirectoryParts[parentIndex])) {
		        		parentDirectoryName = currentDirectory;
		        		for (int i = currentDirectoryParts.Length - 1; i > parentIndex; --i) {
		        			parentDirectoryName = Path.GetDirectoryName(parentDirectoryName);
		        		}
    	        	}
		        }
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            scrollPosition = GUILayout.BeginScrollView(
                scrollPosition,
                false,
                true,
                GUI.skin.horizontalScrollbar,
                GUI.skin.verticalScrollbar,
                GUI.skin.box
            );
                selectedDirectory = GUILayout.SelectionGrid(
                    selectedDirectory,
                    directoriesWithIcons,
                    1
                );
                if (selectedDirectory > -1)
                {
                    callback(Path.Combine(currentDirectory, directories[selectedDirectory]));
                }
                GUI.enabled = true;
            GUILayout.EndScrollView();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Cancel", GUILayout.Width(50)))
                {
                    callback(null);
                }
                if (GUILayout.Button("Select", GUILayout.Width(50)))
                {
                    if (selectedDirectory > -1)
                        callback(Path.Combine(currentDirectory, directories[selectedDirectory]));                
                    else
                        callback(currentDirectory);
                }
                GUI.enabled = true;
            GUILayout.EndHorizontal();
        GUILayout.EndArea();
        if (Event.current.type == EventType.Repaint)
        {
            SwitchDirectory(parentDirectoryName);
        }
    }
}