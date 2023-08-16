using ToDo.Views;

namespace ToDo;

internal enum NavLoc
{
    None,
    Main
}

internal static class Nav
{
    public static Navigator I {  get; set; }
}

internal class Navigator
{
    private Frame _frame;
    public Navigator(Frame frame)
    {
        Nav.I = this;
        _frame = frame;
    }

    private NavLoc _lastLoc = NavLoc.None;
    public void GoTo(NavLoc loc)
    {
        switch (loc)
        {
            case NavLoc.Main:
                VML.I.MainVM.Load();
                break;
        }

        Page newLoc = null;
        switch (Platforms.Current)
        {
            case Platform.Mobile: 
                newLoc = MobileGoTo(loc); 
                break;
            default:
                newLoc = UniversalGoTo(loc); 
                break;
        }

        if (null != newLoc)
        {
            switch (Platforms.Current)
            {
                case Platform.Mobile:
                    _frame.Content = newLoc.Content;
                    break;
                default:
                    _frame.Content = newLoc;
                    break;
            }
            switch (_lastLoc)
            {
                case NavLoc.Main:
                    VML.I.MainVM.Save();
                    break;
            }
            _lastLoc = loc;
        }


    }

    private Page MobileGoTo(NavLoc loc)
    {
        switch (loc)
        {
            case NavLoc.Main:
                return new Mobile_MainView();
        }

        return null;
    }

    private Page UniversalGoTo(NavLoc loc)
    {
        switch (loc)
        {
            case NavLoc.Main:
                return new Universal_MainView();
        }

        return null;
    }
}
