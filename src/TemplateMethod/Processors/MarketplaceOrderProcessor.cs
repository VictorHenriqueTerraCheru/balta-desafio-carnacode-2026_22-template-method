using Template;

namespace Processors
{
    public class MarketplaceOrderProcessor : OrderProcessor
    {
        protected override string GetOrderType() => "Marketplace";

        protected override bool Validate()
        {
            Console.WriteLine("Validando vendedor...");
            if (string.IsNullOrEmpty(_id))
            {
                Console.WriteLine("Vendedor invalido!");
                return false;
            }
            Console.WriteLine("Vendedor validado!");
            return true;
        }

        protected override void CalculateValues()
        {
            var commission = _amount * 0.15m;
            var sellerAmount = _amount - commission;
            Console.WriteLine($"Valor total: R$ {_amount:N2}");
            Console.WriteLine($"Comissao (15%): R$ {commission:N2}");
            Console.WriteLine($"Repasse vendedor: R$ {sellerAmount:N2}");
        }

        protected override void ProcessPayment()
        {
            var commission = _amount * 0.15m;
            var sellerAmount = _amount - commission;
            Console.WriteLine("Processando split payment...");
            Console.WriteLine($"  R$ {commission:N2} para marketplace");
            Console.WriteLine($"  R$ {sellerAmount:N2} para vendedor");
            Console.WriteLine("Pagamento dividido!");
        }

        protected override void ScheduleShipping()
        {
            Console.WriteLine("Agendando envio com opcao do vendedor...");
            Console.WriteLine("Envio agendado!");
        }

        protected override void Notify()
        {
            Console.WriteLine("Notificando partes...");
            Console.WriteLine("  Cliente notificado!");
            Console.WriteLine("  Vendedor notificado!");
        }
    }
}