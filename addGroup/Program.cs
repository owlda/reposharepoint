using System;
using Microsoft.SharePoint;

namespace addGroupUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            // HTTP address of site
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter the site address: ");
            String SiteAddress = Console.ReadLine();
            Console.WriteLine("You entered: {0}", SiteAddress);

            // Name of group users
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter the name of group: ");
            String newGroup = Console.ReadLine();
            Console.WriteLine("You entered: {0}", newGroup);

            // Level of permission
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter the level of permission: ");
            String LevelPerm = Console.ReadLine();
            Console.WriteLine("You entered: {0}", LevelPerm);


            SPSite site = new SPSite(SiteAddress);
            using (SPWeb web = site.OpenWeb())
            {
                String Name = newGroup;
                web.SiteGroups.Add(Name, web.CurrentUser, web.CurrentUser,"group created by Administrator");

                
                SPGroup group = web.SiteGroups[newGroup];
                SPRoleAssignment roles = new SPRoleAssignment(group);
                SPRoleDefinition  permissions = web.RoleDefinitions[LevelPerm];
                roles.RoleDefinitionBindings.Add(permissions);
                web.RoleAssignments.Add(roles);

             }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        
        }
    }
}
