using System.Linq;
using WhooberCore.Domain.PaymentAbstraction;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Payment;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class PaymentService : IPaymentConfirmationService
    {
        private PaymentMethod _whooberReciever;
        private WhooberContext _context;
        private IServiceMediator _mediator;
        public PaymentService(WhooberContext context)
        {
            _context = context;

            // TODO generate admin card
            BaseCard whooberCard = _context.Cards.FirstOrDefault();
            if (whooberCard is null)
            {
                // TODO remove more cringe
                whooberCard = new DummyCard("0000000000000000");
                _context.Cards.Add(whooberCard);
                _context.SaveChanges();
            }

            _whooberReciever = new CardMethod(whooberCard);
        }

        public bool ConfirmPayment(PaymentMethod method, decimal price)
        {
            var transaction = new Transaction(method, _whooberReciever, price);
            if (!transaction.ExecuteTransaction()) return false;
            _context.SaveChanges();
            return true;
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _mediator = mediator;
        }
    }
}