using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.IO;

namespace Yimi.PublishManage.CreateDomainUser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var configFolderPath = AppDomain.CurrentDomain.BaseDirectory;

                var watcher = new FileSystemWatcher()
                {
                    Path = configFolderPath,
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
                };


                watcher.Changed += (s, e) =>
                {
                    string filepath = AppDomain.CurrentDomain.BaseDirectory + "user.txt";

                    var users = ReadUsersFromFile(filepath);
                    if (users.Length > 0)
                    {
                        foreach (var user in users)
                        {
                            var result = CreateUser(user);
                            Console.WriteLine($"user,{user} create:{result}");
                        }

                    }
                };

                watcher.EnableRaisingEvents = true;
                Console.WriteLine("Starting....");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static string[] ReadUsersFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd().Split(new char[] { ',' });
            }
        }

        public static string FriendlyDomainToLdapDomain(string friendlyDomainName)
        {
            string ldapPath = null;
            try
            {
                DirectoryContext objContext = new DirectoryContext(
                    DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.Name;
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }
            return ldapPath;
        }

        public static void EnumerateDomains()
        {
            List<string> alDomains = new List<string>();
            Forest currentForest = Forest.GetCurrentForest();
            DomainCollection myDomains = currentForest.Domains;

            foreach (Domain objDomain in myDomains)
            {
                alDomains.Add(objDomain.Name);
                Console.WriteLine($"domainname:{objDomain.Name}");
            }
            //return alDomains;
        }

        public static void EnumerateOU(string OuDn)
        {
            List<string> alObjects = new List<string>();
            try
            {
                DirectoryEntry directoryObject = new DirectoryEntry("LDAP://" + OuDn);
                foreach (DirectoryEntry child in directoryObject.Children)
                {
                    string childPath = child.Path.ToString();
                    alObjects.Add(childPath.Remove(0, 7));
                    //remove the LDAP prefix from the path
                    Console.WriteLine($"childPath:{childPath}");
                    child.Close();
                    child.Dispose();
                }


                directoryObject.Close();
                directoryObject.Dispose();
            }
            catch (DirectoryServicesCOMException e)
            {
                Console.WriteLine("An Error Occurred: " + e.Message.ToString());
            }
            //return alObjects;
        }



        public static void EnumerateDomainControllers()
        {
            List<string> alDcs = new List<string>();
            Domain domain = Domain.GetCurrentDomain();
            foreach (DomainController dc in domain.DomainControllers)
            {
                alDcs.Add(dc.Name);
                Console.WriteLine($"DomainController:{dc.Name}");
            }
            //return alDcs;
        }

        public static string CreateUserAccount(string userName, string userPassword)
        {
            string oGUID = string.Empty;
            try
            {

                string connectionPrefix = "LDAP://yimihaodi.net/CN=Users,DC=yimihaodi,DC=net";
                DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix);
                DirectoryEntry newUser = dirEntry.Children.Add
                    ("CN=" + userName, "user");
                newUser.Properties["samAccountName"].Value = userName;
                newUser.CommitChanges();
                oGUID = newUser.Guid.ToString();

                newUser.Invoke("SetPassword", new object[] { userPassword });
                newUser.CommitChanges();
                dirEntry.Close();
                newUser.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException e)
            {
                //DoSomethingwith --> E.Message.ToString();
                Console.WriteLine($"CreateUserAccount:{e.Message}");

            }
            return oGUID;
        }

        public static bool IsUserExists(string ldapPath, string username)
        {
            string connectionPrefix = "LDAP://" + ldapPath;
            DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix);
            var user = dirEntry.Children.Find(username);
            return user != null;
        }

        public static bool CreateUser(string userLogonName)
        {
            try
            {

                // Creating the PrincipalContext
                PrincipalContext principalContext = null;
                principalContext = new PrincipalContext(ContextType.Domain, "yimihaodi.net", "CN=Users,DC=yimihaodi,DC=net");
                Console.WriteLine($"ConnectedServer:{principalContext.ConnectedServer},Container:{principalContext.Container},Name:{principalContext.Name},UserName:{principalContext.UserName}");

                GroupPrincipal groupPrincipal = new GroupPrincipal(principalContext);

                Console.WriteLine("get groups");
                var groups = groupPrincipal.GetGroups();
                foreach (var group in groups)
                {
                    Console.WriteLine($"Name:{group.Name},SamAccountName:{group.SamAccountName},DisplayName:{group.DisplayName},UserPrincipalName:{group.UserPrincipalName}");
                }

                Console.WriteLine("get members");
                var members = groupPrincipal.GetMembers();

                foreach (var member in members)
                {
                    Console.WriteLine($"Name:{member.Name},SamAccountName:{member.SamAccountName},DisplayName:{member.DisplayName},UserPrincipalName:{member.UserPrincipalName}");
                }

                UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
                if (usr != null)
                {
                    Console.WriteLine(userLogonName + " already exists. Please use a different User Logon Name.");
                    return false;
                }

                if (string.IsNullOrEmpty(userLogonName))
                {
                    Console.WriteLine($"userLogonName can not be null");
                    return false;
                }

                // Create the new UserPrincipal object
                UserPrincipal userPrincipal = new UserPrincipal(principalContext);

                //userPrincipal.
                userPrincipal.SamAccountName = userLogonName;

                string password = "abcd@1234";
                userPrincipal.SetPassword(password);

                userPrincipal.Enabled = true;

                userPrincipal.PasswordNeverExpires = true;

                userPrincipal.Save();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception creating user object. " + e);
                return false;
            }

            /***************************************************************
             *   The below code demonstrates on how you can make a smooth 
             *   transition to DirectoryEntry from AccountManagement namespace, 
             *   for advanced operations.
             ***************************************************************/
            //if (userPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
            //{
            //    DirectoryEntry entry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();
            //    if (address != null && address.Length > 0)
            //        entry.Properties["streetAddress"].Value = address;
            //    try
            //    {
            //        entry.CommitChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Exception modifying address of the user. " + e);
            //        return false;
            //    }
            //}

            return true;
        }
    }
}
