// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Interface;
using BuildingBlocks.Contracts.Grpc.User;

namespace BuildingBlocks.Contracts.Grpc.Clients;

public sealed class UserClient(UserProtoService.UserProtoServiceClient client) : IUserClient
{
	public async Task<GetUserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default)
	{
		return await client.GetUserAsync(request, cancellationToken: cancellationToken);
	}

	public async Task<GetUsersResponse> GetUsersAsync(GetUsersRequest request, CancellationToken cancellationToken = default)
	{
		return await client.GetUsersAsync(request, cancellationToken: cancellationToken);
	}
}