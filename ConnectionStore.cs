using System.Text.Json;

namespace IRCClient;

// Persists the saved-connection library to a JSON file under %AppData%\IRCClient
public static class ConnectionStore
{
    private static readonly string FilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "IRCClient", "connections.json");

    public static List<SavedConnection> Load()
    {
        try
        {
            if (!File.Exists(FilePath)) return [];
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<SavedConnection>>(json) ?? [];
        }
        catch
        {
            return [];
        }
    }

    public static void Save(List<SavedConnection> connections)
    {
        var dir = Path.GetDirectoryName(FilePath)!;
        Directory.CreateDirectory(dir);
        var json = JsonSerializer.Serialize(connections, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}
