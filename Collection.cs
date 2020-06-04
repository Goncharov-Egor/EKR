using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EKRLIb1 {

    [DataContract]
    public class Collection<T> : IEnumerable<T> where T : Item {

        [DataMember]private List<T> items;

        public Collection() {
            items = new List<T>();
        }

        public IEnumerator<T> GetEnumerator() {
            return new CollectionEnumerator<T>(items);
        }

        public void Add(T item) => items.Add(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [DataContract]
        public class CollectionEnumerator<U> : IEnumerator<U> where U : T {

            [DataMember]List<U> lst = new List<U>();
            [DataMember]int pos = -1;

            public CollectionEnumerator(IEnumerable<U> lst) {
                this.lst = (from i in lst
                            where i.Weight > 0.1
                            select i).ToList();
            } 

            object IEnumerator.Current => lst[pos];

            U IEnumerator<U>.Current => lst[pos];

            public void Dispose() {

            }

            public bool MoveNext() => ++pos  < lst.Count;

            public void Reset() {
                pos = -1;
            }
        }
    }
}
