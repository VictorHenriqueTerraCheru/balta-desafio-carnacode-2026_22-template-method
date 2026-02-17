using Template;

namespace Processors
{
    public class WholesaleOrderProcessor : OrderProcessor
    {
        protected override string GetOrderType() => "Atacado";

        protected override bool Validate()
        {
            Console.WriteLine("Validando empresa...");
            if (string.IsNullOrEmpty(_id))
            {
                Console.WriteLine("Empresa invalida!");
                return false;
            }
            if (_amount < 1000.00m)
            {
                Console.WriteLine("Pedido minimo R$ 1.000,00 para atacado!");
                return false;
            }
            Console.WriteLine("Empresa validada!");
            return true;
        }

        protected override void CalculateValues()
        {
            Console.WriteLine($"Subtotal: R$ {_amount:N2}");
            Console.WriteLine("Total calculado (desconto sera aplicado)!");
        }

        // Sobrescreve o hook!
        protected override void ApplyDiscount()
        {
            var discount = _amount * 0.10m;
            var total = _amount - discount;
            Console.WriteLine($"Desconto atacado (10%): -R$ {discount:N2}");
            Console.WriteLine($"Total com desconto: R$ {total:N2}");
        }

        protected override void ProcessPayment()
        {
            Console.WriteLine("Gerando boleto bancario...");
            Console.WriteLine("Boleto gerado!");
        }

        protected override void ScheduleShipping()
        {
            Console.WriteLine("Agendando coleta com transportadora...");
            Console.WriteLine("Coleta agendada!");
        }

        protected override void Notify()
        {
            Console.WriteLine("Notificando empresa...");
            Console.WriteLine("  Email enviado!");
            Console.WriteLine("  SMS enviado!");
        }
    }
}