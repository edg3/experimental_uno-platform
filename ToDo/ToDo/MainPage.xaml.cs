namespace ToDo;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        new Navigator(frmContent);
        new ViewModelLocator();

        Nav.I.GoTo(NavLoc.Main);
    }
}