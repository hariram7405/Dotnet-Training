namespace SupportPortal.Models
{
    public class SupportAgent
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public SupportAgent(int agentId, string name, string department)
        {
            AgentId = agentId;
            Name = name;
            Department = department;
        }

        public void DisplayAgent()
        {
            Console.WriteLine($"Agent ID: {AgentId}, Name: {Name}, Department: {Department}");
        }
    }
}
