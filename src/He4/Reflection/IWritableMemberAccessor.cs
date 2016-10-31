namespace He4.Reflection
{

  public interface IWritableMemberAccessor<in T>
  {

    /// <summary>
    /// Value of the member.
    /// </summary>
    T Value { set; }

    /// <summary>
    /// Sets the value of the member.
    /// </summary>
    void Set(T value);
  }
}
