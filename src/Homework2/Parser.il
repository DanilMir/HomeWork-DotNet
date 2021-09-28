.assembly Homework2
{
  .ver 1:0:0:0
}
.assembly extern System.Runtime
{
    .ver 4:0:0:0
    .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A)
} 
.assembly extern System.Console{}   
.assembly extern System.Linq{}

.module Homework2.dll

// Type: Homework2.Parser 
// Assembly: Homework2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BC5468D2-8FCC-418C-8C3A-35019793ACA5
// Location: /home/hb/RiderProjects/HomeWork-DotNet/src/Homework2/Homework2/bin/Debug/net5.0/Homework2.dll
// Sequence point data from /home/hb/RiderProjects/HomeWork-DotNet/src/Homework2/Homework2/bin/Debug/net5.0/Homework2.pdb

.class public abstract sealed auto ansi beforefieldinit
  Homework2.Parser
    extends [System.Runtime]System.Object
{

  .class nested private sealed auto ansi serializable beforefieldinit
    '<>c'
      extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public static initonly class Homework2.Parser/'<>c' '<>9'

    .field public static class [System.Runtime]System.Func`3<string, string, string> '<>9__1_0'

    .method private hidebysig static specialname rtspecialname void
      .cctor() cil managed
    {
      .maxstack 8

      IL_0000: newobj       instance void Homework2.Parser/'<>c'::.ctor()
      IL_0005: stsfld       class Homework2.Parser/'<>c' Homework2.Parser/'<>c'::'<>9'
      IL_000a: ret

    } // end of method '<>c'::.cctor

    .method public hidebysig specialname rtspecialname instance void
      .ctor() cil managed
    {
      .maxstack 8

      IL_0000: ldarg.0      // this
      IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
      IL_0006: nop
      IL_0007: ret

    } // end of method '<>c'::.ctor

    .method assembly hidebysig instance string
      '<TryParseArguments>b__1_0'(
        string c,
        string n
      ) cil managed
    {
      .maxstack 8

      // [32 78 - 32 88]
      IL_0000: ldarg.1      // c
      IL_0001: ldstr        " "
      IL_0006: ldarg.2      // n
      IL_0007: call         string [System.Runtime]System.String::Concat(string, string, string)
      IL_000c: ret

    } // end of method '<>c'::'<TryParseArguments>b__1_0'
  } // end of class '<>c'

  .field private static initonly string[] SupportedOperations

  .method public hidebysig static int32
    TryParseArguments(
      string[] args,
      [out] int32& val1,
      [out] string& operation,
      [out] int32& val2
    ) cil managed
  {
    .maxstack 6
    .locals init (
      [0] bool isVal1Int,
      [1] bool isVal2Int,
      [2] bool V_2,
      [3] int32 V_3,
      [4] bool V_4
    )

    // [17 9 - 17 10]
    IL_0000: nop

    // [18 13 - 18 61]
    IL_0001: ldarg.0      // args
    IL_0002: ldc.i4.0
    IL_0003: ldelem.ref
    IL_0004: ldarg.1      // val1
    IL_0005: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_000a: stloc.0      // isVal1Int

    // [19 13 - 19 33]
    IL_000b: ldarg.2      // operation
    IL_000c: ldarg.0      // args
    IL_000d: ldc.i4.1
    IL_000e: ldelem.ref
    IL_000f: stind.ref

    // [20 13 - 20 61]
    IL_0010: ldarg.0      // args
    IL_0011: ldc.i4.2
    IL_0012: ldelem.ref
    IL_0013: ldarg.3      // val2
    IL_0014: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0019: stloc.1      // isVal2Int

    // [22 13 - 22 42]
    IL_001a: ldloc.0      // isVal1Int
    IL_001b: brfalse.s    IL_0023
    IL_001d: ldloc.1      // isVal2Int
    IL_001e: ldc.i4.0
    IL_001f: ceq
    IL_0021: br.s         IL_0024
    IL_0023: ldc.i4.1
    IL_0024: stloc.2      // V_2

    IL_0025: ldloc.2      // V_2
    IL_0026: brfalse.s    IL_006b

    // [23 13 - 23 14]
    IL_0028: nop

    // [24 17 - 24 82]
    IL_0029: ldc.i4.6
    IL_002a: newarr       [System.Runtime]System.String
    IL_002f: dup
    IL_0030: ldc.i4.0
    IL_0031: ldarg.0      // args
    IL_0032: ldc.i4.0
    IL_0033: ldelem.ref
    IL_0034: stelem.ref
    IL_0035: dup
    IL_0036: ldc.i4.1
    IL_0037: ldstr        " "
    IL_003c: stelem.ref
    IL_003d: dup
    IL_003e: ldc.i4.2
    IL_003f: ldarg.0      // args
    IL_0040: ldc.i4.1
    IL_0041: ldelem.ref
    IL_0042: stelem.ref
    IL_0043: dup
    IL_0044: ldc.i4.3
    IL_0045: ldstr        " "
    IL_004a: stelem.ref
    IL_004b: dup
    IL_004c: ldc.i4.4
    IL_004d: ldarg.0      // args
    IL_004e: ldc.i4.2
    IL_004f: ldelem.ref
    IL_0050: stelem.ref
    IL_0051: dup
    IL_0052: ldc.i4.5
    IL_0053: ldstr        " is not valid"
    IL_0058: stelem.ref
    IL_0059: call         string [System.Runtime]System.String::Concat(string[])
    IL_005e: call         void [System.Console]System.Console::WriteLine(string)
    IL_0063: nop

    // [25 17 - 25 26]
    IL_0064: ldc.i4.1
    IL_0065: stloc.3      // V_3
    IL_0066: br           IL_00f0

    // [28 13 - 28 58]
    IL_006b: ldsfld       string[] Homework2.Parser::SupportedOperations
    IL_0070: ldarg.2      // operation
    IL_0071: ldind.ref
    IL_0072: call         bool [System.Linq]System.Linq.Enumerable::Contains<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*string*/>, !!0/*string*/)
    IL_0077: ldc.i4.0
    IL_0078: ceq
    IL_007a: stloc.s      V_4

    IL_007c: ldloc.s      V_4
    IL_007e: brfalse.s    IL_00ec

    // [29 13 - 29 14]
    IL_0080: nop

    // [30 17 - 32 93]
    IL_0081: ldc.i4.7
    IL_0082: newarr       [System.Runtime]System.String
    IL_0087: dup
    IL_0088: ldc.i4.0
    IL_0089: ldarg.0      // args
    IL_008a: ldc.i4.0
    IL_008b: ldelem.ref
    IL_008c: stelem.ref
    IL_008d: dup
    IL_008e: ldc.i4.1
    IL_008f: ldstr        " "
    IL_0094: stelem.ref
    IL_0095: dup
    IL_0096: ldc.i4.2
    IL_0097: ldarg.0      // args
    IL_0098: ldc.i4.1
    IL_0099: ldelem.ref
    IL_009a: stelem.ref
    IL_009b: dup
    IL_009c: ldc.i4.3
    IL_009d: ldstr        " "
    IL_00a2: stelem.ref
    IL_00a3: dup
    IL_00a4: ldc.i4.4
    IL_00a5: ldarg.0      // args
    IL_00a6: ldc.i4.2
    IL_00a7: ldelem.ref
    IL_00a8: stelem.ref
    IL_00a9: dup
    IL_00aa: ldc.i4.5
    IL_00ab: ldstr        " is not valid calculation syntax. Supported Operaions are "
    IL_00b0: stelem.ref
    IL_00b1: dup
    IL_00b2: ldc.i4.6
    IL_00b3: ldsfld       string[] Homework2.Parser::SupportedOperations
    IL_00b8: ldsfld       class [System.Runtime]System.Func`3<string, string, string> Homework2.Parser/'<>c'::'<>9__1_0'
    IL_00bd: dup
    IL_00be: brtrue.s     IL_00d7
    IL_00c0: pop
    IL_00c1: ldsfld       class Homework2.Parser/'<>c' Homework2.Parser/'<>c'::'<>9'
    IL_00c6: ldftn        instance string Homework2.Parser/'<>c'::'<TryParseArguments>b__1_0'(string, string)
    IL_00cc: newobj       instance void class [System.Runtime]System.Func`3<string, string, string>::.ctor(object, native int)
    IL_00d1: dup
    IL_00d2: stsfld       class [System.Runtime]System.Func`3<string, string, string> Homework2.Parser/'<>c'::'<>9__1_0'
    IL_00d7: call         !!0/*string*/ [System.Linq]System.Linq.Enumerable::Aggregate<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*string*/>, class [System.Runtime]System.Func`3<!!0/*string*/, !!0/*string*/, !!0/*string*/>)
    IL_00dc: stelem.ref
    IL_00dd: call         string [System.Runtime]System.String::Concat(string[])
    IL_00e2: call         void [System.Console]System.Console::WriteLine(string)
    IL_00e7: nop

    // [33 17 - 33 26]
    IL_00e8: ldc.i4.2
    IL_00e9: stloc.3      // V_3
    IL_00ea: br.s         IL_00f0

    // [36 13 - 36 22]
    IL_00ec: ldc.i4.0
    IL_00ed: stloc.3      // V_3
    IL_00ee: br.s         IL_00f0

    // [37 9 - 37 10]
    IL_00f0: ldloc.3      // V_3
    IL_00f1: ret

  } // end of method Parser::TryParseArguments

  .method public hidebysig static int32
    CheckArgsCount(
      string[] args
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] int32 V_1
    )

    // [40 9 - 40 10]
    IL_0000: nop

    // [41 13 - 41 34]
    IL_0001: ldarg.0      // args
    IL_0002: ldlen
    IL_0003: conv.i4
    IL_0004: ldc.i4.3
    IL_0005: ceq
    IL_0007: ldc.i4.0
    IL_0008: ceq
    IL_000a: stloc.0      // V_0

    IL_000b: ldloc.0      // V_0
    IL_000c: brfalse.s    IL_001e

    // [42 13 - 42 14]
    IL_000e: nop

    // [43 17 - 43 72]
    IL_000f: ldstr        "The number of arguments must be 3"
    IL_0014: call         void [System.Console]System.Console::WriteLine(string)
    IL_0019: nop

    // [44 17 - 44 26]
    IL_001a: ldc.i4.3
    IL_001b: stloc.1      // V_1
    IL_001c: br.s         IL_0022

    // [47 13 - 47 22]
    IL_001e: ldc.i4.0
    IL_001f: stloc.1      // V_1
    IL_0020: br.s         IL_0022

    // [48 9 - 48 10]
    IL_0022: ldloc.1      // V_1
    IL_0023: ret

  } // end of method Parser::CheckArgsCount

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    // [8 9 - 14 11]
    IL_0000: ldc.i4.4
    IL_0001: newarr       [System.Runtime]System.String
    IL_0006: dup
    IL_0007: ldc.i4.0
    IL_0008: ldstr        "+"
    IL_000d: stelem.ref
    IL_000e: dup
    IL_000f: ldc.i4.1
    IL_0010: ldstr        "-"
    IL_0015: stelem.ref
    IL_0016: dup
    IL_0017: ldc.i4.2
    IL_0018: ldstr        "*"
    IL_001d: stelem.ref
    IL_001e: dup
    IL_001f: ldc.i4.3
    IL_0020: ldstr        "/"
    IL_0025: stelem.ref
    IL_0026: stsfld       string[] Homework2.Parser::SupportedOperations
    IL_002b: ret

  } // end of method Parser::.cctor
} // end of class Homework2.Parser
