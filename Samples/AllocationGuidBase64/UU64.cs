using System.Buffers.Text;

namespace Samples.AllocationGuidBase64;

public class UUBase64
{
    public static string ToStringFromGuid(Guid id)
        => Convert.ToBase64String(id.ToByteArray())
            .Replace("/", "-")
            .Replace("+", "_")
            .Replace("=", string.Empty);

    public static Guid ToGuidFromString(string id)
    {
        byte[] efficientBase64 = Convert.FromBase64String(
            id.Replace("-", "/").Replace("_", "+") + "==");
        return new Guid(efficientBase64);
    }

    private const char EqualsCharacter = '=';
    private const char ForwardsSlashCharacter = '/';
    private const byte ForwardsSlashByte = (byte) ForwardsSlashCharacter;
    private const char PlusCharacter = '+';
    private const byte PlusByte = (byte) PlusCharacter;
    private const char HyphenCharacter = '-';
    private const char UnderscoreCharacter = '_';

    /// <summary>
    /// </summary>
    /// <param name="id">
    /// String can be converted to ReadOnlySpan<char> in the method parameter because it just
    /// uses the fact that a string is immutable so it's uses the memory location to the string
    /// </param>
    /// <returns></returns>
    public static Guid ToGuidFromStringOp(ReadOnlySpan<char> id)
    {
        Span<char> base64_chars = stackalloc char[24];
        for (int i = 0; i < 22; i++)
        {
            // pattern matching...
            base64_chars[i] = id[i] switch
            {
                HyphenCharacter => ForwardsSlashCharacter,
                UnderscoreCharacter => PlusCharacter,
                _ => id[i]
            };
        }

        base64_chars[22] = EqualsCharacter;
        base64_chars[23] = EqualsCharacter;

        Span<byte> id_bytes = stackalloc byte[16];
        Convert.TryFromBase64Chars(base64_chars, id_bytes, out _);

        return new Guid(id_bytes);
    }

    public static string ToStringFromGuidOp(Guid id)
    {
        Span<byte> id_bytes = stackalloc byte[16];
        Span<byte> base64_bytes = stackalloc byte[24];

        MemoryMarshal.TryWrite(id_bytes, ref id);
        Base64.EncodeToUtf8(id_bytes, base64_bytes, out _, out _);

        Span<char> base64_chars = stackalloc char[22];
        for (int i = 0; i < 22; i++)
        {
            // pattern matching...
            base64_chars[i] = base64_bytes[i] switch
            {
                ForwardsSlashByte => HyphenCharacter,
                PlusByte => UnderscoreCharacter,
                _ => (char) base64_bytes[i]
            };
        }

        return new string(base64_chars);
    }
}
