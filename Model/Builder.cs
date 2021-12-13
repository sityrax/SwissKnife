using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using static SwissKnife.RulesPreset;

namespace SwissKnife
{
    class Builder : ModelBase
    {
        internal static RulesPreset CurrentRule { get; private set; }


        static Builder()
        {
            CurrentRule = RulesCollection[0];
        }


        internal static void ChangeCurrentRule(SelectionChangedEventArgs Arg)
        {
            if (Arg is not null)
            {
                if (Arg.AddedItems.Count > 0)
                {
                    RulesPreset rule = (RulesPreset)Arg.AddedItems[0];
                    CurrentRule = rule;
                }
            }
        }


        /// <summary>
        /// Rebuids prepared text with InputText.
        /// </summary>
        internal static void Rebuild(string inputText)
        {
            if (CurrentRule is not null)
            {
                StringBuilder recipient = new StringBuilder(CurrentRule.TextForInsert);
                string[] donor = SplitText(inputText, false);
                var marksCollection = CurrentRule.MarksCollection;

                if (marksCollection.Count > 0)
                {
                    for (int i = marksCollection.Count - 1; i > -1; i--)
                    {
                        if (donor.Length - 1 < i) continue;
                        DualPosition pointer = marksCollection[i];
                        recipient.Remove(pointer.index, pointer.length);
                        recipient.Insert(pointer.index, donor[i]);
                    }
                }
                Clipboard.SetText(recipient.ToString());    //TODO: Add ability to disable by checkbox.
                OutputTextChanger(recipient.ToString());
            }
            else
                MessageBox.Show("We have a problem!");
        }


        /// <summary>
        /// Splits a text by elements.
        /// </summary>
        /// <param name="toLower">Convert to lowercase.</param>
        private static string[] SplitText(string inputedText, bool toLower)
        {
            if (toLower) inputedText = inputedText.ToLower();
            string[] massive;

            massive = new[]{ CurrentRule.InputSeparator ?? "," };

            string[] toPrintM = inputedText.Split(massive, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return toPrintM;
        }


        internal static void RemoveRule()
        {
            if(CurrentRule is not null)
            {
            int index = RulesCollection.IndexOf(CurrentRule);
            RulesCollection.Remove(CurrentRule);
            if(index > RulesCollection.Count - 1)
            CurrentRule = RulesCollection[index - 1];
            else
            if (RulesCollection.Count == 0)
                CurrentRule = null;
            else
                CurrentRule = RulesCollection[index];
            }
        }
    }
}
