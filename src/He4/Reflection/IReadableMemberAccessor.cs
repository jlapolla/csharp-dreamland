namespace He4.Reflection
{

  public interface IReadableMemberAccessor<out T>
  {

    /// <summary>
    /// Value of the member.
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Returns the value of the member.
    /// </summary>
    T Get();
  }
}
