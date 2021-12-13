using System;
using System.Windows;
using System.Windows.Controls;

using static SwissKnife.LanguageManager;
using static SwissKnife.ThemeHolder;
using static SwissKnife.ModelBase;

namespace SwissKnife
{
    public class CommonViewModel : ViewModelBase
    {
        private EventControl changeLanguage;
        public EventControl ChangeLanguage
        {
            get
            {
                return changeLanguage ??
                  (changeLanguage = new EventControl(obj => ChangeLanguage(obj as SelectionChangedEventArgs)));
            }
        }


        private EventControl languageLoaded;
        public EventControl LanguageLoaded
        {
            get
            {
                return languageLoaded ??
                  (languageLoaded = new EventControl(obj => InitilizeLanguage(obj as ComboBox)));
            }
        }


        private EventControl changeTheme;
        public EventControl ChangeTheme
        {
            get
            {
                return changeTheme ??
                  (changeTheme = new EventControl(obj => ChangeTheme(obj as SelectionChangedEventArgs)));
            }
        }


        private EventControl themesLoaded;
        public EventControl ThemesLoaded
        {
            get
            {
                return themesLoaded ??
                  (themesLoaded = new EventControl(obj => InitilizeThemes(obj as ComboBox)));
            }
        }


        /// <summary>
        /// InputRequest window text.
        /// </summary>
        public string InputRequestText
        {
            get
            {
                return inputRequestText;
            }
            set
            {
                inputRequestText = value;
                OnPropertyChanged("InputRequestText");
            }
        }


    }
}