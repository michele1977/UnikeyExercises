using System;

namespace Ninject_Exercise.Domain
{
    public class DomainObject : IEquatable<DomainObject>
    {
        #region Equality
        public bool Equals(DomainObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Prop1 == other.Prop1 && Prop2 == other.Prop2 && Prop3.Equals(other.Prop3);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DomainObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Prop1 != null ? Prop1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Prop2;
                hashCode = (hashCode * 397) ^ Prop3.GetHashCode();
                return hashCode;
            }
        }
       
        public static bool operator ==(DomainObject left, DomainObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DomainObject left, DomainObject right)
        {
            return !Equals(left, right);
        }
        #endregion
       
        public int Id { get; set; }
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
        public DateTime Prop3 { get; set; }
    }
}
