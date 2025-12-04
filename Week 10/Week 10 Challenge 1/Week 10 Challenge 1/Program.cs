public char FindTheDifference(string s, string t)
{
    int result = 0;

    foreach (char c in s)
        result ^= c;

    foreach (char c in t)
        result ^= c;

    return (char)result;
}