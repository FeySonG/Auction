﻿global using MediatR;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Mvc;
global using System.Text.Json.Serialization;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication;

global using Auction.Domain.Result;
global using Auction.Domain.Models.Users;

global using Auction.Api.Extensions;

global using Auction.DAL.Extensions;

global using Auction.Application.Extensions;
global using Auction.Application.Features.Users;
global using Auction.Application.Contracts.Users;
global using Auction.Application.Contracts.Products;
global using Auction.Application.Contracts.ProductAuctions;
global using Auction.Application.Contracts.ServiceAuctions;

global using Auction.Application.Features.UserContacts;
global using Auction.Application.Features.Users.Delete;
global using Auction.Application.Features.Users.GetAll;
global using Auction.Application.Features.Users.Update;
global using Auction.Application.Features.PaymentCards;
global using Auction.Application.Features.Users.GetById;
global using Auction.Application.Contracts.UserContacts;
global using Auction.Application.Contracts.PaymentCards;
global using Auction.Application.Contracts.ServiceLayers;
global using Auction.Application.Features.Products.Create;
global using Auction.Application.Features.Products.Update;
global using Auction.Application.Features.Products.Delete;
global using Auction.Application.Features.Products.GetAll;
global using Auction.Application.Features.Products.GetById;
global using Auction.Application.Features.Users.Auth.Login;
global using Auction.Application.Features.Users.UpdateRole;
global using Auction.Application.Features.Users.UserProfile;
global using Auction.Application.Features.Products.GetByName;
global using Auction.Application.Features.PaymentCards.Create;
global using Auction.Application.Features.PaymentCards.Update;
global using Auction.Application.Features.PaymentCards.Delete;
global using Auction.Application.Features.UserContacts.Update;
global using Auction.Application.Features.UserContacts.Create;
global using Auction.Application.Features.ServiceLayers.Delete;
global using Auction.Application.Features.ServiceLayers.Create;
global using Auction.Application.Features.ServiceLayers.Update;
global using Auction.Application.Features.ServiceLayers.GetAll;
global using Auction.Application.Features.ServiceLayers.GetById;
global using Auction.Application.Features.ProductAuctions.Create;
global using Auction.Application.Features.ProductAuctions.GetAll;
global using Auction.Application.Features.ServiceAuctions.Create;
global using Auction.Application.Features.ServiceAuctions.GetAll;
global using Auction.Application.Features.ProductAuctions.GetById;
global using Auction.Application.Features.Products.ChangeQuantity;
global using Auction.Application.Features.Products.GetUserProduct;
global using Auction.Application.Features.Users.Auth.Registration;
global using Auction.Application.Features.ServiceAuctions.GetById;
global using Auction.Application.Features.ServiceLayers.GetByName;
global using Auction.Application.Features.ServiceLayers.GetUserServices;
global using Auction.Application.Features.ProductAuctions.ChangeCurrentPrice;
global using Auction.Application.Features.ServiceAuctions.ChangeCurrentPrice;
global using Auction.Application.Features.UserContacts.DeleteUserContact;
