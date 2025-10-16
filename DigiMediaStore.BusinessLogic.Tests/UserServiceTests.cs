using DigiMediaStore.BusinessLogic.Services;
using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using FluentAssertions;
using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DigiMediaStore.BusinessLogic.Tests;

public class UserServiceTests
{
    private readonly Mock<IRepositoryWrapper> _repoMock = new();
    private readonly Mock<IRepositoryBase<User>> _userRepoMock = new();
    private readonly UserService _service;

    public UserServiceTests()
    {
        _repoMock.SetupGet(r => r.User).Returns(_userRepoMock.Object);
        _service = new UserService(_repoMock.Object);
    }

    [Fact]
    public async Task Create_should_throw_on_null()
    {
        Func<Task> act = async () => await _service.Create(null!);
        await act.Should().ThrowAsync<ArgumentNullException>();
        _userRepoMock.Verify(r => r.Create(It.IsAny<User>()), Times.Never);
        _repoMock.Verify(r => r.Save(), Times.Never);
    }

    [Theory]
    [MemberData(nameof(InvalidUsers))]
    public async Task Create_should_validate_required_fields(User invalid)
    {
        Func<Task> act = async () => await _service.Create(invalid);
        await act.Should().ThrowAsync<ArgumentException>();
        _userRepoMock.Verify(r => r.Create(It.IsAny<User>()), Times.Never);
        _repoMock.Verify(r => r.Save(), Times.Never);
    }

    public static IEnumerable<object[]> InvalidUsers()
    {
        yield return new object[] { new User { Email = "", PasswordHash = "hash", FullName = "Ivan" } };
        yield return new object[] { new User { Email = "user@example.com", PasswordHash = "", FullName = "Ivan" } };
        yield return new object[] { new User { Email = "user@example.com", PasswordHash = "hash", FullName = "" } };
    }

    [Fact]
    public async Task Create_should_call_repo_on_valid_user()
    {
        var valid = new User { Email = "user@example.com", PasswordHash = "hash", FullName = "Ivan" };

        await _service.Create(valid);

        _userRepoMock.Verify(r => r.Create(It.Is<User>(u => u == valid)), Times.Once);
        _repoMock.Verify(r => r.Save(), Times.Once);
    }
}


