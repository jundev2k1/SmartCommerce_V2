// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Interface;

namespace BuildingBlocks.Contracts.Grpc;

public sealed class GrpcClientFacade(
	IProductClient product,
	IUserClient user) : IGrpcClientFacade
{
	public IProductClient Product => product;

	public IUserClient User => user;
}
