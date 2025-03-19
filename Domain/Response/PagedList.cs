public class PagedList<T>
{
    public T[] Items { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasNext { get; private set; }    

    public PagedList(IEnumerable<T> items, int totalCount, bool hasNext)
    {
        Items = items.ToArray();
        TotalCount = totalCount;
        HasNext = hasNext;
    }
}
