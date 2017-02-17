namespace He4.Reflection
{

  public interface IWritableMemberAccessor<in T>
  {

    /// <summary>
    /// The member.
    /// </summary>
    T Member { set; }

    /// <summary>
    /// Sets the value of the member.
    /// </summary>
    void Set(T value);
  }
}
