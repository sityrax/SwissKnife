using System;

using static SwissKnife.ModelBase;
using static SwissKnife.Builder;
using static SwissKnife.LanguageManager;
using static SwissKnife.ThemeHolder;


namespace SwissKnife
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            InputRequestTextEvent += InputRequestReturn;
        }


        #region Settings
        private EventControl settingsMenuLoaded;
        public EventControl SettingsMenuLoaded
        {
            get
            {
                return settingsMenuLoaded ??
                    (settingsMenuLoaded = new EventControl(obj => SettingsLoaded(obj)));
            }
        }

        private EventControl languageButtonClick;
        public EventControl LanguageButtonClick
        {
            get
            {
                return languageButtonClick ??
                    (languageButtonClick = new EventControl(obj => LanguageClick()));
            }
        }

        private EventControl themeButtonClick;
        public EventControl ThemeButtonClick
        {
            get
            {
                return themeButtonClick ??
                    (themeButtonClick = new EventControl(obj => ThemeClick()));
            }
        }
        #endregion


        /// <summary>
        /// Retrieve input from InputRequest window.
        /// </summary>
        void InputRequestReturn(string message) 
        {
           inputRequestText = string.Empty;
           InputRequest inputRequestWindow = new InputRequest();
           inputRequestWindow.Message.Text = message;
           inputRequestWindow.ShowDialog();
        }
    }
}