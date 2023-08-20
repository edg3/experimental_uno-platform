namespace ToDo;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        new ToDoDataContext();

        this.InitializeComponent();

        new Navigator(frmContent);
        new ViewModelLocator();

        Nav.I.GoTo(NavLoc.Main);
    }
}