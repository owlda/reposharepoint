using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.IO;

namespace CopyListItemsSharepoint
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
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter the name of the destination List :");
            String @nameDestination = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("You entered: {0}", @nameDestination);
           
            SPSite site = new SPSite("http://addressyoursitecollection");
               SPWeb web = site.OpenWeb();
               SPList sourceList = web.Lists[@nameList];
                     foreach (SPListItem sourceItem in sourceList.Items)
                        {
                         SPSite destsite = new SPSite("http://addressyoursitecollectiondestination");
                         SPWeb destweb = destsite.OpenWeb();
                         SPList destinationList = destweb.Lists[@nameDestination];
                         SPListItem destItem = destinationList.Items.Add();
                                        foreach (SPField field in sourceItem.Fields)
                                        {
                                            if (!field.ReadOnlyField && field.InternalName != "Attachments")
                                            {
                                                if (destItem.Fields.ContainsField(field.InternalName))
                                                {
                                                    destItem[field.InternalName] = sourceItem[field.InternalName];
                                                }
                                                                                                  
                                            }
                                        }
                                        foreach (string fileName in sourceItem.Attachments)
                                        {
                                            SPFile file = sourceItem.ParentList.ParentWeb.GetFile(sourceItem.Attachments.UrlPrefix + fileName);
                                            byte[] bData = file.OpenBinary();
                                            destItem.Attachments.Add(fileName, bData);
                                        }
                                        destItem.Update();
                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();
                                        }
                                     }
          }
    }
        
    



