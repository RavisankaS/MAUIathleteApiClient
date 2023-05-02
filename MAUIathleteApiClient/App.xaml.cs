namespace RSIRIWARDENAGE1_Test3;
using RSIRIWARDENAGE1_Test3.Models;

public partial class App : Application
{

    public bool needSportRefresh;
	public List<Sport> AllSports;
    public App()
	{
		
		InitializeComponent();

		MainPage = new AppShell();
	}
}
