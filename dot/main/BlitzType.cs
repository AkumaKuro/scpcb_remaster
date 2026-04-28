class BlitzType<T> where T : BlitzType<T>
{
    static List<T> all;
    public static IEnumerable<T> each()
    {
        return all;
    }
}