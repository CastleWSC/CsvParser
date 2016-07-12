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

        public int ToInt()
        {
            return Convert.ToInt32(_data);
        }

        public bool ToBoolena()
        {
            return Convert.ToBoolean(_data);
        }

        public T ToEnumValue<T>()
        {
            return (T)Enum.Parse(typeof(T), _data);
        }

        public override string ToString()
        {
            return _data;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            CsvObject csvObj = obj as CsvObject;
            if (csvObj == null)
                return false;

            return this.Value == csvObj.Value;
        }

        public static bool operator ==(CsvObject a, CsvObject b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Value == b.Value;
        }

        public static bool operator !=(CsvObject a, CsvObject b)
        {
            return !(a == b);
        }
    }
}
