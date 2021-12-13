using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace SwissKnife
{
    [Serializable]
    public class RulesPreset
    {
        #region Properties
        internal static ObservableCollection<RulesPreset> RulesCollection { get; set; }

        public string Name { get; set; }
        public string TextForInsert { get; set; }    //Редактируемый текст.
        public string InputSeparator { get; set; }   //Элемент по которому разбивается исходный текст.
        public List<DualPosition> MarksCollection { get; set; }
        #endregion


        #region Constructors
        public RulesPreset(string Name) : this() => this.Name = Name;

        public RulesPreset()
        {
            this.Name = "Default";
            InputSeparator = ",";
            MarksCollection = new List<DualPosition>();
        }

        static RulesPreset()
        {
            RulesCollection = new ObservableCollection<RulesPreset>();
            RulesCollection.Add(new RulesPreset("Rule1")
            {
                InputSeparator = ", ",
                TextForInsert = "Край ты мой заброшенный,\nКрай ты мой, пустырь,\nСенокос некошеный,\nЛес да монастырь.",
                MarksCollection = new List<DualPosition>() { (12, 11), (38, 7), (55, 9), (73, 9) }
            });
        }
        #endregion


        #region IO Rules Control
        static XmlSerializer xml = new XmlSerializer(typeof(List<RulesPreset>));

        internal static void LoadRules()
        {
            string path = @"Rules.xml";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
                using (FileStream fs = new FileStream("Rules.xml", FileMode.Open, FileAccess.Read))
                {
                    List<RulesPreset> rules = (List<RulesPreset>)xml.Deserialize(fs);
                    RulesCollection.Clear();
                    foreach (var rule in rules)
                    {
                        RulesCollection.Add(rule);
                    }
                    MessageBox.Show("Successfully loaded");
                }
            else
                MessageBox.Show("Save file not found");
        }


        internal static void SaveRules()
        {
            using(FileStream fs = new FileStream("Rules.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                List<RulesPreset> rules = new List<RulesPreset>(RulesCollection);
                xml.Serialize(fs, rules);
                MessageBox.Show("Successfully saved");
            }
        }
        #endregion


        public override string ToString() =>  Name;
    }


    public class DualPosition
    {
        public int index;
        public int length;
        public int altIndex;
        public int altLength;
        public int SelectionEnd { get => index + length; }
        public int altSelectionEnd { get => altIndex + altLength; }

        public DualPosition(int index, int length, int richBoxIndex, int richBoxLength)
        {
            this.index = index; 
            this.length = length;
            this.altIndex = richBoxIndex;
            this.altLength = richBoxLength;
        }
        public DualPosition(int index, int length)
        {
            this.index = index;
            this.length = length;
        }

        DualPosition() { }

        public static implicit operator DualPosition((int index, int length) x) => 
                                    new DualPosition(x.index, x.length);
    }
}
