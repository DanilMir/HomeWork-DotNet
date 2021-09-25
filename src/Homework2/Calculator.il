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
.module Homework2.dll


.class public abstract sealed auto ansi beforefieldinit
  Homework2.Calculator
    extends [System.Runtime]System.Object
{

  .method public hidebysig static int32
    Calculate(
      string operation,
      int32 val1,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] string V_0,
      [1] string V_1,
      [2] int32 V_2,
      [3] bool V_3
    )

    // [9 9 - 9 10]
    IL_0000: nop

    // [10 13 - 10 31]
    IL_0001: ldarg.0      // operation
    IL_0002: stloc.1      // V_1

    IL_0003: ldloc.1      // V_1
    IL_0004: stloc.0      // V_0

    IL_0005: ldloc.0      // V_0
    IL_0006: ldstr        "+"
    IL_000b: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldloc.0      // V_0
    IL_0013: ldstr        "-"
    IL_0018: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_0041
    IL_001f: ldloc.0      // V_0
    IL_0020: ldstr        "*"
    IL_0025: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0047
    IL_002c: ldloc.0      // V_0
    IL_002d: ldstr        "/"
    IL_0032: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_004d
    IL_0039: br.s         IL_006f

    // [13 21 - 13 40]
    IL_003b: ldarg.1      // val1
    IL_003c: ldarg.2      // val2
    IL_003d: add
    IL_003e: stloc.2      // V_2
    IL_003f: br.s         IL_0073

    // [15 21 - 15 40]
    IL_0041: ldarg.1      // val1
    IL_0042: ldarg.2      // val2
    IL_0043: sub
    IL_0044: stloc.2      // V_2
    IL_0045: br.s         IL_0073

    // [17 21 - 17 40]
    IL_0047: ldarg.1      // val1
    IL_0048: ldarg.2      // val2
    IL_0049: mul
    IL_004a: stloc.2      // V_2
    IL_004b: br.s         IL_0073

    // [19 21 - 19 35]
    IL_004d: ldarg.2      // val2
    IL_004e: ldc.i4.0
    IL_004f: ceq
    IL_0051: stloc.3      // V_3

    IL_0052: ldloc.3      // V_3
    IL_0053: brfalse.s    IL_0069

    // [20 21 - 20 22]
    IL_0055: nop

    // [21 25 - 21 65]
    IL_0056: ldstr        "Error: Val 2 was 0"
    IL_005b: call         void [System.Console]System.Console::WriteLine(string)
    IL_0060: nop

    // [22 25 - 22 47]
    IL_0061: ldc.i4       2147483647 // 0x7fffffff
    IL_0066: stloc.2      // V_2
    IL_0067: br.s         IL_0073

    // [26 21 - 26 40]
    IL_0069: ldarg.1      // val1
    IL_006a: ldarg.2      // val2
    IL_006b: div
    IL_006c: stloc.2      // V_2
    IL_006d: br.s         IL_0073

    // [28 21 - 28 30]
    IL_006f: ldc.i4.0
    IL_0070: stloc.2      // V_2
    IL_0071: br.s         IL_0073

    // [30 9 - 30 10]
    IL_0073: ldloc.2      // V_2
    IL_0074: ret

  } // end of method Calculator::Calculate
} // end of class Homework2.Calculator
