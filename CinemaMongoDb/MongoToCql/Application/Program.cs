namespace Application
{
    using PersonEntities;
    using System;

    public class Program
    {
        public static void Main()
        {
            var controller = new PersonEntitiesController();

            while (true)
            {
                Console.Write("Enter command: ");
                var command = Console.ReadLine();
                controller.ExecuteCommand(command);
            }
        }
    }
}
