using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
    public class ListPhoneBook
    {

        private static ListPhoneBook instance;

        List<PhoneBook> listNumberPhone;

        public List<PhoneBook> ListNumberPhone 
        { 
            get => listNumberPhone; set => listNumberPhone = value; 
        }

        
        public static ListPhoneBook Instance 

        { 
            get 
            { 
                if (instance == null)
                    instance = new ListPhoneBook();
                return instance; 
            } 
        }

        private ListPhoneBook() 
        {
            listNumberPhone = new List<PhoneBook>();
            listNumberPhone.Add(new PhoneBook("Vũ Hoàng","0387598636","IT", "Ok"));
            listNumberPhone.Add(new PhoneBook("Ngọc Minh", "012345678", "IT", "Ok"));
            listNumberPhone.Add(new PhoneBook("Hà Tường", "087654321", "IT", "Ok"));
        }
    }
}
