
using System.Collections.Generic;
namespace TaxiCapture
{
    /// <summary>
    /// http://archive.cnblogs.com/a/1263175/
    /// </summary>
    public class SynchronizedDictionary<TKey, TValue>
    {
        private readonly object _syncRoot = new object();
        private readonly Dictionary<TKey, TValue> _dictionaryBase;
        private TKey[] _allKeys = new TKey[0];
        private bool _keysIsNew = false;
        public SynchronizedDictionary()
        {
            _dictionaryBase = new Dictionary<TKey, TValue>();
        }

        internal Dictionary<TKey, TValue> DictionaryBase
        {
            get
            {
                return _dictionaryBase;
            }
        }

        public void Add(TKey key, TValue val)
        {
            this[key] = val;
            _keysIsNew = true;
        }

        public bool Remove(TKey key)
        {
            lock (_syncRoot)
            {
                if (_dictionaryBase.Remove(key))
                {
                    _keysIsNew = true;
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            lock (_syncRoot)
            {
                _dictionaryBase.Clear();
            }
            _keysIsNew = true;
        }

        public bool ContainsKey(TKey key)
        {
            lock (_syncRoot)
            {
                return _dictionaryBase.ContainsKey(key);
            }
        }

        public Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get
            {
                lock (_syncRoot)
                {
                    return _dictionaryBase.Keys;
                }
            }
        }

        public Dictionary<TKey, TValue>.ValueCollection Values
        {
            get
            {
                lock (_syncRoot)
                {
                    return _dictionaryBase.Values;
                }
            }
        }

        public TKey[] AllKeys
        {
            get
            {
                if (_keysIsNew)
                {
                    lock (_syncRoot)
                    {
                        if (_keysIsNew)
                        {
                            _allKeys = new TKey[_dictionaryBase.Keys.Count];
                            int index = 0;
                            foreach (TKey item in _dictionaryBase.Keys)
                            {
                                _allKeys[index] = item;
                                index++;
                            }
                            _keysIsNew = false;
                        }
                    }
                }
                return _allKeys;
            }
        }


        public TValue this[TKey key]
        {
            get
            {
                TValue v = default(TValue);
                try
                {
                    _dictionaryBase.TryGetValue(key, out v);
                }
                catch (System.Exception)
                {                    
                    lock (_syncRoot)
                    {
                        _dictionaryBase.TryGetValue(key, out v);
                    }
                }
                return v;
            }
            set
            {
                lock (_syncRoot)
                {
                    _dictionaryBase[key] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock (_syncRoot)
                {
                    return _dictionaryBase.Count;
                }
            }
        }

        public object SyncRoot
        {
            get
            {
                return _syncRoot;
            }
        }
    }
}
