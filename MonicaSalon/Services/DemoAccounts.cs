namespace MonicaSalon.Services;
public static class DemoAccounts
{
    public const string CustomerEmail = "customer@email.com";
    public const string OwnerEmail = "owner@email.com";

    public static bool IsCustomer(string email) =>
        email.Trim().Equals(CustomerEmail, StringComparison.OrdinalIgnoreCase);

    public static bool IsOwner(string email) =>
        email.Trim().Equals(OwnerEmail, StringComparison.OrdinalIgnoreCase);
}
