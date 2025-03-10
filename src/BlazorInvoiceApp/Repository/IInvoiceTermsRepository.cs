﻿using System.Security.Claims;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface IInvoiceTermsRepository :
        IGenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>
    {
        public Task Seed(ClaimsPrincipal User);
    }
}
