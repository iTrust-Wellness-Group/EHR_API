using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Shared.Attributes
{
    // 修飾在屬性或欄位(唯讀)
    // sealed -> 不能被繼承或覆寫
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class InjectAttribute : Attribute
    {

    }
}
