﻿using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class CustomerRepository :
        GenericOwnedRepository<Customer, CustomerDTO>,
        ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IMapper mapper) :
            base(context, mapper)
        {
        }
    }
}
