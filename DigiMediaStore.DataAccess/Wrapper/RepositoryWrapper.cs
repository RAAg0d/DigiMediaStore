using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;
using DigiMediaStore.DataAccess.Repositories;

namespace DigiMediaStore.DataAccess.Wrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    private DigiMediaStoreContext _repoContext;
    private IRepositoryBase<User>? _user;
    private IRepositoryBase<Content>? _content;
    private IRepositoryBase<Order>? _order;
    private IRepositoryBase<ContentType>? _contentType;
    private IRepositoryBase<Genre>? _genre;
    private IRepositoryBase<Review>? _review;
    private IRepositoryBase<Payment>? _payment;
    private IRepositoryBase<OrderItem>? _orderItem;
    private IRepositoryBase<PriceOption>? _priceOption;

    public RepositoryWrapper(DigiMediaStoreContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public IRepositoryBase<User> User
    {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(_repoContext);
            }
            return _user;
        }
    }

    public IRepositoryBase<Content> Content
    {
        get
        {
            if (_content == null)
            {
                _content = new ContentRepository(_repoContext);
            }
            return _content;
        }
    }

    public IRepositoryBase<Order> Order
    {
        get
        {
            if (_order == null)
            {
                _order = new OrderRepository(_repoContext);
            }
            return _order;
        }
    }

    public IRepositoryBase<ContentType> ContentType
    {
        get
        {
            if (_contentType == null)
            {
                _contentType = new ContentTypeRepository(_repoContext);
            }
            return _contentType;
        }
    }

    public IRepositoryBase<Genre> Genre
    {
        get
        {
            if (_genre == null)
            {
                _genre = new GenreRepository(_repoContext);
            }
            return _genre;
        }
    }

    public IRepositoryBase<Review> Review
    {
        get
        {
            if (_review == null)
            {
                _review = new ReviewRepository(_repoContext);
            }
            return _review;
        }
    }

    public IRepositoryBase<Payment> Payment
    {
        get
        {
            if (_payment == null)
            {
                _payment = new PaymentRepository(_repoContext);
            }
            return _payment;
        }
    }

    public IRepositoryBase<OrderItem> OrderItem
    {
        get
        {
            if (_orderItem == null)
            {
                _orderItem = new OrderItemRepository(_repoContext);
            }
            return _orderItem;
        }
    }

    public IRepositoryBase<PriceOption> PriceOption
    {
        get
        {
            if (_priceOption == null)
            {
                _priceOption = new PriceOptionRepository(_repoContext);
            }
            return _priceOption;
        }
    }

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
