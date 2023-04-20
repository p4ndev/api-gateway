namespace Auth.Providers;

public abstract class Storage{

    public IDictionary<string, string> Table { get; private set; }

    public Storage() => Table = new SortedDictionary<string, string>();

}