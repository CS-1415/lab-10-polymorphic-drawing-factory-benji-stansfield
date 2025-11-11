namespace Lab10.Main;

public class Program
{
    static void Main()
    {
        Console.Clear();
        List<IGraphic2DFactory> availableShapeTypes = new List<IGraphic2DFactory>();
        List<IGraphic2D> builtShapes = new List<IGraphic2D>();
        bool running = true;

        Console.WriteLine(@"Welcome to the drawing factory!");

        while (running)
        {
            Console.WriteLine(@"Please select an option from below: 
    1 - Display Drawing
    2 - Add Graphic
    3 - Remove Graphic
    4 - Exit Program");

            int choice = Console.ReadLine();
            switch (choice)
            {
                case 1: // Display drawing
                    Console.Clear();
                    AbstractGraphic2D.Display(List<IGraphic2D>);
                    Console.WriteLine("\nPress any key to return to the menu.");
                    Console.ReadKey(true);
                    break;
                case 2: // Add graphic
                    Console.Clear();
                    if (availableShapeTypes.Count == 0)
                    {
                        Console.WriteLine("Cannot find any shape factories.");
                        Console.WriteLine("Press any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    }

                    Console.WriteLine("Available shapes:");
                    for (int i = 0; i < availableShapeTypes.Count; i++)
                    {
                        Console.WriteLine($"{i}) {availableShapeTypes[i].Name}");
                    }
                    Console.Write("Enter the index of the shape you want to create: ");
                    string factoryIndexInput = Console.ReadLine()?.Trim();
                    if (!int.TryParse(factoryIndexInput, out int factoryIndex) ||
                        factoryIndex < 0 || factoryIndex >= availableShapeTypes.Count)
                    {
                        Console.WriteLine("Invalid index.");
                        Console.WriteLine("Press any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    }

                    try
                    {
                        IGraphic2D newShape = availableShapeTypes[factoryIndex].Create();
                        if (newShape != null)
                        {
                            builtShapes.Add(newShape);
                            Console.WriteLine("Shape added to drawing.");
                        }
                        else
                        {
                            Console.WriteLine("Factory returned null; nothing was added.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while creating the shape: {ex.Message}");
                    }

                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadLine();
                    break;
                case 3:
                case 4:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Sorry, that is not an acceptable option.");
                    break;
            }
            

        }

    }
}
