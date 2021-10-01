using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DictionaryEditor
{
    class CoreDictionary
    {

        #region Fields

        private string fileName;
        private List<Word> list;

        public string FileName
        {
            set { fileName = value; }
        }

        #endregion

        #region Constructors

        public CoreDictionary(string fileName)
        {
            this.fileName = fileName;
            list = new List<Word>();
        }

        #endregion

        #region Public Properties

        public Word this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        #endregion

        #region Public Methods

        public void Add(string ru, string eng )
        {
            list.Add(new Word(ru, eng));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }

        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Word>));
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                list = (List<Word>)xmlSerializer.Deserialize(stream);
            }

        }
        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Word>));
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }

        }

        #endregion
    }
}
