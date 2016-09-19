
using ShopTest.Data.Infrastructure;
using ShopTest.Data.Repositories;
using ShopTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTest.Service
{
    public interface IContactDetailService
    {
        ContactDetail GetDefaulContact();
    }
    public class ContactDetailService : IContactDetailService
    {
        IContactDetailRepository _contactDetailRepository;
        IUnitOfWork _unitOfWork;
        public ContactDetailService(IContactDetailRepository contactDetailRepository, IUnitOfWork unitOfWork)
        {
            this._contactDetailRepository = contactDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaulContact()
        {
            return _contactDetailRepository.GetSingleByCondition(y => y.Status==true);
        }
    }
}
