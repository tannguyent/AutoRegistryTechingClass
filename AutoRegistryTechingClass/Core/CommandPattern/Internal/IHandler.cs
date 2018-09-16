namespace AutoRegistryTechingClass.Core.CommandPattern.Internal
{
    public interface IHandler<T> 
    {
        void Handle(T command);
    }
}
