using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates {
	public class Counter {
		private int threshold;
		private int count = 0;
		public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

		public void SetThreshold(int threshold) {
			this.threshold = threshold;
		}
		public void IncreaseCount() {
			this.count += 1;
			if (this.count >= this.threshold) {
				ThresholdReached?.Invoke(this, new ThresholdReachedEventArgs() { Message = $"{this.count} is past the {this.threshold} threshold" });
				//EventPublisherThresholdReached(new Counter_ThresholdReachedEventArgs() { Message = $"{this.count} is past the {this.threshold} threshold" });
			}
		}
		public void PrintCounter() {
			System.Console.WriteLine(this.count);
		}

		protected virtual void OnThresholdReached(ThresholdReachedEventArgs args) {
			ThresholdReached?.Invoke(this, args);
		}
	}

	public class ThresholdReachedEventArgs : EventArgs{
		public string Message { get; set; }
	}


	public static class Console {
		public delegate int ComparatorDelegate<T>(T a, T b);
		private static void QuickSort<T>(this List<T> list, ComparatorDelegate<T> comparator, int low, int high) {
			if (low >= high) { return; }
			T median = list[high];
			int i = low;
			for(int j = low; j < high; j++) {
				if (comparator(list[j], median) < 0) {
					list.Swap(i, j);
					i++;
				}
			}
			list.Swap(i, high);
			list.QuickSort(comparator, low, i - 1);
			list.QuickSort(comparator, i + 1, high);
		}
		private static void Swap<T>(this List<T> list, int i, int j) {
			T temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}
		public static List<T> QuickSort<T>(this List<T> list, ComparatorDelegate<T> comparator) {
			List<T> retVal = new List<T>(list);
			retVal.QuickSort(comparator, 0, list.Count - 1);
			return retVal;
			//if (list.Count <= 1) {
			//	return list;
			//}
			//T median = list[0];
			//List<T> ltList = new List<T>();
			//List<T> equalList = new List<T>();
			//List<T> gtList = new List<T>();
			//foreach (T t in list) {
			//	if (comparator(t, median) < 0) {
			//		ltList.Add(t);
			//	}
			//	if (comparator(t, median) == 0) {
			//		equalList.Add(t);
			//	}
			//	else if (comparator(t, median) > 0) {
			//		gtList.Add(t);
			//	}
			//}
			//List<T> sortedLtList = QuickSort(ltList, comparator);
			//List<T> sortedGtList = QuickSort(gtList, comparator);
			//sortedLtList.AddRange(equalList);
			//sortedLtList.AddRange(sortedGtList);
			//return sortedLtList;
		}
		public static int CompareStrings(string a, string b) {
			return String.Compare(b, a);
		}

		public static void MyHandler(object o, ThresholdReachedEventArgs args) {
			System.Console.WriteLine("{0} and fuck you", args.Message);
		}

		public static void PrintList<T>(this List<T> list) {
			foreach (T t in list) {
				System.Console.Write("{0}, ", t);
			}
			System.Console.WriteLine();
		}

		public static void Main(string[] args) {
			List<string> strings = new List<string>() {	"abc", "bbb", "aaa", "ccc", "cba", "bca", "fuckyou"};
			strings.QuickSort(String.Compare).PrintList();
			strings.QuickSort(CompareStrings).PrintList();
			strings.QuickSort(String.CompareOrdinal).PrintList();
			List<int> ints = new List<int>() { 4, 2, 3, 56, 6, 42, 132, 22222, 15, 15, 13 };
			ints.QuickSort((a, b) => a < b ? -1 : a == b ? 0 : 1).PrintList();
			System.Console.ReadLine();

			Counter c = new Counter();
			c.ThresholdReached += MyHandler;
			c.ThresholdReached -= null;
			c.SetThreshold(10);
			for (int i = 0; i < 11; i++) {
				c.IncreaseCount();
				c.PrintCounter();
			}
			System.Console.ReadLine();

			object o;
			o = new List<int>();
			List<int> list = o as List<int>;
			//o.Add(8);
			
			//List<string> strings = new List<string>() {
			//	"abc", "bbb", "aaa", "ccc", "cba", "bca", "fuckyou"
			//};
			//List<string> sortedStrings = QuickSort(strings, String.Compare);
			//foreach (string s in sortedStrings) {
			//	System.Console.Write("{0}, ", s);
			//}
			//sortedStrings = QuickSort(strings, CompareStrings);
			//System.Console.WriteLine();
			//foreach (string s in sortedStrings) {
			//	System.Console.Write("{0}, ", s);
			//}

			//System.Console.WriteLine();
			//List<int> ints = new List<int>() { 4, 2, 3, 56, 6, 42, 132, 22222, 15, 15, 13 };
			//List<int> sortedInts = QuickSort(ints, (a, b) => a < b ? -1 : a == b ? 0 : 1);
			//foreach (int i in sortedInts) {
			//	System.Console.Write("{0}, ", i);
			//}

			//System.Console.ReadLine();
		}
	}
}
