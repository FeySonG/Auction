﻿namespace Auction.Application.Contracts.ServiceLayers;

public class GetServiceLayerDTO
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ServiceLayerCategory Category { get; set; }
    public decimal Price { get; set; }
    public string? ImagePath { get; set; }
}