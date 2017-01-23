using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SweetyKingdom
{
    class XML
    {

        private XmlDocument XmlDoc;

        public XML()
        {

            this.XmlDoc = new XmlDocument();

        }
        //*****************************************
        public void XmlLoad()
        {

            try
            {

                XmlDoc.Load("resources/document.xml");
                Console.WriteLine("Dokument zaladowany.");

            }
            catch(XmlException e)
            {
                Console.WriteLine("Nie udalo sie zaladowac dokumentu: " + e.Message);
            }

        }
        //*****************************************
        public bool SearchUser(string user)
        {

            int count = XmlDoc.GetElementsByTagName("user").Count;
            for (int i = 0; i < count; i++)
            {

                if (XmlDoc.GetElementsByTagName("login").Item(i).InnerText == user)
                {
                    Console.WriteLine("Znaleziono");
                    return true;
                }

            }
        
            return false;
        }
        //*****************************************
        public void CreateUser(string user)
        {

            XmlElement userNode = XmlDoc.CreateElement("user");

            XmlElement loginNode = XmlDoc.CreateElement("login");
            loginNode.InnerText = user;
            XmlElement progressNode = XmlDoc.CreateElement("statics");
            progressNode.InnerText = "0";

            userNode.AppendChild(loginNode);
            userNode.AppendChild(progressNode);

            XmlDoc.DocumentElement.InsertAfter(userNode, XmlDoc.DocumentElement.LastChild);
            XmlDoc.Save("resources/document.xml");

        }
        //*****************************************
        public bool DeleteUser(string user)
        {
            // Login nodes.
            XmlNodeList userLogins = XmlDoc.SelectNodes("//save/user/login");
            foreach(XmlElement userLogin in userLogins)
            {

                if (userLogin.InnerText == user)
                {
                    // Deleting user node.
                    XmlDoc.SelectSingleNode("//save").RemoveChild(userLogin.ParentNode);
                    XmlDoc.Save("resources/document.xml");
                    Console.WriteLine("Usunieto.");
                    return true;
                }

            }

            return false;
        }
        //*****************************************
    }
}
