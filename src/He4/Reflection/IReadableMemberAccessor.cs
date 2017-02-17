namespace He4.Reflection
{

  public interface IReadableMemberAccessor<out T>
  {

    /// <summary>
    /// The member.
    /// </summary>
    T Member { get; }

    /// <summary>
    /// Returns the value of the member.
    /// </summary>
    T Get();
  }
}
