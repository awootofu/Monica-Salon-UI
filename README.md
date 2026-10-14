# Monica Salon — MAUI UI

Customer + Admin salon app UI built with .NET MAUI.

## Prerequisites

- .NET 10 SDK
- MAUI workloads:
  ```powershell
  dotnet workload install maui
  ```
- Visual Studio 2022 17.13+ with “.NET Multi-platform App UI development” workload, or VS Code with C# + MAUI extensions.
- Windows 10 SDK 10.0.19041.0 for Windows builds; Android SDK API 21+ for Android builds.

## How to Open in Visual Studio

1. Open Visual Studio.
2. File → Open → Project/Solution → select `MonicaSalon/MonicaSalon.slnx` (or open `MonicaSalon/MonicaSalon.csproj` directly).
3. Restore workloads if prompted.
4. Select target framework / device (Windows Machine or Android Emulator).

There is a `MonicaSalon/MonicaSalon.slnx` solution plus the `MonicaSalon.csproj` project file.

## Build & Run

Restore + build (Windows target explicitly):

```powershell
cd "C:\School stuff\Visual programming\Salon UI\MonicaSalon"
dotnet build -f net10.0-windows10.0.19041.0
```

Other common commands:

```powershell
dotnet build
dotnet build -f net10.0-android
```

Run:

- Visual Studio: set `MonicaSalon` as startup project, press F5 with **Windows Machine** or **Android Emulator**.
- CLI (Windows unpackaged):
  ```powershell
  dotnet build -f net10.0-windows10.0.19041.0 -t:Run
  ```

Routes are registered in `AppShell.xaml.cs` via `Routing.RegisterRoute(...)`, e.g. `home`, `catalogue`, `schedule`, `hairstyle-book`, `hairstyle-detail`, `admin-dashboard`, etc. Navigation uses relative pushes `Shell.Current.GoToAsync("route")` (registered routes are not in the Shell visual hierarchy, so absolute `//route` fails at runtime).

## Project Structure

```
MonicaSalon/
  App.xaml / AppShell.xaml(.cs)   — resources + route registration
  MauiProgram.cs
  Models/                         — plain data models
  Services/                       — MockDataService (in-memory seed data)
  ViewModels/                     — page view models (if any)
  Converters/
  Views/
    Customer/                     — C01–C18 customer pages
    Admin/                        — A01–A34 admin pages
    Shared/                       — CoverPage, RoleSelectPage, DesignSystemPage,
                                    CustomerHeaderView, CustomerBottomNav,
                                    AdminHeaderView, AdminBottomNav
  Resources/
    Styles/Colors.xaml, Styles.xaml, MonicaTheme.xaml
    Images/                       — welcome.jpg, haircut.jpg, etc.
    Fonts/                        — OpenSans-*.ttf
    AppIcon/, Splash/, Raw/
  Platforms/                      — Android / iOS / Windows specifics
```

Shared theme keys live in `Resources/Styles/MonicaTheme.xaml`: `Ivory`, `DeepCocoa`, `DustyRose`, `RoseDark`, `Charcoal`, `Muted`, plus styles `ScreenTitle`, `Eyebrow`, `BodyCopy`, `MutedCopy`, `PrimaryButton`, `SecondaryButton`, `GhostButton`, `CardFrame` (Border-based), `FieldEntry`.

Conventions: Ivory page background, `Border` (not `Frame`), images referenced by filename only (e.g. `Source="welcome.jpg"`), `&amp;` escaping in XAML, `async void` code-behind handlers with `Shell.Current.GoToAsync`.

## Mock-Data Note

No real backend. All lists, bookings, inventory, and finance data come from an in-memory mock service (`Services/MockDataService`). No network calls, no persistence — restarting the app resets state. Photo pickers and saves are simulated with local UI state.

## Hairstyle Book Note

The hairstyle book flow (`hairstyle-book` → `hairstyle-detail`) is a **salon lookbook placeholder**:

- No AI generation, no image processing, no upload.
- 8 sample styles live in `Services/MockDataService.Hairstyles` (`Models/HairstyleItem`).
- The customer's pick is kept in `Services/BookingContext.SelectedHairstyle` and shown on `schedule`, `confirm`, and `booking-success` as a stylist reference.
- Every screen carries a note: referensi contoh, hasil akhir mengikuti konsultasi dengan stylist.

Do not present this flow as AI output.

## Assets / Fonts Note

- Images: `Resources/Images/*` with `<MauiImage Include="Resources\Images\*" />`. Reference by filename only in XAML.
- Fonts: `Resources/Fonts/OpenSans-Regular.ttf`, `OpenSans-Semibold.ttf` with `<MauiFont Include="Resources\Fonts\*" />`.
- App icon: `Resources\AppIcon\appicon.svg`; splash: `Resources\Splash\splash.svg`.
- Raw assets: `Resources\Raw\**`.
