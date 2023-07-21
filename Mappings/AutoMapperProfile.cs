using AutoMapper;
using PFM.Commands;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //  for transactions
            CreateMap<TransactionEntity, Transaction>()
                .ForMember(tran => tran.TransactionId, ent => ent.MapFrom(x => x.Id));

            CreateMap<Transaction, TransactionEntity>()
                .ForMember(ent => ent.Id, tran => tran.MapFrom(x => x.TransactionId));

            CreateMap<PagedSortedListTransactions<TransactionEntity>, PagedSortedListTransactions<Transaction>>();

            CreateMap<CreateTransactionCommand, TransactionEntity>()
                .ForMember(ent => ent.Id, ctc => ctc.MapFrom(x => x.TransactionId));



            //  for categories
            CreateMap<CategoryEntity, Category>()
                .ForMember(c => c.CategoryCode, ent => ent.MapFrom(x => x.Code));

            CreateMap<Category, CategoryEntity>()
                .ForMember(c => c.Code, ent => ent.MapFrom(x => x.CategoryCode));

            CreateMap<PagedSortListItems<CategoryEntity>, PagedSortListItems<Category>>();

            CreateMap<CreateCategoryCommand, CategoryEntity>()
                .ForMember(ent => ent.Code, ccc => ccc.MapFrom(x => x.CategoryCode));

        }
    }
}
