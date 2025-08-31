using System.Collections.Generic;
using System.Threading.Tasks;
using CybersecDomain.context;
using CybersecDomain.Dtos;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CybersecTest
{
    [TestFixture]
    public class ProfileServiceTests
    {
        private CyberSecDbContext _dbContext;
        private Mock<ILogoService> _logoServiceMock;
        private Mock<IAlternativeTitleService> _alternativeTitleServiceMock;
        private Mock<IDeliverableService> _deliverableServiceMock;
        private Mock<IKnowledgeService> _knowledgeServiceMock;
        private Mock<IKeySkillService> _keySkillServiceMock;
        private Mock<IMainTaskService> _mainTaskServiceMock;
        private ProfileService _profileService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<CyberSecDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _dbContext = new CyberSecDbContext(options);
            _logoServiceMock = new Mock<ILogoService>();
            _alternativeTitleServiceMock = new Mock<IAlternativeTitleService>();
            _deliverableServiceMock = new Mock<IDeliverableService>();
            _knowledgeServiceMock = new Mock<IKnowledgeService>();
            _keySkillServiceMock = new Mock<IKeySkillService>();
            _mainTaskServiceMock = new Mock<IMainTaskService>();

            _profileService = new ProfileService(
                _dbContext,
                _logoServiceMock.Object,
                _alternativeTitleServiceMock.Object,
                _deliverableServiceMock.Object,
                _knowledgeServiceMock.Object,
                _keySkillServiceMock.Object,
                _mainTaskServiceMock.Object
            );
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetProfilesAsync_ShouldReturnAllProfiles()
        {
            // Arrange
            var profiles = new List<Profile>
            {
                new Profile { ProfileId = 1, Title = "Profile 1", Shortname = "P1", Status = true },
                new Profile { ProfileId = 2, Title = "Profile 2", Shortname = "P2", Status = true },
            };
            _dbContext.Profiles.AddRange(profiles);
            _dbContext.SaveChanges();

            // Act
            var result = await _profileService.GetProfilesAsync();

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Data.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetProfileByIdAsync_ShouldReturnProfile_WhenProfileExists()
        {
            // Arrange
            var profile = new Profile { ProfileId = 1, Title = "Profile 1", Shortname = "P1", Status = true };
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();

            // Act
            var result = await _profileService.GetProfileByIdAsync(1);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Data.Title, Is.EqualTo("Profile 1"));
        }

        [Test]
        public async Task GetProfileByIdAsync_ShouldReturnFailure_WhenProfileDoesNotExist()
        {
            // Act
            var result = await _profileService.GetProfileByIdAsync(1);

            // Assert
            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorMessage, Is.EqualTo("Profile not found"));
        }

        [Test]
        public async Task CreateProfileAsync_ShouldCreateAndReturnProfile()
        {
            // Arrange
            var createProfileDto = new CreateProfileDto { Title = "New Profile", ShortName = "NP", AlternativeTitle = "alt", Deliverable = "del", KeySkill = "skill", Knowledge = "know", MainTask = "task", LogoUrl = "url" };
            _logoServiceMock.Setup(s => s.CreateLogoAsync(It.IsAny<string>())).Returns(Task.FromResult(ServiceResult<Logo>.Success(new Logo())));
            _alternativeTitleServiceMock.Setup(s => s.CreateAlternativeTitles(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<AlternativeTitle>>.Success(new List<AlternativeTitle>())));
            _deliverableServiceMock.Setup(s => s.CreateDeliverables(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<Deliverable>>.Success(new List<Deliverable>())));
            _knowledgeServiceMock.Setup(s => s.CreateKnowledge(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<Knowledge>>.Success(new List<Knowledge>())));
            _keySkillServiceMock.Setup(s => s.CreateKeySkills(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<KeySkill>>.Success(new List<KeySkill>())));
            _mainTaskServiceMock.Setup(s => s.CreateMainTask(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<MainTask>>.Success(new List<MainTask>())));

            // Act
            var result = await _profileService.CreateProfileAsync(createProfileDto);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Data.Title, Is.EqualTo("New Profile"));
        }

        [Test]
        public async Task DeleteProfileAsync_ShouldSoftDeleteProfile()
        {
            // Arrange
            var profile = new Profile { ProfileId = 1, Title = "Profile 1", Shortname = "P1", Status = true };
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();

            // Act
            var result = await _profileService.DeleteProfileAsync(1);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(profile.Status);
        }

        [Test]
        public async Task UpdateProfileAsync_ShouldUpdateProfile()
        {
            // Arrange
            uint profileId = 1;
            
            var updateProfileDto = new UpdateProfileDto {Title = "Updated Profile", ShortName = "UP", AlternativeTitle = "alt", Deliverable = "del", KeySkill = "skill", Knowledge = "know", MainTask = "task", LogoUrl = "url" };
            var profile = new Profile { ProfileId = 1, Title = "Original Profile", Shortname = "OP" };
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();

            _logoServiceMock.Setup(s => s.CreateLogoAsync(It.IsAny<string>())).Returns(Task.FromResult(ServiceResult<Logo>.Success(new Logo())));
            _alternativeTitleServiceMock.Setup(s => s.CreateAlternativeTitles(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<AlternativeTitle>>.Success(new List<AlternativeTitle>())));
            _deliverableServiceMock.Setup(s => s.CreateDeliverables(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<Deliverable>>.Success(new List<Deliverable>())));
            _knowledgeServiceMock.Setup(s => s.CreateKnowledge(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<Knowledge>>.Success(new List<Knowledge>())));
            _keySkillServiceMock.Setup(s => s.CreateKeySkills(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<KeySkill>>.Success(new List<KeySkill>())));
            _mainTaskServiceMock.Setup(s => s.CreateMainTask(It.IsAny<List<string>>(), It.IsAny<uint>())).Returns(Task.FromResult(ServiceResult<List<MainTask>>.Success(new List<MainTask>())));

            // Act
            var result = await _profileService.UpdateProfileAsync(profileId, updateProfileDto);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Data.Title, Is.EqualTo("Updated Profile"));
        }
    }
}
