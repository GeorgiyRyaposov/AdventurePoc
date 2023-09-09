using System;
using UnityEngine;

namespace Common.Data
{
    [Serializable]
    public struct Id : IComparable, IComparable<Guid>, IEquatable<Guid>, IEquatable<Id>
    {
        [SerializeField] private Guid value;

        //[JsonConstructor]
        public Id(string value)
        {
            if (Guid.TryParse(value, out var guid))
            {
                this.value = guid;
            }
            else
            {
                this.value = Guid.Empty;
            }
        }

        public Id(Guid value)
        {
            this.value = value;
        }

        public static Id Create()
        {
            Id result;
            result.value = Guid.NewGuid();
            return result;
        }

        public bool IsZero => value == Guid.Empty;
        public static Id GetZero()
        {
            Id result;
            result.value = Guid.Empty;
            return result;
        }

        public Guid GetValue()
        {
            return value;
        }
        

        #region interfaces
        public int CompareTo(object value)
        {
            if (value == null)
            {
                return 1;
            }

            if (value is Guid guidValue)
            {
                return guidValue.CompareTo(this.value);
            }

            return 0;
        }

        public int CompareTo(Guid other)
        {
            return value.CompareTo(other);
        }

        public bool Equals(Guid other)
        {
            return value.Equals(other);
        }

        public bool Equals(Id other)
        {
            return value == other.value;
        }

        public override int GetHashCode()
        {
            return -1939223833 + value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            if (IsZero)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        // this is first one '=='
        public static bool operator ==(Id a, Id b)
        {
            return a.value == b.value;
        }

        // this is second one '!='
        public static bool operator !=(Id a, Id b)
        {
            return a.value != b.value;
        }

        public static implicit operator Guid(Id id) => id.value;
        public static implicit operator Id(Guid v) => new Id(v);
        public static implicit operator Id(string v) => new Id(v);
        public static implicit operator string(Id v) => v.value.ToString();
        #endregion
    }
}
