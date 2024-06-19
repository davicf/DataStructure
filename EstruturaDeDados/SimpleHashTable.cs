public class SimpleHashTable<TKey, TValue>
{
    private const int TableSize = 100;
    private readonly TValue?[] _values;
    private readonly bool[] _used;

    public SimpleHashTable()
    {
        _values = new TValue?[TableSize];
        _used = new bool[TableSize];
    }

    private int GetHashIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode() % TableSize);
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetHashIndex(key);
        if (!_used[index])
        {
            _values[index] = value;
            _used[index] = true;
        }
        else
        {
            throw new InvalidOperationException("Chave já existe na hashtable.");
        }
    }

    public bool ContainsKey(TKey key)
    {
        int index = GetHashIndex(key);
        return _used[index];
    }

    public TValue? Get(TKey key)
    {
        int index = GetHashIndex(key);
        if (_used[index])
        {
            return _values[index];
        }
        else
        {
            throw new KeyNotFoundException("Chave não encontrada na hashtable.");
        }
    }

    public void Remove(TKey key)
    {
        int index = GetHashIndex(key);
        if (_used[index])
        {
            _values[index] = default;
            _used[index] = false;
        }
        else
        {
            throw new KeyNotFoundException("Chave não encontrada na hashtable.");
        }
    }
}