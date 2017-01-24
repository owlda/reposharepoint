using System;
using Microsoft.SharePoint;

namespace AddItemList
{
    class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter the name of the source List :");
            String @nameList = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("You entered: {0}", @nameList);
            Console.Write("Enter ID of the element in the List");
            String @idnameList = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter GUID of the element in the List");
            String @guidnameList = Console.ReadLine();
            Console.WriteLine();

            using (SPSite site = new SPSite("http://sitecoladdress"))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = web.GetList(@nameList);
                        SPListItemCollection items = list.Items;
                        Guid id = new Guid("@guidnameList"); 
                        SPListItem item = items.Add();
                        item[SPBuiltInFieldId.Title] = "Title";
                        item[SPBuiltInFieldId.ID] = @idnameList; 
                        item.Update();
                    Console.WriteLine(items[id].Title +"was restored. Press any key..");
                    }
                }
                Console.ReadLine();
            }
        }
    }
