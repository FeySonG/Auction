global using MediatR;
global using Mapster;
global using AutoMapper;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.Extensions.DependencyInjection;

global using System.Reflection;
global using System.Security.Claims;
global using System.ComponentModel.DataAnnotations;

global using Auction.Domain.Result;
global using Auction.Domain.Models.Users;
global using Auction.Domain.Models.Products;
global using Auction.Domain.Models.UserContacts;
global using Auction.Domain.Models.PaymentCards;
global using Auction.Domain.Models.ServiceLayers;
global using Auction.Domain.Models.AuctionLots.ServiceAuctions;
global using Auction.Domain.Models.AuctionLots.ProductAuctions;

global using Auction.Application.Services;
global using Auction.Application.Abstractions;
global using Auction.Application.Contracts.Users;
global using Auction.Application.Features.Products;
global using Auction.Application.Contracts.Products;
global using Auction.Application.Contracts.Validation;
global using Auction.Application.Contracts.UserContacts;
global using Auction.Application.Features.ServiceLayers;
global using Auction.Application.Contracts.PaymentCards;
global using Auction.Application.Contracts.ServiceLayers;
global using Auction.Application.Contracts.ProductAuctions;
global using Auction.Application.Contracts.ServiceAuctions;
