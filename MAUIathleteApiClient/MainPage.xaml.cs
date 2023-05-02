using RSIRIWARDENAGE1_Test3.Data;
using RSIRIWARDENAGE1_Test3.Models;
using RSIRIWARDENAGE1_Test3.Utilities;
using System.Text;

namespace RSIRIWARDENAGE1_Test3;

public partial class MainPage : ContentPage
{
	private List<Sport> sports;
	private List<Athlete> athletes;

	public MainPage()
	{
		InitializeComponent();
		sports = new List<Sport> { new Sport { ID = 0, Name = "All Sports" } };
		athletes = new List<Athlete>();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ShowSports();
    }

    private async Task ShowSports()
    {
        //Get the artTypes
        SportRepository atr = new SportRepository();
        try
        {
            List<Sport> dbArtTypes = await atr.GetSports();
            foreach (Sport p in dbArtTypes.OrderBy(d => d.Name))
            {
                sports.Add(p);
            }
            ddlSports.ItemsSource = sports;
            ddlSports.SelectedIndex = 0;
        }
        catch (ApiException apiEx)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Errors:");
            foreach (var error in apiEx.Errors)
            {
                sb.AppendLine("-" + error);
            }
            await DisplayAlert("Problem Getting List of Art Types:", sb.ToString(), "Ok");
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {

                    await DisplayAlert("Error", "No connection with the server. Check that the Web Service is running and available and then click the Refresh button.", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "If the problem persists, please call your system administrator.", "Ok");
                }
            }
            else
            {
                if (ex.Message.Contains("NameResolutionFailure"))
                {
                    await DisplayAlert("Internet Access Error ", "Cannot resolve the Uri: " + Jeeves.DBUri.ToString(), "Ok");
                }
                else
                {
                    await DisplayAlert("General Error ", ex.Message, "Ok");
                }
            }
        }
    }

    private async void ddlSport_SelectedIndexChanged(object sender, EventArgs e)
    {
        await ShowAthlete();
    }

    private async Task ShowAthlete()
    {
        Loading.IsRunning = true;
        int? SportID = ((Sport)ddlSports.SelectedItem).ID;
        AthleteRepository r = new AthleteRepository();
        try
        {
            if (SportID.GetValueOrDefault() > 0)
            {
                athletes = await r.GetAthletesBySport(SportID.GetValueOrDefault());
            }
            else
            {
                athletes = await r.GetAthletes();
            }

            athleteList.ItemsSource = athletes;
            athleteList.SelectedItem = null;

        }
        catch (ApiException apiEx)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Errors:");
            foreach (var error in apiEx.Errors)
            {
                sb.AppendLine("-" + error);
            }
            //artworkList.IsVisible = false;
            await DisplayAlert("Error Getting Artworks:", sb.ToString(), "Ok");
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {

                    await DisplayAlert("Error", "No connection with the server. Check that the Web Service is running and available and then click the Refresh button.", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "If the problem persists, please call your system administrator.", "Ok");
                }
            }
            else
            {
                await DisplayAlert("General Error", "If the problem persists, please call your system administrator.", "Ok");
            }
        }
        finally
        {
            Loading.IsRunning = false;
        }
    }

    private async void AthleteSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedAthlete = e.SelectedItem as Athlete;
        await Navigation.PushAsync(new AthleteDetailPage(selectedAthlete));

        athleteList.SelectedItem = null;
    }
}

