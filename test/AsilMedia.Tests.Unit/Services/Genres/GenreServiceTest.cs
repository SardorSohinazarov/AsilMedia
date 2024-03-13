using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects.Genres;
using AsilMedia.Application.Services.Genres;
using AsilMedia.Domain.Entities;
using Moq;
using Xunit;

namespace AsilMedia.Tests.Unit.Services.Genres
{
    public class GenreServiceTest
    {
        private readonly IGenreService _genreService;
        private readonly Mock<IGenreRepository> _mockGenreRepository;

        public GenreServiceTest()
        {
            _mockGenreRepository = new Mock<IGenreRepository>();
            _genreService = new GenreService(_mockGenreRepository.Object);
        }

        [Fact]
        public async Task ShouldReturnAddedGenreAsync()
        {
            //Arrange
            var inputGenreDTO = new GenreCreationDTO()
            {
                Name = "Tarixiy",
            };

            var expectedGenre = new Genre()
            {
                Name = "Tarixiy"
            };

            var expected2Genre = new Genre()
            {
                Name = "Umuman"
            };

            _mockGenreRepository.Setup(x => x.InsertGenreAsync(It.IsAny<Genre>()))
                .ReturnsAsync(expected2Genre);

            //Act
            var actualGenre = await _genreService.AddAsync(inputGenreDTO);

            //Assert
            Assert.Equal(expectedGenre.Name, actualGenre.Name);
            Assert.Equal(expectedGenre.Id, actualGenre.Id);
        }

        [Fact]
        public async Task ShouldThrowExceptionWhenNameBeNullAsync()
        {
            //Arrange
            var inputGenreDTO = new GenreCreationDTO()
            {
                Name = " ",
            };

            var expectedException = new Exception("Name cannot be null or whitespace");

            //Act
            try
            {
                await _genreService.AddAsync(inputGenreDTO);
            }
            catch (Exception exception)
            {
                Assert.Equal(expectedException.Message, exception.Message);
            }
        }
    }
}
