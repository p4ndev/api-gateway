namespace States.Services;

public interface IReaderServices{
    string                      GetName();
    long                        GetCount();
    bool                        TryParse();
    bool                        HasLoaded();
    Task                        LoadAsync();
    IEnumerable<string>?        GetCities(char letter);
}