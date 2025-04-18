// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductHandler()
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => new CreateProductResult("pro1"));
    }
}
