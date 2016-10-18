namespace He4.Projects.SafeBits
{

  public interface IRandom<T>
    where T : struct
  {

    void Next();
    T Item { get; }
  }
}
