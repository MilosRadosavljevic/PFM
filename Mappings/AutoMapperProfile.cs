using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PFM.Commands;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // for transactions
            CreateMap<TransactionEntity, Transaction>()
                .ForMember(tran => tran.TransactionId, ent => ent.MapFrom(x=>x.Id));

            CreateMap<Transaction, TransactionEntity>()
                .ForMember(ent => ent.Id, tran => tran.MapFrom(x => x.TransactionId));

            CreateMap<PagedSortedList<TransactionEntity>, PagedSortedList<Transaction>>();

            CreateMap<CreateTransactionCommand, TransactionEntity>()
                .ForMember(ent => ent.Id, tran => tran.MapFrom(x => x.TransactionId));

            //// for categories
            //CreateMap<CategoryEntity, Category>()
            //    .ForMember(c => c.CatCode, ent => ent.MapFrom(x => x.Code));

            //CreateMap<Category, CategoryEntity>()
            //    .ForMember(c => c.Code, ent => ent.MapFrom(x => x.CatCode));

        }
    }
}
