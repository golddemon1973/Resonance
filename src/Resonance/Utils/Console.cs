using System;
using System.Collections.Generic;
using Resonance.ModLoader;
using UnityEngine;

namespace Resonance.Utils
{
    public class InGameConsole : MonoBehaviour
    {
        private static readonly List<string> LogLines = new List<string>();
        private static readonly object CollectionLock = new object();
        private Vector2 _scrollPosition;
        private bool _isVisible = true;
        private const int MaxLines = 50;

        private static Font _terminalFont;

        private void OnEnable()
        {
            Logger.OnLogAdded += AppendLine;
        }

        private void OnDisable()
        {
            Logger.OnLogAdded -= AppendLine;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                _isVisible = !_isVisible;
            }
        }

        private void OnApplicationQuit()
        {
            Loader.HandleGameQuit();
        }

        private void AppendLine(string line, ConsoleColor color)
        {
            // Translate C# ConsoleColor into Unity Rich Text hex strings
            string hexColor = color switch
            {
                ConsoleColor.Red => "#FF5555",
                ConsoleColor.DarkRed => "#BB0000",
                ConsoleColor.Yellow => "#FFFF55",
                _ => "#FFFFFF"
            };

            string formattedLine = $"<color={hexColor}>{line}</color>";

            lock (CollectionLock)
            {
                LogLines.Add(formattedLine);
                if (LogLines.Count > MaxLines)
                {
                    LogLines.RemoveAt(0);
                }
            }

            // Auto-scroll layout positioning down to the bottom
            _scrollPosition.y = float.MaxValue;
        }

        private void OnGUI()
        {
            float scale = (Screen.width / 1920f) / (Screen.dpi / 96f);
            Matrix4x4 originalMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(scale, scale, 1f));

            Event e = Event.current;
            if (e != null && e.type == EventType.KeyDown && e.keyCode == KeyCode.BackQuote)
            {
                _isVisible = !_isVisible;
                e.Use();
            }

            if (!_isVisible)
            {
                GUI.matrix = originalMatrix;
                return;
            }

            GUI.backgroundColor = Color.clear;
            GUILayout.BeginArea(new Rect(15, 665, 750, 400));

            if (_terminalFont == null)
            {
                _terminalFont = Font.CreateDynamicFontFromOSFont("Consolas", 13);
            }

            GUIStyle terminalStyle = new GUIStyle(GUI.skin.label)
            {
                richText = true,
                fontSize = 13,
                font = _terminalFont,
                wordWrap = true
            };

            lock (CollectionLock)
            {
                for (int i = 0; i < LogLines.Count; i++)
                {
                    GUILayout.Label(LogLines[i], terminalStyle);
                }
            }

            GUILayout.EndArea();
            GUI.matrix = originalMatrix;
        }

        public static void Initialize()
        {
            GameObject consoleObj = new GameObject("Resonance_ConsoleOverlay");
            consoleObj.AddComponent<InGameConsole>();
            DontDestroyOnLoad(consoleObj);
        }
    }
}