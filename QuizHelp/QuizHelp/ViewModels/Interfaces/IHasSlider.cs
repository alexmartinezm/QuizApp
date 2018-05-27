namespace QuizHelp.ViewModels.Interfaces
{
    public interface IHasSlider
    {
        double SliderValue { get; set; }
        double MinimumValue { get; set; }
        double MaximumValue { get; set; }
    }
}