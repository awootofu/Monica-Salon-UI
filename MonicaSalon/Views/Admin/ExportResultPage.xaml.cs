namespace MonicaSalon.Views.Admin;
public partial class ExportResultPage : ContentPage
{
    public ExportResultPage() => InitializeComponent();
    private void Show(string which)
    {
        ProgressLayout.IsVisible = which == "progress";
        SuccessLayout.IsVisible = which == "success";
        FailureLayout.IsVisible = which == "failure";
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-export-config");
    private async void OnShowProgress(object sender, EventArgs e) { Show("progress"); await Task.CompletedTask; }
    private async void OnShowSuccess(object sender, EventArgs e) { Show("success"); await Task.CompletedTask; }
    private async void OnShowFailure(object sender, EventArgs e) { Show("failure"); await Task.CompletedTask; }
    private async void OnDownload(object sender, EventArgs e) => await Task.CompletedTask;
    private async void OnBackToOverview(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-finance");
    private async void OnRetry(object sender, EventArgs e) { Show("progress"); await Task.CompletedTask; }
    private async void OnReviewConfig(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-export-config");
}
