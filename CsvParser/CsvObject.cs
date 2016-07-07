using System;

namespace CsvParser
{
    public class CsvObject
    {
        protected string _data;
        public string Value { get { return _data; } }

        public CsvObject(string data)
        {
            this._data = data;
        }

        public float ToFloat()
        {
            return Convert.ToSingle(_data);
        }

        public float ToNumber()
        {
            return Convert.ToInt32(_data);
        }

        public T ToEnumValue<T>()
        {
            return (T)Enum.Parse(typeof(T), _data);
        }

        public override string ToString()
        {
            return _data;
        }
    }
}
