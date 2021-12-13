using System;
using System.Windows;


namespace SwissKnife
{
    class BorderViewModel : ViewModelBase
    {
        #region MainControlButtons
        private EventControl closeButton;
        public EventControl CloseButton
        {
            get
            {
                return closeButton ??
                  (closeButton = new EventControl(obj =>
                  {
                      (obj as Window).Close();

                  }));
            }
        }


        private EventControl minimizeButton;
        public EventControl MinimizeButton
        {
            get
            {
                return minimizeButton ??
                  (minimizeButton = new EventControl(obj =>
                  {
                          foreach (Window item in Application.Current.Windows)
                          {
                              if (item.IsActive == true)
                                  item.WindowState = WindowState.Minimized;
                          }
                  }));
            }
        }


        private EventControl fixOver;
        public EventControl FixOver
        {
            get
            {
                return fixOver ??
                  (fixOver = new EventControl(obj =>
                  {
                      Window curentWindow = obj as Window;
                      curentWindow.Topmost = !curentWindow.Topmost;
                  }));
            }
        }


        private EventControl fullScreenButton;
        [ObsoleteAttribute("This property temporarily unavailable", false)]
        public EventControl FullScreenButton
        {
            get
            {
                return fullScreenButton ??
                  (fullScreenButton = new EventControl(obj =>
                  {
                      Window window = obj as Window;

                      if (window.WindowState == WindowState.Normal || window.WindowState == WindowState.Minimized)
                      {
                          window.WindowState = WindowState.Maximized;
                          if (window is MainWindow)
                          ((MainWindow)window).BackGroundFullScreen.Visibility = Visibility.Visible;
                      }
                      else
                      {
                          window.WindowState = WindowState.Normal;
                          if (window is MainWindow)
                              ((MainWindow)window).BackGroundFullScreen.Visibility = Visibility.Hidden;
                      }
                  }));
            }
        }
        #endregion
    }
}
