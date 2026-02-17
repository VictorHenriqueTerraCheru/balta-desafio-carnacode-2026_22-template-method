namespace Template
{
    public abstract class OrderProcessor
    {
        protected string _id;
        protected List<string> _items;
        protected decimal _amount;

        // template - sequência IMUTÁVEL!
        public void ProcessOrder(string id, List<string> items, decimal amount)
        {
            _id = id;
            _items = items;
            _amount = amount;

            Console.WriteLine($"\n=== Processando Pedido ({GetOrderType()}) ===");

            if (!Validate()) return;

            CheckStock();       // igual para todos
            CalculateValues();
            ProcessPayment();
            SeparateItems();    // igual para todos
            ScheduleShipping();
            ApplyDiscount();    // hook - opcional!
            Notify();

            Console.WriteLine($"\nPedido {GetOrderType()} processado com sucesso!");
        }

        // VARIAM - subclasse obrigada a implementar
        protected abstract bool Validate();
        protected abstract void CalculateValues();
        protected abstract void ProcessPayment();
        protected abstract void ScheduleShipping();
        protected abstract void Notify();
        protected abstract string GetOrderType();

        // COMUNS - implementados aqui, subclasse herda
        protected void CheckStock()
        {
            Console.WriteLine("Verificando estoque...");
            foreach (var item in _items)
                Console.WriteLine($"  {item}: Disponivel");
            Console.WriteLine("Estoque confirmado!");
        }

        protected void SeparateItems()
        {
            Console.WriteLine("Separando itens no estoque...");
            Console.WriteLine("Itens separados!");
        }

        // Hook - subclasse PODE sobrescrever, mas não é obrigada
        protected virtual void ApplyDiscount()
        {
            // padrão: sem desconto
        }
    }
}