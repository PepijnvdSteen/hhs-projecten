namespace GokAsync;


class Asynsync    // SyncAsyn
{
    static async Task Yuurr(string[] args)
    {  
        // Asynchroon
        Console.WriteLine("Start asynchroon voorbeeld waarbij de taken parallel lopen:");
        await VoorbeeldAsync(); 
        Console.WriteLine("Asynchrone voorbeeld klaar!");
    }
    
    static async Task VoorbeeldAsync()
    {
        Console.WriteLine("Asynchrone lange taak wordt aangeroepen...");
        Task langeTaak = LangeTaakAsync(); 
        
        for (int i = 0; i < 6; i++) 
        {
            Console.WriteLine($"Ik ben nog steeds bezig... (asynchroon), iteratie: {i + 1}");
            await Task.Delay(1000); 
        }
        
        await langeTaak; 
        Console.WriteLine("Lange taak en for-lus in asynchrone methode klaar!");
    }
    static async Task LangeTaakAsync() 
    {
        Console.WriteLine("Asynchrone lange taak gestart...");
        await Task.Delay(3000); 
        Console.WriteLine("Asynchrone lange taak klaar!");
    }
}
