using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Helló");

        // Karakterlánc hozzáadása
        sb.Append(" világ!");
        Console.WriteLine(sb); // Kimenet: Helló világ!

        // Karakterlánc beszúrása egy adott helyre
        sb.Insert(5, " kedves");
        Console.WriteLine(sb); // Kimenet: Helló kedves világ!

        // Karakterlánc törlése
        sb.Remove(5, 7);
        Console.WriteLine(sb); // Kimenet: Helló világ!

        // Karakterlánc cseréje
        sb.Replace("világ", "barát");
        Console.WriteLine(sb); // Kimenet: Helló barát!
    }
}
