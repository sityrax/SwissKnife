using System;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;

using static SwissKnife.Builder;
using static SwissKnife.RulesPreset;
using System.IO;

namespace SwissKnife
{
    class RuleEditor : ModelBase
    {
        #region UIElemenst
        internal static RichTextBox RichBoxEditor { get; set; }
        internal static TextBox TextBoxEditor { get; set; }
        internal static UIElement DropPanel { get; set; }
        #endregion

        internal static RulesPreset Edited { get; set; }
        static bool textChangeFlag;


        static RuleEditor()
        {
            Edited = CurrentRule;
        }


        #region RuleCreate
        /// <summary>
        /// Marks word or another element.
        /// </summary>
        internal static void Mark()
        {
            GetSelectionPosition(out int markLength, out int markIndex);

            if (markIndex > 0 || markLength > 0)
            {
                int richBoxIndex = RichBoxEditor.Document.ContentStart.GetOffsetToPosition(RichBoxEditor.Selection.Start);
                int richBoxLength = RichBoxEditor.Selection.Start.GetOffsetToPosition(RichBoxEditor.Selection.End);
                Edited.MarksCollection.Add(new DualPosition(markIndex, markLength, richBoxIndex, richBoxLength));
                Edited.MarksCollection.Sort(delegate (DualPosition first, DualPosition second)
                {
                    if (first.index > second.index) return 1;
                    else
                    if (first.index < second.index) return -1;
                    else return 0;
                });

                Random random = new Random();
                byte r = (byte)random.Next(100, 130);
                byte g = (byte)random.Next(100, 130);
                byte b = (byte)random.Next(100, 130);

                int index = random.Next(0, 3);
                float[] complementary = new float[] { 1, 1, 1 };
                complementary[index] = 0.2f;

                float[] oppositeComplementary = new float[] { 0.2f, 0.2f, 0.2f };
                oppositeComplementary[index] = 1;

                int i = random.Next(0, 2);
                int[] reverse = new int[] { 100, 100 };
                reverse[i] = 0;

                Color markColorBackground = Color.FromRgb((byte)(complementary[0] * (reverse[0] + r)), 
                                                          (byte)(complementary[1] * (reverse[0] + g)), 
                                                          (byte)(complementary[2] * (reverse[0] + b)));
                Color markColorForeground = Color.FromRgb((byte)(oppositeComplementary[0] * (reverse[1] + r)), 
                                                          (byte)(oppositeComplementary[1] * (reverse[1] + g)), 
                                                          (byte)(oppositeComplementary[2] * (reverse[1] + b)));
                                                                                    
                RichBoxEditor.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(markColorBackground));
                RichBoxEditor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(markColorForeground));

