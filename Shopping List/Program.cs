/*
✔
TASK:
- MAKE A SHOPPING LIST PROGRAM 
    - BE ABLE TO STORE ITEMS 
- CONTAINS TWO COLLECTIONS 
    1. MENU 
    2. SHOPPING LIST 
 
 BUILD SPECS:
✔ 1. DISPLAY >= 8 NAMES + PRICES                                         ✔ 7. LIST<STRING> FOR SHOPPING LIST                                              
✔ 2. ASK USER TO ENTER ITEM NAME                                               ✔ - STORE NAME OF ITEMS                                                    
    ✔ - IF ITEM EXIST, DISPLAY ITEM + PRICE                              ✔ 8. APP TAKES ITEM NAME INPUT                                            
    ✔ - ADD TO ORDER                                                           ✔ - RESPONDS IF DOESNT EXIST                                                         
✔ 3. ASK IF THEY WANT TO CONTINUE                                              ✔ - ADDS ITEM TO ORDER IF IT DOES                                                   
4. WHEN DONE, DISPLAY LIST OF ITEMS + PRICES                           9. MENU SYSTEM SO USER CAN ENTER LET/NUM FOR ITEM                                   
✔ 5. DISPLAY TOTAL                                                       10. SORT TOTAL FROM HIGH TO LOW                                       
✔ 6. USES DICTIONARY <STRING, DECIMAL> TO KEEP TRACK OF MENU ITEMS       11. DISPLAY ITEMS ORDERED HIGH TO LOW            
    - LITERALS
        - INSTANTIATION (List<string>)
        - INITIALIZATION (= new List<string>())

BRAIN TALK:
- make dictionary filled with items 
- empty list of string (cart)
    - cart is the list of keys 
- loop 
    - display menu (foreach kvp)
    - ask for input 
    - if item is in store -> add to cart (.ContainsKey())
    - add more item 
- foreach the cart
    - display item name and price (dictionary[itemName])
        - total = 0 
            - add price to total
            - display total 
*/

//----------------------------------------------------------------------------------------------------------------------
bool runProgram = true;

decimal receiptTotal = 0.0M;
List<decimal> tab = new List<decimal>();

string receiptOrder = "";
List<string> tabs = new List<string>();

string storeFront = "Fancy a bevvy? ;-)";
Console.SetCursorPosition((Console.WindowWidth - storeFront.Length) / 4, Console.CursorTop); // to center text 
Console.WriteLine(storeFront); 
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

// i have two dictionaries because one is strictly for display/alignment/OCD -- the other is fully functional  
Dictionary<string, decimal> dranks = new Dictionary<string, decimal>();
dranks.Add("Carajillo", 12.99M); dranks.Add("Lone Star", 4.99M); dranks.Add("Water", 100.00M); dranks.Add("Rumple Minze", 7.99M); dranks.Add("Green Tea Shot", 7.99M); dranks.Add("Pimms Cup", 15.99M); dranks.Add("Long Island", 8.99M); dranks.Add("AMF", 12.00M);

Dictionary<string, decimal> dranksForViewing = new Dictionary<string, decimal>();
dranksForViewing.Add("Carajillo", 12.99M); dranksForViewing.Add("Lone Star", 4.99M); dranksForViewing.Add("Water   ", 100.00M); dranksForViewing.Add("Rumple Minze", 7.99M); dranksForViewing.Add("Green Tea Shot", 7.99M); dranksForViewing.Add("Pimms Cup", 15.99M); dranksForViewing.Add("Long Island", 8.99M); dranksForViewing.Add("AMF     ", 12.00M);

foreach (KeyValuePair<string, decimal> kvp in dranksForViewing) // list of bevvies 
{
    Console.WriteLine($"{kvp.Key} \t\t\t\t ${kvp.Value}"); 
}

while (runProgram)
{
    Console.WriteLine();
    //tab.Add(order);
    while (true)
    {
        Console.WriteLine("What adult beverage would you like, bud?");
        string order = Console.ReadLine().Trim();
        if (dranks.ContainsKey(order))
        {
            // water/long island/amf has space 
            Console.WriteLine($"You ordered a {order} for {(dranks[order])}.");
            tab.Add(dranks[order]);
            tabs.Add(order);
            Console.WriteLine();
            break;
        }
        else
        {
            Console.WriteLine("Sorry, bud, we don't have that. Please choose something that is on the menu.");
            Console.WriteLine();
            
        }
    }
    //Console.WriteLine();
    while (true)
    {
        Console.Write("Do you want to keep your tab open or close it out? (open/close)  ");
        string answer = Console.ReadLine().ToLower().Trim();
        if (answer.Contains("open"))
        {
            //Console.WriteLine();
            break;
        }
        else if (answer.Contains("close"))
        { 
            Console.WriteLine("Hope you enjoyed your night! Here if your receipt...");
            runProgram = !true;
            Console.WriteLine();
            break; 
        }
        else
        {
            Console.WriteLine("Alrighty, buddy, it's time to cut you off."); 
            runProgram = !true;
            Console.WriteLine();
            break;
        }
    }
}

receiptTotal = tab.Sum();
Console.WriteLine(receiptTotal);
Console.WriteLine();

// validation
foreach (decimal t in tab) // cost per item
{
    Console.Write($"{t}       ");
}

Console.WriteLine();

foreach (string t in tabs) // name of items
{
    Console.Write($"{t}       ");
}

Console.WriteLine();

var sorted = tab.Max(i => i); // max value 
Console.WriteLine();
Console.WriteLine($"The most expensive thing you bought was something for {sorted}.");

