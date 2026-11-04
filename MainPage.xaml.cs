
namespace Apphotel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void HospedesStepper_ValueChanged(
        object sender, ValueChangedEventArgs e)
    {
        int quantidade = (int)e.NewValue;

        HospedesLabel.Text = quantidade == 1
            ? "1 hóspede"
            : $"{quantidade} hóspedes";
    }

    private async void Reservar_Clicked(
        object sender, EventArgs e)
    {
        string nome = NomeEntry.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nome))
        {
            await DisplayAlertAsync(
                "Atenção",
                "Digite seu nome.",
                "OK");
            return;
        }

        if (QuartoPicker.SelectedIndex == -1)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Escolha um quarto.",
                "OK");
            return;
        }

        DateTime entrada = EntradaPicker.Date ?? DateTime.Today;
        DateTime saida = SaidaPicker.Date ?? DateTime.Today;

        if (saida <= entrada)
        {
            await DisplayAlertAsync(
                "Atenção",
                "A saída deve ser depois da entrada.",
                "OK");
            return;
        }

        string quarto = QuartoPicker.SelectedItem.ToString()!;
        int hospedes = (int)HospedesStepper.Value;
        int diarias = (saida - entrada).Days;

        int valorDiaria = QuartoPicker.SelectedIndex switch
        {
            0 => 150,
            1 => 250,
            2 => 400,
            _ => 0
        };

        int total = diarias * valorDiaria;

        string mensagem =
            $"Hóspede: {nome}\n" +
            $"Quarto: {quarto}\n" +
            $"Hóspedes: {hospedes}\n" +
            $"Entrada: {entrada:dd/MM/yyyy}\n" +
            $"Saída: {saida:dd/MM/yyyy}\n" +
            $"Diárias: {diarias}\n" +
            $"Total: R$ {total:N2}";

        await DisplayAlertAsync(
            "Reserva confirmada!",
            mensagem,
            "OK");
    }

    private async void Sobre_Clicked(
        object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}
