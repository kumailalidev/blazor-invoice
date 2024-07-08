using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Customer
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(destinationMember: dest => dest.Id, // Do not override the Id, ignore it
                           memberOptions: opt => opt.Ignore());
            // Invoice Terms
            CreateMap<InvoiceTerms, InvoiceTermsDTO>();
            CreateMap<InvoiceTermsDTO, InvoiceTerms>()
                .ForMember(destinationMember: dest => dest.Id, // Do not override the Id, ignore it
                           memberOptions: opt => opt.Ignore());

            // Invoice Line Items
            CreateMap<InvoiceLineItem, InvoiceLineItemDTO>();
            CreateMap<InvoiceLineItemDTO, InvoiceLineItem>()
                .ForMember(destinationMember: dest => dest.Id, // Do not override the Id, ignore it
                           memberOptions: opt => opt.Ignore());

            // Invoice
            CreateMap<Invoice, InvoiceDTO>()
                .ForMember(destinationMember: dest => dest.CustomerName,
                           memberOptions: opt => opt.MapFrom(src => src.Customer!.Name))
                .ForMember(destinationMember: dest => dest.InvoiceTermsName,
                           memberOptions: opt => opt.MapFrom(src => src.InvoiceTerms!.Name));
            CreateMap<InvoiceDTO, Invoice>()
                .ForMember(destinationMember: dest => dest.Id, // Do not override the Id, ignore it
                           memberOptions: opt => opt.Ignore());
        }
    }
}
