using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class Logger : MonoBehaviour
    {
        private string logFile;

        private int errors;
        private int warns;
        void Awake()
        {
            if (!Directory.Exists(Application.dataPath + "\\logs\\"))
                Directory.CreateDirectory(Application.dataPath + "\\logs\\");
            
            logFile = Application.dataPath + 
                      $"\\logs\\{DateTime.Now.Year}-" +
                      $"{DateTime.Now.Month}-" +
                      $"{DateTime.Now.Day}.log";

            if (!File.Exists(logFile))
                File.Create(logFile);
            var sessionInfo = $"\n\t[Session start time {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}]\n";
            File.AppendAllText(logFile, sessionInfo);
            Application.logMessageReceivedThreaded += LogCatcher;
        }

        private void LogCatcher(string condition, string stacktrace, LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    errors++;
                    break;
                case LogType.Warning:
                    warns++;
                    break;
                default:
                    break;
            }
            List<string> formattedStacktrace = new List<string>(); 
            foreach (var line in stacktrace.Split('\n'))
            {
                if (line.Contains("0x"))
                {
                    formattedStacktrace.Add(line);
                }
                else
                {
                    formattedStacktrace.Add(line.Insert(0, "    at "));
                }
            }

            formattedStacktrace[formattedStacktrace.Count - 1] = "\n";

            File.AppendAllText(logFile,
                "[" + DateTime.Now.TimeOfDay + "] " + type + ": " + condition + "\n" +
                string.Join("\n", formattedStacktrace.ToArray()));
        }

        void OnDestroy()
        {
            var summaryInfo = $"\nRuntime Errors: {errors}\nRuntime Warns: {warns}\n";
            File.AppendAllText(logFile, summaryInfo);
        }
    }
}