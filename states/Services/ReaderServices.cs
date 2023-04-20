using States.Domains.Contract;
using States.Domains.Entity;
using Newtonsoft.Json;

namespace States.Services;

public class ReaderServices : IDisposable,
    ISaoPauloServices, ITocantinsServices, IAcreServices {

    private State? DataSource { get; set; }
    private readonly StreamReader _reader;
    private string? _json;

    public ReaderServices(string accronym)
        => _reader = new($"wwwroot/{accronym}.json");

    public async Task LoadAsync()
        => _json = await _reader.ReadToEndAsync();

    public bool HasLoaded() 
        => (DataSource is not null);

    public long GetCount()
        => DataSource!.Cidades!.LongCount();

    public void Dispose() 
        => _reader.Dispose();

    public bool TryParse(){
        if (String.IsNullOrEmpty(_json)) return false;
        DataSource = JsonConvert.DeserializeObject<State>(_json);
        return (DataSource is not null);
    }

    public string GetName() {
        if (DataSource is null) return "";
        return DataSource?.Nome!;
    }

    public IEnumerable<string>? GetCities(char letter) {

        if (DataSource is null || DataSource.Cidades is null)
            return null;

        return DataSource!.Cidades!
            .Where(item => item.StartsWith(letter));

    }

}