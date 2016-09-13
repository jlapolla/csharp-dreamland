using System;
using System.Runtime.InteropServices;

namespace He4.Projects.SafeBits
{

  public static class TypeProperties
  {

    public static int SizeOf(Type t)
    {

      return Marshal.SizeOf(t);
    }

    public static bool IsSigned(Type t)
    {

      bool result = false;

      if (typeof(sbyte) == t || typeof(short) == t || typeof(int) == t || typeof(long) == t)
      {

        result = true;
      }
      else if (typeof (byte) == t || typeof(ushort) == t || typeof(uint) == t || typeof(ulong) == t)
      {

        result = false;
      }
      else
      {

        throw new ArgumentException();
      }

      return result;
    }
  }
}
