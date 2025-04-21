// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Interface;

namespace BuildingBlocks.Contracts.Grpc;

public interface IGrpcClientFacade
{
    IProductClient Product { get; }

    IUserClient User { get; }
}
