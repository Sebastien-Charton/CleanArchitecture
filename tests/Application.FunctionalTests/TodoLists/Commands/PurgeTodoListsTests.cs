using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Application.TodoLists.Commands.PurgeTodoLists;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.FunctionalTests.TodoLists.Commands;

using static TestingFixture;

public class PurgeTodoListsTests : IClassFixture<BaseTestFixture>
{
    private readonly BaseTestFixture _fixture;

    public PurgeTodoListsTests(BaseTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShouldDenyAnonymousUser()
    {
        PurgeTodoListsCommand command = new();

        command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

        Func<Task> action = () => SendAsync(command);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }

    [Fact]
    public async Task ShouldDenyNonAdministrator()
    {
        await RunAsDefaultUserAsync();

        PurgeTodoListsCommand command = new();

        Func<Task> action = () => SendAsync(command);

        await action.Should().ThrowAsync<ForbiddenAccessException>();
    }

    [Fact]
    public async Task ShouldAllowAdministrator()
    {
        await RunAsAdministratorAsync();

        PurgeTodoListsCommand command = new();

        Func<Task> action = () => SendAsync(command);

        await action.Should().NotThrowAsync<ForbiddenAccessException>();
    }

    [Fact]
    public async Task ShouldDeleteAllLists()
    {
        await RunAsAdministratorAsync();

        await SendAsync(new CreateTodoListCommand { Title = "New List #1" });

        await SendAsync(new CreateTodoListCommand { Title = "New List #2" });

        await SendAsync(new CreateTodoListCommand { Title = "New List #3" });

        await SendAsync(new PurgeTodoListsCommand());

        int count = await CountAsync<TodoList>();

        count.Should().Be(0);
    }
}
