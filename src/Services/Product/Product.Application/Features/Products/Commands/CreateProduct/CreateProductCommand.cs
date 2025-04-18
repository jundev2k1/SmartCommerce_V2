// Copyright (c) 2025 - Jun Dev. All rights reserved

using FluentValidation;

namespace Product.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(ProductDto Product)
    : ICommand<CreateProductResult>;

public record CreateProductResult(string productId);

public sealed class CreateProductCommandValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product)
            .NotNull()
            .WithMessage("Product cannot be null");
        RuleFor(x => x.Product.Name)
            .NotEmpty()
            .WithMessage("Product name cannot be empty");
        RuleFor(x => x.Product.Description)
            .NotEmpty()
            .WithMessage("Product description cannot be empty");
        RuleFor(x => x.Product.Price)
            .GreaterThan(0)
            .WithMessage("Product price must be greater than 0");
    }
}
