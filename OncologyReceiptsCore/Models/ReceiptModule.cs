using Autofac;
using OncologyCore.Model;

namespace OncologyReceiptsCore
{
    public class ReceiptModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OncologyReceiptsContext>();
        }
    }
}
