using Microsoft.Extensions.DependencyInjection;

namespace MonicaSalon;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window(new AppShell())
		{
			Width = 400,
			Height = 900,
			MinimumWidth = 360,
			MaximumWidth = 480,
			MinimumHeight = 700,
			MaximumHeight = 960,
		};
		return window;
	}
}