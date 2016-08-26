using System;

namespace He4.Collections.Generic
{

  /// <summary>
  /// Does something awesome
  /// </summary>
  public interface IIndexedDictionary<TKey, TValue> :
    System.Collections.Generic.IDictionary<TKey, TValue>,
    System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<TKey, TValue>>
  {
  }
}

