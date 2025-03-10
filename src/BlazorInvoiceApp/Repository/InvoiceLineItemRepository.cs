﻿using System.Security.Claims;

using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceLineItemRepository :
        GenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>,
        IInvoiceLineItemRepository
    {
        public InvoiceLineItemRepository(ApplicationDbContext context, IMapper mapper) :
            base(context, mapper)
        {
        }

        public async Task<List<InvoiceLineItemDTO>> GetAllByInvoiceId(
            ClaimsPrincipal User,
            string invoiceId)
        {
            return await GenericQuery(User, l => l.InvoiceId == invoiceId, null!);
        }
    }
}
