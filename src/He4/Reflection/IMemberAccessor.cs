namespace He4.Reflection
{

  public interface IMemberAccessor<T> : IReadableMemberAccessor<T>, IWritableMemberAccessor<T>
  {

    /// <summary>
    /// Replaces IReadableMemberAccessor.Value and
    /// IWritableMemberAccessor.Value.
    /// </summary>
    new T Value { get; set; }
  }
}
