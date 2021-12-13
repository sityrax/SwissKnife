using System.Windows;
using System.Windows.Input;


namespace SwissKnife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Release the Kraken!
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }


        void DragMode(object sender, MouseButtonEventArgs e) => this.DragMove();
    }
}
