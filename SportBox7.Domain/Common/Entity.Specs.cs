﻿namespace SportBox7.Domain.Common
{
    using FluentAssertions;
    using Models.Articles;
    using SportBox7.Domain.Models.Categories;
    using Xunit;

    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            // Arrange
            var first = new Category("Първа", "First").SetId(1);
            var second = new Category("Втора", "Second").SetId(1);
       
            // Act
            var result = first == second;
       
            // Arrange
            result.Should().BeTrue();
        }
       
        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            // Arrange
             var first = new Category("Първа", "First").SetId(1);
            var second = new Category("Втора", "Second").SetId(2);
       
            // Act
            var result = first == second;
       
            // Arrange
            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {
        public static TEntity SetId<TEntity>(this TEntity entity, int id)
            where TEntity : Entity<int>
            => (entity.SetId<int>(id) as TEntity)!;

        private static Entity<T> SetId<T>(this Entity<T> entity, int id)
            where T : struct
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
