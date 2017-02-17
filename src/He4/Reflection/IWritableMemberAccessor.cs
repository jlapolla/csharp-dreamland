namespace He4.Reflection
{

  public interface IWritableMemberAccessor<in T>
  {

    /// <summary>
    /// The member.
    /// </summary>
    T Member { set; }

    /// <summary>
    /// Set the member.
    /// </summary>
    void SetMember(T value);
  }
}
