using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

using static SwissKnife.ModelBase;
using static SwissKnife.FileWorker;
using static SwissKnife.RulesPreset;
using static SwissKnife.RuleEditor;


namespace SwissKnife
{
    class RulesViewModel : ViewModelBase
    {
        public RulesViewModel()
        {
            CurrentTitleChangedEvent += (title) => CurrentTitle = title;
            RulesPresetsUpdated += (preset) => RulesPresets.Add(preset);
        }

        #region Buttons
        private EventControl makeRule;
        public EventControl MakeRule
        {
            get
            {
                return makeRule ??
                    (makeRule = new EventControl(obj => MakeRule()));
            }
        }

        private EventControl assignSeparator;
        public EventControl AssignSeparator
        {
            get
            {
                return assignSeparator ??
                    (assignSeparator = new EventControl(obj => AssignSeparator()));
            }
        }

        private EventControl mark;
        public EventControl Mark
        {
            get
            {
                return mark ??
                    (mark = new EventControl(obj => Mark()));
            }
        }

        private EventControl unmark;
        public EventControl Unmark
        {
            get
            {
                return unmark ??
                    (unmark = new EventControl(obj => Unmark()));
            }
        }
        #endregion

        private EventControl dropPanelLoaded;
        public EventControl DropPanelLoaded
        {
            get
            {
                return dropPanelLoaded ??
                    (dropPanelLoaded = new EventControl(obj => DropPanel = obj as UIElement));
            }
        }

        private EventControl richEditorLoaded;
        public EventControl RichEditorLoaded
        {
            get
            {
                return richEditorLoaded ??
                    (richEditorLoaded = new EventControl(obj => RichEditorAssign(obj as RichTextBox)));
            }
        }


        #region Processing with text
        public ObservableCollection<RulesPreset> RulesPresets
        {
            get
            {
                return RulesCollection;
            }
            set
            {
                RulesCollection = value;
                OnPropertyChanged("RulesPresets");
            }
        }

        private EventControl rulesPresetLoad;
        public EventControl RulesPresetLoad
        {
            get
            {
                return rulesPresetLoad ??
                    (rulesPresetLoad = new EventControl(obj => LoadRules()));
            }
        }

        private EventControl rulesPresetSave;
        public EventControl RulesPresetSave
        {
            get
            {
                return rulesPresetSave ??
                    (rulesPresetSave = new EventControl(obj => SaveRules()));
            }
        }

        private EventControl openFile;
        public EventControl OpenFile
        {
            get
            {
                return openFile ??
                    (openFile = new EventControl(obj => OpenTextFile()));
            }
        }


        private EventControl textFileDrop;
        public EventControl TextFileDrop
        {
            get
            {
                return textFileDrop ??
                    (textFileDrop = new EventControl(obj => DropTextFile(obj as System.Windows.DragEventArgs)));
            }
        }

        private string currentTitle;
        public string CurrentTitle
        {
            get
            {
                return currentTitle;
            }
            set
            {
                currentTitle = value;
                OnPropertyChanged("CurrentTitle");
            }
        }
        #endregion
    }
}
