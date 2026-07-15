namespace IRCClient;

// Loads icon.ico from the assembly's embedded resources so every window can
// use it without depending on shell icon extraction from the running exe
// (unreliable while the process has the file open) or a loose file on disk.
public static class AppIcon
{
    public static Icon? Load()
    {
        using var stream = typeof(AppIcon).Assembly.GetManifestResourceStream("IRCClient.icon.ico");
        return stream != null ? new Icon(stream) : null;
    }
}
