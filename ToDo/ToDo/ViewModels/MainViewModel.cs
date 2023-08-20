namespace ToDo.ViewModels;

internal class MainViewModel : IViewModel
{
    public void Load()
    {
        var test = DB.I.GetToDos();
    }

    public void Save()
    {

    }
}
