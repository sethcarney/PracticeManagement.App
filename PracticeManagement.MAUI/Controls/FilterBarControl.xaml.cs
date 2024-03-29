using System.Windows.Input;
using PracticeManagement.Library.Models;

namespace PracticeManagement.MAUI.Controls;

public partial class FilterBarControl : ContentView
{
    public static readonly BindableProperty SearchFiltersProperty
        = BindableProperty.Create(nameof(SearchFilters)
            , typeof(List<Filter>)
            , typeof(FilterBarControl)
            , new List<Filter>()
            , BindingMode.TwoWay);

    public static readonly BindableProperty UpdateCommandProperty
        = BindableProperty.Create(
            nameof(UpdateCommand)
            , typeof(ICommand)
            , typeof(FilterBarControl)
            , default(ICommand));



    public List<Filter> SearchFilters
    {
        get => (List<Filter>)GetValue(SearchFiltersProperty);
        set => SetValue(SearchFiltersProperty, value);
    }
    public ICommand UpdateCommand
    {
        get => (ICommand)GetValue(UpdateCommandProperty);
        set => SetValue(UpdateCommandProperty, value);
    }

    private void Filter_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        var firstColor = button.BackgroundColor;
        Filter filterClicked = SearchFilters.FirstOrDefault(f => f.Name == button.Text);
        if (filterClicked.Applied)
        {
            button.BackgroundColor = Colors.Gray;
            filterClicked.Applied = false;
        }
        else
        {
            button.BackgroundColor = Colors.MediumSeaGreen;
            filterClicked.Applied = true;
        }
        UpdateCommand?.Execute(this);
    }

    public FilterBarControl()
    {
        InitializeComponent();
        Content.BindingContext = this;
    }
}