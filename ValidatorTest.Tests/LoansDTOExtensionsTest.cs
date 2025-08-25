using LibraryDb_Gabriel_Viinikka.DTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;
using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Diagnostics;

namespace ValidatorTest.Test
{
    [TestClass]
    public sealed class LoansDTOExtensionsTest
    {
        [TestMethod]
        public void ToActiveLoanDTOTest()
        {
           
                #region Arrange
                #region SettingUpLoan
                DateTime presentTime = DateTime.Now;
                DateTime futureTime = DateTime.Now.AddDays(1);


                Loan loan = new Loan
                {
                    Id = 1,
                    LoanDate = presentTime,
                    ReturnDate = futureTime,
                    Inventory = new Inventory
                    {
                        Id = 1,
                        BookId = 1,
                        Book = new Book
                        {
                            Id = 1,
                            Title = "Testing Book",
                            ISBN = "9781471129391",
                            PublicationDate = new DateOnly(1999, 01, 01),
                            Authors = [new Author
                        {
                            Id = 1,
                            FirstName = "Testing Author",
                            LastName = "Testing Author LastName"
                        }
                            ]
                        },
                        DaysToLoan = 1
                    },
                    LoanCard = new LoanCard
                    {
                        Id = 1,
                        CreationDate = presentTime,
                        ExpirationDate = futureTime
                    }

                };

                ActiveLoanDTO actualActiveLoanDTO = loan.ToActiveLoanDTO();
                ActiveLoanDTO expectedActiveLoanDTO = new ActiveLoanDTO
                {
                    Id = 1,
                    LoanDate = DateOnly.FromDateTime(presentTime),
                    ExpectedReturnDate = DateOnly.FromDateTime(futureTime),
                    Inventory = loan.Inventory.ToMinimalInventoryDTO(),
                    LoanCard = loan.LoanCard.ToMinimalLoanCardDTO(),
                    DaysToLoan = 1
                };

                #endregion
                #endregion
                #region Act
                loan.ToActiveLoanDTO();
                #endregion
                #region Assert
                Assert.AreEqual(actualActiveLoanDTO.ExpectedReturnDate, expectedActiveLoanDTO.ExpectedReturnDate);
                #endregion
            
       
            

}
    }
}



//LOAN
//public int Id { get; set; }
//public required DateTime LoanDate { get; set; } = DateTime.Now;
//public DateTime? ReturnDate { get; set; }
//public required Inventory Inventory { get; set; }
//public int InventoryId { get; set; }
//public int LoanCardId { get; set; }
//public required LoanCard LoanCard { get; set; }

//Inventory
//{
//        public int Id { get; set; }
//public int BookId { get; set; }
//public required Book Book { get; set; }
//public bool Available { get; set; } = true;
//public required int DaysToLoan { get; set; } = 1;
//    }

//Book
//public int Id { get; set; }
//public required string Title { get; set; }

//public required string ISBN { get; set; }

//public required DateOnly PublicationDate { get; set; }
//public required ICollection<Author> Authors { get; set; }

//public ICollection<Rating> Ratings { get; set; } = [];
//public ICollection<Inventory> Inventories { get; set; } = [];