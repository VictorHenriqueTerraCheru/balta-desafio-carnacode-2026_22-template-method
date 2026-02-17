using Processors;
using Template;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Template Method - Processamento de Pedidos ===");

        var items = new List<string> { "Notebook", "Mouse", "Teclado" };

        var processors = new List<OrderProcessor>
        {
            new OnlineOrderProcessor(),
            new WholesaleOrderProcessor(),
            new MarketplaceOrderProcessor()
        };

        foreach (var processor in processors)
            processor.ProcessOrder("ID001", items, 2500.00m);

        Console.WriteLine("\nValidacao falhando (atacado abaixo do minimo)\n");
        new WholesaleOrderProcessor().ProcessOrder("COMP001", items, 500.00m);

        Console.WriteLine("\nBeneficios\n");
        Console.WriteLine("ANTES: sequencia duplicada em 3 classes");
        Console.WriteLine("DEPOIS: sequencia definida UMA vez na base!");
        Console.WriteLine("CheckStock e SeparateItems: implementados uma vez, herdados por todos!");
        Console.WriteLine("ApplyDiscount (hook): so Atacado sobrescreve!");
        Console.WriteLine("Novo canal? So criar nova subclasse!");
    }
}