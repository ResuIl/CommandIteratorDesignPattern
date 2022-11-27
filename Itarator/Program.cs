interface IIterator
{
    bool HasNext();
    string Next();
    void Reset();
}

interface ICollection
{
    public IIterator CreateIterator();
}

class ResulCollection : ICollection
{
    List<string> list = new();
    public void Add(string item) => list.Add(item);
    public void Remove(string item) => list.Remove(item);
    public void Clear() => list.Clear();
    public IIterator CreateIterator() => new ResulIterator(list);
}

class ResulIterator : IIterator
{
    List<string> List = new();
    int pos = 0;
    public ResulIterator(List<string> list) => List = list;
    public bool HasNext() => List.Count > pos;
    public string Next() => List[pos++];
    public void Reset() => pos = 0;
}

class Program
{
    static void Main()
    {
        ResulCollection notification = new ResulCollection();
        notification.Add("one");
        notification.Add("two");
        notification.Add("three");
        IIterator iterator = notification.CreateIterator();

        while(iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }

        iterator.Reset();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}