
namespace Apphotel;

public partial class SobrePage : ContentPage
{
    public SobrePage()
    {
        InitializeComponent();
    }

    private async void Voltar_Clicked(
        object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
