// ListPhoneBook.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDanhBa
{
    public class ListPhoneBook
    {
        private static ListPhoneBook instance;
        private List<PhoneBook> listNumberPhone;

        public List<PhoneBook> ListNumberPhone
        {
            get => listNumberPhone;
            set => listNumberPhone = value;
        }

        private ListPhoneBook()
        {
            listNumberPhone = new List<PhoneBook>();
            
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

<<<<<<< HEAD
        private void LoadDataFromDatabase()
        {
            // Your database loading logic remains unchanged
            // Make sure the data is loaded properly from the database
        }

        public void Add(PhoneBook phoneBook)
        {
            listNumberPhone.Add(phoneBook);
        }

        public void Update(int index, PhoneBook phoneBook)
        {
            listNumberPhone[index] = phoneBook;
        }

        public void Remove(int index)
        {
            listNumberPhone.RemoveAt(index);
        }
=======
        
>>>>>>> f3a665c1db34ca41f053395e2a56d16b45f94ab2
    }
}
