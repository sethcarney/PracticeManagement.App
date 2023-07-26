using System.Windows.Input;

namespace PracticeManagement.MAUI.Controls;

public partial class SearchBarControl : ContentView
{
 

    public static readonly BindableProperty SearchCommandProperty
        = BindableProperty.Create(
            nameof(SearchCommand)
            , typeof(ICommand)
            , typeof(SearchBarControl)
            , default(ICommand));

    public static readonly BindableProperty RefreshCommandProperty
       = BindableProperty.Create(
           nameof(RefreshCommand)
           , typeof(ICommand)
           , typeof(SearchBarControl)
           , default(ICommand));


    public static readonly BindableProperty QueryTextProperty
        = BindableProperty.Create(nameof(QueryText)
            , typeof(string)
            , typeof(SearchBarControl)
            , string.Empty
            , BindingMode.TwoWay);

    public string QueryText
    {
        get => (string)GetValue(QueryTextProperty);
        set => SetValue(QueryTextProperty, value);
    }

    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }

    public ICommand RefreshCommand
    {
        get => (ICommand)GetValue(RefreshCommandProperty);
        set => SetValue(RefreshCommandProperty, value);
    }


    public SearchBarControl()
    {
        InitializeComponent();
        Content.BindingContext = this;
    }

    private void Query_TextChanged(object sender, TextChangedEventArgs e)
    {
     SearchCommand?.Execute(this);
    }
}