class Program
{
    static void Main(string[] args)
    {
        // Create an instance of Jisho
        var jdata = new Jisho<string, int>();

        // Test adding elements
        jdata.Add("One", 1);
        jdata.Add("Two", 2);
        jdata.Add("Three", 3);
        jdata.Add("Four", 4);
        jdata.Add("Five", 5);

        // Test Count property
        Console.WriteLine($"Count: {jdata.Count}");  // Output: Count: 5

        // Test ContainsKey method
        Console.WriteLine($"ContainsKey 'Three': {jdata.ContainsKey("Three")}");  // Output: ContainsKey 'Three': True
        Console.WriteLine($"ContainsKey 'Ten': {jdata.ContainsKey("Ten")}");  // Output: ContainsKey 'Ten': False

        // Test TryGetValue method
        if (jdata.TryGetValue("Four", out int value))
        {
            Console.WriteLine($"Value for key 'Four': {value}");  // Output: Value for key 'Four': 4
        }

        if (jdata.TryGetValue("Ten", out int nonExistentValue))
        {
            Console.WriteLine($"Value for key 'Ten': {nonExistentValue}");  // This won't be executed
        }
        else
        {
            Console.WriteLine("Key 'Ten' does not exist");  // Output: Key 'Ten' does not exist
        }

        // Test Remove method
        bool removed = jdata.Remove("Two");
        Console.WriteLine($"Removed 'Two': {removed}");  // Output: Removed 'Two': True

        bool removedNonExistent = jdata.Remove("Ten");
        Console.WriteLine($"Removed 'Ten': {removedNonExistent}");  // Output: Removed 'Ten': False

        Console.WriteLine($"Count after removal: {jdata.Count}");  // Output: Count after removal: 4

        // Test Clear method
        jdata.Clear();
        Console.WriteLine($"Count after clearing: {jdata.Count}");  // Output: Count after clearing: 0

        Console.ReadLine();
    }
}
