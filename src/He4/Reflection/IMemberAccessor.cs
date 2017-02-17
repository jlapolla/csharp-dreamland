namespace He4.Reflection
{

  public interface IMemberAccessor<T> : IReadableMemberAccessor<T>, IWritableMemberAccessor<T>
  {

    /// <summary>
    /// Replaces IReadableMemberAccessor.Member and
    /// IWritableMemberAccessor.Member.
    /// </summary>
    new T Member { get; set; }
  }
}
