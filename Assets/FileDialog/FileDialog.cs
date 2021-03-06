﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


/*
 * SandBox3D.Assets.UI.DirectoryBrowser
 *
 * Info:
 *  the idea of ​​implementation was partially borrowed from http://wiki.unity3d.com/index.php?title=ImprovedFileBrowser
 *
 * Simple example:
 *
 *  
 * FileDialog fileDialog;
 * Texture2D texture2D;
 *
 * void Start() {
 *     fileDialog = new FileDialog(
 *          title: "FileDialog capture",
 *          screenRect: new Rect(300, 100, 800, 800)
 *          callback: Handler
 *     );
 *     fileDialog.DirectoryIcon = texture2D;
 * }
 * 
 * void Handler(string path) {}
 * 
 * void OnGUI() {
 *     fileDialog.Draw();
 * }
 *
 */


namespace Assets.FileDialog
{
    public class FileDialog
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
                    centeredText.margin = new RectOffset(10, 0, 4, 0);
                    //centeredText.fixedHeight = GUI.skin.button.fixedHeight;
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
        /// 
        /// </summary>
        /// <param name="title">FileDialog capture</param>
        /// <param name="screenRect">FileDialog screen position</param>
        /// <param name="callback">path handler</param>
        public FileDialog(string title, Rect screenRect, FinishedCallback callback)
        {
            this.title = title;
            this.screenRect = screenRect;
            this.callback = callback;
            SwitchDirectory(Directory.GetCurrentDirectory());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">FileDialog capture</param>
        /// <param name="screenRect">FileDialog screen position</param>
        /// <param name="callback">path handler</param>
        /// <param name="currentDirectory">path to browsed directory</param>
        public FileDialog(string title, Rect screenRect, FinishedCallback callback, string currentDirectory)
        {
            this.title = title;
            this.screenRect = screenRect;
            this.callback = callback;
            SwitchDirectory(currentDirectory);
        }

        protected void SwitchDirectory(string directory)
        {
            if (directory == null || currentDirectory == directory)
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
            List<GUIContent> bufferList = directories.Select(dir => new GUIContent {text = new DirectoryInfo(dir).Name, image = DirectoryIcon}).ToList();
        
            directoriesWithIcons = bufferList.ToArray();
            bufferList.Clear();
        }
        /// <summary>
        /// Draw and build FileDialog window
        /// </summary>
        public void Draw() 
        {
            string parentDirectoryName = null;
            GUI.skin.window.alignment = TextAnchor.UpperLeft;
            GUI.skin.window.fontStyle = FontStyle.Normal;
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
                    Debug.Log(parentDirectoryName);
                    for (int i = currentDirectoryParts.Length - 1; i > parentIndex; --i) {
                        parentDirectoryName = Path.GetDirectoryName(parentDirectoryName);
                        Debug.Log(parentDirectoryName);
                    }
                    SwitchDirectory(parentDirectoryName);
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
                1,
                CenteredText
            );
            if (selectedDirectory > -1)
            {
                SwitchDirectory(directories[selectedDirectory]);
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
}