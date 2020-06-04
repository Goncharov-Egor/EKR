using System;
using System.Runtime.Serialization;

namespace EKRLIb1 {
    [DataContract]
    public class Freight : Item {
        public Freight(double weight, double a, double b, double c) : base(weight) {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentException("Invalid A, B or C");
            A = a;
            B = b;
            C = c;
        }

        [DataMember]public double A { get; private set; }
        [DataMember]public double B { get; private set; }
        [DataMember]public double C { get; private set; }

        public double GetDimensionalWeight() => A * B * C / 50;

        public double GetRealValue() => Weight > GetDimensionalWeight() ? Weight : GetDimensionalWeight();
        public override string ToString() => base.ToString() + $" A = {A:F4}, B = {B:F4}, C = {C:F4}, " +
                                            $"Dimensional Weight = {GetDimensionalWeight():F4}, " +
                                            $"Real Value = {GetRealValue():F4}"; 
    }
}
