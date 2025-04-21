// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.User;
using Grpc.Core;

namespace User.Infrastructure.Grpc;

public sealed class UserGrpcService()
    : UserProtoService.UserProtoServiceBase
{
    public override async Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
    {
        return await Task.FromResult(new GetUserResponse() { User = new UserModel { FirstName = "Test grpc user" } });
    }

    public override async Task<GetUsersResponse> GetUsers(GetUsersRequest request, ServerCallContext context)
    {
        var response = new GetUsersResponse();
        response.Users.Add(new UserModel() { UserId = "User test Grpc" });
        response.Users.Add(new UserModel() { UserId = "User test Grpc 2" });
        return await Task.FromResult(response);
    }
}
