using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace John.Span;

public class Guider
{
    private const char EqualsChar = '=';
    private const char Hyphen = '-';
    private const char Uderscore = '_';
    private const char Slash = '/';
    private const byte SlashByte = (byte)'/';
    private const char Plus = '+';
    private const byte PlusByte = (byte)'+';

    public static string ToStringFromGuidOp(Guid id)
    {
        Span<byte> idBytes = stackalloc byte[16];
        Span<byte> base64Chars = stackalloc byte[24];

        MemoryMarshal.TryWrite(idBytes, ref id);
        Base64.EncodeToUtf8(idBytes, base64Chars, out _, out _);

        Span<char> finalChars = stackalloc char[22];

        for (int i = 0; i < 22; i++)
        {
            finalChars[i] = base64Chars[i] switch
            {
                SlashByte => Hyphen,
                PlusByte => Uderscore,
                _ => (char)base64Chars[i]
            };
        }

        return new string(finalChars);
    }

    public static Guid ToGuidFromStringOp(ReadOnlySpan<char> id)
    {
        Span<char> base64Chars = stackalloc char[24];

        for (int i = 0; i < 22; i++)
        {
            base64Chars[i] = id[i] switch
            {
                Hyphen => Slash,
                Uderscore => Plus,
                _ => id[i]
            };
        }

        base64Chars[22] = EqualsChar;
        base64Chars[23] = EqualsChar;

        Span<byte> idBytes = stackalloc byte[16];
        Convert.TryFromBase64Chars(base64Chars, idBytes, out _);

        return new Guid(idBytes);
    }
}
