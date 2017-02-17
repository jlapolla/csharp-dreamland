namespace He4.Reflection
{

  public interface IReadableMemberAccessor<out T>
  {

    /// <summary>
    /// The member.
    /// </summary>
    T Member { get; }

    /// <summary>
    /// Returns the member.
    /// </summary>
    T GetMember();
  }
}
