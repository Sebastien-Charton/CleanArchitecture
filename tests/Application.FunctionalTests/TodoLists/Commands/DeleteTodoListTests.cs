using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Application.TodoLists.Commands.DeleteTodoList;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.FunctionalTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        DeleteTodoListCommand command = new(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        int listId = await SendAsync(new CreateTodoListCommand { Title = "New List" });

        await SendAsync(new DeleteTodoListCommand(listId));

        TodoList? list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
