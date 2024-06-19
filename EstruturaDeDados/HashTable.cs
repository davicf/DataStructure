public class HashTable<TKey, TValue>
{
    private const int DefaultCapacity = 10;
    private KeyValuePair<TKey, TValue>[] table;
    private bool[] slotsUsed;

    public HashTable()
    {
        table = new KeyValuePair<TKey, TValue>[DefaultCapacity];
        slotsUsed = new bool[DefaultCapacity];
    }

    private int GetHashIndex(TKey key)
    {
        int hash = key.GetHashCode();
        return Math.Abs(hash % table.Length);
    }

    private int Probe(int index)
    {
        return (index + 1) % table.Length;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetHashIndex(key);

        while (slotsUsed[index])
        {
            if (table[index].Key.Equals(key))
            {
                throw new ArgumentException("Chave já existe na hashtable.");
            }
            index = Probe(index);
        }

        table[index] = new KeyValuePair<TKey, TValue>(key, value);
        slotsUsed[index] = true;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = GetHashIndex(key);
        int startIndex = index;

        while (slotsUsed[index])
        {
            if (table[index].Key.Equals(key))
            {
                value = table[index].Value;
                return true;
            }
            index = Probe(index);
            if (index == startIndex) break;
        }

        value = default(TValue);
        return false;
    }

    public bool Remove(TKey key)
    {
        int index = GetHashIndex(key);
        int startIndex = index;

        while (slotsUsed[index])
        {
            if (table[index].Key.Equals(key))
            {
                table[index] = default;
                slotsUsed[index] = false;
                return true;
            }
            index = Probe(index);
            if (index == startIndex) break;
        }

        return false;
    }
}