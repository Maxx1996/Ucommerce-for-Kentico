using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCommerce.EntitiesV2;
using UCommerce.Pipelines;

namespace UCommerce.MasterClass.BusinessLogic.Pipelines
{
    public class NotifyOnVipCustomerTask : IPipelineTask<PurchaseOrder>
    {
        public PipelineExecutionResult Execute(PurchaseOrder subject)
        {
            if(subject.OrderTotal.GetValueOrDefault() > 500)
            {

            }

            return PipelineExecutionResult.Success;
        }
    }
}
