namespace RSIRIWARDENAGE1_Test3;
using RSIRIWARDENAGE1_Test3.Data;
using RSIRIWARDENAGE1_Test3.Models;
using RSIRIWARDENAGE1_Test3.Utilities;
using System.Text;

public partial class AthleteDetailPage : ContentPage
{
    private Athlete _selectedAthlete;

    public AthleteDetailPage(Models.Athlete selectedAthlete)
	{
		InitializeComponent();
        _selectedAthlete = selectedAthlete;
        BindingContext = _selectedAthlete;

        // Calculate and display BMI and BMI Category
        double _bmi = BMI.CalcBMI(_selectedAthlete.Weight, _selectedAthlete.Height);
        string category = BMI.GetCategory(_bmi);
        BMIValue.Text = _bmi.ToString("F2");
        BMICategoryValue.Text = category;
    }
}