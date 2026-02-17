using Template;

namespace Processors
{
    public class OnlineOrderProcessor : OrderProcessor
    {
        protected override string GetOrderType() => "Online";

        protected override bool Validate()
        {
            Console.WriteLine("Validando cliente online...");
            if (string.IsNullOrEmpty(_id))
            {
                Console.WriteLine("Cliente invalido!");
                return false;
            }
            Console.WriteLine("Cliente validado!");
            return true;
        }

        protected override void CalculateValues()
        {
            var shipping = 15.00m;
            var total = _amount + shipping;
            Console.WriteLine($"Subtotal: R$ {_amount:N2}");
            Console.WriteLine($"Frete: R$ {shipping:N2}");
            Console.WriteLine($"Total: R$ {total:N2}");
        }

        protected override void ProcessPayment()
        {
            Console.WriteLine("Processando pagamento com cartao...");
            Console.WriteLine("Pagamento aprovado!");
        }

        protected override void ScheduleShipping()
        {
            Console.WriteLine("Agendando envio via Correios...");
            Console.WriteLine("Envio agendado!");
        }

        protected override void Notify()
        {
            Console.WriteLine("Enviando email de confirmacao...");
            Console.WriteLine("Email enviado!");
        }

        // Nao sobrescreve ApplyDiscount
    }
}