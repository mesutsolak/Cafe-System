using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class ContactOperation : BaseOperation
    {
        public static int ContactAdd(Contact contact)
        {
            _data.ContactRepository.Add(contact);
            return _data.Complete();
        }
        public static int ContactUpdate(Contact contact)
        {
            _data.ContactRepository.Update(contact);
            return _data.Complete();
        }
        public static int ContactRemove(int id)
        {
            _data.ContactRepository.Remove(id);
            return _data.Complete();
        }
        public static Contact GetContact()
        {
            return _data.ContactRepository.FirstRecord();
        }
    }
}
