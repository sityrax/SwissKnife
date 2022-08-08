using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace SwissKnife
{
    abstract class ModelBase
    {
        internal static event Action<RulesPreset> RulesPresetsUpdated;
        internal static event Action<string> CurrentTitleChangedEvent;
        internal static event Action<string> OutputTextChangedEvent;
        internal static event Action<string> InputTextChangedEvent;
        internal static event Action<string> InputRequestTextEvent;

        internal static event Action SettingsMenuLoadedEvent;
        internal static string inputRequestText;
        protected static Frame frame;
        
        protected static bool firstStart = true;    //Flag


        /// <summary>
        /// Changes InputText content.
        /// </summary>
        /// <param name="text">Text to print</param>
        protected static void InputTextChanger(string text)
        {
            InputTextChangedEvent?.Invoke(text);
        }


        /// <summary>
        /// Changes OutputText content.
        /// </summary>
        /// <param name="text">Text to print</param>
        protected static void OutputTextChanger(string text)
        {
            OutputTextChangedEvent?.Invoke(text);
        }


        /// <summary>
        /// Input Request require.
        /// </summary>
        protected static string InputRequestRequire(string message)
        {
            InputRequestTextEvent?.Invoke(message);
            return inputRequestText;
        }


        /// <summary>
        /// Notifies CurrentTitle of edited rule.
        /// </summary>
        protected static void CurrentTitleChanged(string title)
        {
            CurrentTitleChangedEvent?.Invoke(title);
        }


        /// <summary>
        /// Adds list of Rule Presets.
        /// </summary>
        /// <param name="text">Element to add</param>
        protected static void RulesPresetsUpdate(RulesPreset rule)
        {
            RulesPresetsUpdated?.Invoke(rule);
        }


        /// <summary>
        /// Gets text from dropped file.
        /// </summary>
        internal static void InputDrop(DragEventArgs e)
        {
            if(e is not null)
            {
               string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
               string readText = File.ReadAllText(filePath[0]);
               InputTextChangedEvent?.Invoke(readText);
               firstStart = false;
            }
        }


        internal static void DragEnterFile(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true;
            }
        }


        internal static void FirstFocus()
        {
            if (firstStart)
            {
                InputTextChangedEvent.Invoke(string.Empty);
                firstStart = false;
            }
        }


        internal static void SettingsLoaded(object element)
        {
            if (element is Frame settingsFrame)
                frame = settingsFrame;                //Запоминаем ссылку на экземпляр "фрейма" настроек.
                SettingsMenuLoadedEvent.Invoke();    //Оповещаем всех, кому надо.
        }
    }
}
