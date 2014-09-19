using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using DataAccessLayerDemo.Services.Messages;
using DataAccessLayerDemo.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerDemo.Services.ViewModels;

namespace DataAccessLayerDemo.Services
{
    public class LibraryService
    {
        private IUnitOfWork _unitOfWork;
        private IBookTitleRepository _bookTitleRepository;
        private IBookRepository _bookRepository;
        private IMemberRepository _memberRepository;
        private LoanService _loanService;

        public LibraryService(IUnitOfWork unitOfWork, 
            IBookTitleRepository bookTitleRepository, 
            IBookRepository bookRepository,
            IMemberRepository memberRepository) 
        {
            _unitOfWork = unitOfWork;
            _bookTitleRepository = bookTitleRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _loanService = new LoanService(_bookRepository, _memberRepository, _unitOfWork);
        }

        public AddBookResponse AddBook(AddBookRequest request) 
        {
            AddBookResponse response = new AddBookResponse();
            BookTitle bookTitle = _bookTitleRepository.FindBy(request.ISBN);
            Book book = new Book();
            book.Id = Guid.NewGuid();
            book.Title = bookTitle;
            _bookRepository.Add(book);
            _unitOfWork.Commit();
            response.Success = true;

            return response;
        }

        public AddBookTitleResponse AddBookTitle(AddBookTitleRequest request) 
        {
            AddBookTitleResponse response = new AddBookTitleResponse();
            BookTitle bookTitle = new BookTitle();
            bookTitle.ISBN = request.ISBN;
            bookTitle.Title = request.Title;
            _bookTitleRepository.Add(bookTitle);
            _unitOfWork.Commit();
            response.Success = true;

            return response;
        }

        public AddMemberResponse AddMember(AddMemberRequest request) 
        {
            AddMemberResponse response = new AddMemberResponse();
            Member member = new Member();
            member.Id = Guid.NewGuid();
            member.FirstName = request.FirstName;
            member.LastName = request.LastName;
            _memberRepository.Add(member);
            _unitOfWork.Commit();
            response.Success = true;

            return response;
        }

        public FindBooksResponse FindBooks(FindBooksRequest request) 
        {
            FindBooksResponse response = new FindBooksResponse();
            IEnumerable<Book> books = _bookRepository.FindAll();
            response.Books = books.ConvertToBookViews();
            response.Success = true;

            return response;
        }

        public FindBookTitlesResponse FindBookTitles(FindBookTitlesRequest request) 
        {
            FindBookTitlesResponse response = new FindBookTitlesResponse();
            IList<BookTitleView> bookTitleViews = new List<BookTitleView>();
            if (request.All)
            {
                bookTitleViews = _bookTitleRepository.FindAll().ConvertToBookTitleViews();
            }
            else 
            {
                BookTitle bookTitle = _bookTitleRepository.FindBy(request.ISBN);
                bookTitleViews.Add(bookTitle.ConvertToBookTitleView());
            }
            response.BookTitles = bookTitleViews;
            response.Success = true;

            return response;
        }

        public FindMemberResponse FindMember(FindMemberRequest request) 
        {
            FindMemberResponse response = new FindMemberResponse();
            IList<MemberView> memberViews = new List<MemberView>();
            if (request.All)
            {
                memberViews = _memberRepository.FindAll().ConvertToMemberViews();
            }
            else 
            {
                MemberView memverView = _memberRepository.FindBy(new Guid(request.MemberId)).ConvertToMemberView();
                memberViews.Add(memverView);
            }
            response.MembersFound = memberViews;
            response.Success = true;

            return response;
        }

        public LoanBookResponse LoanBook(LoanBookRequest request) 
        {
            LoanBookResponse response = new LoanBookResponse();
            Loan loan = _loanService.Loan(new Guid(request.MemberId), new Guid(request.CopyId));
            if (loan != null)
            {
                response.Success = true;
                response.Loan = loan.ConvertToLoanView();
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        public ReturnBookResponse ReturnBook(ReturnBookRequest request) 
        {
            ReturnBookResponse response = new ReturnBookResponse();
            _loanService.Return(new Guid(request.CopyId));
            response.Success = true;

            return response;
        }
    }
}
