using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    #region State
    public class StateCollection
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Capitol { get; set; }
        public int Population { get; set; }
        public static List<StateCollection> StateList
        {
            get
            {
                var list = new List<StateCollection>();
                foreach (var s in states)
                {
                    list.Add(s);
                }
                list.AddRange(states);
                return list;
            }
        }
        public static SortedDictionary<string, string> StateSD
        {
            get
            {
                var StatesSD = new SortedDictionary<string, string>();
                foreach (var s in states)
                {
                    StatesSD.Add(s.Code,s.Name);
                }
                return StatesSD;

            }
        }
        public static SortedList<string, string> StateSL
        {
            get
            {
                var StateSL = new SortedList<string, string>();
                foreach (var s in states)
                {
                    StateSL.Add(s.Code, s.Name);
                }
                return StateSL;

            }
        }
        private static StateCollection[] states =
        {
            new StateCollection("Virginia", "VA", "Richmond", 1234234),
            new StateCollection("Maryland", "MY", "UrM", 2341234),
            new StateCollection("Florida", "FL", "Idk", 923423),
            new StateCollection("New York", "NY", "sadf", 323445),
            new StateCollection("Texas", "TX", "Houston", 538834)
        };
        public StateCollection(string name, string code, string capitol, int population)
        {
            Name = name;
            Code = code;
            Capitol = capitol;
            Population = population;
        }
        //properties
        ///constructor
        //and property to create like students
    }
    #endregion
}
