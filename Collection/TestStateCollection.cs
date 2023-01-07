
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class TestStateCollection
    {
        public static void TestStateCollections()
        {

            // add new state
            var newState = new StateCollection("ME", "Maine", "Augusta", 1350141);

            // list
            var sList = StateCollection.StateList;
            sList.Add(newState);
            Console.WriteLine("\n\t-- State List with Maine --");
            foreach (var state in sList)
                Console.WriteLine(state);
            var item = sList.SingleOrDefault(sl => sl.Name.Equals("Maine"));

            //sList.Remove("Maine");

            Console.WriteLine("\t-- List - Maine removed --");
            foreach (var state in sList)
                Console.WriteLine(state);

            // SortedDictionary 
            var sDict = StateCollection.StateSD;
            sDict.Add(newState.Code, newState.Name);

            Console.WriteLine("\n\t-- State Dictionary with Maine --");
            foreach (var state in sDict)
                Console.WriteLine("{0}\t{1}", state.Key, state.Value);

            sDict.Remove("ME");

            Console.WriteLine("\n\t-- Dictionary - Maine removed --");
            foreach (var state in sDict)
                Console.WriteLine("{0}\t{1}", state.Key, state.Value);

            // SortedList
            var sSort = StateCollection.StateSL;
            sSort.Add(newState.Code, newState.Name);

            Console.WriteLine("\n\t-- State Sorted List with Maine  --");
            foreach (KeyValuePair<string, StateCollection> state in sSort)
                Console.WriteLine(state.Value);

            sSort.Remove("ME");

            Console.WriteLine("\n\t-- Sorted List - Maine removed --");
            foreach (KeyValuePair<string, StateCollection> state in sSort)
                Console.WriteLine("{0} {1,15} {2,15} {3,12}", state.Key, state.Value.Name, state.Value.Capitol, state.Value.Population);

        }
    }
}
