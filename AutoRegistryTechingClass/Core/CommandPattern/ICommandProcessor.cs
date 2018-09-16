namespace AutoRegistryTechingClass.Core.CommandPattern
{
    public interface ICommandProcessor
    {
        void Process<TCommand>(TCommand command);
    }
}
