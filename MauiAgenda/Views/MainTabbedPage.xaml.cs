using MauiAgenda.ViewModels;

namespace MauiAgenda.Views;

public partial class MainTabbedPage : TabbedPage
{
    public MainTabbedPage(TasksViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}