using System;
using System.Windows;
using System.Windows.Controls;

using static SwissKnife.ModelBase;
using static SwissKnife.Builder;

namespace SwissKnife
{
    class BuildViewModel : ViewModelBase
    {
        public BuildViewModel()
        {
            InputTextChangedEvent += InputTextChanger;
            OutputTextChangedEvent += OutputTextChanger;
        }


        private EventControl inputFocus;
        public EventControl InputFocus
        {
            get
            {
                return inputFocus ??
                    (inputFocus = new EventControl(obj => FirstFocus()));
            }
        }


        private EventControl inputDrop;
        public EventControl InputDrop
        {
            get
            {
                return inputDrop ??
                    (inputDrop = new EventControl(obj => { InputDrop(obj as DragEventArgs); }));
            }
        }


        private EventControl dragEnterFile;
        public EventControl DragEnterFile
        {
            get
            {
                return dragEnterFile ??
                    (dragEnterFile = new EventControl(obj => { DragEnterFile(obj as DragEventArgs); }));
            }
        }


        private EventControl rebuild;
        public EventControl Rebuild
        {
            get
            {
                return rebuild ??
                  (rebuild = new EventControl(obj => Rebuild(inputText)));
            }
        }


        private EventControl changeRule;
        public EventControl ChangeRule
        {
            get
            {
                return changeRule ??
                  (changeRule = new EventControl(obj => ChangeCurrentRule(obj as SelectionChangedEventArgs)));
            }
        }


        private EventControl removeRule;
        public EventControl RemoveRule
        {
            get
            {
                return removeRule ??
                  (removeRule = new EventControl(obj => RemoveRule()));
            }
        }

        #region InputText
        private string inputText;
        public string InputText
        {
            get
            {
                return inputText;
            }
            set
            {
                inputText = value;
                OnPropertyChanged("InputText");
            }
        }
        void InputTextChanger(string text) => InputText = text;
        #endregion

        #region OutputText
        private string outputText;
        public string OutputText
        {
            get
            {
                return outputText;
            }
            set
            {
                outputText = value;
                OnPropertyChanged("OutputText");
            }
        }
        void OutputTextChanger(string text) => OutputText = text;
        #endregion
    }
}
