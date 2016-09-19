using ShopTest.Model.Models;
using ShopTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTest.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateFeedback(this Feedback feedback,FeedbackViewModel feedbackVm)
        {
            feedback.Name = feedbackVm.Name;
            feedback.Email = feedbackVm.Email;
            feedback.Message = feedbackVm.Message;
            feedback.Status = feedbackVm.Status;
            feedback.CreatedDate = feedbackVm.CreatedDate;
        }
    }
}