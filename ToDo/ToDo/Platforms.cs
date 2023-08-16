namespace ToDo;

public enum Platform
{
    NotSet,
    Mobile,
    Skia,
    Wasm,
    Windows
}

public static class Platforms
{
    public static Platform Current { get; set; } = Platform.NotSet;
}