                StringBuilder message = new StringBuilder();
                foreach (var item in Edited.MarksCollection)
                {
                    message.Append(item.index.ToString() + ", ");
                }
                MessageBox.Show(message.ToString());
            }
            else
                MessageBox.Show("Pleace, import or print a text");
        }


        /// <summary>
        /// Unmarks word or another element.
        /// </summary>
        internal static void Unmark()
        {
            GetSelectionPosition(out int markLength, out int markIndex);

            if (markIndex > 0 || markLength > 0)
            {
                Color markColorBackground = Colors.White;
                Color markColorForeground = Colors.Black;

                RichBoxEditor.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(markColorBackground));
                RichBoxEditor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(markColorForeground));

                DualPosition element = Edited.MarksCollection.Find((x) => x.index <= markIndex && (x.index + x.length) >= markIndex);
                if (!Edited.MarksCollection.Remove(element))
                {
                    MessageBox.Show("Sorry, this mark is not exist.");
                    return;
                }
            }
            else
                MessageBox.Show("Select a symbol");
        }


        /// <summary>
        /// Requests and preserve a string for separating input text.
        /// </summary>
        internal static void AssignSeparator()
        {
            string message = Application.Current.Resources["t_inputseparator"].ToString();
            string separator = InputRequestRequire(message);
            Edited.InputSeparator = separator;
        }


        /// <summary>
        /// Adds a rule to RuleCollection.
        /// </summary>
        internal static void MakeRule()
        {
            Edited.TextForInsert = new TextRange(RichBoxEditor.Document.ContentStart, RichBoxEditor.Document.ContentEnd).Text;
            if (!RulesCollection.Contains(Edited))
            {
                RulesPresetsUpdate(Edited);
                MessageBox.Show("Rule was made");
            }
            else
                MessageBox.Show("Rule was changed");
        }


        /// <summary>
        /// Preserve a link to an RichTextBox element.
        /// </summary>
        internal static void RichEditorAssign(RichTextBox receivedRichBox)
        {
            if (receivedRichBox is not null)
            {
                if (!textChangeFlag)
                {
                    receivedRichBox.TextChanged += RichBoxChanged;  //Остаемся в курсе последних событий.
                    textChangeFlag = true;
                }
                RichBoxEditor = receivedRichBox;    //Сохраняем ссылку.
            }
        }


        /// <summary>
        /// Controls changes in the text and makes appropriate changes to the collection.
        /// </summary>
        internal static void RichBoxChanged(object sender, TextChangedEventArgs args)   //TODO: Проверять на удаление символов внутри отмеченной зоны.
        {
            if (args.Changes.Count == 1)
            {
                List<TextChange> list = new List<TextChange>(args.Changes);  //Укутываем коллекцию.
                var marksCollection = Edited.MarksCollection;               //Кэшируем ссылку на коллекцию.

                GetSelectionPosition(out int markLength, out int markIndex);

                if (marksCollection.Count > 0)
                {
                    if (list[0].AddedLength > 0)    //Если символы добавлены.
                        for (int j = marksCollection.Count - 1; markIndex - list[0].AddedLength <= marksCollection[j].index || 
                                                                markIndex - list[0].AddedLength <= marksCollection[j].SelectionEnd; j--)
                        {
                            var item = marksCollection[j];
                            if (marksCollection[j].index <= markIndex - list[0].AddedLength)
                            {
                                marksCollection[j].length = item.length + list[0].AddedLength;
                                marksCollection[j].altLength = item.altLength + list[0].AddedLength;
                                break;
                            }
                            marksCollection[j].index = item.index + list[0].AddedLength;
                            marksCollection[j].altIndex = item.altIndex + list[0].AddedLength;
                        }
                    else
                    if (list[0].RemovedLength > 0)  //Если символы удалены.
                        for (int k = marksCollection.Count - 1; markIndex + list[0].RemovedLength <= marksCollection[k].index ||
                                                                markIndex <= marksCollection[k].SelectionEnd; k--)
                        {
                            var item = marksCollection[k];
                            if (marksCollection[k].index <= markIndex + list[0].RemovedLength)
                            {
                                int removed = (marksCollection[k].SelectionEnd) - markIndex;
                                if (markIndex + list[0].RemovedLength <= marksCollection[k].SelectionEnd)
                                {
                                    marksCollection[k].length = item.length - list[0].RemovedLength;
                                    marksCollection[k].altLength = item.altLength - list[0].RemovedLength;
                                }
                                else
                                {
                                    marksCollection[k].length = item.length - removed;
                                    marksCollection[k].altLength = item.altLength - removed;
                                }
                                break;
                            }
                            marksCollection[k].index = item.index - list[0].RemovedLength;
                            marksCollection[k].altIndex = item.altIndex - list[0].RemovedLength;
                        }
                }
            }
        }


        /// <summary>
        /// Caret position without formatting characters.
        /// </summary>
        static void GetSelectionPosition( out int markLength, out int markIndex)
        {
            markLength = RichBoxEditor.Selection.Text.Length;
            RichBoxEditor.Selection.Select(RichBoxEditor.Document.ContentStart, RichBoxEditor.Selection.Start);
            markIndex = RichBoxEditor.Selection.Text.Length;
            RichBoxEditor.Selection.Select(RichBoxEditor.Selection.End, RichBoxEditor.Selection.End.GetPositionAtOffset(markLength));
        }
        #endregion
    }
}
