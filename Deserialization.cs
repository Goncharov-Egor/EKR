using System;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Linq;
using EKRLIb1;
using System.Collections.Generic;

namespace Deserialization {
    class MainClass {

        public static readonly string path = @"../../../Serialization/bin/Debug/freights.json";

        public static void Main(string[] args) {
            do {
                Console.Clear();
                try {
                    Collection<Freight> freights;
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Collection<Freight>));
                        freights = (js.ReadObject(fs) as Collection<Freight>);
                        if (freights == null) throw new Exception("It was desirialization error");
                    }


                    Console.WriteLine("Sucsess deserializtion:");
                    foreach(var it in freights)
                        Console.WriteLine(it);
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (var i in Linq1(freights))
                        Console.WriteLine(i);
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (var i in Linq2(freights)) {
                        Console.WriteLine("Elements with weight " + i.Key + " are:");
                        foreach(var j in i)
                            Console.WriteLine(j);
                    }

                } catch (Exception ex) {
                    Console.WriteLine(ex.Message + " " + ex.HelpLink);
                }
                Console.WriteLine("If you wanna exit -> press escape");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public static IEnumerable<Freight> Linq1(IEnumerable<Freight> freights) {
            var ans = from i in freights
                      where i.GetRealValue() > 3.0
                      orderby i.Weight descending
                      select i;
            Console.WriteLine("Elements with real weight above 3 are " + ans.Count());
            return ans;
        }

        public static IEnumerable<IGrouping<double, Freight>> Linq2(IEnumerable<Freight> freights) {
            var ans = from i in freights
                      group i by i.Weight;
            return ans;
        }
    }
}
