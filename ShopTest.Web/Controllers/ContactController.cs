using AutoMapper;
using ShopTest.Model.Models;
using ShopTest.Service;
using ShopTest.Web.Infrastructure.Extensions;
using ShopTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTest.Web.Controllers
{
    public class ContactController : Controller
    {
        IContactDetailService _contactDetailService;
        IFeedbackService _feedbackService;
        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedbackService = feedbackService;
        }
        // GET: Contact
        public ActionResult Index()
        {
           
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if(ModelState.IsValid)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.Save();
            }
            feedbackViewModel.ContactDetail = GetDetail();
            return View("Index", feedbackViewModel);
        }
        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaulContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactViewModel;
        }
    }
}