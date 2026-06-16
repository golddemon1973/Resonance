using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Resonance.ModLoader;

namespace Resonance.Utils
{
    public static class Logger
    {
        private static readonly string LogFilePath;
        private static readonly object FileLock = new();

        private static readonly List<string> LogBuffer = new();
        internal static event Action<string, ConsoleColor> OnLogAdded;

        /// <summary>
        /// Initializes logger
        /// </summary>
        static Logger()
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string LocalLow = Path.Combine(Path.GetDirectoryName(AppData), "LocalLow");
            string HkFolder = Path.Combine(LocalLow, "Team Cherry", "Hollow Knight");

            LogFilePath = Path.Combine(HkFolder, "Resonance.log");

            try
            {
                File.WriteAllText(LogFilePath, $"[Resonance] Logger initialized at {DateTime.Now}\n\n");
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"[Resonance] Could not initialize file logger: {Ex.Message}");
            }
        }

        /// <summary>
        /// Internal Log
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Message"></param>
        public static void Log(string Sender, string Message) => WriteToOutputs("[INFO]", Sender, Message, ConsoleColor.White);

        /// <summary>
        /// Internal Warn
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Message"></param>
        public static void Warn(string Sender, string Message) => WriteToOutputs("[WARN]", Sender, Message, ConsoleColor.Yellow);

        /// <summary>
        /// Internal Error
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Message"></param>
        /// <param name="Ex"></param>
        public static void Error(string Sender, string Message, Exception Ex = null)
        {
            string OutMessage = Ex != null ? $"{Message}\nException: {Ex}" : Message;
            WriteToOutputs("[ERROR]", Sender, OutMessage, ConsoleColor.Red);
        }

        /// <summary>
        /// Internal Assert
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Condition"></param>
        /// <param name="Message"></param>
        public static void Assert(string Sender, bool Condition, string Message)
        {
            if (Condition) return;
            WriteToOutputs("[ASSERT]", Sender, $"Assertion Failed: {Message}", ConsoleColor.DarkRed);
            if (Debugger.IsAttached) Debugger.Break();
        }

        /// <summary>
        /// Sends an info message
        /// </summary>
        /// <param name="ActiveMod"></param>
        /// <param name="Message"></param>
        public static void Log(this Mod ActiveMod, string Message) => Log(ActiveMod.GetName(), Message);

        /// <summary>
        /// Sends a warn message
        /// </summary>
        /// <param name="ActiveMod"></param>
        /// <param name="Message"></param>
        public static void Warn(this Mod ActiveMod, string Message) => Warn(ActiveMod.GetName(), Message);

        /// <summary>
        /// Sends an error message
        /// </summary>
        /// <param name="ActiveMod"></param>
        /// <param name="Message"></param>
        /// <param name="Ex"></param>
        public static void Error(this Mod ActiveMod, string Message, Exception Ex = null) => Error(ActiveMod.GetName(), Message, Ex);

        /// <summary>
        /// Errors if condition is not fulfilled
        /// </summary>
        /// <param name="ActiveMod"></param>
        /// <param name="Condition"></param>
        /// <param name="Message"></param>
        public static void Assert(this Mod ActiveMod, bool Condition, string Message) => Assert(ActiveMod.GetName(), Condition, Message);

        /// <summary>
        /// Write a new line to the log buffer
        /// </summary>
        /// <param name="Level"></param>
        /// <param name="Sender"></param>
        /// <param name="Message"></param>
        /// <param name="Color"></param>
        private static void WriteToOutputs(string Level, string Sender, string Message, ConsoleColor Color)
        {
            string Timestamp = DateTime.Now.ToString("HH:mm:ss");
            string FullLine = $"{Timestamp} | {Level.PadRight(5)} | {Sender} > {Message}";

            Console.ForegroundColor = Color;
            Console.WriteLine(FullLine);
            Console.ResetColor();

            lock (FileLock)
            {
                LogBuffer.Add(FullLine);
            }

            OnLogAdded?.Invoke(FullLine, Color);
        }

        /// <summary>
        /// Flushes all queued lines sitting inside the memory array directly into the output file.
        /// Call this at the end of Loader.HandleGameQuit().
        /// </summary>
        public static void FlushToDisk()
        {
            if (string.IsNullOrEmpty(LogFilePath)) return;

            lock (FileLock)
            {
                if (LogBuffer.Count == 0) return;

                try
                {
                    // This dumps the entire layout array to disk in one fast sequential stream operation
                    File.AppendAllLines(LogFilePath, LogBuffer);
                    LogBuffer.Clear();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine($"[Resonance] Critical error flushing buffered logs to disk: {Ex.Message}");
                }
            }
        }
    }
}