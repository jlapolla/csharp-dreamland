using System;

namespace He4.Projects.SafeBits
{

  public static class UnsafeFunctions
  {

    public static int DoMask(int data, short mask)
    {

      return data & mask;
    }
  }
}
