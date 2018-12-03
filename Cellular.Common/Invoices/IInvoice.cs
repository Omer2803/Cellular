namespace Cellular.Common.Invoices
{
    public interface IInvoice
    {
        double AdditionalPrice { get; }

        double TotalPrice { get; }
    }
}
