using ToDo.ViewModels;

namespace ToDo;

internal static class VML
{
    public static ViewModelLocator I { get; set; }
}

internal class ViewModelLocator
{
    public ViewModelLocator()
    {
        VML.I = this;
    }

    public MainViewModel MainVM { get; init; } = new();
}
