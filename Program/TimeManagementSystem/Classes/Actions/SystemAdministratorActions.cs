using Interfaces;

namespace SystemAdministratorActions
{
    public class TechSupportAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Техническая поддержка оказана!");
        }   
    }
}