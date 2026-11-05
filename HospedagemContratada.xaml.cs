
namespace Apphotel;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(
        string nome,
        string suite,
        int adultos,
        int criancas,
        DateTime entrada,
        DateTime saida,
        double total)
    {
        InitializeComponent();

        int diarias = (saida.Date - entrada.Date).Days;

        NomeLabel.Text = nome;
        SuiteLabel.Text = suite;

        AdultosLabel.Text = adultos.ToString();
        CriancasLabel.Text = criancas.ToString();

        EntradaLabel.Text =
            $"Check-in: {entrada:dd/MM/yyyy}";

        SaidaLabel.Text =
            $"Check-out: {saida:dd/MM/yyyy}";

        DiariasLabel.Text =
            $"Quantidade de diárias: {diarias}";

        TotalLabel.Text = $"R$ {total:N2}";
    }

    private async void Voltar_Clicked(
        object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
