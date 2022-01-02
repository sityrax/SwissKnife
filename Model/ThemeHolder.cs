using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SwissKnife
{
    class ThemeHolder: ModelBase
    {
        static new bool firstStart = true;

        /// <summary>
        /// Themes collection.
        /// </summary>
        public static List<ThemeHolder> Themes { get => themes; }
        private static List<ThemeHolder> themes = new List<ThemeHolder>();

        ResourceDictionary ThemeDictionary { get; }
        public string Name { get; set; }
        Color ColorSquare { get; set; }
        StackPanel DisplayMember { get; set; }


        private static ThemeHolder currentTheme;
        public static ThemeHolder CurrentTheme
        {
            get
            {
                return currentTheme;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");      //Пришло пустое значение, расстраиваемся.
                if (value == CurrentTheme) return;                                //Ничего нового.

                //Находим ссылку на старый ResourceDictionary.
                ResourceDictionary oldDict = Application.Current.Resources.MergedDictionaries.Where(x => x.Source != null &&
                                                                                             x.Source.OriginalString.EndsWith("Theme.xaml"))
                                                                                             .First();
                //Организуем подмену.
                int index = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(index, value.ThemeDictionary);
                currentTheme = value;
            }
        }


        static ThemeHolder()
        {
            themes.Clear();
            themes.Add(("Neon", Colors.Aquamarine));
            themes.Add(("Ice", Colors.Aqua));
        }


        #region InstanceConstructors
        public ThemeHolder(string name)
        {
            this.Name = name;
            this.ThemeDictionary = ToResourceDictionary();
        }

        public ThemeHolder((string name, Color color) cortege)
        {
            this.Name = cortege.name;
            this.ColorSquare = cortege.color;
            this.ThemeDictionary = ToResourceDictionary();
            this.ToPack();
        }
        #endregion


        public static implicit operator ThemeHolder(string x) => new ThemeHolder(x);             //Create new instance by string value
        public static implicit operator ThemeHolder((string, Color) x) => new ThemeHolder(x);    //Create new instance by cortege value
        public static implicit operator string(ThemeHolder x) => x.Name;                         //Return string represent


        /// <summary>
        /// Наполняем ComboBox элементами.
        /// </summary>
        /// <param name="comboBox"></param>
        internal static void InitilizeThemes(ComboBox comboBox)
        {
            if (firstStart)
            {
                comboBox.Items.Clear();
                foreach (var theme in Themes)
                {
                    comboBox.Items.Add(theme.DisplayMember);
                    if (theme.Name == "Ice")
                        comboBox.SelectedIndex = comboBox.Items.Count - 1;
                }
                firstStart = false;
            }
        }


        internal static void ChangeTheme(SelectionChangedEventArgs Args)
        {
            if (Args is not null)
            {
                if (Args.AddedItems.Count > 0)
                {
                    CurrentTheme = Themes.Find(x => x.DisplayMember.Equals(Args.AddedItems[0] as StackPanel));
                }
            }
        }


        /// <summary>
        /// Поиск соответствующего словаря.
        /// </summary>
        /// <returns></returns>
        ResourceDictionary ToResourceDictionary() =>
        new ResourceDictionary() { Source = new Uri(string.Format("/VisualStyle/{0}Theme.xaml", this.Name), UriKind.Relative) };


        /// <summary>
        /// Создание контейнера для отображения элементов.
        /// </summary>
        StackPanel ToPack()
        {
            DisplayMember = new StackPanel() { Orientation = Orientation.Horizontal};
            if (ColorSquare != default)
            {
                Rectangle square = new Rectangle { Fill = new SolidColorBrush(ColorSquare), Width = 8, Height = 8 };    //Квадратик цвета
                DisplayMember.Children.Add(square);
            }
            DisplayMember.Children.Add(new TextBlock() { Text = Name, Margin = new Thickness(4,0,0,0) });   //Название темы
            return DisplayMember;
        }


        internal static void ThemeClick()
        {
            if (frame.Content is not ThemeSettings)
                frame.Navigate(ThemeSettings.Instance ?? new ThemeSettings());
        }
    }
}
