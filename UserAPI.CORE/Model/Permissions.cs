using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.CORE.Model
{
    public static class Permissions
    {
        public const string View = "Permissions.Products.View";
        public const string Create = "Permissions.Products.Create";
        public const string Edit = "Permissions.Products.Edit";
        public const string Delete = "Permissions.Products.Delete";
        public const string Commited = "Permissions.Products.Commited";
        public const string ProductBuy = "Permissions.Products.Buy";


        public static List<string> GeneratePermissionsSysAdmin()
        {
            return new List<string>()
        {
            $"Permissions.Products.Create",
            $"Permissions.Products.View",
            $"Permissions.Products.Edit",
            $"Permissions.Products.Delete",
            "Permissions.Products.Commited",
            "Permissions.Products.Buy"
        };
        }
        public static List<string> GeneratePermissionsCustomer()
        {
            return new List<string>()
        {
            $"Permissions.Products.View",
            "Permissions.Products.Commited",
            "Permissions.Products.Buy"
        };
        }
        public static List<string> GeneratePermissionsAdmin()
        {
            return new List<string>()
        {
            $"Permissions.Products.Create",
            $"Permissions.Products.View",
            $"Permissions.Products.Edit",
            $"Permissions.Products.Delete",
            "Permissions.Products.Commited",
            "Permissions.Products.Buy"
        };
        }

    }
}
