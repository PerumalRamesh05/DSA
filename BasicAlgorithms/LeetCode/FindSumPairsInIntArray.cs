using System.Collections.Generic;

public class FindSumPairsInIntArray
{  
    /// The time complexity is O(n^2) since of the loop-i and loop-j
    public IList<KVPair<int, int>> doBruteForcedlogic(int[] array, int sum)
    {
        IList<KVPair<int, int>> kvs = null; 
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if ((array[i] + array[j]) == sum)
                {
                    if (kvs == null) kvs = new List<KVPair<int, int>>();
                    kvs.Add(new KVPair<int, int>(array[i], array[j]));
                }
            }
        }
        return kvs;
    }

    /// Use HashSet to reduce Timecomplexity to O(n)
    public IList<KVPair<int, int>> doHashSetBasedLogic(int[] array, int sum)
    {
        HashSet<int> tempStore = new HashSet<int>(array.Length);
        IList<KVPair<int, int>> kvs = new List<KVPair<int, int>>();

        int difference;
        for (int i = 0; i < array.Length; i++)
        {
            difference = sum - array[i];
            if (!tempStore.Contains(difference))
            {
                tempStore.Add(array[i]);
            }
            else
            {
                kvs.Add(new KVPair<int, int>(array[i], difference));
            }
        }
        return kvs;
    }
}

public class KVPair<K, V>
{
    private K key;

    private V value;

    public KVPair(K key, V value)
    {
        this.key = key;
        this.value = value;
    }

    public K getKey()
    {
        return key;
    }

    public V getValue()
    {
        return value;
    }
    public override string ToString()
    {
        return key.ToString() + "," + value.ToString();
    }
}
