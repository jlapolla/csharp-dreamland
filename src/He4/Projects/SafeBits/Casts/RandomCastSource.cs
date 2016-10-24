namespace He4.Projects.SafeBits.Casts
{

  public class RandomCastSource
  {

    private Random2 RandomSource;
    private IRandom<byte> RandomByte;

    public ICast Item { get; protected set; }

    public void Next()
    {

      RandomByte.Next();

      switch (RandomByte.Item)
      {

        case 0:
          Item = CastSByteSByte.Make(RandomSource);
          break;

        case 1:
          Item = ExplicitCastSByteSByte.Make(RandomSource);
          break;

        case 2:
          Item = UncheckedCastSByteSByte.Make(RandomSource);
          break;

        case 3:
          Item = ExplicitUncheckedCastSByteSByte.Make(RandomSource);
          break;

        case 4:
          Item = CastSByteByte.Make(RandomSource);
          break;

        case 5:
          Item = ExplicitCastSByteByte.Make(RandomSource);
          break;

        case 6:
          Item = UncheckedCastSByteByte.Make(RandomSource);
          break;

        case 7:
          Item = ExplicitUncheckedCastSByteByte.Make(RandomSource);
          break;

        case 8:
          Item = CastSByteInt16.Make(RandomSource);
          break;

        case 9:
          Item = ExplicitCastSByteInt16.Make(RandomSource);
          break;

        case 10:
          Item = UncheckedCastSByteInt16.Make(RandomSource);
          break;

        case 11:
          Item = ExplicitUncheckedCastSByteInt16.Make(RandomSource);
          break;

        case 12:
          Item = CastSByteUInt16.Make(RandomSource);
          break;

        case 13:
          Item = ExplicitCastSByteUInt16.Make(RandomSource);
          break;

        case 14:
          Item = UncheckedCastSByteUInt16.Make(RandomSource);
          break;

        case 15:
          Item = ExplicitUncheckedCastSByteUInt16.Make(RandomSource);
          break;

        case 16:
          Item = CastSByteInt32.Make(RandomSource);
          break;

        case 17:
          Item = ExplicitCastSByteInt32.Make(RandomSource);
          break;

        case 18:
          Item = UncheckedCastSByteInt32.Make(RandomSource);
          break;

        case 19:
          Item = ExplicitUncheckedCastSByteInt32.Make(RandomSource);
          break;

        case 20:
          Item = CastSByteUInt32.Make(RandomSource);
          break;

        case 21:
          Item = ExplicitCastSByteUInt32.Make(RandomSource);
          break;

        case 22:
          Item = UncheckedCastSByteUInt32.Make(RandomSource);
          break;

        case 23:
          Item = ExplicitUncheckedCastSByteUInt32.Make(RandomSource);
          break;

        case 24:
          Item = CastSByteInt64.Make(RandomSource);
          break;

        case 25:
          Item = ExplicitCastSByteInt64.Make(RandomSource);
          break;

        case 26:
          Item = UncheckedCastSByteInt64.Make(RandomSource);
          break;

        case 27:
          Item = ExplicitUncheckedCastSByteInt64.Make(RandomSource);
          break;

        case 28:
          Item = CastSByteUInt64.Make(RandomSource);
          break;

        case 29:
          Item = ExplicitCastSByteUInt64.Make(RandomSource);
          break;

        case 30:
          Item = UncheckedCastSByteUInt64.Make(RandomSource);
          break;

        case 31:
          Item = ExplicitUncheckedCastSByteUInt64.Make(RandomSource);
          break;

        case 32:
          Item = CastByteSByte.Make(RandomSource);
          break;

        case 33:
          Item = ExplicitCastByteSByte.Make(RandomSource);
          break;

        case 34:
          Item = UncheckedCastByteSByte.Make(RandomSource);
          break;

        case 35:
          Item = ExplicitUncheckedCastByteSByte.Make(RandomSource);
          break;

        case 36:
          Item = CastByteByte.Make(RandomSource);
          break;

        case 37:
          Item = ExplicitCastByteByte.Make(RandomSource);
          break;

        case 38:
          Item = UncheckedCastByteByte.Make(RandomSource);
          break;

        case 39:
          Item = ExplicitUncheckedCastByteByte.Make(RandomSource);
          break;

        case 40:
          Item = CastByteInt16.Make(RandomSource);
          break;

        case 41:
          Item = ExplicitCastByteInt16.Make(RandomSource);
          break;

        case 42:
          Item = UncheckedCastByteInt16.Make(RandomSource);
          break;

        case 43:
          Item = ExplicitUncheckedCastByteInt16.Make(RandomSource);
          break;

        case 44:
          Item = CastByteUInt16.Make(RandomSource);
          break;

        case 45:
          Item = ExplicitCastByteUInt16.Make(RandomSource);
          break;

        case 46:
          Item = UncheckedCastByteUInt16.Make(RandomSource);
          break;

        case 47:
          Item = ExplicitUncheckedCastByteUInt16.Make(RandomSource);
          break;

        case 48:
          Item = CastByteInt32.Make(RandomSource);
          break;

        case 49:
          Item = ExplicitCastByteInt32.Make(RandomSource);
          break;

        case 50:
          Item = UncheckedCastByteInt32.Make(RandomSource);
          break;

        case 51:
          Item = ExplicitUncheckedCastByteInt32.Make(RandomSource);
          break;

        case 52:
          Item = CastByteUInt32.Make(RandomSource);
          break;

        case 53:
          Item = ExplicitCastByteUInt32.Make(RandomSource);
          break;

        case 54:
          Item = UncheckedCastByteUInt32.Make(RandomSource);
          break;

        case 55:
          Item = ExplicitUncheckedCastByteUInt32.Make(RandomSource);
          break;

        case 56:
          Item = CastByteInt64.Make(RandomSource);
          break;

        case 57:
          Item = ExplicitCastByteInt64.Make(RandomSource);
          break;

        case 58:
          Item = UncheckedCastByteInt64.Make(RandomSource);
          break;

        case 59:
          Item = ExplicitUncheckedCastByteInt64.Make(RandomSource);
          break;

        case 60:
          Item = CastByteUInt64.Make(RandomSource);
          break;

        case 61:
          Item = ExplicitCastByteUInt64.Make(RandomSource);
          break;

        case 62:
          Item = UncheckedCastByteUInt64.Make(RandomSource);
          break;

        case 63:
          Item = ExplicitUncheckedCastByteUInt64.Make(RandomSource);
          break;

        case 64:
          Item = CastInt16SByte.Make(RandomSource);
          break;

        case 65:
          Item = ExplicitCastInt16SByte.Make(RandomSource);
          break;

        case 66:
          Item = UncheckedCastInt16SByte.Make(RandomSource);
          break;

        case 67:
          Item = ExplicitUncheckedCastInt16SByte.Make(RandomSource);
          break;

        case 68:
          Item = CastInt16Byte.Make(RandomSource);
          break;

        case 69:
          Item = ExplicitCastInt16Byte.Make(RandomSource);
          break;

        case 70:
          Item = UncheckedCastInt16Byte.Make(RandomSource);
          break;

        case 71:
          Item = ExplicitUncheckedCastInt16Byte.Make(RandomSource);
          break;

        case 72:
          Item = CastInt16Int16.Make(RandomSource);
          break;

        case 73:
          Item = ExplicitCastInt16Int16.Make(RandomSource);
          break;

        case 74:
          Item = UncheckedCastInt16Int16.Make(RandomSource);
          break;

        case 75:
          Item = ExplicitUncheckedCastInt16Int16.Make(RandomSource);
          break;

        case 76:
          Item = CastInt16UInt16.Make(RandomSource);
          break;

        case 77:
          Item = ExplicitCastInt16UInt16.Make(RandomSource);
          break;

        case 78:
          Item = UncheckedCastInt16UInt16.Make(RandomSource);
          break;

        case 79:
          Item = ExplicitUncheckedCastInt16UInt16.Make(RandomSource);
          break;

        case 80:
          Item = CastInt16Int32.Make(RandomSource);
          break;

        case 81:
          Item = ExplicitCastInt16Int32.Make(RandomSource);
          break;

        case 82:
          Item = UncheckedCastInt16Int32.Make(RandomSource);
          break;

        case 83:
          Item = ExplicitUncheckedCastInt16Int32.Make(RandomSource);
          break;

        case 84:
          Item = CastInt16UInt32.Make(RandomSource);
          break;

        case 85:
          Item = ExplicitCastInt16UInt32.Make(RandomSource);
          break;

        case 86:
          Item = UncheckedCastInt16UInt32.Make(RandomSource);
          break;

        case 87:
          Item = ExplicitUncheckedCastInt16UInt32.Make(RandomSource);
          break;

        case 88:
          Item = CastInt16Int64.Make(RandomSource);
          break;

        case 89:
          Item = ExplicitCastInt16Int64.Make(RandomSource);
          break;

        case 90:
          Item = UncheckedCastInt16Int64.Make(RandomSource);
          break;

        case 91:
          Item = ExplicitUncheckedCastInt16Int64.Make(RandomSource);
          break;

        case 92:
          Item = CastInt16UInt64.Make(RandomSource);
          break;

        case 93:
          Item = ExplicitCastInt16UInt64.Make(RandomSource);
          break;

        case 94:
          Item = UncheckedCastInt16UInt64.Make(RandomSource);
          break;

        case 95:
          Item = ExplicitUncheckedCastInt16UInt64.Make(RandomSource);
          break;

        case 96:
          Item = CastUInt16SByte.Make(RandomSource);
          break;

        case 97:
          Item = ExplicitCastUInt16SByte.Make(RandomSource);
          break;

        case 98:
          Item = UncheckedCastUInt16SByte.Make(RandomSource);
          break;

        case 99:
          Item = ExplicitUncheckedCastUInt16SByte.Make(RandomSource);
          break;

        case 100:
          Item = CastUInt16Byte.Make(RandomSource);
          break;

        case 101:
          Item = ExplicitCastUInt16Byte.Make(RandomSource);
          break;

        case 102:
          Item = UncheckedCastUInt16Byte.Make(RandomSource);
          break;

        case 103:
          Item = ExplicitUncheckedCastUInt16Byte.Make(RandomSource);
          break;

        case 104:
          Item = CastUInt16Int16.Make(RandomSource);
          break;

        case 105:
          Item = ExplicitCastUInt16Int16.Make(RandomSource);
          break;

        case 106:
          Item = UncheckedCastUInt16Int16.Make(RandomSource);
          break;

        case 107:
          Item = ExplicitUncheckedCastUInt16Int16.Make(RandomSource);
          break;

        case 108:
          Item = CastUInt16UInt16.Make(RandomSource);
          break;

        case 109:
          Item = ExplicitCastUInt16UInt16.Make(RandomSource);
          break;

        case 110:
          Item = UncheckedCastUInt16UInt16.Make(RandomSource);
          break;

        case 111:
          Item = ExplicitUncheckedCastUInt16UInt16.Make(RandomSource);
          break;

        case 112:
          Item = CastUInt16Int32.Make(RandomSource);
          break;

        case 113:
          Item = ExplicitCastUInt16Int32.Make(RandomSource);
          break;

        case 114:
          Item = UncheckedCastUInt16Int32.Make(RandomSource);
          break;

        case 115:
          Item = ExplicitUncheckedCastUInt16Int32.Make(RandomSource);
          break;

        case 116:
          Item = CastUInt16UInt32.Make(RandomSource);
          break;

        case 117:
          Item = ExplicitCastUInt16UInt32.Make(RandomSource);
          break;

        case 118:
          Item = UncheckedCastUInt16UInt32.Make(RandomSource);
          break;

        case 119:
          Item = ExplicitUncheckedCastUInt16UInt32.Make(RandomSource);
          break;

        case 120:
          Item = CastUInt16Int64.Make(RandomSource);
          break;

        case 121:
          Item = ExplicitCastUInt16Int64.Make(RandomSource);
          break;

        case 122:
          Item = UncheckedCastUInt16Int64.Make(RandomSource);
          break;

        case 123:
          Item = ExplicitUncheckedCastUInt16Int64.Make(RandomSource);
          break;

        case 124:
          Item = CastUInt16UInt64.Make(RandomSource);
          break;

        case 125:
          Item = ExplicitCastUInt16UInt64.Make(RandomSource);
          break;

        case 126:
          Item = UncheckedCastUInt16UInt64.Make(RandomSource);
          break;

        case 127:
          Item = ExplicitUncheckedCastUInt16UInt64.Make(RandomSource);
          break;

        case 128:
          Item = CastInt32SByte.Make(RandomSource);
          break;

        case 129:
          Item = ExplicitCastInt32SByte.Make(RandomSource);
          break;

        case 130:
          Item = UncheckedCastInt32SByte.Make(RandomSource);
          break;

        case 131:
          Item = ExplicitUncheckedCastInt32SByte.Make(RandomSource);
          break;

        case 132:
          Item = CastInt32Byte.Make(RandomSource);
          break;

        case 133:
          Item = ExplicitCastInt32Byte.Make(RandomSource);
          break;

        case 134:
          Item = UncheckedCastInt32Byte.Make(RandomSource);
          break;

        case 135:
          Item = ExplicitUncheckedCastInt32Byte.Make(RandomSource);
          break;

        case 136:
          Item = CastInt32Int16.Make(RandomSource);
          break;

        case 137:
          Item = ExplicitCastInt32Int16.Make(RandomSource);
          break;

        case 138:
          Item = UncheckedCastInt32Int16.Make(RandomSource);
          break;

        case 139:
          Item = ExplicitUncheckedCastInt32Int16.Make(RandomSource);
          break;

        case 140:
          Item = CastInt32UInt16.Make(RandomSource);
          break;

        case 141:
          Item = ExplicitCastInt32UInt16.Make(RandomSource);
          break;

        case 142:
          Item = UncheckedCastInt32UInt16.Make(RandomSource);
          break;

        case 143:
          Item = ExplicitUncheckedCastInt32UInt16.Make(RandomSource);
          break;

        case 144:
          Item = CastInt32Int32.Make(RandomSource);
          break;

        case 145:
          Item = ExplicitCastInt32Int32.Make(RandomSource);
          break;

        case 146:
          Item = UncheckedCastInt32Int32.Make(RandomSource);
          break;

        case 147:
          Item = ExplicitUncheckedCastInt32Int32.Make(RandomSource);
          break;

        case 148:
          Item = CastInt32UInt32.Make(RandomSource);
          break;

        case 149:
          Item = ExplicitCastInt32UInt32.Make(RandomSource);
          break;

        case 150:
          Item = UncheckedCastInt32UInt32.Make(RandomSource);
          break;

        case 151:
          Item = ExplicitUncheckedCastInt32UInt32.Make(RandomSource);
          break;

        case 152:
          Item = CastInt32Int64.Make(RandomSource);
          break;

        case 153:
          Item = ExplicitCastInt32Int64.Make(RandomSource);
          break;

        case 154:
          Item = UncheckedCastInt32Int64.Make(RandomSource);
          break;

        case 155:
          Item = ExplicitUncheckedCastInt32Int64.Make(RandomSource);
          break;

        case 156:
          Item = CastInt32UInt64.Make(RandomSource);
          break;

        case 157:
          Item = ExplicitCastInt32UInt64.Make(RandomSource);
          break;

        case 158:
          Item = UncheckedCastInt32UInt64.Make(RandomSource);
          break;

        case 159:
          Item = ExplicitUncheckedCastInt32UInt64.Make(RandomSource);
          break;

        case 160:
          Item = CastUInt32SByte.Make(RandomSource);
          break;

        case 161:
          Item = ExplicitCastUInt32SByte.Make(RandomSource);
          break;

        case 162:
          Item = UncheckedCastUInt32SByte.Make(RandomSource);
          break;

        case 163:
          Item = ExplicitUncheckedCastUInt32SByte.Make(RandomSource);
          break;

        case 164:
          Item = CastUInt32Byte.Make(RandomSource);
          break;

        case 165:
          Item = ExplicitCastUInt32Byte.Make(RandomSource);
          break;

        case 166:
          Item = UncheckedCastUInt32Byte.Make(RandomSource);
          break;

        case 167:
          Item = ExplicitUncheckedCastUInt32Byte.Make(RandomSource);
          break;

        case 168:
          Item = CastUInt32Int16.Make(RandomSource);
          break;

        case 169:
          Item = ExplicitCastUInt32Int16.Make(RandomSource);
          break;

        case 170:
          Item = UncheckedCastUInt32Int16.Make(RandomSource);
          break;

        case 171:
          Item = ExplicitUncheckedCastUInt32Int16.Make(RandomSource);
          break;

        case 172:
          Item = CastUInt32UInt16.Make(RandomSource);
          break;

        case 173:
          Item = ExplicitCastUInt32UInt16.Make(RandomSource);
          break;

        case 174:
          Item = UncheckedCastUInt32UInt16.Make(RandomSource);
          break;

        case 175:
          Item = ExplicitUncheckedCastUInt32UInt16.Make(RandomSource);
          break;

        case 176:
          Item = CastUInt32Int32.Make(RandomSource);
          break;

        case 177:
          Item = ExplicitCastUInt32Int32.Make(RandomSource);
          break;

        case 178:
          Item = UncheckedCastUInt32Int32.Make(RandomSource);
          break;

        case 179:
          Item = ExplicitUncheckedCastUInt32Int32.Make(RandomSource);
          break;

        case 180:
          Item = CastUInt32UInt32.Make(RandomSource);
          break;

        case 181:
          Item = ExplicitCastUInt32UInt32.Make(RandomSource);
          break;

        case 182:
          Item = UncheckedCastUInt32UInt32.Make(RandomSource);
          break;

        case 183:
          Item = ExplicitUncheckedCastUInt32UInt32.Make(RandomSource);
          break;

        case 184:
          Item = CastUInt32Int64.Make(RandomSource);
          break;

        case 185:
          Item = ExplicitCastUInt32Int64.Make(RandomSource);
          break;

        case 186:
          Item = UncheckedCastUInt32Int64.Make(RandomSource);
          break;

        case 187:
          Item = ExplicitUncheckedCastUInt32Int64.Make(RandomSource);
          break;

        case 188:
          Item = CastUInt32UInt64.Make(RandomSource);
          break;

        case 189:
          Item = ExplicitCastUInt32UInt64.Make(RandomSource);
          break;

        case 190:
          Item = UncheckedCastUInt32UInt64.Make(RandomSource);
          break;

        case 191:
          Item = ExplicitUncheckedCastUInt32UInt64.Make(RandomSource);
          break;

        case 192:
          Item = CastInt64SByte.Make(RandomSource);
          break;

        case 193:
          Item = ExplicitCastInt64SByte.Make(RandomSource);
          break;

        case 194:
          Item = UncheckedCastInt64SByte.Make(RandomSource);
          break;

        case 195:
          Item = ExplicitUncheckedCastInt64SByte.Make(RandomSource);
          break;

        case 196:
          Item = CastInt64Byte.Make(RandomSource);
          break;

        case 197:
          Item = ExplicitCastInt64Byte.Make(RandomSource);
          break;

        case 198:
          Item = UncheckedCastInt64Byte.Make(RandomSource);
          break;

        case 199:
          Item = ExplicitUncheckedCastInt64Byte.Make(RandomSource);
          break;

        case 200:
          Item = CastInt64Int16.Make(RandomSource);
          break;

        case 201:
          Item = ExplicitCastInt64Int16.Make(RandomSource);
          break;

        case 202:
          Item = UncheckedCastInt64Int16.Make(RandomSource);
          break;

        case 203:
          Item = ExplicitUncheckedCastInt64Int16.Make(RandomSource);
          break;

        case 204:
          Item = CastInt64UInt16.Make(RandomSource);
          break;

        case 205:
          Item = ExplicitCastInt64UInt16.Make(RandomSource);
          break;

        case 206:
          Item = UncheckedCastInt64UInt16.Make(RandomSource);
          break;

        case 207:
          Item = ExplicitUncheckedCastInt64UInt16.Make(RandomSource);
          break;

        case 208:
          Item = CastInt64Int32.Make(RandomSource);
          break;

        case 209:
          Item = ExplicitCastInt64Int32.Make(RandomSource);
          break;

        case 210:
          Item = UncheckedCastInt64Int32.Make(RandomSource);
          break;

        case 211:
          Item = ExplicitUncheckedCastInt64Int32.Make(RandomSource);
          break;

        case 212:
          Item = CastInt64UInt32.Make(RandomSource);
          break;

        case 213:
          Item = ExplicitCastInt64UInt32.Make(RandomSource);
          break;

        case 214:
          Item = UncheckedCastInt64UInt32.Make(RandomSource);
          break;

        case 215:
          Item = ExplicitUncheckedCastInt64UInt32.Make(RandomSource);
          break;

        case 216:
          Item = CastInt64Int64.Make(RandomSource);
          break;

        case 217:
          Item = ExplicitCastInt64Int64.Make(RandomSource);
          break;

        case 218:
          Item = UncheckedCastInt64Int64.Make(RandomSource);
          break;

        case 219:
          Item = ExplicitUncheckedCastInt64Int64.Make(RandomSource);
          break;

        case 220:
          Item = CastInt64UInt64.Make(RandomSource);
          break;

        case 221:
          Item = ExplicitCastInt64UInt64.Make(RandomSource);
          break;

        case 222:
          Item = UncheckedCastInt64UInt64.Make(RandomSource);
          break;

        case 223:
          Item = ExplicitUncheckedCastInt64UInt64.Make(RandomSource);
          break;

        case 224:
          Item = CastUInt64SByte.Make(RandomSource);
          break;

        case 225:
          Item = ExplicitCastUInt64SByte.Make(RandomSource);
          break;

        case 226:
          Item = UncheckedCastUInt64SByte.Make(RandomSource);
          break;

        case 227:
          Item = ExplicitUncheckedCastUInt64SByte.Make(RandomSource);
          break;

        case 228:
          Item = CastUInt64Byte.Make(RandomSource);
          break;

        case 229:
          Item = ExplicitCastUInt64Byte.Make(RandomSource);
          break;

        case 230:
          Item = UncheckedCastUInt64Byte.Make(RandomSource);
          break;

        case 231:
          Item = ExplicitUncheckedCastUInt64Byte.Make(RandomSource);
          break;

        case 232:
          Item = CastUInt64Int16.Make(RandomSource);
          break;

        case 233:
          Item = ExplicitCastUInt64Int16.Make(RandomSource);
          break;

        case 234:
          Item = UncheckedCastUInt64Int16.Make(RandomSource);
          break;

        case 235:
          Item = ExplicitUncheckedCastUInt64Int16.Make(RandomSource);
          break;

        case 236:
          Item = CastUInt64UInt16.Make(RandomSource);
          break;

        case 237:
          Item = ExplicitCastUInt64UInt16.Make(RandomSource);
          break;

        case 238:
          Item = UncheckedCastUInt64UInt16.Make(RandomSource);
          break;

        case 239:
          Item = ExplicitUncheckedCastUInt64UInt16.Make(RandomSource);
          break;

        case 240:
          Item = CastUInt64Int32.Make(RandomSource);
          break;

        case 241:
          Item = ExplicitCastUInt64Int32.Make(RandomSource);
          break;

        case 242:
          Item = UncheckedCastUInt64Int32.Make(RandomSource);
          break;

        case 243:
          Item = ExplicitUncheckedCastUInt64Int32.Make(RandomSource);
          break;

        case 244:
          Item = CastUInt64UInt32.Make(RandomSource);
          break;

        case 245:
          Item = ExplicitCastUInt64UInt32.Make(RandomSource);
          break;

        case 246:
          Item = UncheckedCastUInt64UInt32.Make(RandomSource);
          break;

        case 247:
          Item = ExplicitUncheckedCastUInt64UInt32.Make(RandomSource);
          break;

        case 248:
          Item = CastUInt64Int64.Make(RandomSource);
          break;

        case 249:
          Item = ExplicitCastUInt64Int64.Make(RandomSource);
          break;

        case 250:
          Item = UncheckedCastUInt64Int64.Make(RandomSource);
          break;

        case 251:
          Item = ExplicitUncheckedCastUInt64Int64.Make(RandomSource);
          break;

        case 252:
          Item = CastUInt64UInt64.Make(RandomSource);
          break;

        case 253:
          Item = ExplicitCastUInt64UInt64.Make(RandomSource);
          break;

        case 254:
          Item = UncheckedCastUInt64UInt64.Make(RandomSource);
          break;

        case 255:
          Item = ExplicitUncheckedCastUInt64UInt64.Make(RandomSource);
          break;

        default:
          throw new System.Exception(); // Unreachable
      }
    }

    public static RandomCastSource Make(Random2 randomSource)
    {

      RandomCastSource instance = new RandomCastSource();
      Setup(instance, randomSource);
      return instance;
    }

    protected static void Setup(RandomCastSource instance, Random2 randomSource)
    {

      instance.RandomSource = randomSource;
      instance.RandomByte = randomSource;
    }

    protected RandomCastSource()
    {
    }
  }
}
