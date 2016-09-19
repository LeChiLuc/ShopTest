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
    public interface IFeedbackService
    {
        Feedback Create(Feedback feedback);
        void Save();
    }
    public class FeedbackService : IFeedbackService
    {
        FeedbackRepository _feedBackRepository;
        IUnitOfWork _unitOfWork;
        public FeedbackService(FeedbackRepository feedBackRepository, IUnitOfWork unitOfWork)
        {
            this._feedBackRepository = feedBackRepository;
            this._unitOfWork = unitOfWork;
        }
        public Feedback Create(Feedback feedback)
        {
            return _feedBackRepository.Add(feedback);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
