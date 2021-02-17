using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class Logger : MonoBehaviour
    {
        private string logFile;

        void Awake()
        {
            if (!Directory.Exists(Application.dataPath + "\\logs\\"))
                Directory.CreateDirectory(Application.dataPath + "\\logs\\");
            
            logFile = Application.dataPath + 
                      $"\\logs\\{DateTime.Now.Day}-" +
                      $"{DateTime.Now.Month}-" +
                      $"{DateTime.Now.Year}.log";

            if (!File.Exists(logFile))
                File.Create(logFile);
            Application.logMessageReceivedThreaded += LogCatcher;
        }

        private void LogCatcher(string condition, string stacktrace, LogType type)
        {
            List<string> formattedStacktrace = new List<string>(); 
            foreach (var line in stacktrace.Split('\n'))
            {
                formattedStacktrace.Add(line.Insert(0, "    at "));
            }

            formattedStacktrace[formattedStacktrace.Count - 1] = "\n";

            File.AppendAllText(logFile,
                "[" + DateTime.Now.TimeOfDay + " " + type + "]: " + condition + "\n[Stacktrace]:\n" +
                string.Join("\n", formattedStacktrace.ToArray()));
        }

    }
}