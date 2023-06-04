public class Jisho<TKey, TValue>
{
    private const int DefaultCapacity = 16;

    private TKey[] keys;
    private TValue[] values;
    private int count;

    public Jisho()
    {
        keys = new TKey[DefaultCapacity];
        values = new TValue[DefaultCapacity];
        count = 0;
    }

    public int Count => count;

    public void Add(TKey key, TValue value)
    {
        // Resize arrays if necessary
        if (count == keys.Length)
        {
            Array.Resize(ref keys, keys.Length * 2);
            Array.Resize(ref values, values.Length * 2);
        }

        keys[count] = key;
        values[count] = value;
        count++;
    }

    public bool ContainsKey(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
                return true;
        }
        return false;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
            {
                value = values[i];
                return true;
            }
        }
        value = default;
        return false;
    }

    public bool Remove(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
            {
                // Move the last element to the current position
                keys[i] = keys[count - 1];
                values[i] = values[count - 1];
                count--;
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        count = 0;
    }
}
