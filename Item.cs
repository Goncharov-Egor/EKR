using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace EKRLIb1 {

    [DataContract]
    public class Item : IComparable<Item>{
        public Item(double weight) {
            if (weight < 0) throw new ArgumentException("Weight is not valid");
            Weight = weight;
        }
        [DataMember] public double Weight { get; private set; }

        public int CompareTo(Item other) => Weight.CompareTo(other.Weight);

        public override string ToString() => $"Weight = {Weight:F4}";

        public static explicit operator double (Item other) => other.Weight;
    }
}
