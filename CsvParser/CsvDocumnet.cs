using System;
using System.Collections.Generic;

namespace CsvParser
{
    public class CsvDocumnet
    {

        private string[] _tags = null;
        public string[] Tags { get { return _tags; } }

        private CsvRowData[] _rowDatas = null;
        public CsvRowData[] RowDatas { get { return _rowDatas; } }

        public int NumOfRows { get { return _rowDatas.Length; } }
        public int NumOfColumns { get { return _tags.Length; } }

        public const char LINE_SEPARATOR = '\n';
        public const char FIELD_SEPARATOR = ',';
        

        public CsvDocumnet(string csvStr)
        {
            Parsing(csvStr);
        }

        void Parsing(string csvStr)
        {
            if (string.IsNullOrEmpty(csvStr))
                return;

            string[] rows = csvStr.Trim().Split(LINE_SEPARATOR);

            // Tags
            _tags = rows[0].Split(FIELD_SEPARATOR);
            for(int i=0; i<_tags.Length; i++)
            {
                _tags[i] = _tags[i].Trim().ToUpper();
            }

            // Row datas
            _rowDatas = new CsvRowData[rows.Length - 1];
            for(int i=0; i<_rowDatas.Length; i++)
            {
                string[] fields = rows[i + 1].Trim().Split(FIELD_SEPARATOR);
                _rowDatas[i] = new CsvRowData(_tags, fields);
            }
        }

        public CsvRowData GetRowData(int row)
        {
            if (row < 0 || row >= _rowDatas.Length)
                return null;

            return _rowDatas[row];
        }

        public CsvRowData GetRowData(string tag, string value)
        {
            int indx = Array.IndexOf(_tags, tag.ToUpper());

            if (indx < 0)
                return null;

            CsvObject csvObj = new CsvObject(value);
            
            foreach (var row in _rowDatas)
            {
                if (row.GetField(tag) == csvObj)
                    return row;   
            }

            return null;
        }
    }
}
