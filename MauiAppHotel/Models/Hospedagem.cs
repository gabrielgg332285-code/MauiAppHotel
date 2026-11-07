namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; } = new();
        public int Adultos { get; set; }
        public int Criancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia => (DataCheckOut - DataCheckIn).Days;

        // Adultos pagam a diária inteira; crianças pagam metade
        public double ValorTotal =>
            Estadia * ((Adultos * QuartoSelecionado.ValorDiaria) +
                       (Criancas * QuartoSelecionado.ValorDiaria / 2));
    }
}