namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object? sender, EventArgs e)
        => await Navigation.PopAsync();
}