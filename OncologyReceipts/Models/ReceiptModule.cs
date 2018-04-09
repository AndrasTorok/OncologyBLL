using Autofac;
using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OncologyReceipts.Models
{
    public class ReceiptModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OncologyReceiptsContext>().InstancePerRequest();
        }
    }
}