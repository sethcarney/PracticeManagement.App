using System.Windows.Input;

namespace PracticeManagement.MAUI.Controls;

public partial class SearchBarControl : ContentView
{


    public static readonly BindableProperty LocalSearchCommandProperty
       = BindableProperty.Create(
           nameof(LocalSearchCommand)
           , typeof(ICommand)
           , typeof(SearchBarControl)
           , default(ICommand));

    public static readonly BindableProperty RefreshCommandProperty
       = BindableProperty.Create(
           nameof(RefreshCommand)
           , typeof(ICommand)
           , typeof(SearchBarControl)
           , default(ICommand));

    public static readonly BindableProperty ResetCommandProperty
     = BindableProperty.Create(
         nameof(ResetCommand)
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

    public ICommand RefreshCommand
    {
        get => (ICommand)GetValue(RefreshCommandProperty);
        set => SetValue(RefreshCommandProperty, value);
    }

    public ICommand LocalSearchCommand
    {
        get => (ICommand)GetValue(LocalSearchCommandProperty);
        set => SetValue(LocalSearchCommandProperty, value);
    }

    public ICommand ResetCommand
    {
        get => (ICommand)GetValue(ResetCommandProperty);
        set => SetValue(ResetCommandProperty, value);
    }

    public SearchBarControl()
    {
        InitializeComponent();
        Content.BindingContext = this;
    }

    private void Query_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(QueryText != string.Empty)
            LocalSearchCommand?.Execute(this);
        else
            RefreshCommand?.Execute(this);
    }

    private void Reset_Clicked(object sender, EventArgs e)
    {
        QueryText = string.Empty;
    }
}