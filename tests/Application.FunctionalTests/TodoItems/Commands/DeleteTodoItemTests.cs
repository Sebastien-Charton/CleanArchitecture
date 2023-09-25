﻿using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.FunctionalTests.TodoItems.Commands;

using static TestingFixture;

public class DeleteTodoItemTests : IClassFixture<BaseTestFixture>
{
    private readonly BaseTestFixture _fixture;

    public DeleteTodoItemTests(BaseTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShouldRequireValidTodoItemId()
    {
        DeleteTodoItemCommand command = new(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task ShouldDeleteTodoItem()
    {
        int listId = await SendAsync(new CreateTodoListCommand { Title = $"New List {Guid.NewGuid()}" });

        int itemId = await SendAsync(new CreateTodoItemCommand { ListId = listId, Title = "New Item" });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        TodoItem? item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
