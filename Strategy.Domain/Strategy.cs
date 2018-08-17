using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy.Domain
{
    internal abstract class SortStrategy
    {
        public abstract void Sort(IList<string> list);
    }

    internal class QuickSort : SortStrategy
    {
        public override void Sort(IList<string> list)
        {
            list.ToList().Sort();
            Console.WriteLine("QuickSorted list");
        }
    }

    internal class ShellSort : SortStrategy
    {
        public override void Sort(IList<string> list)
        {
            list.ToList().Sort();
            Console.WriteLine("ShellSorted list");
        }
    }

    internal class MergeSort : SortStrategy
    {
        public override void Sort(IList<string> list)
        {
            list.ToList().Sort();
            Console.WriteLine("MergeSorted list");
        }
    }

    internal class SortedList
    {
        private readonly IList<string> list = new List<string>();
        private SortStrategy strategy;

        public void SetSortedList(SortStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Add(string name) => list.Add(name);
        public void Sort()
        {
            strategy.Sort(list);

            list.ToList().ForEach(x => Console.WriteLine($"Name: {x}"));
        }
    }

    public class Strategy
    {
        public static void Execucao()
        {
            var studentRecords = new SortedList();
            studentRecords.Add("Samuel");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortedList(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortedList(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortedList(new MergeSort());
            studentRecords.Sort();
        }
    }

}
