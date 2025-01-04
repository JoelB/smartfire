// Full credit to jbruening from this Github issue:
// https://github.com/merbanan/rtl_433/issues/1905#issuecomment-1019601981

var foundval = "";

var X = new Func<byte, byte, byte>((cd, cmd) => {
    var a = cmd >> 4;
    var b = cmd & 0b0001111;
    return (byte)(((cd >> 4) ^ (a << 1) ^ a ^ (b << 1)) & 0xF);
});
var Y = new Func<byte, byte, byte>((cd, cmd) => {
    var a = cmd >> 4;
    var b = cmd & 0b0001111;
    return (byte)((cd & 0b0001111) ^ a ^ b);
});

var ecc = new Func<byte, byte, byte>((cd, cmd) =>
{
    var x = X(cd, cmd);
    var y = Y(cd, cmd);
    return (byte)((x << 4) | y);
});

var findCandD = new Action<byte, byte>((cmd, r) =>
{
    for (byte i = 0; i < 0b11111111; i++)
    {
        var ec = ecc(i, cmd);
        if (ec == r)
            foundval=$"{i:X2}";
    }
});

byte Cmd1 = 0x60;
byte Err1 = 0xB3;

byte Cmd2 = 0x66;
byte Err2 = 0xE2;

findCandD(Cmd1,Err1);
Console.WriteLine("Err1: 0x" + foundval);

findCandD(Cmd2,Err2);
Console.WriteLine("Err2: 0x" + foundval);

