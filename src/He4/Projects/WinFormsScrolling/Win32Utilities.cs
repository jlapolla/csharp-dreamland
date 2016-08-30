using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace He4.Projects.WinFormsScrolling
{


  /// <summary>
  /// Utilities used by other Win32 classes.
  /// </summary>
  public static class Win32Utilities
  {

    /// <summary>
    /// Copies bytes from source to destination, taking into account the
    /// endianness of the current computer architecture. Designed for use with
    /// System.BitConverter.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The copy operation always proceeds in the direction from the least
    /// significant byte in the source array to the most significant byte in
    /// the source array. The startByte argument specifies which byte in the
    /// source array to start copying at (a positive startByte is similar to
    /// right shifting the source array before copying). A negative startByte
    /// begins the copy operation at a byte index before the least significant
    /// byte in the source array (similar to left shifting the source array
    /// before copying). Any bytes read outside of the byte range of the source
    /// array are read as 0x00. The copy operation proceeds until all bytes in
    /// the destination array have been written to.
    /// </para>
    ///
    /// <para>
    /// When copying bytes, this function takes into account the endianness of
    /// the current computer architecture. The function determines which array
    /// index is the least significant byte in the source array by querying the
    /// System.BitConverter.IsLittleEndian property. The order of bytes in the
    /// source array must reflect the endianness of the current computer
    /// architecture. After the copy operation, the order of bytes in the
    /// destination array also reflect the endianness of the current computer
    /// architecture.
    /// </para>
    ///
    /// <para>
    /// This function is designed to be used directly with the arrays that are
    /// output by (and consumed by) System.BitConverter, without having to use
    /// worry about endianness.
    /// </para>
    ///
    /// <para>
    /// Using this function in conjunction with System.Bitconverter is similar
    /// in effect to using casting and bitwise shift operators to select
    /// certain bytes from an integral type.
    /// </para>
    ///
    /// <para>
    /// The source array and the destination array must both be zero indexed.
    /// </para>
    /// </remarks>
    public static void CopyLeastSignificantBytes(byte[] source, byte[] destination, int startByte = 0)
    {

      int sourceIndex;

      if (BitConverter.IsLittleEndian)
      {

        sourceIndex = startByte;
      }
      else
      {

        sourceIndex = source.Length - startByte - destination.Length;
      }

      for (int destinationIndex = 0; destinationIndex < destination.Length; destinationIndex++, sourceIndex++)
      {

        byte nextByte;

        if (0 <= sourceIndex && sourceIndex < source.Length)
        {

          nextByte = source[sourceIndex];
        }
        else
        {

          nextByte = 0;
        }

        destination[destinationIndex] = nextByte;
      }
    }
  }
}
