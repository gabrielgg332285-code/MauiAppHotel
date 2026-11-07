using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = new List<Quarto>
        {
            new Quarto { Descricao = "Suíte Executiva", ValorDiaria = 450 },
            new Quarto { Descricao = "Suíte Master",    ValorDiaria = 600 },
            new Quarto { Descricao = "Quarto Simples",  ValorDiaria = 250 }
        };

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddYears(1);

        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Today.AddYears(1).AddDays(1);
        dtpck_checkout.Date = DateTime.Today.AddDays(1);
    }

    private void dtpck_checkin_DateSelected(object? sender, DateChangedEventArgs e)
    {
        DateTime checkin = e.NewDate ?? DateTime.Today;
        DateTime checkout = dtpck_checkout.Date ?? DateTime.Today.AddDays(1);

        dtpck_checkout.MinimumDate = checkin.AddDays(1);

        if (checkout <= checkin)
            dtpck_checkout.Date = checkin.AddDays(1);
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlert("Atenção", "Selecione uma suíte.", "OK");
                return;
            }

            var hospedagem = new Hospedagem
            {
                QuartoSelecionado = quarto,
                Adultos = Convert.ToInt32(stp_adultos.Value),
                Criancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date ?? DateTime.Today,
                DataCheckOut = dtpck_checkout.Date ?? DateTime.Today.AddDays(1)
            };

            await Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = hospedagem
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void Sobre_Clicked(object? sender, EventArgs e)
        => await Navigation.PushAsync(new Sobre());
}