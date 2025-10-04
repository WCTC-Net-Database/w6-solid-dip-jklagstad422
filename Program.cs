using W6_assignment_template.Interfaces;
using W6_assignment_template.Data; 
using W6_assignment_template.Services;

public class Program
{
    public static void Main()
    {
 
        IContext context = new GameContext();


        GameEngine engine = new GameEngine(context);

        engine.Run();
    }
}