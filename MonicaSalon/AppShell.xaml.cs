using MonicaSalon.Views.Admin;
using MonicaSalon.Views.Customer;
using MonicaSalon.Views.Shared;

namespace MonicaSalon;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private static void RegisterRoutes()
    {
        // Reference / shell screens
        Routing.RegisterRoute("roles", typeof(RoleSelectPage));
        Routing.RegisterRoute("system", typeof(DesignSystemPage));
        Routing.RegisterRoute("flows", typeof(FlowsPage));

        // Customer C01-C18
        Routing.RegisterRoute("welcome", typeof(WelcomePage));
        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("register", typeof(RegisterPage));
        Routing.RegisterRoute("home", typeof(HomePage));
        Routing.RegisterRoute("catalogue", typeof(CataloguePage));
        Routing.RegisterRoute("details", typeof(ServiceDetailPage));
        Routing.RegisterRoute("schedule", typeof(SchedulePage));
        Routing.RegisterRoute("confirm", typeof(ConfirmBookingPage));
        Routing.RegisterRoute("booking-success", typeof(BookingSuccessPage));
        Routing.RegisterRoute("history", typeof(BookingHistoryPage));
        Routing.RegisterRoute("booking-details", typeof(BookingDetailsPage));
        Routing.RegisterRoute("booking-feedback", typeof(BookingFeedbackPage));
        Routing.RegisterRoute("simulation-intro", typeof(SimulationIntroPage));
        Routing.RegisterRoute("photo-selection", typeof(PhotoSelectionPage));
        Routing.RegisterRoute("hair-editor", typeof(HairEditorPage));
        Routing.RegisterRoute("simulation-result", typeof(SimulationResultPage));
        Routing.RegisterRoute("profile", typeof(ProfilePage));
        Routing.RegisterRoute("settings", typeof(SettingsPage));

        // Admin A01-A34 + More
        Routing.RegisterRoute("admin-login", typeof(AdminLoginPage));
        Routing.RegisterRoute("admin-dashboard", typeof(AdminDashboardPage));
        Routing.RegisterRoute("admin-bookings", typeof(AdminBookingsPage));
        Routing.RegisterRoute("admin-create-booking", typeof(AdminCreateBookingPage));
        Routing.RegisterRoute("admin-booking-details", typeof(AdminBookingDetailsPage));
        Routing.RegisterRoute("admin-reschedule", typeof(AdminReschedulePage));
        Routing.RegisterRoute("admin-cashier", typeof(CashierPage));
        Routing.RegisterRoute("admin-transaction-review", typeof(TransactionReviewPage));
        Routing.RegisterRoute("admin-payment", typeof(PaymentPage));
        Routing.RegisterRoute("admin-transaction-success", typeof(TransactionSuccessPage));
        Routing.RegisterRoute("admin-transactions", typeof(TransactionHistoryPage));
        Routing.RegisterRoute("admin-transaction-details", typeof(TransactionDetailsPage));
        Routing.RegisterRoute("admin-inventory", typeof(InventoryOverviewPage));
        Routing.RegisterRoute("admin-inventory-add", typeof(AddInventoryPage));
        Routing.RegisterRoute("admin-inventory-edit", typeof(EditInventoryPage));
        Routing.RegisterRoute("admin-stock-in", typeof(StockInPage));
        Routing.RegisterRoute("admin-stock-out", typeof(StockOutPage));
        Routing.RegisterRoute("admin-inventory-history", typeof(InventoryHistoryPage));
        Routing.RegisterRoute("admin-inventory-details", typeof(InventoryItemDetailsPage));
        Routing.RegisterRoute("admin-finance", typeof(FinanceOverviewPage));
        Routing.RegisterRoute("admin-add-income", typeof(AddIncomePage));
        Routing.RegisterRoute("admin-add-expense", typeof(AddExpensePage));
        Routing.RegisterRoute("admin-financial-records", typeof(FinancialRecordsPage));
        Routing.RegisterRoute("admin-financial-details", typeof(FinancialDetailsPage));
        Routing.RegisterRoute("admin-export-config", typeof(ExportConfigPage));
        Routing.RegisterRoute("admin-export-result", typeof(ExportResultPage));
        Routing.RegisterRoute("admin-more", typeof(AdminMorePage));
        Routing.RegisterRoute("admin-services", typeof(ServiceManagementPage));
        Routing.RegisterRoute("admin-service-form", typeof(ServiceFormPage));
        Routing.RegisterRoute("admin-products", typeof(ProductManagementPage));
        Routing.RegisterRoute("admin-product-form", typeof(ProductFormPage));
        Routing.RegisterRoute("admin-salon-settings", typeof(SalonSettingsPage));
        Routing.RegisterRoute("admin-users", typeof(UserManagementPage));
        Routing.RegisterRoute("admin-salon-profile", typeof(SalonProfilePage));
        Routing.RegisterRoute("admin-help", typeof(HelpPage));
    }
}
