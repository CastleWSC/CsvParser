using System;
using System.Collections.Generic;
using System.Text;

namespace CsvParser
{
    public class CsvRowData
    {

        protected Dictionary<string, CsvObject> _datas;

        public string[] Tags
        {
            get
            {
                List<string> tags = new List<string>(_datas.Keys);
                return tags.ToArray();
            }
        }

        public CsvObject[] Datas
        {
            get
            {
                List<CsvObject> datas = new List<CsvObject>(_datas.Values);
                return datas.ToArray();
            }
        }


        public CsvRowData(string[] tags, string[] fields)
        {
            _datas = new Dictionary<string, CsvObject>();

            for (int i=0; i<tags.Length; i++)
            {
                _datas.Add(tags[i], new CsvObject(fields[i].Trim()));
            }
        }

        public CsvObject GetField(string tag)
        {
            CsvObject ret = null;
            _datas.TryGetValue(tag.ToUpper(), out ret);
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kv in _datas)
                sb.Append(kv.Value + " ");

            return sb.ToString();
        }
    }
}
