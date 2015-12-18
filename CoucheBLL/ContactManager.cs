using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel;
using CoucheDAL;
using Excel = Microsoft.Office.Interop.Excel;


namespace CoucheBLL
{
    public class ContactManager
    {
        public static List<Contact> GetMesContact(int id)
        {
            return ContactService.GetMesContact(id);
        }

        public static List<Contact> GetContactByGroup(int id)
        {
            return ContactService.GetContactByGroup(id);
        }

        public static List<Contact> SearchContact(string nom)
        {
            return ContactService.SearchContact(nom);
        }

        public static void DeleteContact(Contact contact)
        {
            ContactService.DelateContact(contact);
        }

        public static bool UpdateContact(Contact contact)
        {
            return ContactService.UpdateContact(contact);
        }

        public static int addContact(Contact contact)
        {
            int indice = ContactService.AddContact(contact);
            return indice;


        }

        public static int downloadContacts(int id)
        {
            int retour = 1;
            List<Contact> mesContact = GetMesContact(id);
            int i = 1;
            int misValue = 1;
            try {
             Excel.Application excel=new Excel.Application();
            Excel.Workbook worbook;
            Excel.Worksheet xlWorkSheet;
            excel.Visible = true;
            worbook = excel.Workbooks.Add(1);
            xlWorkSheet = (Excel.Worksheet)worbook.Worksheets.get_Item(1);
            foreach(Contact con in mesContact)
            {
                xlWorkSheet.Cells[i, 1] = i;
                xlWorkSheet.Cells[i, 2] = con.PreNom;
                xlWorkSheet.Cells[i, 3] = con.Nom;
                xlWorkSheet.Cells[i, 4] = con.Email;
                i++;
            }
            worbook.SaveAs("d:\\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            worbook.Close();
            excel.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(worbook);
            releaseObject(excel);
            }
            catch(Exception e)
            {
                retour = -1;
            }
            return retour;
        
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
