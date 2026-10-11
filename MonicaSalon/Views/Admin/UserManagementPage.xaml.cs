namespace MonicaSalon.Views.Admin;
public partial class UserManagementPage : ContentPage
{
    public UserManagementPage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnAddUser(object sender, EventArgs e)
    {
        FormTitle.Text = "Add User";
        FormOverlay.IsVisible = true;
        await Task.CompletedTask;
    }
    private async void OnEditUser(object sender, EventArgs e)
    {
        FormTitle.Text = "Edit User";
        FormOverlay.IsVisible = true;
        await Task.CompletedTask;
    }
    private async void OnRolePicked(object sender, EventArgs e)
    {
        var b = (Button)sender;
        foreach (var child in ((Grid)b.Parent).Children)
            if (child is Button btn)
                btn.Style = btn == b ? (Style)Application.Current.Resources["PrimaryButton"] : (Style)Application.Current.Resources["SecondaryButton"];
        await Task.CompletedTask;
    }
    private async void OnFormSave(object sender, EventArgs e) { FormOverlay.IsVisible = false; await Task.CompletedTask; }
    private async void OnFormCancel(object sender, EventArgs e) { FormOverlay.IsVisible = false; await Task.CompletedTask; }
    private async void OnDeactivateUser(object sender, EventArgs e) { ConfirmOverlay.IsVisible = true; await Task.CompletedTask; }
    private async void OnConfirmDeactivate(object sender, EventArgs e) { ConfirmOverlay.IsVisible = false; await Task.CompletedTask; }
    private async void OnCancelDeactivate(object sender, EventArgs e) { ConfirmOverlay.IsVisible = false; await Task.CompletedTask; }
}
