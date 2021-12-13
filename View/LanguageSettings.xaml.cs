using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace SwissKnife
{
    /// <summary>
    /// Interaction logic for LanguageSettings.xaml
    /// </summary>
    public partial class LanguageSettings : Page
    {
        public static LanguageSettings Instance { get; set; }
        public LanguageSettings()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
