namespace HW8.Services
{
    public interface IParser
    {
        int TryParseArguments(string[] args, out int val1, out string operation, out int val2);
    }
}