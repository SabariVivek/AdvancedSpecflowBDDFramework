using Autofac;

namespace SpecflowBDDFramework.Base
{
    public class ContainerBase
    {
        public static IContainer Container { get; protected set; } = null!;
    }
}