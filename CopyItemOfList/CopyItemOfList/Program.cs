using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.IO;

namespace CopyItemOfList
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
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter ID of the element in the source List");
            String idnameList = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Searching...");

            SPSite site = new SPSite("http://httpaddressyoursitecollection");
            SPWeb web = site.OpenWeb();
            SPList sourceList = web.Lists.TryGetList(@nameList);


            foreach (SPListItem sourceItem in sourceList.Items)
            {
                SPSite destsite = new SPSite("http://httpaddressyoursitecollection");
                SPWeb destweb = destsite.OpenWeb();
                SPList destinationList = destweb.Lists.TryGetList(@nameDestination);
                try
                {
                    int number = Convert.ToInt32(idnameList);
                    
                    if (sourceItem.ID == number)
                    {

                        SPListItem destItem = destinationList.Items.Add();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("The element was found with the ID: {0} ",sourceItem.ID);


                        foreach (SPField field in sourceItem.Fields)
                        {
                            if (field.InternalName != "Attachments" && !field.Hidden && !field.ReadOnlyField)
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
                    }
                
                }
                catch (OverflowException) 
                { 
                    Console.WriteLine("-----------------------------------------------"); 
                    Console.WriteLine("You entered not the ID, but a text."); 
                }
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        }
    }

