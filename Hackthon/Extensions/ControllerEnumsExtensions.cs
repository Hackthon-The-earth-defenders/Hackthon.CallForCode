using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Hackthon.Extensions
{
    public static class ControllerEnumsExtensions
    {
        public static List<SelectListItem> MontarSelectListParaEnum<T>(this Controller controller, T selected = default(T), bool excludeDefault = false) where T : struct, IConvertible
        {
            var items = new List<SelectListItem>();
            var enums = Enum.GetValues(typeof(T)).Cast<T>();
            foreach (var enumerador in enums.OrderBy(o => o.GetDisplayName()))
            {
                if (excludeDefault && enumerador.Equals(default(T)))
                    continue;
                var name = enumerador.GetDisplayName();
                var item = new SelectListItem()
                {
                    Value = enumerador.ToString(),
                    Text = name,
                    Selected = selected.Equals(enumerador)
                };
                items.Add(item);
            }
            return items;
        }
        public static List<SelectListItem> MontarSelectListParaEnum2<T>(T selected = default(T), bool excludeDefault = false) where T : struct, IConvertible
        {
            var items = new List<SelectListItem>();
            var enums = Enum.GetValues(typeof(T)).Cast<T>();
            foreach (var enumerador in enums)
            {
                if (excludeDefault && enumerador.Equals(default(T)))
                    continue;
                var name = enumerador.GetDisplayName();
                var item = new SelectListItem()
                {
                    Value = enumerador.ToString(),
                    Text = name,
                    Selected = selected.Equals(enumerador)
                };
                items.Add(item);
            }
            return items;
        }

        public static string GetFlagDisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var names = new List<string>();
            foreach (var e in Enum.GetValues(enumType))
            {

                var flag = (Enum)e;
                if (enumValue.HasFlag(flag) && e.ToString() != "Nenhum")
                {
                    names.Add(GetSingleDisplayName(flag));
                }
            }
            if (names.Count <= 0) throw new ArgumentException();
            if (names.Count == 1) return names.First();
            return string.Join(", ", names);
        }
        public static string GetSingleDisplayName(this Enum flag)
        {
            try
            {
                return flag.GetType()
                        .GetMember(flag.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .Name;
            }
            catch
            {
                return flag.ToString();
            }
        }
    }
}
