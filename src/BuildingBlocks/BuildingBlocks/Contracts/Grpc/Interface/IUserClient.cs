// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.User;

namespace BuildingBlocks.Contracts.Grpc.Interface;

public interface IUserClient
{
	Task<GetUserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default);

	Task<GetUsersResponse> GetUsersAsync(GetUsersRequest request, CancellationToken cancellationToken = default);
}
