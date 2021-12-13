using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace SwissKnife
{
    /// <summary>
    /// Тут поддерживают культурный уровень.
    /// </summary>
    class LanguageManager : ModelBase
    {
        static new bool firstStart = true;
        /// <summary>
        /// Languages collection.
        /// </summary>
        public static Dictionary<string, CultureInfo> Languages { get => languages; }
        private static Dictionary<string, CultureInfo> languages;

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");                    //Пришло пустое значение, негодуем.
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;    //Текущий язык не изменился, расходимся.

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;     //Меняем язык всего приложения:

                //Заменяем ссылку на старый словарь в ResourceDictionary на словарь другого языка.
                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri(string.Format("/Languages/lang.{0}.xaml", value.Name), UriKind.Relative);     //Режим для славян
                        break;
                    default:
                        dict.Source = new Uri("/Languages/lang.xaml", UriKind.Relative);    //Забугорный режим
                        break;
                }

                //Находим ссылку на старый ResourceDictionary.
                ResourceDictionary oldDict = Application.Current.Resources.MergedDictionaries.Where(x => x.Source != null &&
                                                                                             x.Source.OriginalString.StartsWith("/Languages/lang."))
                                                                                             .First();
                //Заменяем старый ResourceDictionary на новый.
                if (oldDict != null)
                {
                    int index = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                                Application.Current.Resources.MergedDictionaries.Remove(oldDict);          //Амнезия
                                Application.Current.Resources.MergedDictionaries.Insert(index, dict);     //Расширяем словарный запас

                    InputTextChanger(dict["t_inputtext"] as string);
                    OutputTextChanger(dict["t_outputtext"] as string);
                    ModelBase.firstStart = true;
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }


        static LanguageManager()
        {
            languages = new Dictionary<string, CultureInfo>();
            languages.Add("English", new CultureInfo("en-US"));
            languages.Add("Русский", new CultureInfo("ru-RU"));
            Language = languages["English"];
            SettingsMenuLoadedEvent += LanguageClick; 
        }


        /// <summary>
        /// Loads languages to combobox list at startup.
        /// </summary>
        internal static void InitilizeLanguage(ComboBox comboBox)
        {
            if (comboBox is not null && firstStart)
            {
            comboBox.Items.Clear();
            foreach (var lang in Languages)
            {
                comboBox.Items.Add(lang);
                if (lang.Key == "English")
                    comboBox.SelectedIndex = comboBox.Items.Count - 1;
            }
            comboBox.DisplayMemberPath = "Key";     //Поле с которого берется текст для представления записи в элементе.
                firstStart = false;                
            }
        }


        internal static void ChangeLanguage(SelectionChangedEventArgs Args)
        {
            if (Args is not null)
            {
                if (Args.AddedItems.Count > 0)
                {
                    KeyValuePair<string, CultureInfo> lang = (KeyValuePair<string, CultureInfo>)Args.AddedItems[0];
                    Language = lang.Value;
                }
            }
        }


        /// <summary>
        /// Switch to anguage menu.
        /// </summary>
        internal static void LanguageClick()
        {
            if (frame.Content is not LanguageSettings)
                frame.Navigate(LanguageSettings.Instance ?? new LanguageSettings());
        }
    }
}
