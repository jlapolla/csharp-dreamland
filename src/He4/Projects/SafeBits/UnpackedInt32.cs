using System;

namespace He4.Projects.SafeBits
{

  public struct UnpackedInt32 : IEquatable<UnpackedInt32>
  {

    public Int16 HighWord { get; set; }
    public Int16 LowWord { get; set; }

    public bool Equals(UnpackedInt32 other)
    {

      return HighWord == other.HighWord
        && LowWord == other.LowWord;
    }

    public override bool Equals(object obj)
    {

      bool result = false;

      if (obj is UnpackedInt32)
      {

        result = Equals((UnpackedInt32) obj);
      }

      return result;
    }

    public override int GetHashCode()
    {

      var hash = HashCombiner.Make();
      hash.Put(HighWord);
      hash.Put(LowWord);
      return hash.Value;
    }

    public static bool operator ==(UnpackedInt32 left, UnpackedInt32 right)
    {

      return left.Equals(right);
    }

    public static bool operator !=(UnpackedInt32 left, UnpackedInt32 right)
    {

      return !left.Equals(right);
    }

    public Int32 ToInt32()
    {

      // return (HighWord << 16) | LowWord; // Incorrect behavior, compiler warning CS0675
      // return (HighWord << 16) | unchecked((Int32) LowWord); // Incorrect behavior, no compiler warning
      return (HighWord << 16) | unchecked((UInt16) LowWord); // Correct behavior, no compiler warning
    }

    public static UnpackedInt32 Parse(Int32 packed)
    {

      var result = default(UnpackedInt32);
      result.HighWord = unchecked((Int16) (packed >> 16));
      result.LowWord = unchecked((Int16) packed);
      return result;
    }

    public static UnpackedInt32 Make()
    {

      return default(UnpackedInt32);
    }
  }
}
