using System;

namespace He4.Collections.Generic
{

  /// <summary>
  /// Does something awesome
  /// </summary>
  ///
  /// <remarks>
  /// <para>
  /// This is similar to a
  /// System.Collections.ObjectModel.KeyedCollection&lt;TKey, TItem&gt;, but it
  /// requires unique keys, and it allows looking up a numerical index from a
  /// key in O(1).
  /// </para>
  /// </remarks>
  public interface IIndexedDictionary<TKey, TValue> :
    System.Collections.Generic.IDictionary<TKey, TValue>,
    System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<TKey, TValue>>
  {
  }
}

