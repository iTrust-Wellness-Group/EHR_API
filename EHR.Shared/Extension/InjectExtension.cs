using EHR.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Shared.Extension
{

    public static class InjectExtension
    {
        // 透過反射, 取得目標class, 然後取得內部有標記InjectAttribute的屬性或欄位
        public static void Inject(this IServiceProvider provider, object target)
        {

            // class type
            var type = target.GetType();

            // for properties
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var prop in props)
            {
                // 有標記InjectAttribute 且有setMethd者
                if (prop.GetCustomAttribute<InjectAttribute>() != null && prop.SetMethod != null)
                {
                    // 反射注入進class內的屬性
                    prop.SetValue(target, provider.GetService(prop.GetType()));
                }
            }

            // for fields
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute<InjectAttribute>() != null)
                {
                    field.SetValue(target, provider.GetService(field.FieldType));
                }
            }

        }
    }

}
