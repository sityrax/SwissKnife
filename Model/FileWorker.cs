using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;

using static SwissKnife.RulesPreset;
using static SwissKnife.RuleEditor;


namespace SwissKnife
{
    class FileWorker : ModelBase
    {
        #region ImportTextFile
        internal static void OpenTextFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Text"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                ImportTextFile(dlg.FileName);
            }
        }


        internal static void DropTextFile(DragEventArgs Arg)
        {
            if (Arg is not null)
            {
                string[] filePath = (string[])Arg.Data.GetData(DataFormats.FileDrop);
                FileInfo fi = new FileInfo(filePath[0]);
                if (fi.Name.EndsWith(".txt"))
                {
                    ImportTextFile(filePath[0]);
                }
            }
        }


        private static void ImportTextFile(string path)
        {
            string message = Application.Current.Resources["t_inputnamerequest"].ToString();
            string name = InputRequestRequire(message);

            if (name is null || name == string.Empty) name = $"Rule{RulesCollection.Count + 1}";
            Edited = new RulesPreset(name) { InputSeparator = Edited.InputSeparator };
            CurrentTitleChanged(name);

            TextRange doc = new TextRange(RichBoxEditor.Document.ContentStart, RichBoxEditor.Document.ContentEnd);
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                doc.Load(fs, DataFormats.Text);
            }
            DropPanel.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
