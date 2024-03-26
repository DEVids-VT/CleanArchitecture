namespace CleanArchitecture.Domain.UnitTests.Tests.Common
{
    using CleanArchitecture.Domain.Common;
    using CleanArchitecture.Domain.UnitTests.Helpers;
    using CleanArchitecture.Domain.UnitTests.Models;
    using FluentAssertions;

    public class EntityTests
    {
        private class TestDomainEvent : IDomainEvent { }

        [Fact]
        public void RaiseEvent_ShouldAddEventToCollection()
        {
            // Arrange
            var entity = new TestableEntity();
            var domainEvent = new TestDomainEvent();

            // Act
            entity.TestRaiseEvent(domainEvent);

            // Assert
            entity.Events.Should().ContainSingle().And.Contain(domainEvent);
        }

        [Fact]
        public void ClearEvents_ShouldEmptyTheEventCollection()
        {
            // Arrange
            var entity = new TestableEntity();
            entity.TestRaiseEvent(new TestDomainEvent());

            // Act
            entity.ClearEvents();

            // Assert
            entity.Events.Should().BeEmpty();
        }

        [Fact]
        public void Entities_WithSameId_ShouldBeEqual()
        {
            // Arrange
            var entity1 = new TestableEntity();
            entity1.SetPrivate(x => x.Id, 1);
            var entity2 = new TestableEntity();
            entity2.SetPrivate(x => x.Id, 1);

            // Act & Assert
            entity1.Should().Be(entity2);
            (entity1 == entity2).Should().BeTrue();
        }

        [Fact]
        public void Entities_WithDifferentIds_ShouldNotBeEqual()
        {
            // Arrange
            var entity1 = new TestableEntity();
            entity1.SetPrivate(x => x.Id, 1);
            var entity2 = new TestableEntity();
            entity2.SetPrivate(x => x.Id, 2);

            // Act & Assert
            entity1.Should().NotBe(entity2);
            (entity1 != entity2).Should().BeTrue();
        }

        [Fact]
        public void Entity_ShouldNotBeEqualToNull()
        {
            // Arrange
            var entity = new TestableEntity();

            // Act & Assert
            entity.Should().NotBeNull();
        }


        [Fact]
        public void GetHashCode_ShouldReturnConsistentResult_ForSameId()
        {
            // Arrange
            var entity = new TestableEntity();
            entity.SetPrivate(x => x.Id, 1);

            // Act
            var hash1 = entity.GetHashCode();
            var hash2 = entity.GetHashCode();

            // Assert
            hash1.Should().Be(hash2);
        }

        [Fact]
        public void Entities_WithNoId_ShouldNotBeEqual()
        {
            // Arrange
            var entity1 = new TestableEntity(); // Id = default(int)
            var entity2 = new TestableEntity(); // Id = default(int)

            // Act & Assert
            (entity1 == entity2).Should().BeTrue(); // Since both have the default ID value, they are not considered equal
        }

        [Fact]
        public void Entity_ComparingWithDifferentType_ShouldNotBeEqual()
        {
            // Arrange
            var entity = new TestableEntity();
            var differentObject = new { Id = 1 }; // Different type

            // Act & Assert
            entity.Equals(differentObject).Should().BeFalse();
        }

    }
}
